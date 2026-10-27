using System.Diagnostics;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class InformeStockCritico : Form
    {
        private class FiltroOpcion
        {
            public string Clave { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public override string ToString() => Descripcion;
        }

        public InformeStockCritico()
        {
            InitializeComponent();

            cmbTipoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoFiltro.Items.Add(new FiltroOpcion { Clave = "", Descripcion = "Todos en alerta" });
            cmbTipoFiltro.Items.Add(new FiltroOpcion { Clave = "SinStock", Descripcion = "Sin stock (0)" });
            cmbTipoFiltro.Items.Add(new FiltroOpcion { Clave = "StockBajo", Descripcion = "Stock bajo umbral" });
            cmbTipoFiltro.Items.Add(new FiltroOpcion { Clave = "PreVenta", Descripcion = "Solo pre-venta" });
            cmbTipoFiltro.SelectedIndex = 0;

            nudUmbral.Minimum = 0;
            nudUmbral.Maximum = 1000;
            nudUmbral.Value = 5;

            ConfigurarGrillas();
        }

        private string? TipoSeleccionado
        {
            get
            {
                if (cmbTipoFiltro.SelectedItem is FiltroOpcion opc && !string.IsNullOrWhiteSpace(opc.Clave))
                    return opc.Clave;
                return null;
            }
        }

        private void ConfigurarGrillas()
        {
            PrepararGrilla(dgvProductos);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Id), "ID", 50);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Nombre), "Producto", 220);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Categoria), "Categoría", 110);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Marca), "Marca", 110);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Stock), "Stock", 65, alinearDerecha: true);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.EsPreVenta), "Pre-Venta", 75);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Criticidad), "Criticidad", 140);
            AgregarColumna(dgvProductos, nameof(ProductoStockCriticoDTO.Precio), "Precio", 90, "C2", true);

            dgvProductos.CellFormatting += DgvProductos_CellFormatting;

            PrepararGrilla(dgvPorCategoria);
            AgregarColumna(dgvPorCategoria, nameof(StockPorCategoriaDTO.Categoria), "Categoría", 180);
            AgregarColumna(dgvPorCategoria, nameof(StockPorCategoriaDTO.CantidadProductos), "Productos en alerta", 120, alinearDerecha: true);

            PrepararGrilla(dgvPorMarca);
            AgregarColumna(dgvPorMarca, nameof(StockPorMarcaDTO.Marca), "Marca", 180);
            AgregarColumna(dgvPorMarca, nameof(StockPorMarcaDTO.CantidadProductos), "Productos en alerta", 120, alinearDerecha: true);
        }

        private void DgvProductos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProductos.Rows.Count) return;

            var item = dgvProductos.Rows[e.RowIndex].DataBoundItem as ProductoStockCriticoDTO;
            if (item == null) return;

            if (item.Stock == 0 && !item.EsPreVenta)
            {
                e.CellStyle!.ForeColor = Color.Crimson;
                e.CellStyle!.SelectionForeColor = Color.Pink;
                if (dgvProductos.Columns[e.ColumnIndex].DataPropertyName == nameof(ProductoStockCriticoDTO.Stock)
                    || dgvProductos.Columns[e.ColumnIndex].DataPropertyName == nameof(ProductoStockCriticoDTO.Criticidad))
                {
                    e.CellStyle!.Font = new Font(dgvProductos.Font, FontStyle.Bold);
                }
            }
            else if (item.Stock <= (int)nudUmbral.Value && !item.EsPreVenta)
            {
                e.CellStyle!.ForeColor = Color.DarkOrange;
            }
            else if (item.EsPreVenta)
            {
                e.CellStyle!.ForeColor = Color.SteelBlue;
            }
        }

        private static void PrepararGrilla(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = false;
            grilla.ReadOnly = true;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.AllowUserToResizeRows = false;
            grilla.MultiSelect = false;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grilla.BackgroundColor = SystemColors.Window;
            grilla.BorderStyle = BorderStyle.None;
            grilla.RowHeadersVisible = false;
        }

        private static void AgregarColumna(DataGridView grilla, string propiedad, string titulo, int ancho, string? formato = null, bool alinearDerecha = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propiedad,
                HeaderText = titulo,
                Width = ancho,
                DefaultCellStyle =
                {
                    Format = formato ?? string.Empty,
                    Alignment = alinearDerecha ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft
                }
            };
            if (alinearDerecha)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            grilla.Columns.Add(col);
        }

        private async void btnVerInforme_Click(object sender, EventArgs e)
        {
            btnVerInforme.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var umbral = (int)nudUmbral.Value;
                var tipo = TipoSeleccionado;

                var tareaInforme = ReporteApiClient.GetInformeStockCriticoAsync(umbral, tipo);
                var tareaGraficos = ReporteApiClient.GetGraficosInformeStockAsync(umbral, tipo);

                var informe = await tareaInforme;
                var graficos = await tareaGraficos;

                if (informe == null)
                {
                    MessageBox.Show("No se obtuvo respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MostrarInforme(informe, graficos);
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return;
                MessageBox.Show($"No se pudo generar el informe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnVerInforme.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void MostrarInforme(InformeStockCriticoDTO informe, GraficosInformeStockDTO? graficos)
        {
            lblFiltrosAplicados.Text = $"Umbral mínimo: {informe.UmbralMinimo} unidades   |   Filtro: {informe.TipoFiltroDescripcion}   |   Total en alerta: {informe.Resumen.TotalAlertas}";
            if (informe.Resumen.TotalAlertas == 0)
                lblFiltrosAplicados.Text += "   |   No se detectaron productos en condición de alerta";

            lblTotalAlertas.Text = informe.Resumen.TotalAlertas.ToString();
            lblSinStock.Text = informe.Resumen.CantidadSinStock.ToString();
            lblStockBajo.Text = informe.Resumen.CantidadStockBajo.ToString();
            lblPreVenta.Text = informe.Resumen.CantidadPreVenta.ToString();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = informe.Productos;

            dgvPorCategoria.DataSource = null;
            dgvPorCategoria.DataSource = informe.PorCategoria;

            dgvPorMarca.DataSource = null;
            dgvPorMarca.DataSource = informe.PorMarca;

            AsignarImagen(picPorCriticidad, graficos?.PorCriticidad);
            AsignarImagen(picPorCategoria, graficos?.PorCategoria);
            AsignarImagen(picPorMarca, graficos?.PorMarca);
        }

        private static void AsignarImagen(PictureBox pictureBox, string? base64)
        {
            var anterior = pictureBox.Image;
            pictureBox.Image = base64 == null ? null : ImagenDesdeBase64(base64);
            anterior?.Dispose();
        }

        private static Image ImagenDesdeBase64(string base64)
        {
            using var stream = new MemoryStream(Convert.FromBase64String(base64));
            using var imagen = Image.FromStream(stream);
            return new Bitmap(imagen);
        }

        private async void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            btnGenerarPdf.Enabled = false;
            try
            {
                var umbral = (int)nudUmbral.Value;
                var tipo = TipoSeleccionado;

                var pdf = await ReporteApiClient.GetInformeStockCriticoPdfAsync(umbral, tipo);

                var ruta = Path.Combine(Path.GetTempPath(), $"informe-stock-critico-{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(ruta, pdf);
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return;
                MessageBox.Show($"No se pudo generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerarPdf.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
