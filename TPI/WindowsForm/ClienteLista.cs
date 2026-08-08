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
using DTOs;

namespace WindowsForm
{
    public partial class ClienteLista : Form
    {
        public ClienteLista()
        {
            InitializeComponent();
        }

        public async Task Listar()
        {
            try
            {
                var listaClientes = await ApiClient.Http.GetFromJsonAsync<List<ClienteDTO>>("clientes")
                    ?? new List<ClienteDTO>();

                dgvClientes.DataSource = null; // Limpia los datos anteriores (muy útil para tu botón Actualizar)
                dgvClientes.DataSource = listaClientes; // Asigna la nueva lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ClienteLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
