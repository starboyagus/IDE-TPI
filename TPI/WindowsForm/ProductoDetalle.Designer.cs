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
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(197, 42);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(216, 23);
            idTextBox.TabIndex = 0;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(197, 83);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(216, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // precioTextBox
            // 
            precioTextBox.Location = new Point(197, 125);
            precioTextBox.Name = "precioTextBox";
            precioTextBox.Size = new Size(216, 23);
            precioTextBox.TabIndex = 2;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(108, 50);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 4;
            idLabel.Text = "ID";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(108, 91);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 5;
            nombreLabel.Text = "Nombre";
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new Point(108, 133);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new Size(40, 15);
            precioLabel.TabIndex = 6;
            precioLabel.Text = "Precio";
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(108, 173);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(36, 15);
            stockLabel.TabIndex = 7;
            stockLabel.Text = "Stock";
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(197, 207);
            descTextBox.Multiline = true;
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(216, 94);
            descTextBox.TabIndex = 8;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(108, 207);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(69, 15);
            descLabel.TabIndex = 9;
            descLabel.Text = "Descripcion";
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(197, 165);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(216, 23);
            stockTextBox.TabIndex = 10;
            // 
            // preventaLabel
            // 
            preventaLabel.AutoSize = true;
            preventaLabel.Location = new Point(108, 332);
            preventaLabel.Name = "preventaLabel";
            preventaLabel.Size = new Size(53, 15);
            preventaLabel.TabIndex = 11;
            preventaLabel.Text = "Preventa";
            // 
            // preventaComboBox
            // 
            preventaComboBox.FormattingEnabled = true;
            preventaComboBox.Location = new Point(197, 329);
            preventaComboBox.Name = "preventaComboBox";
            preventaComboBox.Size = new Size(216, 23);
            preventaComboBox.TabIndex = 12;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(447, 402);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(106, 36);
            aceptarButton.TabIndex = 13;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(580, 402);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(101, 36);
            cancelarButton.TabIndex = 14;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ProductoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 450);
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
            Name = "ProductoDetalle";
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
    }
}