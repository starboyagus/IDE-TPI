using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class OrdenDetalle : Form
    {
        private OrdenDTO orden = new();
        private FormMode mode;
        private List<ProductoDTO> productosDisponibles = new();

        public OrdenDTO Orden
        {
            get { return orden; }
            set
            {
                orden = value;
                this.SetOrden();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public OrdenDetalle()
        {
            InitializeComponent();
            ConfigurarColumnasGrilla();
        }

        public OrdenDetalle(FormMode mode, OrdenDTO orden) : this()
        {
            Init(mode, orden);
        }

        private void ConfigurarColumnasGrilla()
        {
            dgvItems.AutoGenerateColumns = false;

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataPropertyName = nameof(OrdenItemDTO.Producto),
                FillWeight = 160
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = nameof(OrdenItemDTO.Cantidad),
                FillWeight = 50
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unit.",
                DataPropertyName = nameof(OrdenItemDTO.PrecioUnitario),
                FillWeight = 70,
                DefaultCellStyle = { Format = "C2" }
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = nameof(OrdenItemDTO.Subtotal),
                FillWeight = 70,
                DefaultCellStyle = { Format = "C2" }
            });
        }

        private void SetOrden()
        {
            this.idTextBox.Text = this.Orden.Id > 0 ? this.Orden.Id.ToString() : "";
            this.dtpFecha.Value = this.Orden.Fecha == default ? DateTime.Now : this.Orden.Fecha;
            this.direccionTextBox.Text = this.Orden.DireccionEnvio ?? "";

            this.estadoComboBox.DataSource = Enum.GetValues(typeof(EstadoOrden));
            if (this.Mode == FormMode.Add && this.Orden.Estado == default)
            {
                this.estadoComboBox.SelectedItem = EstadoOrden.Procesando;
            }
            else
            {
                this.estadoComboBox.SelectedItem = this.Orden.Estado;
            }

            RefrescarGrillaItems();
        }

        private void RefrescarGrillaItems()
        {
            dgvItems.DataSource = null;
            if (this.Orden.Items != null && this.Orden.Items.Any())
            {
                dgvItems.DataSource = this.Orden.Items.ToList();
            }

            decimal total = this.Orden.Items?.Sum(i => i.Cantidad * i.PrecioUnitario) ?? 0;
            this.Orden.Total = total;
            this.totalTextBox.Text = total.ToString("C2");
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                estadoComboBox.SelectedItem = EstadoOrden.Procesando;
                estadoComboBox.Enabled = false;

                lblProducto.Visible = true;
                productoComboBox.Visible = true;
                lblCantidad.Visible = true;
                nudCantidad.Visible = true;
                btnAgregarItem.Visible = true;
                btnQuitarItem.Visible = true;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                dtpFecha.Enabled = false;
                usuarioComboBox.Enabled = false;
                estadoComboBox.Enabled = AuthService.AuthService.IsAdmin;

                // En modo edición no se alteran los ítems para no desfasar el stock ya descontado
                lblProducto.Visible = false;
                productoComboBox.Visible = false;
                lblCantidad.Visible = false;
                nudCantidad.Visible = false;
                btnAgregarItem.Visible = false;
                btnQuitarItem.Visible = false;
            }
        }

        private async Task CargarUsuariosAsync()
        {
            if (AuthService.AuthService.IsAdmin)
            {
                var usuarios = await UsuarioApiClient.GetAllAsync() ?? new();
                usuarioComboBox.DataSource = usuarios.Where(u => u.EsActivo).ToList();
                usuarioComboBox.DisplayMember = nameof(UsuarioDTO.Email);
                usuarioComboBox.ValueMember = nameof(UsuarioDTO.Id);

                if (this.Mode == FormMode.Add)
                {
                    usuarioComboBox.SelectedValue = AuthService.AuthService.UsuarioActual?.Id ?? (usuarios.FirstOrDefault()?.Id ?? 0);
                }
                else
                {
                    usuarioComboBox.SelectedValue = this.Orden.UsuarioId;
                }
            }
            else
            {
                var usuarioActual = AuthService.AuthService.UsuarioActual;
                if (usuarioActual != null)
                {
                    var lista = new List<UsuarioDTO>
                    {
                        new UsuarioDTO
                        {
                            Id = usuarioActual.Id,
                            Nombre = usuarioActual.Nombre,
                            Apellido = usuarioActual.Apellido,
                            Email = usuarioActual.Email
                        }
                    };
                    usuarioComboBox.DataSource = lista;
                    usuarioComboBox.DisplayMember = nameof(UsuarioDTO.Email);
                    usuarioComboBox.ValueMember = nameof(UsuarioDTO.Id);
                    usuarioComboBox.SelectedValue = usuarioActual.Id;
                }
                usuarioComboBox.Enabled = false;
            }
        }

        private async Task CargarProductosAsync()
        {
            var productos = await ProductoApiClient.GetAllAsync() ?? new();
            productosDisponibles = productos.Where(p => p.EsActivo && (p.EsPreVenta || p.Stock > 0)).ToList();

            productoComboBox.DataSource = productosDisponibles;
            productoComboBox.DisplayMember = nameof(ProductoDTO.Nombre);
            productoComboBox.ValueMember = nameof(ProductoDTO.Id);

            if (productosDisponibles.Any())
            {
                productoComboBox.SelectedIndex = 0;
            }
        }

        private async void Init(FormMode mode, OrdenDTO orden)
        {
            try
            {
                this.Mode = mode;
                this.Orden = orden;

                await CargarUsuariosAsync();
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (productoComboBox.SelectedItem is not ProductoDTO producto)
            {
                MessageBox.Show("Seleccioná un producto de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemExistente = this.Orden.Items.FirstOrDefault(i => i.ProductoId == producto.Id);
            int cantidadTotal = (itemExistente?.Cantidad ?? 0) + cantidad;

            if (!producto.EsPreVenta && producto.Stock < cantidadTotal)
            {
                MessageBox.Show($"Stock insuficiente para '{producto.Nombre}'. Disponible: {producto.Stock}, en orden: {itemExistente?.Cantidad ?? 0}.",
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemExistente != null)
            {
                itemExistente.Cantidad = cantidadTotal;
            }
            else
            {
                this.Orden.Items.Add(new OrdenItemDTO
                {
                    ProductoId = producto.Id,
                    Producto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });
            }

            nudCantidad.Value = 1;
            RefrescarGrillaItems();
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un ítem de la grilla para quitar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvItems.SelectedRows[0].DataBoundItem is OrdenItemDTO itemSeleccionado)
            {
                this.Orden.Items.Remove(itemSeleccionado);
                RefrescarGrillaItems();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(direccionTextBox.Text))
            {
                MessageBox.Show("Completá la dirección de envío.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (usuarioComboBox.SelectedValue == null || (int)usuarioComboBox.SelectedValue <= 0)
            {
                MessageBox.Show("Seleccioná un usuario válido.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.Mode == FormMode.Add && (this.Orden.Items == null || !this.Orden.Items.Any()))
            {
                MessageBox.Show("Debes agregar al menos un ítem a la orden.", "Sin ítems", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            this.Orden.DireccionEnvio = direccionTextBox.Text.Trim();
            this.Orden.Fecha = dtpFecha.Value;
            this.Orden.UsuarioId = (int)usuarioComboBox.SelectedValue!;

            if (estadoComboBox.SelectedItem is EstadoOrden estado)
            {
                this.Orden.Estado = estado;
            }

            try
            {
                HttpResponseMessage? response;

                if (this.Mode == FormMode.Update)
                {
                    response = await OrdenApiClient.UpdateAsync(this.Orden);
                }
                else
                {
                    response = await OrdenApiClient.AddAsync(this.Orden);
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
                MessageBox.Show($"Error al guardar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static async Task<string> ExtraerMensajeError(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<JsonElement>();
                if (body.ValueKind == JsonValueKind.Object && body.TryGetProperty("error", out var errorProp))
                {
                    return errorProp.GetString() ?? "Ocurrió un error al procesar la orden.";
                }
            }
            catch
            {
            }

            return $"Ocurrió un error al procesar la orden ({(int)response.StatusCode} {response.ReasonPhrase}).";
        }
    }
}
