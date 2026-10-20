using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class ProductoEspecificaciones : Form
    {
        private readonly ProductoDTO producto;

        public ProductoEspecificaciones(ProductoDTO producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private async void ProductoEspecificaciones_Load(object sender, EventArgs e)
        {
            // Solo un Admin puede dar de alta especificaciones; el resto solo las consulta.
            btnAgregar.Visible = AuthService.AuthService.IsAdmin;

            CargarDatosProducto();
            await CargarEspecificacionesAsync();
        }

        private void CargarDatosProducto()
        {
            lblNombreValor.Text = producto.Nombre;
            lblPrecioValor.Text = producto.Precio.ToString("C2");
            lblStockValor.Text = producto.Stock.ToString();
            lblCategoriaValor.Text = producto.Categoria ?? "-";
            lblMarcaValor.Text = producto.Marca ?? "-";
            lblDescValor.Text = producto.Descripcion;
            lblPreventaValor.Text = producto.EsPreVenta ? "Sí" : "No";
        }

        private async Task CargarEspecificacionesAsync()
        {
            try
            {
                var especificaciones = await EspecificacionApiClient.GetByProductoAsync(producto.Id);

                if (especificaciones == null || especificaciones.Count == 0)
                {
                    pnlEspecificaciones.Visible = false;
                    lblSinEspecificaciones.Visible = true;
                    return;
                }

                pnlEspecificaciones.Visible = true;
                lblSinEspecificaciones.Visible = false;
                CrearFilasEspecificaciones(especificaciones);
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                MessageBox.Show($"No se pudieron cargar las especificaciones:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearFilasEspecificaciones(List<EspecificacionDTO> especificaciones)
        {
            pnlEspecificaciones.Controls.Clear();

            int anchoPanel = pnlEspecificaciones.ClientSize.Width - 20; // padding
            int alturaFila = 28;
            int y = 5;

            for (int i = 0; i < especificaciones.Count; i++)
            {
                var spec = especificaciones[i];

                // Panel fila
                Panel fila = new Panel
                {
                    Location = new Point(10, y),
                    Size = new Size(anchoPanel, alturaFila),
                    BackColor = i % 2 == 0 ? SystemColors.Control : SystemColors.ControlLightLight
                };

                // Label Clave (izquierda)
                Label lblClave = new Label
                {
                    Text = spec.Clave,
                    Location = new Point(8, 5),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F)
                };

                // Label Valor + Unidad (derecha)
                string valorTexto = string.IsNullOrWhiteSpace(spec.Unidad)
                    ? spec.Valor
                    : $"{spec.Valor} {spec.Unidad}";

                Label lblValor = new Label
                {
                    Text = valorTexto,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                // Posicionar a la derecha
                int bordeDerecho = anchoPanel - 8;

                // Un Admin además ve los botones para modificar o eliminar cada especificación.
                if (AuthService.AuthService.IsAdmin)
                {
                    Button btnEliminarFila = CrearBotonFila("Eliminar", bordeDerecho - 65);
                    btnEliminarFila.Click += async (s, e) => await EliminarEspecificacionAsync(spec);

                    Button btnEditarFila = CrearBotonFila("Editar", bordeDerecho - 65 - 5 - 65);
                    btnEditarFila.Click += async (s, e) => await EditarEspecificacionAsync(spec);

                    fila.Controls.Add(btnEditarFila);
                    fila.Controls.Add(btnEliminarFila);

                    bordeDerecho = btnEditarFila.Left - 10;
                }

                lblValor.Location = new Point(bordeDerecho - lblValor.PreferredWidth, 5);

                fila.Controls.Add(lblClave);
                fila.Controls.Add(lblValor);
                pnlEspecificaciones.Controls.Add(fila);

                // Línea separadora
                if (i < especificaciones.Count - 1)
                {
                    Panel linea = new Panel
                    {
                        Location = new Point(10, y + alturaFila),
                        Size = new Size(anchoPanel, 1),
                        BackColor = SystemColors.ControlDark
                    };
                    pnlEspecificaciones.Controls.Add(linea);
                }

                y += alturaFila + 1;
            }
        }

        private static Button CrearBotonFila(string texto, int x)
        {
            return new Button
            {
                Text = texto,
                Location = new Point(x, 2),
                Size = new Size(65, 24),
                Font = new Font("Segoe UI", 8.25F),
                UseVisualStyleBackColor = true
            };
        }

        // Se vuelve a pedir la especificación a la API por si otro usuario la cambió o la borró mientras tanto.
        private async Task EditarEspecificacionAsync(EspecificacionDTO spec)
        {
            try
            {
                var especificacion = await EspecificacionApiClient.GetAsync(spec.Id);

                if (especificacion == null)
                {
                    MessageBox.Show("La especificación ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await CargarEspecificacionesAsync();
                    return;
                }

                using var detalle = new EspecificacionDetalle(FormMode.Update, especificacion);

                if (detalle.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarEspecificacionesAsync();
                }
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                MessageBox.Show($"Error al actualizar la especificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarEspecificacionAsync(EspecificacionDTO spec)
        {
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la especificación {spec.Clave}?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool eliminada = await EspecificacionApiClient.DeleteAsync(spec.Id);

                if (!eliminada)
                {
                    if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                    MessageBox.Show("No se pudo eliminar la especificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await CargarEspecificacionesAsync();
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                MessageBox.Show($"Error al eliminar la especificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Abre el detalle en modo alta para el producto actual y, si se guardó, recarga la lista.
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevaEspecificacion = new EspecificacionDTO
            {
                ProductoId = producto.Id,
                Producto = producto.Nombre
            };

            using var detalle = new EspecificacionDetalle(FormMode.Add, nuevaEspecificacion);

            if (detalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarEspecificacionesAsync();
            }
        }
    }
}
