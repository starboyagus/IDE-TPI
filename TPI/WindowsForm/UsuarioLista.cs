using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;

namespace WindowsForm
{
    public partial class UsuarioLista : Form
    {
        public UsuarioLista()
        {
            InitializeComponent();
        }

        public async Task Listar()
        {
            try
            {
                var listaUsuarios = await ApiClient.Http.GetFromJsonAsync<List<UsuarioDTO>>("usuarios")
                    ?? new List<UsuarioDTO>();

                dgvUsuarios.DataSource = null; // Limpia los datos anteriores 
                dgvUsuarios.DataSource = listaUsuarios; // Asigna la nueva lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a la API ({ApiClient.Http.BaseAddress}):\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UsuarioLista_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().Id;
                UsuarioDTO usuario = await ApiClient.Http.GetFromJsonAsync<UsuarioDTO>($"usuarios/{id}");

                UsuarioDetalle usuarioDetalle = new UsuarioDetalle(FormMode.Update, usuario);
                usuarioDetalle.ShowDialog();

                await Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private UsuarioDTO SelectedItem()
        {
            UsuarioDTO usuario;

            usuario = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            return usuario;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioNuevo = new UsuarioDTO();
            // 1. Creamos una instancia del formulario UsuarioDetalle
            UsuarioDetalle formUsuariosDetalle = new UsuarioDetalle(FormMode.Add, usuarioNuevo);

            // 2. Lo mostramos en pantalla
            formUsuariosDetalle.ShowDialog();

            await Listar();

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = this.SelectedItem();


            var result = MessageBox.Show($"¿Está seguro que desea eliminar el cliente {usuario.Nombre} {usuario.Apellido} ({usuario.Email})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await ApiClient.Http.DeleteAsync($"usuarios/{usuario.Id}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                await Listar();
            }
        }
    }
}
