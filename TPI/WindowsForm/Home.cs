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
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            LoginForm appLogin = new LoginForm();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
                return;
            }

            ConfigurarMenuSegunRol();
        }

        // Usuarios y Categorías son tareas de administración: si el logueado no es Admin, no se muestran.
        // Productos queda visible para todos; ProductoLista se encarga de ocultar los botones de edición.
        private void ConfigurarMenuSegunRol()
        {
            var usuario = AuthService.AuthService.UsuarioActual;
            bool esAdmin = AuthService.AuthService.IsAdmin;

            usuariosToolStripMenuItem.Visible = esAdmin;
            categoriaToolStripMenuItem.Visible = esAdmin;

            if (usuario != null)
            {
                this.Text = $"Inicio - {usuario.Nombre} {usuario.Apellido} ({usuario.Rol})";
            }
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioLista formUsuarios = new UsuarioLista();
            formUsuarios.Show(this);
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoLista formProducto = new ProductoLista();
            formProducto.Show(this);
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaLista formCategoria = new CategoriaLista();
            formCategoria.Show(this);
        }
    }
}
