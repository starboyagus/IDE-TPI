using API.Clients;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            ApiClient.SesionExpirada += OnSesionExpirada;
        }

        private void OnSesionExpirada()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OnSesionExpirada));
                return;
            }

            // Se cierra todo lo abierto: hijos MDI y también los detalles abiertos con ShowDialog.
            foreach (Form form in Application.OpenForms.Cast<Form>().Where(f => f != this).ToList())
            {
                form.Close();
            }

            AuthService.AuthService.Logout();

            // El aviso y el login se encolan para que primero terminen de cerrarse los formularios.
            BeginInvoke(new Action(() =>
            {
                MessageBox.Show("Tu sesión venció. Volvé a iniciar sesión.", "Sesión vencida",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarSesion();
            }));
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        // Pide las credenciales y deja el menú acorde al rol de quien entró.
        // Se usa tanto al arrancar como al volver del logout, porque puede entrar otro usuario con otro rol.
        private void IniciarSesion()
        {
            LoginForm appLogin = new LoginForm();
            if (appLogin.ShowDialog(this) != DialogResult.OK)
            {
                this.Dispose();
                return;
            }

            ConfigurarMenuSegunRol();
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            // Las ventanas abiertas quedaron con los datos del usuario anterior: se cierran antes de salir.
            foreach (Form hijo in this.MdiChildren)
            {
                hijo.Close();
            }

            AuthService.AuthService.Logout();

            IniciarSesion();
        }

        // Usuarios y Categorías son tareas de administración: si el logueado no es Admin, no se muestran.
        // Productos queda visible para todos; ProductoLista se encarga de ocultar los botones de edición.
        private void ConfigurarMenuSegunRol()
        {
            var usuario = AuthService.AuthService.UsuarioActual;
            bool esAdmin = AuthService.AuthService.IsAdmin;

            usuariosToolStripMenuItem.Visible = esAdmin;
            categoriaToolStripMenuItem.Visible = esAdmin;
            marcaToolStripMenuItem.Visible = esAdmin;
            ordenesToolStripMenuItem.Visible = true;

            if (usuario != null)
            {
                this.Text = $"Inicio - {usuario.Nombre} {usuario.Apellido} ({usuario.Rol})";
            }
        }
        private void AbrirHijo<T>() where T : Form, new()
        {
            T? abierto = this.MdiChildren.OfType<T>().FirstOrDefault();
            if (abierto != null)
            {
                if (abierto.WindowState == FormWindowState.Minimized)
                    abierto.WindowState = FormWindowState.Normal;

                abierto.Activate();
                return;
            }

            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirHijo<UsuarioLista>();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirHijo<ProductoLista>();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirHijo<CategoriaLista>();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirHijo<MarcaLista>();
        }

        private void ordenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirHijo<OrdenLista>();
        }
    }
}
