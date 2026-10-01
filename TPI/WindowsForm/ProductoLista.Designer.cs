namespace WindowsForm
{
    partial class ProductoLista
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
            tscProductos = new ToolStripContainer();
            tlProductos = new TableLayoutPanel();
            dgvProductos = new DataGridView();
            btnVerEspecificaciones = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            tsProductos = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tscProductos.ContentPanel.SuspendLayout();
            tscProductos.TopToolStripPanel.SuspendLayout();
            tscProductos.SuspendLayout();
            tlProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tsProductos.SuspendLayout();
            SuspendLayout();
            // 
            // tscProductos
            // 
            // 
            // tscProductos.ContentPanel
            // 
            tscProductos.ContentPanel.Controls.Add(tlProductos);
            tscProductos.ContentPanel.Size = new Size(850, 426);
            tscProductos.Dock = DockStyle.Fill;
            tscProductos.Location = new Point(0, 0);
            tscProductos.Name = "tscProductos";
            tscProductos.Size = new Size(850, 451);
            tscProductos.TabIndex = 0;
            tscProductos.Text = "toolStripContainer1";
            // 
            // tscProductos.TopToolStripPanel
            // 
            tscProductos.TopToolStripPanel.Controls.Add(tsProductos);
            // 
            // tlProductos
            // 
            tlProductos.ColumnCount = 4;
            tlProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlProductos.ColumnStyles.Add(new ColumnStyle());
            tlProductos.ColumnStyles.Add(new ColumnStyle());
            tlProductos.ColumnStyles.Add(new ColumnStyle());
            tlProductos.Controls.Add(dgvProductos, 0, 0);
            tlProductos.Controls.Add(btnVerEspecificaciones, 0, 1);
            tlProductos.Controls.Add(btnActualizar, 1, 1);
            tlProductos.Controls.Add(btnEliminar, 2, 1);
            tlProductos.Controls.Add(btnSalir, 3, 1);
            tlProductos.Dock = DockStyle.Fill;
            tlProductos.Location = new Point(0, 0);
            tlProductos.Name = "tlProductos";
            tlProductos.RowCount = 2;
            tlProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlProductos.RowStyles.Add(new RowStyle());
            tlProductos.Size = new Size(850, 426);
            tlProductos.TabIndex = 0;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            // Las columnas se reparten todo el ancho según el FillWeight de cada una.
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.ControlDarkDark;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlProductos.SetColumnSpan(dgvProductos, 4);
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(844, 391);
            dgvProductos.TabIndex = 0;
            // 
            // btnVerEspecificaciones
            // 
            btnVerEspecificaciones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerEspecificaciones.Location = new Point(480, 400);
            btnVerEspecificaciones.Name = "btnVerEspecificaciones";
            btnVerEspecificaciones.Size = new Size(124, 23);
            btnVerEspecificaciones.TabIndex = 4;
            btnVerEspecificaciones.Text = "Ver Especificaciones";
            btnVerEspecificaciones.UseVisualStyleBackColor = true;
            btnVerEspecificaciones.Click += btnVerEspecificaciones_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(610, 400);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.RightToLeft = RightToLeft.No;
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(691, 400);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(772, 400);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // tsProductos
            // 
            tsProductos.Dock = DockStyle.None;
            tsProductos.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsProductos.Location = new Point(3, 0);
            tsProductos.Name = "tsProductos";
            tsProductos.Size = new Size(58, 25);
            tsProductos.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(46, 22);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // ProductoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 451);
            Controls.Add(tscProductos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductoLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista Productos";
            Load += ProductoLista_Load;
            tscProductos.ContentPanel.ResumeLayout(false);
            tscProductos.TopToolStripPanel.ResumeLayout(false);
            tscProductos.TopToolStripPanel.PerformLayout();
            tscProductos.ResumeLayout(false);
            tscProductos.PerformLayout();
            tlProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tsProductos.ResumeLayout(false);
            tsProductos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscProductos;
        private ToolStrip tsProductos;
        private TableLayoutPanel tlProductos;
        private DataGridView dgvProductos;
        private Button btnVerEspecificaciones;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
    }
}