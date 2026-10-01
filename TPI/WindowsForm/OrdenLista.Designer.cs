namespace WindowsForm
{
    partial class OrdenLista
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
            tscOrdenes = new ToolStripContainer();
            tlOrdenes = new TableLayoutPanel();
            dgvOrdenes = new DataGridView();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            tsOrdenes = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tscOrdenes.ContentPanel.SuspendLayout();
            tscOrdenes.TopToolStripPanel.SuspendLayout();
            tscOrdenes.SuspendLayout();
            tlOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            tsOrdenes.SuspendLayout();
            SuspendLayout();
            // 
            // tscOrdenes
            // 
            // 
            // tscOrdenes.ContentPanel
            // 
            tscOrdenes.ContentPanel.Controls.Add(tlOrdenes);
            tscOrdenes.ContentPanel.Size = new Size(850, 426);
            tscOrdenes.Dock = DockStyle.Fill;
            tscOrdenes.Location = new Point(0, 0);
            tscOrdenes.Name = "tscOrdenes";
            tscOrdenes.Size = new Size(850, 451);
            tscOrdenes.TabIndex = 0;
            tscOrdenes.Text = "toolStripContainer1";
            // 
            // tscOrdenes.TopToolStripPanel
            // 
            tscOrdenes.TopToolStripPanel.Controls.Add(tsOrdenes);
            // 
            // tlOrdenes
            // 
            tlOrdenes.ColumnCount = 3;
            tlOrdenes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlOrdenes.ColumnStyles.Add(new ColumnStyle());
            tlOrdenes.ColumnStyles.Add(new ColumnStyle());
            tlOrdenes.Controls.Add(dgvOrdenes, 0, 0);
            tlOrdenes.Controls.Add(btnActualizar, 0, 1);
            tlOrdenes.Controls.Add(btnEliminar, 1, 1);
            tlOrdenes.Controls.Add(btnSalir, 2, 1);
            tlOrdenes.Dock = DockStyle.Fill;
            tlOrdenes.Location = new Point(0, 0);
            tlOrdenes.Name = "tlOrdenes";
            tlOrdenes.RowCount = 2;
            tlOrdenes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlOrdenes.RowStyles.Add(new RowStyle());
            tlOrdenes.Size = new Size(850, 426);
            tlOrdenes.TabIndex = 0;
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.AllowUserToResizeColumns = false;
            dgvOrdenes.AllowUserToResizeRows = false;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.BackgroundColor = SystemColors.ControlDarkDark;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlOrdenes.SetColumnSpan(dgvOrdenes, 3);
            dgvOrdenes.Dock = DockStyle.Fill;
            dgvOrdenes.Location = new Point(3, 3);
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new Size(844, 391);
            dgvOrdenes.TabIndex = 0;
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
            // tsOrdenes
            // 
            tsOrdenes.Dock = DockStyle.None;
            tsOrdenes.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsOrdenes.Location = new Point(3, 0);
            tsOrdenes.Name = "tsOrdenes";
            tsOrdenes.Size = new Size(58, 25);
            tsOrdenes.TabIndex = 0;
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
            // OrdenLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 451);
            Controls.Add(tscOrdenes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrdenLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista Órdenes";
            Load += OrdenLista_Load;
            tscOrdenes.ContentPanel.ResumeLayout(false);
            tscOrdenes.TopToolStripPanel.ResumeLayout(false);
            tscOrdenes.TopToolStripPanel.PerformLayout();
            tscOrdenes.ResumeLayout(false);
            tscOrdenes.PerformLayout();
            tlOrdenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            tsOrdenes.ResumeLayout(false);
            tsOrdenes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscOrdenes;
        private ToolStrip tsOrdenes;
        private TableLayoutPanel tlOrdenes;
        private DataGridView dgvOrdenes;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
    }
}
