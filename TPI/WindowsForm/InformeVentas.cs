using System.Diagnostics;
using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForm
{
    public partial class InformeVentas : Form
    {
        public InformeVentas()
        {
            InitializeComponent();

            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.Add("Todos (sin cancelados)");
            foreach (var estado in Enum.GetValues<EstadoOrden>())
                cmbEstado.Items.Add(estado);
            cmbEstado.SelectedIndex = 0;

            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;

            nudTop.Minimum = 1;
            nudTop.Maximum = 100;
            nudTop.Value = 10;

            ConfigurarGrillas();
        }

        private EstadoOrden? EstadoSeleccionado =>
            cmbEstado.SelectedItem is EstadoOrden estadoElegido ? estadoElegido : null;

        private bool ValidarFiltros()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.", "Filtros inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ConfigurarGrillas()
        {
            PrepararGrilla(dgvVentasPorMes);
            AgregarColumna(dgvVentasPorMes, nameof(VentasPorMesDTO.Periodo), "Mes", 60);
            AgregarColumna(dgvVentasPorMes, nameof(VentasPorMesDTO.CantidadOrdenes), "Órdenes", 50, alinearDerecha: true);
            AgregarColumna(dgvVentasPorMes, nameof(VentasPorMesDTO.TotalFacturado), "Facturación", 80, "C2", true);
            AgregarColumna(dgvVentasPorMes, nameof(VentasPorMesDTO.TicketPromedio), "Ticket promedio", 80, "C2", true);

            PrepararGrilla(dgvTopProductos);
            AgregarColumna(dgvTopProductos, nameof(ProductoVendidoDTO.Producto), "Producto", 140);
            AgregarColumna(dgvTopProductos, nameof(ProductoVendidoDTO.Categoria), "Categoría", 70);
            AgregarColumna(dgvTopProductos, nameof(ProductoVendidoDTO.Marca), "Marca", 70);
            AgregarColumna(dgvTopProductos, nameof(ProductoVendidoDTO.UnidadesVendidas), "Unidades", 50, alinearDerecha: true);
            AgregarColumna(dgvTopProductos, nameof(ProductoVendidoDTO.Facturacion), "Facturación", 80, "C2", true);

            PrepararGrilla(dgvPorMarca);
            AgregarColumna(dgvPorMarca, nameof(FacturacionMarcaDTO.Marca), "Marca", 100);
            AgregarColumna(dgvPorMarca, nameof(FacturacionMarcaDTO.UnidadesVendidas), "Unidades", 50, alinearDerecha: true);
            AgregarColumna(dgvPorMarca, nameof(FacturacionMarcaDTO.Facturacion), "Facturación", 80, "C2", true);
            AgregarColumna(dgvPorMarca, nameof(FacturacionMarcaDTO.Porcentaje), "%", 40, "N2", true);
        }

        private static void PrepararGrilla(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = false;
            grilla.ReadOnly = true;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.RowHeadersVisible = false;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void AgregarColumna(DataGridView grilla, string propiedad, string encabezado, int ancho, string? formato = null, bool alinearDerecha = false)
        {
            var columna = new DataGridViewTextBoxColumn
            {
                Name = propiedad,
                HeaderText = encabezado,
                DataPropertyName = propiedad,
                FillWeight = ancho
            };

            if (formato != null)
                columna.DefaultCellStyle.Format = formato;

            if (alinearDerecha)
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grilla.Columns.Add(columna);
        }

        private async void btnVerInforme_Click(object sender, EventArgs e)
        {
            if (!ValidarFiltros())
                return;

            btnVerInforme.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date;
                var top = (int)nudTop.Value;

                var tareaInforme = ReporteApiClient.GetInformeVentasAsync(desde, hasta, EstadoSeleccionado, top);
                var tareaGraficos = ReporteApiClient.GetGraficosInformeAsync(desde, hasta, EstadoSeleccionado, top);

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

        private void MostrarInforme(InformeVentasDTO informe, GraficosInformeDTO? graficos)
        {
            lblFiltrosAplicados.Text = $"Período: {informe.Desde:dd/MM/yyyy} al {informe.Hasta:dd/MM/yyyy}   |   Estado: {informe.EstadoDescripcion}";
            if (informe.Resumen.CantidadOrdenes == 0)
                lblFiltrosAplicados.Text += "   |   Sin ventas en el período";

            lblCantidadOrdenes.Text = informe.Resumen.CantidadOrdenes.ToString();
            lblTotalFacturado.Text = informe.Resumen.TotalFacturado.ToString("C2");
            lblTicketPromedio.Text = informe.Resumen.TicketPromedio.ToString("C2");

            dgvVentasPorMes.DataSource = null;
            dgvVentasPorMes.DataSource = informe.VentasPorMes;

            dgvTopProductos.DataSource = null;
            dgvTopProductos.DataSource = informe.TopProductos;

            dgvPorMarca.DataSource = null;
            dgvPorMarca.DataSource = informe.FacturacionPorMarca;

            AsignarImagen(picVentasPorMes, graficos?.VentasPorMes);
            AsignarImagen(picTopProductos, graficos?.TopProductos);
            AsignarImagen(picPorMarca, graficos?.FacturacionPorMarca);
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
            if (!ValidarFiltros())
                return;

            btnGenerarPdf.Enabled = false;
            try
            {
                var pdf = await ReporteApiClient.GetInformeVentasPdfAsync(dtpDesde.Value.Date, dtpHasta.Value.Date, EstadoSeleccionado, (int)nudTop.Value);

                var ruta = Path.Combine(Path.GetTempPath(), $"informe-ventas-{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(ruta, pdf);
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return;
                MessageBox.Show($"No se pudo generar el informe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerarPdf.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}