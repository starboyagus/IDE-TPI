namespace WindowsForm
{
    partial class ProductoDetalle
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
            nombreTextBox = new TextBox();
            precioTextBox = new TextBox();
            idLabel = new Label();
            nombreLabel = new Label();
            precioLabel = new Label();
            stockLabel = new Label();
            descTextBox = new TextBox();
            descLabel = new Label();
            stockTextBox = new TextBox();
            preventaLabel = new Label();
            preventaComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            txtCategoria = new Label();
            categComboBox = new ComboBox();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(87, 12);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(215, 23);
            idTextBox.TabIndex = 0;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(87, 50);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(215, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // precioTextBox
            // 
            precioTextBox.Location = new Point(87, 88);
            precioTextBox.Name = "precioTextBox";
            precioTextBox.Size = new Size(215, 23);
            precioTextBox.TabIndex = 2;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 4;
            idLabel.Text = "ID";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(12, 53);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 5;
            nombreLabel.Text = "Nombre";
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new Point(12, 91);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new Size(40, 15);
            precioLabel.TabIndex = 6;
            precioLabel.Text = "Precio";
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(12, 129);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(36, 15);
            stockLabel.TabIndex = 7;
            stockLabel.Text = "Stock";
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(87, 165);
            descTextBox.Multiline = true;
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(215, 95);
            descTextBox.TabIndex = 8;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(12, 165);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(69, 15);
            descLabel.TabIndex = 9;
            descLabel.Text = "Descripcion";
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(87, 126);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(215, 23);
            stockTextBox.TabIndex = 10;
            // 
            // preventaLabel
            // 
            preventaLabel.AutoSize = true;
            preventaLabel.Location = new Point(12, 277);
            preventaLabel.Name = "preventaLabel";
            preventaLabel.Size = new Size(53, 15);
            preventaLabel.TabIndex = 11;
            preventaLabel.Text = "Preventa";
            // 
            // preventaComboBox
            // 
            preventaComboBox.FormattingEnabled = true;
            preventaComboBox.Location = new Point(87, 274);
            preventaComboBox.Name = "preventaComboBox";
            preventaComboBox.Size = new Size(215, 23);
            preventaComboBox.TabIndex = 12;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(87, 353);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(105, 35);
            aceptarButton.TabIndex = 13;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(198, 353);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(105, 35);
            cancelarButton.TabIndex = 14;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // txtCategoria
            // 
            txtCategoria.AutoSize = true;
            txtCategoria.Location = new Point(12, 319);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(58, 15);
            txtCategoria.TabIndex = 15;
            txtCategoria.Text = "Categoria";
            // 
            // categComboBox
            // 
            categComboBox.FormattingEnabled = true;
            categComboBox.Location = new Point(87, 311);
            categComboBox.Name = "categComboBox";
            categComboBox.Size = new Size(216, 23);
            categComboBox.TabIndex = 16;
            // 
            // ProductoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 400);
            Controls.Add(categComboBox);
            Controls.Add(txtCategoria);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(preventaComboBox);
            Controls.Add(preventaLabel);
            Controls.Add(stockTextBox);
            Controls.Add(descLabel);
            Controls.Add(descTextBox);
            Controls.Add(stockLabel);
            Controls.Add(precioLabel);
            Controls.Add(nombreLabel);
            Controls.Add(idLabel);
            Controls.Add(precioTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductoDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Producto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox nombreTextBox;
        private TextBox precioTextBox;
        private Label idLabel;
        private Label nombreLabel;
        private Label precioLabel;
        private Label stockLabel;
        private TextBox descTextBox;
        private Label descLabel;
        private TextBox stockTextBox;
        private Label preventaLabel;
        private ComboBox preventaComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private Label txtCategoria;
        private ComboBox categComboBox;
    }
}