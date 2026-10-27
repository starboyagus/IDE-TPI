namespace WindowsForm
{
    partial class InformeStockCritico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            nudUmbral = new NumericUpDown();
            label2 = new Label();
            cmbTipoFiltro = new ComboBox();
            btnGenerarPdf = new Button();
            btnSalir = new Button();
            btnVerInforme = new Button();
            lblFiltrosAplicados = new Label();
            tabInforme = new TabControl();
            tabProductos = new TabPage();
            dgvProductos = new DataGridView();
            tabResumen = new TabPage();
            splitContainerResumen = new SplitContainer();
            tlpResumen = new TableLayoutPanel();
            grpTotalAlertas = new GroupBox();
            lblTotalAlertas = new Label();
            grpSinStock = new GroupBox();
            lblSinStock = new Label();
            grpStockBajo = new GroupBox();
            lblStockBajo = new Label();
            grpPreVenta = new GroupBox();
            lblPreVenta = new Label();
            picPorCriticidad = new PictureBox();
            tabPorCategoria = new TabPage();
            splitContainerCat = new SplitContainer();
            picPorCategoria = new PictureBox();
            dgvPorCategoria = new DataGridView();
            tabPorMarca = new TabPage();
            splitContainerMarca = new SplitContainer();
            picPorMarca = new PictureBox();
            dgvPorMarca = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)nudUmbral).BeginInit();
            tabInforme.SuspendLayout();
            tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tabResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerResumen).BeginInit();
            splitContainerResumen.Panel1.SuspendLayout();
            splitContainerResumen.Panel2.SuspendLayout();
            splitContainerResumen.SuspendLayout();
            tlpResumen.SuspendLayout();
            grpTotalAlertas.SuspendLayout();
            grpSinStock.SuspendLayout();
            grpStockBajo.SuspendLayout();
            grpPreVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPorCriticidad).BeginInit();
            tabPorCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCat).BeginInit();
            splitContainerCat.Panel1.SuspendLayout();
            splitContainerCat.Panel2.SuspendLayout();
            splitContainerCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPorCategoria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorCategoria).BeginInit();
            tabPorMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMarca).BeginInit();
            splitContainerMarca.Panel1.SuspendLayout();
            splitContainerMarca.Panel2.SuspendLayout();
            splitContainerMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPorMarca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorMarca).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Umbral mínimo:";
            // 
            // nudUmbral
            // 
            nudUmbral.Location = new Point(110, 19);
            nudUmbral.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudUmbral.Name = "nudUmbral";
            nudUmbral.Size = new Size(90, 23);
            nudUmbral.TabIndex = 1;
            nudUmbral.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 23);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Filtro:";
            // 
            // cmbTipoFiltro
            // 
            cmbTipoFiltro.FormattingEnabled = true;
            cmbTipoFiltro.Location = new Point(265, 19);
            cmbTipoFiltro.Name = "cmbTipoFiltro";
            cmbTipoFiltro.Size = new Size(200, 23);
            cmbTipoFiltro.TabIndex = 3;
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.Location = new Point(924, 14);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(84, 37);
            btnGenerarPdf.TabIndex = 4;
            btnGenerarPdf.Text = "Generar PDF";
            btnGenerarPdf.UseVisualStyleBackColor = true;
            btnGenerarPdf.Click += btnGenerarPdf_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1014, 14);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(84, 37);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnVerInforme
            // 
            btnVerInforme.Location = new Point(1104, 14);
            btnVerInforme.Name = "btnVerInforme";
            btnVerInforme.Size = new Size(84, 37);
            btnVerInforme.TabIndex = 6;
            btnVerInforme.Text = "Ver Informe";
            btnVerInforme.UseVisualStyleBackColor = true;
            btnVerInforme.Click += btnVerInforme_Click;
            // 
            // lblFiltrosAplicados
            // 
            lblFiltrosAplicados.AutoSize = true;
            lblFiltrosAplicados.Location = new Point(16, 53);
            lblFiltrosAplicados.Name = "lblFiltrosAplicados";
            lblFiltrosAplicados.Size = new Size(0, 15);
            lblFiltrosAplicados.TabIndex = 7;
            // 
            // tabInforme
            // 
            tabInforme.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabInforme.Controls.Add(tabProductos);
            tabInforme.Controls.Add(tabResumen);
            tabInforme.Controls.Add(tabPorCategoria);
            tabInforme.Controls.Add(tabPorMarca);
            tabInforme.Location = new Point(16, 78);
            tabInforme.Name = "tabInforme";
            tabInforme.SelectedIndex = 0;
            tabInforme.Size = new Size(1172, 544);
            tabInforme.TabIndex = 8;
            // 
            // tabProductos
            // 
            tabProductos.Controls.Add(dgvProductos);
            tabProductos.Location = new Point(4, 24);
            tabProductos.Name = "tabProductos";
            tabProductos.Padding = new Padding(3);
            tabProductos.Size = new Size(1164, 516);
            tabProductos.TabIndex = 0;
            tabProductos.Text = "Productos en alerta";
            tabProductos.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(1158, 510);
            dgvProductos.TabIndex = 0;
            // 
            // tabResumen
            // 
            tabResumen.Controls.Add(splitContainerResumen);
            tabResumen.Location = new Point(4, 24);
            tabResumen.Name = "tabResumen";
            tabResumen.Padding = new Padding(3);
            tabResumen.Size = new Size(1164, 516);
            tabResumen.TabIndex = 1;
            tabResumen.Text = "Resumen de alertas";
            tabResumen.UseVisualStyleBackColor = true;
            // 
            // splitContainerResumen
            // 
            splitContainerResumen.Dock = DockStyle.Fill;
            splitContainerResumen.Location = new Point(3, 3);
            splitContainerResumen.Name = "splitContainerResumen";
            splitContainerResumen.Orientation = Orientation.Horizontal;
            // 
            // splitContainerResumen.Panel1
            // 
            splitContainerResumen.Panel1.Controls.Add(tlpResumen);
            // 
            // splitContainerResumen.Panel2
            // 
            splitContainerResumen.Panel2.Controls.Add(picPorCriticidad);
            splitContainerResumen.Size = new Size(1158, 510);
            splitContainerResumen.SplitterDistance = 125;
            splitContainerResumen.TabIndex = 1;
            // 
            // tlpResumen
            // 
            tlpResumen.ColumnCount = 4;
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.Controls.Add(grpTotalAlertas, 0, 0);
            tlpResumen.Controls.Add(grpSinStock, 1, 0);
            tlpResumen.Controls.Add(grpStockBajo, 2, 0);
            tlpResumen.Controls.Add(grpPreVenta, 3, 0);
            tlpResumen.Dock = DockStyle.Fill;
            tlpResumen.Location = new Point(0, 0);
            tlpResumen.Name = "tlpResumen";
            tlpResumen.RowCount = 1;
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumen.Size = new Size(1158, 125);
            tlpResumen.TabIndex = 0;
            // 
            // grpTotalAlertas
            // 
            grpTotalAlertas.Controls.Add(lblTotalAlertas);
            grpTotalAlertas.Dock = DockStyle.Fill;
            grpTotalAlertas.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpTotalAlertas.Location = new Point(3, 3);
            grpTotalAlertas.Name = "grpTotalAlertas";
            grpTotalAlertas.Size = new Size(283, 119);
            grpTotalAlertas.TabIndex = 0;
            grpTotalAlertas.TabStop = false;
            grpTotalAlertas.Text = "Total en alerta";
            // 
            // lblTotalAlertas
            // 
            lblTotalAlertas.Dock = DockStyle.Fill;
            lblTotalAlertas.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAlertas.ForeColor = Color.DarkSlateBlue;
            lblTotalAlertas.Location = new Point(3, 21);
            lblTotalAlertas.Name = "lblTotalAlertas";
            lblTotalAlertas.Size = new Size(277, 95);
            lblTotalAlertas.TabIndex = 0;
            lblTotalAlertas.Text = "-";
            lblTotalAlertas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpSinStock
            // 
            grpSinStock.Controls.Add(lblSinStock);
            grpSinStock.Dock = DockStyle.Fill;
            grpSinStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpSinStock.Location = new Point(292, 3);
            grpSinStock.Name = "grpSinStock";
            grpSinStock.Size = new Size(283, 119);
            grpSinStock.TabIndex = 1;
            grpSinStock.TabStop = false;
            grpSinStock.Text = "Sin Stock (0)";
            // 
            // lblSinStock
            // 
            lblSinStock.Dock = DockStyle.Fill;
            lblSinStock.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSinStock.ForeColor = Color.Crimson;
            lblSinStock.Location = new Point(3, 21);
            lblSinStock.Name = "lblSinStock";
            lblSinStock.Size = new Size(277, 95);
            lblSinStock.TabIndex = 0;
            lblSinStock.Text = "-";
            lblSinStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpStockBajo
            // 
            grpStockBajo.Controls.Add(lblStockBajo);
            grpStockBajo.Dock = DockStyle.Fill;
            grpStockBajo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpStockBajo.Location = new Point(581, 3);
            grpStockBajo.Name = "grpStockBajo";
            grpStockBajo.Size = new Size(283, 119);
            grpStockBajo.TabIndex = 2;
            grpStockBajo.TabStop = false;
            grpStockBajo.Text = "Stock Crítico";
            // 
            // lblStockBajo
            // 
            lblStockBajo.Dock = DockStyle.Fill;
            lblStockBajo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockBajo.ForeColor = Color.DarkOrange;
            lblStockBajo.Location = new Point(3, 21);
            lblStockBajo.Name = "lblStockBajo";
            lblStockBajo.Size = new Size(277, 95);
            lblStockBajo.TabIndex = 0;
            lblStockBajo.Text = "-";
            lblStockBajo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpPreVenta
            // 
            grpPreVenta.Controls.Add(lblPreVenta);
            grpPreVenta.Dock = DockStyle.Fill;
            grpPreVenta.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpPreVenta.Location = new Point(870, 3);
            grpPreVenta.Name = "grpPreVenta";
            grpPreVenta.Size = new Size(285, 119);
            grpPreVenta.TabIndex = 3;
            grpPreVenta.TabStop = false;
            grpPreVenta.Text = "En Pre-Venta";
            // 
            // lblPreVenta
            // 
            lblPreVenta.Dock = DockStyle.Fill;
            lblPreVenta.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPreVenta.ForeColor = Color.SteelBlue;
            lblPreVenta.Location = new Point(3, 21);
            lblPreVenta.Name = "lblPreVenta";
            lblPreVenta.Size = new Size(279, 95);
            lblPreVenta.TabIndex = 0;
            lblPreVenta.Text = "-";
            lblPreVenta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picPorCriticidad
            // 
            picPorCriticidad.BackColor = Color.White;
            picPorCriticidad.Dock = DockStyle.Fill;
            picPorCriticidad.Location = new Point(0, 0);
            picPorCriticidad.Name = "picPorCriticidad";
            picPorCriticidad.Size = new Size(1158, 381);
            picPorCriticidad.SizeMode = PictureBoxSizeMode.Zoom;
            picPorCriticidad.TabIndex = 0;
            picPorCriticidad.TabStop = false;
            // 
            // tabPorCategoria
            // 
            tabPorCategoria.Controls.Add(splitContainerCat);
            tabPorCategoria.Location = new Point(4, 24);
            tabPorCategoria.Name = "tabPorCategoria";
            tabPorCategoria.Padding = new Padding(3);
            tabPorCategoria.Size = new Size(1164, 516);
            tabPorCategoria.TabIndex = 2;
            tabPorCategoria.Text = "Por categoría";
            tabPorCategoria.UseVisualStyleBackColor = true;
            // 
            // splitContainerCat
            // 
            splitContainerCat.Dock = DockStyle.Fill;
            splitContainerCat.Location = new Point(3, 3);
            splitContainerCat.Name = "splitContainerCat";
            splitContainerCat.Orientation = Orientation.Horizontal;
            // 
            // splitContainerCat.Panel1
            // 
            splitContainerCat.Panel1.Controls.Add(picPorCategoria);
            // 
            // splitContainerCat.Panel2
            // 
            splitContainerCat.Panel2.Controls.Add(dgvPorCategoria);
            splitContainerCat.Size = new Size(1158, 510);
            splitContainerCat.SplitterDistance = 259;
            splitContainerCat.TabIndex = 0;
            // 
            // picPorCategoria
            // 
            picPorCategoria.BackColor = Color.White;
            picPorCategoria.Dock = DockStyle.Fill;
            picPorCategoria.Location = new Point(0, 0);
            picPorCategoria.Name = "picPorCategoria";
            picPorCategoria.Size = new Size(1158, 259);
            picPorCategoria.SizeMode = PictureBoxSizeMode.Zoom;
            picPorCategoria.TabIndex = 0;
            picPorCategoria.TabStop = false;
            // 
            // dgvPorCategoria
            // 
            dgvPorCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPorCategoria.Dock = DockStyle.Fill;
            dgvPorCategoria.Location = new Point(0, 0);
            dgvPorCategoria.Name = "dgvPorCategoria";
            dgvPorCategoria.Size = new Size(1158, 247);
            dgvPorCategoria.TabIndex = 0;
            // 
            // tabPorMarca
            // 
            tabPorMarca.Controls.Add(splitContainerMarca);
            tabPorMarca.Location = new Point(4, 24);
            tabPorMarca.Name = "tabPorMarca";
            tabPorMarca.Padding = new Padding(3);
            tabPorMarca.Size = new Size(1164, 516);
            tabPorMarca.TabIndex = 3;
            tabPorMarca.Text = "Por marca";
            tabPorMarca.UseVisualStyleBackColor = true;
            // 
            // splitContainerMarca
            // 
            splitContainerMarca.Dock = DockStyle.Fill;
            splitContainerMarca.Location = new Point(3, 3);
            splitContainerMarca.Name = "splitContainerMarca";
            splitContainerMarca.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMarca.Panel1
            // 
            splitContainerMarca.Panel1.Controls.Add(picPorMarca);
            // 
            // splitContainerMarca.Panel2
            // 
            splitContainerMarca.Panel2.Controls.Add(dgvPorMarca);
            splitContainerMarca.Size = new Size(1158, 510);
            splitContainerMarca.SplitterDistance = 259;
            splitContainerMarca.TabIndex = 0;
            // 
            // picPorMarca
            // 
            picPorMarca.BackColor = Color.White;
            picPorMarca.Dock = DockStyle.Fill;
            picPorMarca.Location = new Point(0, 0);
            picPorMarca.Name = "picPorMarca";
            picPorMarca.Size = new Size(1158, 259);
            picPorMarca.SizeMode = PictureBoxSizeMode.Zoom;
            picPorMarca.TabIndex = 0;
            picPorMarca.TabStop = false;
            // 
            // dgvPorMarca
            // 
            dgvPorMarca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPorMarca.Dock = DockStyle.Fill;
            dgvPorMarca.Location = new Point(0, 0);
            dgvPorMarca.Name = "dgvPorMarca";
            dgvPorMarca.Size = new Size(1158, 247);
            dgvPorMarca.TabIndex = 0;
            // 
            // InformeStockCritico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 634);
            Controls.Add(tabInforme);
            Controls.Add(lblFiltrosAplicados);
            Controls.Add(btnVerInforme);
            Controls.Add(btnSalir);
            Controls.Add(btnGenerarPdf);
            Controls.Add(cmbTipoFiltro);
            Controls.Add(label2);
            Controls.Add(nudUmbral);
            Controls.Add(label1);
            Name = "InformeStockCritico";
            Text = "Stock Crítico y Alerta de Reposición";
            ((System.ComponentModel.ISupportInitialize)nudUmbral).EndInit();
            tabInforme.ResumeLayout(false);
            tabProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerResumen).EndInit();
            splitContainerResumen.Panel1.ResumeLayout(false);
            splitContainerResumen.Panel2.ResumeLayout(false);
            splitContainerResumen.ResumeLayout(false);
            tlpResumen.ResumeLayout(false);
            grpTotalAlertas.ResumeLayout(false);
            grpSinStock.ResumeLayout(false);
            grpStockBajo.ResumeLayout(false);
            grpPreVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPorCriticidad).EndInit();
            tabPorCategoria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCat).EndInit();
            splitContainerCat.Panel1.ResumeLayout(false);
            splitContainerCat.Panel2.ResumeLayout(false);
            splitContainerCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPorCategoria).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorCategoria).EndInit();
            tabPorMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMarca).EndInit();
            splitContainerMarca.Panel1.ResumeLayout(false);
            splitContainerMarca.Panel2.ResumeLayout(false);
            splitContainerMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPorMarca).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPorMarca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nudUmbral;
        private Label label2;
        private ComboBox cmbTipoFiltro;
        private Button btnGenerarPdf;
        private Button btnSalir;
        private Button btnVerInforme;
        private Label lblFiltrosAplicados;
        private TabControl tabInforme;
        private TabPage tabProductos;
        private DataGridView dgvProductos;
        private TabPage tabResumen;
        private SplitContainer splitContainerResumen;
        private TableLayoutPanel tlpResumen;
        private GroupBox grpTotalAlertas;
        private Label lblTotalAlertas;
        private GroupBox grpSinStock;
        private Label lblSinStock;
        private GroupBox grpStockBajo;
        private Label lblStockBajo;
        private GroupBox grpPreVenta;
        private Label lblPreVenta;
        private PictureBox picPorCriticidad;
        private TabPage tabPorCategoria;
        private SplitContainer splitContainerCat;
        private PictureBox picPorCategoria;
        private DataGridView dgvPorCategoria;
        private TabPage tabPorMarca;
        private SplitContainer splitContainerMarca;
        private PictureBox picPorMarca;
        private DataGridView dgvPorMarca;
    }
}
