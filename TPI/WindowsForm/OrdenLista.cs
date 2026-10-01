using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class OrdenLista : Form
    {
        public OrdenLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvOrdenes.AutoGenerateColumns = false;

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = nameof(OrdenDTO.Id),
                FillWeight = 25
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Usuario",
                HeaderText = "Usuario",
                DataPropertyName = nameof(OrdenDTO.Usuario),
                FillWeight = 80
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = nameof(OrdenDTO.Fecha),
                FillWeight = 70,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = nameof(OrdenDTO.Estado),
                FillWeight = 60
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total",
                DataPropertyName = nameof(OrdenDTO.Total),
                FillWeight = 50,
                DefaultCellStyle = { Format = "C2" }
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DireccionEnvio",
                HeaderText = "Dirección de Envío",
                DataPropertyName = nameof(OrdenDTO.DireccionEnvio),
                FillWeight = 120
            });
        }

        public async Task Listar()
        {
            try
            {
                var listaOrdenes = await OrdenApiClient.GetAllAsync();

                dgvOrdenes.DataSource = null;
                dgvOrdenes.DataSource = listaOrdenes;
                dgvOrdenes.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OrdenLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            var seleccionada = this.SelectedItem();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccioná una orden de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OrdenDTO? orden = await OrdenApiClient.GetAsync(seleccionada.Id);
                if (orden == null)
                {
                    MessageBox.Show("La orden ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OrdenDetalle ordenDetalle = new OrdenDetalle(FormMode.Update, orden);
                ordenDetalle.ShowDialog();

                await Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private OrdenDTO? SelectedItem()
        {
            if (dgvOrdenes.SelectedRows.Count == 0)
                return null;

            return dgvOrdenes.SelectedRows[0].DataBoundItem as OrdenDTO;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            OrdenDTO ordenNueva = new OrdenDTO();
            OrdenDetalle formOrdenDetalle = new OrdenDetalle(FormMode.Add, ordenNueva);
            formOrdenDetalle.ShowDialog();

            await Listar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var orden = this.SelectedItem();
            if (orden == null)
            {
                MessageBox.Show("Seleccioná una orden de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar la orden #{orden.Id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await OrdenApiClient.DeleteAsync(orden.Id);
                if (!response)
                {
                    MessageBox.Show($"No se pudo eliminar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Listar();
        }
    }
}
