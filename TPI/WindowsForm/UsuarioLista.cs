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
using API.Clients;
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
               var listaUsuarios = await UsuarioApiClient.GetAllAsync();

                dgvUsuarios.DataSource = null; // Limpia los datos anteriores
                dgvUsuarios.DataSource = listaUsuarios; // Asigna la nueva lista
                dgvUsuarios.ReadOnly = true;
                dgvUsuarios.Columns["esActivo"].Visible = false;
                dgvUsuarios.Columns["contrasenia"].Visible = false;

                dgvUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
            var seleccionado = this.SelectedItem();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccioná un usuario de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioDTO? usuario = await UsuarioApiClient.GetAsync(seleccionado.Id); //dsadsad asdsa
                if (usuario == null)
                {
                    MessageBox.Show("El usuario ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UsuarioDetalle usuarioDetalle = new UsuarioDetalle(FormMode.Update, usuario);
                usuarioDetalle.ShowDialog();

                await Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private UsuarioDTO? SelectedItem()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
                return null;

            return dgvUsuarios.SelectedRows[0].DataBoundItem as UsuarioDTO;
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioNuevo = new UsuarioDTO();
            UsuarioDetalle formUsuariosDetalle = new UsuarioDetalle(FormMode.Add, usuarioNuevo);
            formUsuariosDetalle.ShowDialog();

            await Listar();

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var usuario = this.SelectedItem();
            if (usuario == null)
            {
                MessageBox.Show("Seleccioná un usuario de la lista primero.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar el usuario {usuario.Nombre} {usuario.Apellido} ({usuario.Email})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await UsuarioApiClient.DeleteAsync(usuario.Id);
                if (!response)
                {
                    MessageBox.Show($"No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Listar();
        }
    }
}
