namespace WindowsForm
{
    partial class MarcaLista
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
            tscMarcas = new ToolStripContainer();
            tlMarcas = new TableLayoutPanel();
            dgvMarcas = new DataGridView();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            tsMarcas = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tscMarcas.ContentPanel.SuspendLayout();
            tscMarcas.TopToolStripPanel.SuspendLayout();
            tscMarcas.SuspendLayout();
            tlMarcas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            tsMarcas.SuspendLayout();
            SuspendLayout();
            // 
            // tscMarcas
            // 
            // 
            // tscMarcas.ContentPanel
            // 
            tscMarcas.ContentPanel.Controls.Add(tlMarcas);
            tscMarcas.ContentPanel.Size = new Size(850, 426);
            tscMarcas.Dock = DockStyle.Fill;
            tscMarcas.Location = new Point(0, 0);
            tscMarcas.Name = "tscMarcas";
            tscMarcas.Size = new Size(850, 451);
            tscMarcas.TabIndex = 0;
            tscMarcas.Text = "toolStripContainer1";
            // 
            // tscMarcas.TopToolStripPanel
            // 
            tscMarcas.TopToolStripPanel.Controls.Add(tsMarcas);
            // 
            // tlMarcas
            // 
            tlMarcas.ColumnCount = 3;
            tlMarcas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlMarcas.ColumnStyles.Add(new ColumnStyle());
            tlMarcas.ColumnStyles.Add(new ColumnStyle());
            tlMarcas.Controls.Add(dgvMarcas, 0, 0);
            tlMarcas.Controls.Add(btnActualizar, 0, 1);
            tlMarcas.Controls.Add(btnEliminar, 1, 1);
            tlMarcas.Controls.Add(btnSalir, 2, 1);
            tlMarcas.Dock = DockStyle.Fill;
            tlMarcas.Location = new Point(0, 0);
            tlMarcas.Name = "tlMarcas";
            tlMarcas.RowCount = 2;
            tlMarcas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlMarcas.RowStyles.Add(new RowStyle());
            tlMarcas.Size = new Size(850, 426);
            tlMarcas.TabIndex = 0;
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToDeleteRows = false;
            dgvMarcas.AllowUserToResizeColumns = false;
            dgvMarcas.AllowUserToResizeRows = false;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.BackgroundColor = SystemColors.ControlDarkDark;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlMarcas.SetColumnSpan(dgvMarcas, 3);
            dgvMarcas.Dock = DockStyle.Fill;
            dgvMarcas.Location = new Point(3, 3);
            dgvMarcas.MultiSelect = false;
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(844, 391);
            dgvMarcas.TabIndex = 0;
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
            // tsMarcas
            // 
            tsMarcas.Dock = DockStyle.None;
            tsMarcas.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsMarcas.Location = new Point(3, 0);
            tsMarcas.Name = "tsMarcas";
            tsMarcas.Size = new Size(89, 25);
            tsMarcas.TabIndex = 0;
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
            // MarcaLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 451);
            Controls.Add(tscMarcas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MarcaLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista Marcas";
            Load += MarcaLista_Load;
            tscMarcas.ContentPanel.ResumeLayout(false);
            tscMarcas.TopToolStripPanel.ResumeLayout(false);
            tscMarcas.TopToolStripPanel.PerformLayout();
            tscMarcas.ResumeLayout(false);
            tscMarcas.PerformLayout();
            tlMarcas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            tsMarcas.ResumeLayout(false);
            tsMarcas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscMarcas;
        private ToolStrip tsMarcas;
        private TableLayoutPanel tlMarcas;
        private DataGridView dgvMarcas;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
    }
}
