using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.rolTextBox.Text = this.Usuario.Rol.ToString();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                rolLabel.Visible = false;
                rolTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
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
        }

        public UsuarioDetalle(FormMode mode, UsuarioDTO usuario) : this()
        {
            Init(mode, usuario);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    this.Usuario.Nombre = nombreTextBox.Text;
                    this.Usuario.Apellido = apellidoTextBox.Text;
                    this.Usuario.Email = emailTextBox.Text;
                    this.Usuario.Telefono = telefonoTextBox.Text;

                    if (this.Mode == FormMode.Update)
                    {
                        string json = JsonSerializer.Serialize(this.Usuario);
                        var content = new StringContent(json, encoding: Encoding.UTF8, mediaType: "application/json");
                        var reponse = await ApiClient.Http.PutAsync("usuarios", content);

                    }
                    else
                    {
                        string json = JsonSerializer.Serialize(this.Usuario);
                        var content = new StringContent(json, encoding: Encoding.UTF8, mediaType: "application/json");
                        var reponse = await ApiClient.Http.PostAsync("usuarios", content);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
