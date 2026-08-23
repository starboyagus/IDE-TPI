using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using API.Clients;
using DTOs;
namespace WindowsForm
{
    public partial class ProductoLista : Form
    {
        public ProductoLista()
        {
            InitializeComponent();
        }

        public async Task Listar()
        {
            try
            {
                var listaProductos = await ApiClient.Http.GetFromJsonAsync<List<ProductoDTO>>("productos")
                    ?? new List<ProductoDTO>();
                dgvProductos.DataSource = null; // Limpia los datos anteriores
                dgvProductos.DataSource = listaProductos; // Asigna la nueva lista
                dgvProductos.ReadOnly = true;
                dgvProductos.Columns["esActivo"].Visible = false;
                dgvProductos.Columns["precio"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ProductoLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var seleccionado = this.SelectedItem();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccioná un producto de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ProductoDTO? producto = await ApiClient.Http.GetFromJsonAsync<ProductoDTO>($"productos/{seleccionado.Id}");
                if (producto == null)
                {
                    MessageBox.Show("El producto ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProductoDetalle productoDetalle= new ProductoDetalle(FormMode.Update, producto);
                productoDetalle.ShowDialog();

                await Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ProductoDTO? SelectedItem()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                return null;

            return dgvProductos.SelectedRows[0].DataBoundItem as ProductoDTO;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            ProductoDTO prodNuevo= new ProductoDTO();
            ProductoDetalle formProductosDetalle = new ProductoDetalle(FormMode.Add, prodNuevo);
            formProductosDetalle.ShowDialog();

            await Listar();

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var producto = this.SelectedItem();
            if (producto == null)
            {
                MessageBox.Show("Seleccioná un producto de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar el producto {producto.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await ApiClient.Http.DeleteAsync($"productos/{producto.Id}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"No se pudo eliminar el producto ({(int)response.StatusCode} {response.ReasonPhrase}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Listar();
        }
    }
}
