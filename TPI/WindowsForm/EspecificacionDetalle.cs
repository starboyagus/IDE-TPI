using API.Clients;
using DTOs;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class EspecificacionDetalle : Form
    {
        private EspecificacionDTO especificacion;
        private FormMode mode;

        public EspecificacionDTO Especificacion
        {
            get { return especificacion; }
            set
            {
                especificacion = value;
                this.SetEspecificacion();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        private void SetEspecificacion()
        {
            this.idTextBox.Text = this.Especificacion.Id.ToString();
            this.productoTextBox.Text = this.Especificacion.Producto;
            this.claveTextBox.Text = this.Especificacion.Clave;
            this.valorTextBox.Text = this.Especificacion.Valor;
            this.unidadTextBox.Text = this.Especificacion.Unidad;
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

        private void Init(FormMode mode, EspecificacionDTO especificacion)
        {
            try
            {
                this.Mode = mode;
                this.Especificacion = especificacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EspecificacionDetalle()
        {
            InitializeComponent();
        }

        public EspecificacionDetalle(FormMode mode, EspecificacionDTO especificacion) : this()
        {
            Init(mode, especificacion);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // La unidad es opcional (ej. "Color: Negro" no lleva unidad); clave y valor son obligatorios.
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(claveTextBox.Text) ||
                string.IsNullOrWhiteSpace(valorTextBox.Text))
            {
                MessageBox.Show("Completá clave y valor.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.Especificacion.Clave = claveTextBox.Text.Trim();
            this.Especificacion.Valor = valorTextBox.Text.Trim();
            this.Especificacion.Unidad = string.IsNullOrWhiteSpace(unidadTextBox.Text) ? null : unidadTextBox.Text.Trim();

            try
            {
                HttpResponseMessage? response;

                if (this.Mode == FormMode.Update)
                {
                    response = await EspecificacionApiClient.UpdateAsync(this.Especificacion);
                }
                else
                {
                    this.Especificacion.EsActivo = true;
                    response = await EspecificacionApiClient.AddAsync(this.Especificacion);
                }

                if (response == null || !response.IsSuccessStatusCode)
                {
                    if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                    string mensaje = response != null ? await ExtraerMensajeError(response) : "No se obtuvo respuesta del servidor.";
                    MessageBox.Show(mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ApiClient.SesionVencida) return; // Home ya avisa y vuelve al login
                MessageBox.Show($"Error al guardar la especificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al guardar la especificación.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al guardar la especificación ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}
