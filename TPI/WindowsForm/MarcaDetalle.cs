using API.Clients;
using DTOs;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class MarcaDetalle : Form
    {
        private MarcaDTO marca;
        private FormMode mode;

        public MarcaDTO Marca
        {
            get { return marca; }
            set
            {
                marca = value;
                this.SetMarca();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        private void SetMarca()
        {
            this.idTextBox.Text = this.Marca.Id.ToString();
            this.nombreTextBox.Text = this.Marca.Nombre;
            this.paisOrigenTextBox.Text = this.Marca.PaisOrigen;
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

        private void Init(FormMode mode, MarcaDTO marca)
        {
            try
            {
                this.Mode = mode;
                this.Marca = marca;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MarcaDetalle()
        {
            InitializeComponent();
        }

        public MarcaDetalle(FormMode mode, MarcaDTO marca) : this()
        {
            Init(mode, marca);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(paisOrigenTextBox.Text))
            {
                MessageBox.Show("Completá nombre y país de origen.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.Marca.Nombre = nombreTextBox.Text.Trim();
            this.Marca.PaisOrigen = paisOrigenTextBox.Text.Trim();

            try
            {
                HttpResponseMessage? response;

                if (this.Mode == FormMode.Update)
                {
                    response = await MarcaApiClient.UpdateAsync(this.Marca);
                }
                else
                {
                    response = await MarcaApiClient.AddAsync(this.Marca);
                }

                if (response == null || !response.IsSuccessStatusCode)
                {
                    string mensaje = response != null ? await ExtraerMensajeError(response) : "No se obtuvo respuesta del servidor.";
                    MessageBox.Show(mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al guardar la marca.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al guardar la marca ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}
