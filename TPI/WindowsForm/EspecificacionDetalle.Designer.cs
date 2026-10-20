namespace WindowsForm
{
    partial class EspecificacionDetalle
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
            productoTextBox = new TextBox();
            claveTextBox = new TextBox();
            valorTextBox = new TextBox();
            unidadTextBox = new TextBox();
            idLabel = new Label();
            productoLabel = new Label();
            claveLabel = new Label();
            valorLabel = new Label();
            unidadLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(105, 12);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(205, 23);
            idTextBox.TabIndex = 0;
            idTextBox.TabStop = false;
            // 
            // productoTextBox
            // 
            productoTextBox.BackColor = SystemColors.Control;
            productoTextBox.Location = new Point(105, 50);
            productoTextBox.Name = "productoTextBox";
            productoTextBox.ReadOnly = true;
            productoTextBox.Size = new Size(205, 23);
            productoTextBox.TabIndex = 1;
            productoTextBox.TabStop = false;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(105, 88);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(205, 23);
            claveTextBox.TabIndex = 2;
            // 
            // valorTextBox
            // 
            valorTextBox.Location = new Point(105, 126);
            valorTextBox.Name = "valorTextBox";
            valorTextBox.Size = new Size(205, 23);
            valorTextBox.TabIndex = 3;
            // 
            // unidadTextBox
            // 
            unidadTextBox.Location = new Point(105, 164);
            unidadTextBox.Name = "unidadTextBox";
            unidadTextBox.PlaceholderText = "Opcional";
            unidadTextBox.Size = new Size(205, 23);
            unidadTextBox.TabIndex = 4;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 7;
            idLabel.Text = "ID";
            // 
            // productoLabel
            // 
            productoLabel.AutoSize = true;
            productoLabel.Location = new Point(12, 53);
            productoLabel.Name = "productoLabel";
            productoLabel.Size = new Size(56, 15);
            productoLabel.TabIndex = 8;
            productoLabel.Text = "Producto";
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.Location = new Point(12, 91);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new Size(35, 15);
            claveLabel.TabIndex = 9;
            claveLabel.Text = "Clave";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new Point(12, 129);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(33, 15);
            valorLabel.TabIndex = 10;
            valorLabel.Text = "Valor";
            // 
            // unidadLabel
            // 
            unidadLabel.AutoSize = true;
            unidadLabel.Location = new Point(12, 167);
            unidadLabel.Name = "unidadLabel";
            unidadLabel.Size = new Size(45, 15);
            unidadLabel.TabIndex = 11;
            unidadLabel.Text = "Unidad";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(105, 211);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(100, 35);
            aceptarButton.TabIndex = 5;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(210, 211);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(100, 35);
            cancelarButton.TabIndex = 6;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // EspecificacionDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelarButton;
            ClientSize = new Size(334, 261);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(unidadLabel);
            Controls.Add(valorLabel);
            Controls.Add(claveLabel);
            Controls.Add(productoLabel);
            Controls.Add(idLabel);
            Controls.Add(unidadTextBox);
            Controls.Add(valorTextBox);
            Controls.Add(claveTextBox);
            Controls.Add(productoTextBox);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EspecificacionDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Especificación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox productoTextBox;
        private TextBox claveTextBox;
        private TextBox valorTextBox;
        private TextBox unidadTextBox;
        private Label idLabel;
        private Label productoLabel;
        private Label claveLabel;
        private Label valorLabel;
        private Label unidadLabel;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}
