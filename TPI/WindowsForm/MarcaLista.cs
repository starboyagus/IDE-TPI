using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class MarcaLista : Form
    {
        public MarcaLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvMarcas.AutoGenerateColumns = false;

            dgvMarcas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = nameof(MarcaDTO.Id),
                FillWeight = 30
            });

            dgvMarcas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = nameof(MarcaDTO.Nombre),
                FillWeight = 80
            });

            dgvMarcas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PaisOrigen",
                HeaderText = "País de Origen",
                DataPropertyName = nameof(MarcaDTO.PaisOrigen),
                FillWeight = 190
            });

            dgvMarcas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlta",
                HeaderText = "Fecha Alta",
                DataPropertyName = nameof(MarcaDTO.FechaAlta),
                FillWeight = 80,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });
        }

        public async Task Listar()
        {
            try
            {
                var listaMarcas = await MarcaApiClient.GetAllAsync();

                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = listaMarcas;
                dgvMarcas.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MarcaLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var seleccionada = this.SelectedItem();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccioná una marca de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MarcaDTO? marca = await MarcaApiClient.GetAsync(seleccionada.Id);
                if (marca == null)
                {
                    MessageBox.Show("La marca ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MarcaDetalle marcaDetalle = new MarcaDetalle(FormMode.Update, marca);
                marcaDetalle.ShowDialog();

                await Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private MarcaDTO? SelectedItem()
        {
            if (dgvMarcas.SelectedRows.Count == 0)
                return null;

            return dgvMarcas.SelectedRows[0].DataBoundItem as MarcaDTO;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            MarcaDTO marcaNueva = new MarcaDTO();
            MarcaDetalle formMarcaDetalle = new MarcaDetalle(FormMode.Add, marcaNueva);
            formMarcaDetalle.ShowDialog();

            await Listar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var marca = this.SelectedItem();
            if (marca == null)
            {
                MessageBox.Show("Seleccioná una marca de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar la marca {marca.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await MarcaApiClient.DeleteAsync(marca.Id);
                if (!response)
                {
                    MessageBox.Show($"No se pudo eliminar la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Listar();
        }
    }
}
