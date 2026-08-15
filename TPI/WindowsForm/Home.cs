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
            }

        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioLista formUsuarios = new UsuarioLista();
            formUsuarios.Show();
        }
    }
}
