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
            ConfigurarColumnas();
        }

        // Las columnas se definen a mano para mostrar solo lo que le interesa al usuario y con el
        // encabezado en castellano. AutoGenerateColumns = false evita que se agreguen las del DTO
        // (EsActivo, por ejemplo) y tiene que asignarse antes que el DataSource.
        private void ConfigurarColumnas()
        {
            dgvCategorias.AutoGenerateColumns = false;

            // FillWeight es la proporción con la que cada columna se reparte el ancho de la grilla.
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = nameof(CategoriaDTO.Id),
                FillWeight = 30
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = nameof(CategoriaDTO.Nombre),
                FillWeight = 80
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                DataPropertyName = nameof(CategoriaDTO.Descripcion),
                FillWeight = 190
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlta",
                HeaderText = "Fecha Alta",
                DataPropertyName = nameof(CategoriaDTO.FechaAlta),
                FillWeight = 80,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });
        }

        public async Task Listar()
        {
            try
            {
                var listaCategorias = await CategoriaApiClient.GetAllAsync();

                dgvCategorias.DataSource = null; // Limpia los datos anteriores
                dgvCategorias.DataSource = listaCategorias; // Asigna la nueva lista
                dgvCategorias.ReadOnly = true;
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
