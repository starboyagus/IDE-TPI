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
    public partial class CategoriaLista : Form
    {
        public CategoriaLista()
        {
            InitializeComponent();
        }

        public async Task Listar()
        {
            try
            {
                var listaCategorias = await CategoriaApiClient.GetAllAsync();

                dgvCategorias.DataSource = null; // Limpia los datos anteriores
                dgvCategorias.DataSource = listaCategorias; // Asigna la nueva lista
                dgvCategorias.ReadOnly = true;
                dgvCategorias.Columns["esActivo"].Visible = false;

                // Proporción con la que cada columna se reparte el ancho de la grilla.
                dgvCategorias.Columns["id"].FillWeight = 30;
                dgvCategorias.Columns["nombre"].FillWeight = 80;
                dgvCategorias.Columns["descripcion"].FillWeight = 190;
                dgvCategorias.Columns["fechaAlta"].FillWeight = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CategoriaLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var seleccionada = this.SelectedItem();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccioná una categoría de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CategoriaDTO? categoria = await CategoriaApiClient.GetAsync(seleccionada.Id);
                if (categoria == null)
                {
                    MessageBox.Show("La categoría ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CategoriaDetalle categoriaDetalle = new CategoriaDetalle(FormMode.Update, categoria);
                categoriaDetalle.ShowDialog();

                await Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private CategoriaDTO? SelectedItem()
        {
            if (dgvCategorias.SelectedRows.Count == 0)
                return null;

            return dgvCategorias.SelectedRows[0].DataBoundItem as CategoriaDTO;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            CategoriaDTO categoriaNueva = new CategoriaDTO();
            CategoriaDetalle formCategoriasDetalle = new CategoriaDetalle(FormMode.Add, categoriaNueva);
            formCategoriasDetalle.ShowDialog();

            await Listar();

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var categoria = this.SelectedItem();
            if (categoria == null)
            {
                MessageBox.Show("Seleccioná una categoría de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar la categoría {categoria.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await CategoriaApiClient.DeleteAsync(categoria.Id);
                if (!response)
                {
                    MessageBox.Show($"No se pudo eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Listar();
        }
    }
}
