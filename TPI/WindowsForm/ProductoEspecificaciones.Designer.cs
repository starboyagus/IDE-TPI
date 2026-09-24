namespace WindowsForm
{
    partial class ProductoEspecificaciones
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
            lblNombreTitulo = new Label();
            lblNombreValor = new Label();
            lblPrecioTitulo = new Label();
            lblPrecioValor = new Label();
            lblStockTitulo = new Label();
            lblStockValor = new Label();
            lblCategoriaTitulo = new Label();
            lblCategoriaValor = new Label();
            lblMarcaTitulo = new Label();
            lblMarcaValor = new Label();
            lblDescTitulo = new Label();
            lblDescValor = new Label();
            lblPreventaTitulo = new Label();
            lblPreventaValor = new Label();
            grpProducto = new GroupBox();
            grpEspecificaciones = new GroupBox();
            pnlEspecificaciones = new Panel();
            lblSinEspecificaciones = new Label();
            btnCerrar = new Button();
            grpProducto.SuspendLayout();
            grpEspecificaciones.SuspendLayout();
            SuspendLayout();
            // 
            // grpProducto
            // 
            grpProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpProducto.Controls.Add(lblNombreTitulo);
            grpProducto.Controls.Add(lblNombreValor);
            grpProducto.Controls.Add(lblPrecioTitulo);
            grpProducto.Controls.Add(lblPrecioValor);
            grpProducto.Controls.Add(lblStockTitulo);
            grpProducto.Controls.Add(lblStockValor);
            grpProducto.Controls.Add(lblCategoriaTitulo);
            grpProducto.Controls.Add(lblCategoriaValor);
            grpProducto.Controls.Add(lblMarcaTitulo);
            grpProducto.Controls.Add(lblMarcaValor);
            grpProducto.Controls.Add(lblDescTitulo);
            grpProducto.Controls.Add(lblDescValor);
            grpProducto.Controls.Add(lblPreventaTitulo);
            grpProducto.Controls.Add(lblPreventaValor);
            grpProducto.Location = new Point(12, 12);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new Size(560, 165);
            grpProducto.TabIndex = 0;
            grpProducto.TabStop = false;
            grpProducto.Text = "Datos del Producto";
            // 
            // lblNombreTitulo
            // 
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombreTitulo.Location = new Point(15, 25);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(55, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre:";
            // 
            // lblNombreValor
            // 
            lblNombreValor.AutoSize = true;
            lblNombreValor.Location = new Point(100, 25);
            lblNombreValor.Name = "lblNombreValor";
            lblNombreValor.Size = new Size(12, 15);
            lblNombreValor.TabIndex = 1;
            lblNombreValor.Text = "-";
            // 
            // lblPrecioTitulo
            // 
            lblPrecioTitulo.AutoSize = true;
            lblPrecioTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecioTitulo.Location = new Point(15, 50);
            lblPrecioTitulo.Name = "lblPrecioTitulo";
            lblPrecioTitulo.Size = new Size(46, 15);
            lblPrecioTitulo.TabIndex = 2;
            lblPrecioTitulo.Text = "Precio:";
            // 
            // lblPrecioValor
            // 
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.Location = new Point(100, 50);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(12, 15);
            lblPrecioValor.TabIndex = 3;
            lblPrecioValor.Text = "-";
            // 
            // lblStockTitulo
            // 
            lblStockTitulo.AutoSize = true;
            lblStockTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStockTitulo.Location = new Point(280, 50);
            lblStockTitulo.Name = "lblStockTitulo";
            lblStockTitulo.Size = new Size(42, 15);
            lblStockTitulo.TabIndex = 4;
            lblStockTitulo.Text = "Stock:";
            // 
            // lblStockValor
            // 
            lblStockValor.AutoSize = true;
            lblStockValor.Location = new Point(340, 50);
            lblStockValor.Name = "lblStockValor";
            lblStockValor.Size = new Size(12, 15);
            lblStockValor.TabIndex = 5;
            lblStockValor.Text = "-";
            // 
            // lblCategoriaTitulo
            // 
            lblCategoriaTitulo.AutoSize = true;
            lblCategoriaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoriaTitulo.Location = new Point(15, 75);
            lblCategoriaTitulo.Name = "lblCategoriaTitulo";
            lblCategoriaTitulo.Size = new Size(66, 15);
            lblCategoriaTitulo.TabIndex = 6;
            lblCategoriaTitulo.Text = "Categoría:";
            // 
            // lblCategoriaValor
            // 
            lblCategoriaValor.AutoSize = true;
            lblCategoriaValor.Location = new Point(100, 75);
            lblCategoriaValor.Name = "lblCategoriaValor";
            lblCategoriaValor.Size = new Size(12, 15);
            lblCategoriaValor.TabIndex = 7;
            lblCategoriaValor.Text = "-";
            // 
            // lblMarcaTitulo
            // 
            lblMarcaTitulo.AutoSize = true;
            lblMarcaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMarcaTitulo.Location = new Point(280, 75);
            lblMarcaTitulo.Name = "lblMarcaTitulo";
            lblMarcaTitulo.Size = new Size(45, 15);
            lblMarcaTitulo.TabIndex = 8;
            lblMarcaTitulo.Text = "Marca:";
            // 
            // lblMarcaValor
            // 
            lblMarcaValor.AutoSize = true;
            lblMarcaValor.Location = new Point(340, 75);
            lblMarcaValor.Name = "lblMarcaValor";
            lblMarcaValor.Size = new Size(12, 15);
            lblMarcaValor.TabIndex = 9;
            lblMarcaValor.Text = "-";
            // 
            // lblDescTitulo
            // 
            lblDescTitulo.AutoSize = true;
            lblDescTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescTitulo.Location = new Point(15, 100);
            lblDescTitulo.Name = "lblDescTitulo";
            lblDescTitulo.Size = new Size(79, 15);
            lblDescTitulo.TabIndex = 10;
            lblDescTitulo.Text = "Descripción:";
            // 
            // lblDescValor
            // 
            lblDescValor.Location = new Point(100, 100);
            lblDescValor.Name = "lblDescValor";
            lblDescValor.Size = new Size(445, 30);
            lblDescValor.TabIndex = 11;
            lblDescValor.Text = "-";
            // 
            // lblPreventaTitulo
            // 
            lblPreventaTitulo.AutoSize = true;
            lblPreventaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreventaTitulo.Location = new Point(15, 138);
            lblPreventaTitulo.Name = "lblPreventaTitulo";
            lblPreventaTitulo.Size = new Size(63, 15);
            lblPreventaTitulo.TabIndex = 12;
            lblPreventaTitulo.Text = "Preventa:";
            // 
            // lblPreventaValor
            // 
            lblPreventaValor.AutoSize = true;
            lblPreventaValor.Location = new Point(100, 138);
            lblPreventaValor.Name = "lblPreventaValor";
            lblPreventaValor.Size = new Size(12, 15);
            lblPreventaValor.TabIndex = 13;
            lblPreventaValor.Text = "-";
            // 
            // grpEspecificaciones
            // 
            grpEspecificaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpEspecificaciones.Controls.Add(pnlEspecificaciones);
            grpEspecificaciones.Controls.Add(lblSinEspecificaciones);
            grpEspecificaciones.Location = new Point(12, 185);
            grpEspecificaciones.Name = "grpEspecificaciones";
            grpEspecificaciones.Size = new Size(560, 220);
            grpEspecificaciones.TabIndex = 1;
            grpEspecificaciones.TabStop = false;
            grpEspecificaciones.Text = "Especificaciones";
            // 
            // pnlEspecificaciones
            // 
            pnlEspecificaciones.AutoScroll = true;
            pnlEspecificaciones.Dock = DockStyle.Fill;
            pnlEspecificaciones.Location = new Point(3, 19);
            pnlEspecificaciones.Name = "pnlEspecificaciones";
            pnlEspecificaciones.Padding = new Padding(10, 5, 10, 5);
            pnlEspecificaciones.Size = new Size(554, 198);
            pnlEspecificaciones.TabIndex = 0;
            // 
            // lblSinEspecificaciones
            // 
            lblSinEspecificaciones.Dock = DockStyle.Fill;
            lblSinEspecificaciones.ForeColor = SystemColors.GrayText;
            lblSinEspecificaciones.Location = new Point(3, 19);
            lblSinEspecificaciones.Name = "lblSinEspecificaciones";
            lblSinEspecificaciones.Size = new Size(554, 198);
            lblSinEspecificaciones.TabIndex = 1;
            lblSinEspecificaciones.Text = "Este producto no tiene especificaciones cargadas.";
            lblSinEspecificaciones.TextAlign = ContentAlignment.MiddleCenter;
            lblSinEspecificaciones.Visible = false;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Location = new Point(497, 415);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 30);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // ProductoEspecificaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 455);
            Controls.Add(btnCerrar);
            Controls.Add(grpEspecificaciones);
            Controls.Add(grpProducto);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductoEspecificaciones";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Especificaciones del Producto";
            Load += ProductoEspecificaciones_Load;
            grpProducto.ResumeLayout(false);
            grpProducto.PerformLayout();
            grpEspecificaciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpProducto;
        private Label lblNombreTitulo;
        private Label lblNombreValor;
        private Label lblPrecioTitulo;
        private Label lblPrecioValor;
        private Label lblStockTitulo;
        private Label lblStockValor;
        private Label lblCategoriaTitulo;
        private Label lblCategoriaValor;
        private Label lblMarcaTitulo;
        private Label lblMarcaValor;
        private Label lblDescTitulo;
        private Label lblDescValor;
        private Label lblPreventaTitulo;
        private Label lblPreventaValor;
        private GroupBox grpEspecificaciones;
        private Panel pnlEspecificaciones;
        private Label lblSinEspecificaciones;
        private Button btnCerrar;
    }
}
