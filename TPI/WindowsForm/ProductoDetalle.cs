using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForm
{
    public partial class ProductoDetalle : Form
    {
        private ProductoDTO producto;
        private FormMode mode;
        public ProductoDTO Producto{
            get { return producto; }
            set{
                producto = value;
                this.SetProducto();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        private void SetCombos()
        {
            preventaComboBox.Items.Clear();
            preventaComboBox.Items.Add("Si");
            preventaComboBox.Items.Add("No");
        }

        private void SetProducto()
        {
            this.idTextBox.Text = this.Producto.Id.ToString();
            this.nombreTextBox.Text = this.Producto.Nombre;
            this.precioTextBox.Text = this.Producto.Precio.ToString("F2");
            this.stockTextBox.Text = this.Producto.Stock.ToString();
            this.descTextBox.Text = this.Producto.Descripcion;
            this.preventaComboBox.SelectedItem = this.Producto.EsPreVenta ? "Si" : "No" ;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private async void Init(FormMode mode, ProductoDTO producto)
        {
            try
            {
                this.Mode = mode;
                this.Producto = producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ProductoDetalle()
        {
            InitializeComponent();
            SetCombos();
            //rolComboBox.Items.AddRange(Enum.GetValues(typeof(RolUsuario)).Cast<object>().ToArray());
        }

        public ProductoDetalle(FormMode mode, ProductoDTO producto) : this()
        {
            Init(mode, producto);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(precioTextBox.Text) ||
                string.IsNullOrWhiteSpace(stockTextBox.Text) ||
                string.IsNullOrWhiteSpace(descTextBox.Text))
            {
                MessageBox.Show("Completá nombre, precio, stock y descripcion.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (preventaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná si el producto es pre-venta.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.Mode == FormMode.Update && preventaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná la preventa.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            this.Producto.Nombre = nombreTextBox.Text.Trim();
            if (!decimal.TryParse(precioTextBox.Text.Trim().Replace(",", "."),
                System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal precio))
            {
                MessageBox.Show("El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Producto.Precio = precio;
            if (!int.TryParse(stockTextBox.Text.Trim(), out int stock))
            {
                MessageBox.Show("El stock ingresado no es válido.");
                return;
            }
            this.Producto.Stock = stock;
            this.Producto.Descripcion = descTextBox.Text.Trim();

            bool esPreVenta = preventaComboBox.SelectedItem?.ToString() == "Si";
            this.Producto.EsPreVenta = esPreVenta;

            try
            {
                HttpResponseMessage response;

                if (this.Mode == FormMode.Update)
                {
                    response = await ApiClient.Http.PutAsJsonAsync("productos", this.Producto);
                }
                else
                {
                    response = await ApiClient.Http.PostAsJsonAsync("productos", this.Producto);
                }

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ExtraerMensajeError(response);
                    MessageBox.Show(mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al guardar el producto.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al guardar el producto ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}

