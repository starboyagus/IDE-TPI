namespace WindowsForm
{
    partial class ClienteLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteLista));
            tscClientes = new ToolStripContainer();
            tlClientes = new TableLayoutPanel();
            dgvClientes = new DataGridView();
            btnActualizar = new Button();
            btnSalir = new Button();
            tsClientes = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tscClientes.ContentPanel.SuspendLayout();
            tscClientes.TopToolStripPanel.SuspendLayout();
            tscClientes.SuspendLayout();
            tlClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            tsClientes.SuspendLayout();
            SuspendLayout();
            // 
            // tscClientes
            // 
            // 
            // tscClientes.ContentPanel
            // 
            tscClientes.ContentPanel.Controls.Add(tlClientes);
            tscClientes.ContentPanel.Size = new Size(800, 425);
            tscClientes.Dock = DockStyle.Fill;
            tscClientes.Location = new Point(0, 0);
            tscClientes.Name = "tscClientes";
            tscClientes.Size = new Size(800, 450);
            tscClientes.TabIndex = 0;
            tscClientes.Text = "toolStripContainer1";
            // 
            // tscClientes.TopToolStripPanel
            // 
            tscClientes.TopToolStripPanel.Controls.Add(tsClientes);
            // 
            // tlClientes
            // 
            tlClientes.ColumnCount = 2;
            tlClientes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlClientes.ColumnStyles.Add(new ColumnStyle());
            tlClientes.Controls.Add(dgvClientes, 0, 0);
            tlClientes.Controls.Add(btnActualizar, 0, 1);
            tlClientes.Controls.Add(btnSalir, 1, 1);
            tlClientes.Dock = DockStyle.Fill;
            tlClientes.Location = new Point(0, 0);
            tlClientes.Name = "tlClientes";
            tlClientes.RowCount = 2;
            tlClientes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlClientes.RowStyles.Add(new RowStyle());
            tlClientes.Size = new Size(800, 425);
            tlClientes.TabIndex = 0;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlClientes.SetColumnSpan(dgvClientes, 2);
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(3, 3);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(794, 390);
            dgvClientes.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(641, 399);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(722, 399);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // tsClientes
            // 
            tsClientes.Dock = DockStyle.None;
            tsClientes.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsClientes.Location = new Point(3, 0);
            tsClientes.Name = "tsClientes";
            tsClientes.Size = new Size(35, 25);
            tsClientes.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(23, 22);
            tsbNuevo.Text = "toolStripButton1";
            tsbNuevo.ToolTipText = "Nuevo";
            // 
            // ClienteLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tscClientes);
            Name = "ClienteLista";
            Text = "Lista Clientes";
            Load += ClienteLista_Load;
            tscClientes.ContentPanel.ResumeLayout(false);
            tscClientes.TopToolStripPanel.ResumeLayout(false);
            tscClientes.TopToolStripPanel.PerformLayout();
            tscClientes.ResumeLayout(false);
            tscClientes.PerformLayout();
            tlClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            tsClientes.ResumeLayout(false);
            tsClientes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscClientes;
        private TableLayoutPanel tlClientes;
        private DataGridView dgvClientes;
        private Button btnActualizar;
        private Button btnSalir;
        private ToolStrip tsClientes;
        private ToolStripButton tsbNuevo;
    }
}