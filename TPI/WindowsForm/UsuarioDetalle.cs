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
using API.Clients;
using Domain.Model;
using DTOs;
using System.Text.Json;

namespace WindowsForm
{
    public enum FormMode
    {
        Add,
        Update
    }
    public partial class UsuarioDetalle : Form
    {
        private UsuarioDTO usuario;
        private FormMode mode;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                this.SetUsuario();
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

        private void SetUsuario()
        {
            this.idTextBox.Text = this.Usuario.Id.ToString();
            this.nombreTextBox.Text = this.Usuario.Nombre;
            this.apellidoTextBox.Text = this.Usuario.Apellido;
            this.emailTextBox.Text = this.Usuario.Email;
            this.telefonoTextBox.Text = this.Usuario.Telefono;
            this.rolComboBox.SelectedItem = this.Usuario.Rol == default ? RolUsuario.Usuario : this.Usuario.Rol;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                // Todo usuario nuevo se crea con Rol = Usuario; el combo no se muestra hasta que exista en un Update.
                rolLabel.Visible = false;
                rolComboBox.Visible = false;
                contraseniaLabel.Text = "Contraseña";
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                rolLabel.Visible = true;
                rolComboBox.Visible = true;
                contraseniaLabel.Text = "Nueva contraseña (opcional)";
            }
        }

        private async void Init(FormMode mode, UsuarioDTO usuario)
        {
            try
            {
                this.Mode = mode;
                this.Usuario = usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public UsuarioDetalle()
        {
            InitializeComponent();
            rolComboBox.Items.AddRange(Enum.GetValues(typeof(RolUsuario)).Cast<object>().ToArray());
        }

        public UsuarioDetalle(FormMode mode, UsuarioDTO usuario) : this()
        {
            Init(mode, usuario);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                MessageBox.Show("Completá nombre, apellido, email y teléfono.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.Mode == FormMode.Update && rolComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // En Add la contraseña es obligatoria; en Update se puede dejar vacía para no cambiarla.
            if (this.Mode == FormMode.Add && string.IsNullOrWhiteSpace(contraseniaTextBox.Text))
            {
                MessageBox.Show("Ingresá una contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.Usuario.Nombre = nombreTextBox.Text.Trim();
            this.Usuario.Apellido = apellidoTextBox.Text.Trim();
            this.Usuario.Email = emailTextBox.Text.Trim();
            this.Usuario.Telefono = telefonoTextBox.Text.Trim();
            // Vacío = no cambiar la contraseña (el servidor conserva la actual cuando llega null/vacío).
            this.Usuario.Contrasenia = string.IsNullOrWhiteSpace(contraseniaTextBox.Text) ? null : contraseniaTextBox.Text;

            try
            {
                HttpResponseMessage response;

                if (this.Mode == FormMode.Update)
                {
                    this.Usuario.Rol = (RolUsuario)rolComboBox.SelectedItem!;
                    response = await ApiClient.Http.PutAsJsonAsync("usuarios", this.Usuario);
                }
                else
                {
                    response = await ApiClient.Http.PostAsJsonAsync("usuarios", this.Usuario);
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
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al guardar el usuario.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al guardar el usuario ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}
