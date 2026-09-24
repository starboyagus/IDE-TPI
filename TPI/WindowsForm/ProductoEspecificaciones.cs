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
                lblValor.Location = new Point(anchoPanel - lblValor.PreferredWidth - 8, 5);

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
