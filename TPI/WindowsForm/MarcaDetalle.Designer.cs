namespace WindowsForm
{
    partial class MarcaDetalle
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
            paisOrigenTextBox = new TextBox();
            idLabel = new Label();
            nombreLabel = new Label();
            paisOrigenLabel = new Label();
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
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(105, 50);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(205, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // paisOrigenTextBox
            // 
            paisOrigenTextBox.Location = new Point(105, 88);
            paisOrigenTextBox.Name = "paisOrigenTextBox";
            paisOrigenTextBox.Size = new Size(205, 23);
            paisOrigenTextBox.TabIndex = 2;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 3;
            idLabel.Text = "ID";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(12, 53);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Nombre";
            // 
            // paisOrigenLabel
            // 
            paisOrigenLabel.AutoSize = true;
            paisOrigenLabel.Location = new Point(12, 91);
            paisOrigenLabel.Name = "paisOrigenLabel";
            paisOrigenLabel.Size = new Size(82, 15);
            paisOrigenLabel.TabIndex = 5;
            paisOrigenLabel.Text = "País de Origen";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(105, 135);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(100, 35);
            aceptarButton.TabIndex = 6;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(210, 135);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(100, 35);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // MarcaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 185);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(paisOrigenLabel);
            Controls.Add(nombreLabel);
            Controls.Add(idLabel);
            Controls.Add(paisOrigenTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MarcaDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Marca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox nombreTextBox;
        private TextBox paisOrigenTextBox;
        private Label idLabel;
        private Label nombreLabel;
        private Label paisOrigenLabel;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}
