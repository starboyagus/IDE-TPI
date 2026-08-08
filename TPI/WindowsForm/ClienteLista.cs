using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;

namespace WindowsForm
{
    public partial class ClienteLista : Form
    {
        public ClienteLista()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente cliente1 = new Cliente(1, "Ana", "Gómez", "fasfa@gmail.com", DateTime.Now);
            listaClientes.Add(cliente1);


            dgvClientes.DataSource = null; // Limpia los datos anteriores (muy útil para tu botón Actualizar)
            dgvClientes.DataSource = listaClientes; // Asigna la nueva lista
        }

        private void ClienteLista_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
