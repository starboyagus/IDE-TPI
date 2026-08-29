namespace WindowsForm
{
    partial class CategoriaDetalle
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
            descTextBox = new TextBox();
            idLabel = new Label();
            nombreLabel = new Label();
            descLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            //
            // idTextBox
            //
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(87, 12);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
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
            // descTextBox
            //
            descTextBox.Location = new Point(87, 88);
            descTextBox.Multiline = true;
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(215, 95);
            descTextBox.TabIndex = 2;
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
            // descLabel
            //
            descLabel.AutoSize = true;
            descLabel.Location = new Point(12, 88);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(69, 15);
            descLabel.TabIndex = 5;
            descLabel.Text = "Descripcion";
            //
            // aceptarButton
            //
            aceptarButton.Location = new Point(87, 200);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(105, 35);
            aceptarButton.TabIndex = 6;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            //
            // cancelarButton
            //
            cancelarButton.Location = new Point(198, 200);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(105, 35);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            //
            // CategoriaDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 250);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(descLabel);
            Controls.Add(nombreLabel);
            Controls.Add(idLabel);
            Controls.Add(descTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriaDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Categoria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox nombreTextBox;
        private TextBox descTextBox;
        private Label idLabel;
        private Label nombreLabel;
        private Label descLabel;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}
