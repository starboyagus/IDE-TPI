namespace WindowsForm
{
    partial class UsuarioDetalle
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
            apellidoTextBox = new TextBox();
            emailTextBox = new TextBox();
            telefonoTextBox = new TextBox();
            contraseniaTextBox = new TextBox();
            rolComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            idLabel = new Label();
            nombreLabel = new Label();
            apellidoLabel = new Label();
            emailLabel = new Label();
            rolLabel = new Label();
            telefonoLabel = new Label();
            contraseniaLabel = new Label();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(205, 44);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(212, 23);
            idTextBox.TabIndex = 0;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(205, 95);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(212, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(205, 144);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(212, 23);
            apellidoTextBox.TabIndex = 2;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(205, 201);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(212, 23);
            emailTextBox.TabIndex = 3;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(205, 258);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(212, 23);
            telefonoTextBox.TabIndex = 4;
            //
            // contraseniaTextBox
            //
            contraseniaTextBox.Location = new Point(205, 314);
            contraseniaTextBox.Name = "contraseniaTextBox";
            contraseniaTextBox.Size = new Size(212, 23);
            contraseniaTextBox.TabIndex = 5;
            contraseniaTextBox.UseSystemPasswordChar = true;
            //
            // rolComboBox
            //
            rolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rolComboBox.Location = new Point(205, 370);
            rolComboBox.Name = "rolComboBox";
            rolComboBox.Size = new Size(212, 23);
            rolComboBox.TabIndex = 6;
            //
            // aceptarButton
            //
            aceptarButton.Location = new Point(482, 439);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(106, 36);
            aceptarButton.TabIndex = 7;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            //
            // cancelarButton
            //
            cancelarButton.Location = new Point(621, 439);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(101, 36);
            cancelarButton.TabIndex = 8;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // idLabel
            //
            idLabel.AutoSize = true;
            idLabel.Location = new Point(106, 47);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 9;
            idLabel.Text = "ID";
            //
            // nombreLabel
            //
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(106, 98);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 10;
            nombreLabel.Text = "Nombre";
            //
            // apellidoLabel
            //
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(106, 144);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(51, 15);
            apellidoLabel.TabIndex = 11;
            apellidoLabel.Text = "Apellido";
            //
            // emailLabel
            //
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(106, 204);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "Email";
            //
            // rolLabel
            //
            rolLabel.AutoSize = true;
            rolLabel.Location = new Point(106, 373);
            rolLabel.Name = "rolLabel";
            rolLabel.Size = new Size(24, 15);
            rolLabel.TabIndex = 13;
            rolLabel.Text = "Rol";
            //
            // telefonoLabel
            //
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(104, 258);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(53, 15);
            telefonoLabel.TabIndex = 14;
            telefonoLabel.Text = "Telefono";
            //
            // contraseniaLabel
            //
            contraseniaLabel.AutoSize = true;
            contraseniaLabel.Location = new Point(106, 317);
            contraseniaLabel.Name = "contraseniaLabel";
            contraseniaLabel.Size = new Size(75, 15);
            contraseniaLabel.TabIndex = 15;
            contraseniaLabel.Text = "Contraseña";
            //
            // UsuarioDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 506);
            Controls.Add(contraseniaLabel);
            Controls.Add(telefonoLabel);
            Controls.Add(rolLabel);
            Controls.Add(emailLabel);
            Controls.Add(apellidoLabel);
            Controls.Add(nombreLabel);
            Controls.Add(idLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(rolComboBox);
            Controls.Add(contraseniaTextBox);
            Controls.Add(telefonoTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(apellidoTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(idTextBox);
            Name = "UsuarioDetalle";
            Text = "Detalle de Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox nombreTextBox;
        private TextBox apellidoTextBox;
        private TextBox emailTextBox;
        private TextBox telefonoTextBox;
        private TextBox contraseniaTextBox;
        private ComboBox rolComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private Label idLabel;
        private Label nombreLabel;
        private Label apellidoLabel;
        private Label emailLabel;
        private Label rolLabel;
        private Label telefonoLabel;
        private Label contraseniaLabel;
    }
}