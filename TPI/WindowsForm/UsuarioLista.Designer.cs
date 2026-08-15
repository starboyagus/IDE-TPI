namespace WindowsForm
{
    partial class UsuarioLista
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
            tscUsuarios = new ToolStripContainer();
            tlUsuarios = new TableLayoutPanel();
            dgvUsuarios = new DataGridView();
            btnActualizar = new Button();
            btnSalir = new Button();
            tsUsuarios = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            btnEliminar = new Button();
            tscUsuarios.ContentPanel.SuspendLayout();
            tscUsuarios.TopToolStripPanel.SuspendLayout();
            tscUsuarios.SuspendLayout();
            tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tsUsuarios.SuspendLayout();
            SuspendLayout();
            // 
            // tscUsuarios
            // 
            // 
            // tscUsuarios.ContentPanel
            // 
            tscUsuarios.ContentPanel.Controls.Add(tlUsuarios);
            tscUsuarios.ContentPanel.Size = new Size(800, 425);
            tscUsuarios.Dock = DockStyle.Fill;
            tscUsuarios.Location = new Point(0, 0);
            tscUsuarios.Name = "tscUsuarios";
            tscUsuarios.Size = new Size(800, 450);
            tscUsuarios.TabIndex = 0;
            tscUsuarios.Text = "toolStripContainer1";
            // 
            // tscUsuarios.TopToolStripPanel
            // 
            tscUsuarios.TopToolStripPanel.Controls.Add(tsUsuarios);
            // 
            // tlUsuarios
            // 
            tlUsuarios.ColumnCount = 3;
            tlUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.Controls.Add(dgvUsuarios, 0, 0);
            tlUsuarios.Controls.Add(btnSalir, 1, 1);
            tlUsuarios.Controls.Add(btnActualizar, 0, 1);
            tlUsuarios.Controls.Add(btnEliminar, 2, 0);
            tlUsuarios.Dock = DockStyle.Fill;
            tlUsuarios.Location = new Point(0, 0);
            tlUsuarios.Name = "tlUsuarios";
            tlUsuarios.RowCount = 2;
            tlUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlUsuarios.RowStyles.Add(new RowStyle());
            tlUsuarios.Size = new Size(800, 425);
            tlUsuarios.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlUsuarios.SetColumnSpan(dgvUsuarios, 3);
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(3, 3);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(794, 390);
            dgvUsuarios.TabIndex = 0;
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
            // tsUsuarios
            // 
            tsUsuarios.Dock = DockStyle.None;
            tsUsuarios.Items.AddRange(new ToolStripItem[] { tsbNuevo });
            tsUsuarios.Location = new Point(3, 0);
            tsUsuarios.Name = "tsUsuarios";
            tsUsuarios.Size = new Size(35, 25);
            tsUsuarios.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(23, 22);
            tsbNuevo.Text = "toolStripButton1";
            tsbNuevo.ToolTipText = "Nuevo";
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(3, 399);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // UsuarioLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tscUsuarios);
            Name = "UsuarioLista";
            Text = "Lista Usuarios";
            Load += UsuarioLista_Load;
            tscUsuarios.ContentPanel.ResumeLayout(false);
            tscUsuarios.TopToolStripPanel.ResumeLayout(false);
            tscUsuarios.TopToolStripPanel.PerformLayout();
            tscUsuarios.ResumeLayout(false);
            tscUsuarios.PerformLayout();
            tlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tsUsuarios.ResumeLayout(false);
            tsUsuarios.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer tscUsuarios;
        private TableLayoutPanel tlUsuarios;
        private DataGridView dgvUsuarios;
        private Button btnActualizar;
        private Button btnSalir;
        private ToolStrip tsUsuarios;
        private ToolStripButton tsbNuevo;
        private Button btnEliminar;
    }
}
