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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                var listaProductos = await ProductoApiClient.GetAllAsync();

                dgvProductos.DataSource = null; // Limpia los datos anteriores
                dgvProductos.DataSource = listaProductos; // Asigna la nueva lista
                dgvProductos.ReadOnly = true;
                dgvProductos.Columns["esActivo"].Visible = false;
                dgvProductos.Columns["categoriaId"].Visible = false;
                dgvProductos.Columns["precio"].DefaultCellStyle.Format = "C2";

                dgvProductos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ProductoLista_Load(object sender, EventArgs e)
        {
            ConfigurarBotonesSegunRol();
            await Listar();
        }

        // Un usuario común solo puede ver la lista: la API le devolvería 403 en cualquier alta, baja o
        // modificación, así que directamente no se le muestran esos botones. Un Admin ve todo.
        private void ConfigurarBotonesSegunRol()
        {
            bool esAdmin = AuthService.AuthService.IsAdmin;

            tsbNuevo.Visible = esAdmin;
            btnActualizar.Visible = esAdmin;
            btnEliminar.Visible = esAdmin;
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
                ProductoDTO? producto = await ProductoApiClient.GetAsync(seleccionado.Id);
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

        private async void btnVerEspecificaciones_Click(object sender, EventArgs e)
        {
            var seleccionado = this.SelectedItem();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccioná un producto de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ProductoDTO? producto = await ProductoApiClient.GetAsync(seleccionado.Id);
                if (producto == null)
                {
                    MessageBox.Show("El producto ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProductoEspecificaciones formEspecificaciones = new ProductoEspecificaciones(producto);
                formEspecificaciones.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las especificaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var response = await ProductoApiClient.DeleteAsync(producto.Id);
                if (!response)
                {
                    MessageBox.Show($"No se pudo eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
