namespace WindowsForm
{
    partial class CategoriaLista
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
            tscCategorias = new ToolStripContainer();
            tlCategorias = new TableLayoutPanel();
            dgvCategorias = new DataGridView();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            tsCategorias = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tscCategorias.ContentPanel.SuspendLayout();
            tscCategorias.TopToolStripPanel.SuspendLayout();
            tscCategorias.SuspendLayout();
            tlCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            tsCategorias.SuspendLayout();
            SuspendLayout();
            //
            // tscCategorias
            //
            //
            // tscCategorias.ContentPanel
            //
            tscCategorias.ContentPanel.Controls.Add(tlCategorias);
            tscCategorias.ContentPanel.Size = new Size(850, 426);
            tscCategorias.Dock = DockStyle.Fill;
            tscCategorias.Location = new Point(0, 0);
            tscCategorias.Name = "tscCategorias";
            tscCategorias.Size = new Size(850, 451);
            tscCategorias.TabIndex = 0;
            tscCategorias.Text = "toolStripContainer1";
            //
            // tscCategorias.TopToolStripPanel
            //
            tscCategorias.TopToolStripPanel.Controls.Add(tsCategorias);
            //
            // tlCategorias
            //
            tlCategorias.ColumnCount = 3;
            tlCategorias.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlCategorias.ColumnStyles.Add(new ColumnStyle());
            tlCategorias.ColumnStyles.Add(new ColumnStyle());
            tlCategorias.Controls.Add(dgvCategorias, 0, 0);
            tlCategorias.Controls.Add(btnActualizar, 0, 1);
            tlCategorias.Controls.Add(btnEliminar, 1, 1);
            tlCategorias.Controls.Add(btnSalir, 2, 1);
            tlCategorias.Dock = DockStyle.Fill;
            tlCategorias.Location = new Point(0, 0);
            tlCategorias.Name = "tlCategorias";
            tlCategorias.RowCount = 2;
            tlCategorias.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlCategorias.RowStyles.Add(new RowStyle());
            tlCategorias.Size = new Size(850, 426);
            tlCategorias.TabIndex = 0;
            //
            // dgvCategorias
            //
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeColumns = false;
            dgvCategorias.AllowUserToResizeRows = false;
            // Las columnas se reparten todo el ancho disponible en vez de ajustarse al contenido.
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = SystemColors.ControlDarkDark;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlCategorias.SetColumnSpan(dgvCategorias, 3);
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.Location = new Point(3, 3);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.MultiSelect = false;
            dgvCategorias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            // Al hacer clic en cualquier celda se selecciona la fila entera.
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(844, 391);
            dgvCategorias.TabIndex = 0;
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
            // tsCategorias
            //
            tsCategorias.Dock = DockStyle.None;
            tsCategorias.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsCategorias.Location = new Point(3, 0);
            tsCategorias.Name = "tsCategorias";
            tsCategorias.Size = new Size(58, 25);
            tsCategorias.TabIndex = 0;
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
            // CategoriaLista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 451);
            Controls.Add(tscCategorias);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriaLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista Categorias";
            Load += CategoriaLista_Load;
            tscCategorias.ContentPanel.ResumeLayout(false);
            tscCategorias.TopToolStripPanel.ResumeLayout(false);
            tscCategorias.TopToolStripPanel.PerformLayout();
            tscCategorias.ResumeLayout(false);
            tscCategorias.PerformLayout();
            tlCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            tsCategorias.ResumeLayout(false);
            tsCategorias.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscCategorias;
        private ToolStrip tsCategorias;
        private TableLayoutPanel tlCategorias;
        private DataGridView dgvCategorias;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
    }
}
