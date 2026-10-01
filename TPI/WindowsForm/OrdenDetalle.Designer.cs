namespace WindowsForm
{
    partial class OrdenDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            idTextBox = new TextBox();
            usuarioComboBox = new ComboBox();
            dtpFecha = new DateTimePicker();
            estadoComboBox = new ComboBox();
            direccionTextBox = new TextBox();
            totalTextBox = new TextBox();
            idLabel = new Label();
            usuarioLabel = new Label();
            fechaLabel = new Label();
            estadoLabel = new Label();
            direccionLabel = new Label();
            totalLabel = new Label();
            gbItems = new GroupBox();
            btnQuitarItem = new Button();
            btnAgregarItem = new Button();
            nudCantidad = new NumericUpDown();
            lblCantidad = new Label();
            productoComboBox = new ComboBox();
            lblProducto = new Label();
            dgvItems = new DataGridView();
            aceptarButton = new Button();
            cancelarButton = new Button();
            gbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(15, 18);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(115, 15);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(120, 23);
            idTextBox.TabIndex = 1;
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new Point(270, 18);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new Size(38, 15);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(315, 15);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(270, 23);
            dtpFecha.TabIndex = 3;
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Location = new Point(15, 51);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(47, 15);
            usuarioLabel.TabIndex = 4;
            usuarioLabel.Text = "Usuario";
            // 
            // usuarioComboBox
            // 
            usuarioComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            usuarioComboBox.FormattingEnabled = true;
            usuarioComboBox.Location = new Point(115, 48);
            usuarioComboBox.Name = "usuarioComboBox";
            usuarioComboBox.Size = new Size(470, 23);
            usuarioComboBox.TabIndex = 5;
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Location = new Point(15, 84);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new Size(90, 15);
            direccionLabel.TabIndex = 6;
            direccionLabel.Text = "Dirección Envío";
            // 
            // direccionTextBox
            // 
            direccionTextBox.Location = new Point(115, 81);
            direccionTextBox.Name = "direccionTextBox";
            direccionTextBox.Size = new Size(470, 23);
            direccionTextBox.TabIndex = 7;
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(15, 117);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(42, 15);
            estadoLabel.TabIndex = 8;
            estadoLabel.Text = "Estado";
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(115, 114);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(200, 23);
            estadoComboBox.TabIndex = 9;
            // 
            // gbItems
            // 
            gbItems.Controls.Add(btnQuitarItem);
            gbItems.Controls.Add(btnAgregarItem);
            gbItems.Controls.Add(nudCantidad);
            gbItems.Controls.Add(lblCantidad);
            gbItems.Controls.Add(productoComboBox);
            gbItems.Controls.Add(lblProducto);
            gbItems.Controls.Add(dgvItems);
            gbItems.Location = new Point(15, 150);
            gbItems.Name = "gbItems";
            gbItems.Size = new Size(570, 310);
            gbItems.TabIndex = 10;
            gbItems.TabStop = false;
            gbItems.Text = "Ítems de la Orden";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(10, 25);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto:";
            // 
            // productoComboBox
            // 
            productoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productoComboBox.FormattingEnabled = true;
            productoComboBox.Location = new Point(75, 22);
            productoComboBox.Name = "productoComboBox";
            productoComboBox.Size = new Size(230, 23);
            productoComboBox.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(315, 25);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(38, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cant:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(355, 22);
            nudCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(55, 23);
            nudCantidad.TabIndex = 3;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Location = new Point(420, 21);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new Size(68, 25);
            btnAgregarItem.TabIndex = 4;
            btnAgregarItem.Text = "Agregar";
            btnAgregarItem.UseVisualStyleBackColor = true;
            btnAgregarItem.Click += btnAgregarItem_Click;
            // 
            // btnQuitarItem
            // 
            btnQuitarItem.Location = new Point(494, 21);
            btnQuitarItem.Name = "btnQuitarItem";
            btnQuitarItem.Size = new Size(65, 25);
            btnQuitarItem.TabIndex = 5;
            btnQuitarItem.Text = "Quitar";
            btnQuitarItem.UseVisualStyleBackColor = true;
            btnQuitarItem.Click += btnQuitarItem_Click;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(10, 55);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(550, 245);
            dgvItems.TabIndex = 6;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            totalLabel.Location = new Point(380, 475);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(46, 19);
            totalLabel.TabIndex = 11;
            totalLabel.Text = "Total:";
            // 
            // totalTextBox
            // 
            totalTextBox.BackColor = SystemColors.Control;
            totalTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            totalTextBox.Location = new Point(430, 472);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.ReadOnly = true;
            totalTextBox.Size = new Size(155, 25);
            totalTextBox.TabIndex = 12;
            totalTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(350, 515);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(115, 35);
            aceptarButton.TabIndex = 13;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(475, 515);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(110, 35);
            cancelarButton.TabIndex = 14;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // OrdenDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 565);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(totalTextBox);
            Controls.Add(totalLabel);
            Controls.Add(gbItems);
            Controls.Add(estadoComboBox);
            Controls.Add(estadoLabel);
            Controls.Add(direccionTextBox);
            Controls.Add(direccionLabel);
            Controls.Add(usuarioComboBox);
            Controls.Add(usuarioLabel);
            Controls.Add(dtpFecha);
            Controls.Add(fechaLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrdenDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Orden";
            gbItems.ResumeLayout(false);
            gbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label fechaLabel;
        private DateTimePicker dtpFecha;
        private Label usuarioLabel;
        private ComboBox usuarioComboBox;
        private Label direccionLabel;
        private TextBox direccionTextBox;
        private Label estadoLabel;
        private ComboBox estadoComboBox;
        private GroupBox gbItems;
        private Label lblProducto;
        private ComboBox productoComboBox;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregarItem;
        private Button btnQuitarItem;
        private DataGridView dgvItems;
        private Label totalLabel;
        private TextBox totalTextBox;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}
