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
            tscProductos.ContentPanel.Size = new Size(800, 425);
            tscProductos.Dock = DockStyle.Fill;
            tscProductos.Location = new Point(0, 0);
            tscProductos.Name = "tscProductos";
            tscProductos.Size = new Size(800, 450);
            tscProductos.TabIndex = 0;
            tscProductos.Text = "toolStripContainer1";
            // 
            // tscProductos.TopToolStripPanel
            // 
            tscProductos.TopToolStripPanel.Controls.Add(tsProductos);
            // 
            // tlProductos
            // 
            tlProductos.ColumnCount = 3;
            tlProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlProductos.ColumnStyles.Add(new ColumnStyle());
            tlProductos.ColumnStyles.Add(new ColumnStyle());
            tlProductos.Controls.Add(dgvProductos, 0, 0);
            tlProductos.Controls.Add(btnActualizar, 0, 1);
            tlProductos.Controls.Add(btnEliminar, 1, 1);
            tlProductos.Controls.Add(btnSalir, 2, 1);
            tlProductos.Dock = DockStyle.Fill;
            tlProductos.Location = new Point(0, 0);
            tlProductos.Name = "tlProductos";
            tlProductos.RowCount = 2;
            tlProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlProductos.RowStyles.Add(new RowStyle());
            tlProductos.Size = new Size(800, 425);
            tlProductos.TabIndex = 0;
            // 
            // dgvProductos
            // 
            dgvProductos.BackgroundColor = SystemColors.ControlDarkDark;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlProductos.SetColumnSpan(dgvProductos, 3);
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(794, 390);
            dgvProductos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(560, 399);
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
            btnEliminar.Location = new Point(641, 399);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(722, 399);
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
            ClientSize = new Size(800, 450);
            Controls.Add(tscProductos);
            Name = "ProductoLista";
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
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
    }
}