using API.Clients;
using DTOs;
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

namespace WindowsForm
{
    public partial class CategoriaDetalle : Form
    {
        private CategoriaDTO categoria;
        private FormMode mode;

        public CategoriaDTO Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                this.SetCategoria();
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

        private void SetCategoria()
        {
            this.idTextBox.Text = this.Categoria.Id.ToString();
            this.nombreTextBox.Text = this.Categoria.Nombre;
            this.descTextBox.Text = this.Categoria.Descripcion;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private void Init(FormMode mode, CategoriaDTO categoria)
        {
            try
            {
                this.Mode = mode;
                this.Categoria = categoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public CategoriaDetalle()
        {
            InitializeComponent();
        }

        public CategoriaDetalle(FormMode mode, CategoriaDTO categoria) : this()
        {
            Init(mode, categoria);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(descTextBox.Text))
            {
                MessageBox.Show("Completá nombre y descripcion.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.Categoria.Nombre = nombreTextBox.Text.Trim();
            this.Categoria.Descripcion = descTextBox.Text.Trim();

            try
            {
                HttpResponseMessage response;

                if (this.Mode == FormMode.Update)
                {
                    response = await CategoriaApiClient.UpdateAsync(this.Categoria);
                }
                else
                {
                    response = await CategoriaApiClient.AddAsync(this.Categoria);
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
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al guardar la categoría.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al guardar la categoría ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}
