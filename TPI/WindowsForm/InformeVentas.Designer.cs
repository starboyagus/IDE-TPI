namespace WindowsForm
{
    partial class InformeVentas
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
            Label label2;
            label1 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            label3 = new Label();
            cmbEstado = new ComboBox();
            label4 = new Label();
            nudTop = new NumericUpDown();
            btnGenerarPdf = new Button();
            btnSalir = new Button();
            btnVerInforme = new Button();
            lblFiltrosAplicados = new Label();
            tabInforme = new TabControl();
            tabResumen = new TabPage();
            tabPorMes = new TabPage();
            tabTopProductos = new TabPage();
            tabPorMarca = new TabPage();
            tlpResumen = new TableLayoutPanel();
            grpCantidadOrdenes = new GroupBox();
            lblCantidadOrdenes = new Label();
            grpTotalFacturado = new GroupBox();
            lblTotalFacturado = new Label();
            grpTicketPromedio = new GroupBox();
            lblTicketPromedio = new Label();
            splitContainer1 = new SplitContainer();
            picVentasPorMes = new PictureBox();
            dgvVentasPorMes = new DataGridView();
            splitContainer2 = new SplitContainer();
            picTopProductos = new PictureBox();
            dgvTopProductos = new DataGridView();
            splitContainer3 = new SplitContainer();
            dgvPorMarca = new DataGridView();
            picPorMarca = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTop).BeginInit();
            tabInforme.SuspendLayout();
            tabResumen.SuspendLayout();
            tlpResumen.SuspendLayout();
            grpCantidadOrdenes.SuspendLayout();
            grpTotalFacturado.SuspendLayout();
            grpTicketPromedio.SuspendLayout();
            tabPorMes.SuspendLayout();
            tabTopProductos.SuspendLayout();
            tabPorMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVentasPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTopProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPorMarca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPorMarca).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 25);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Hasta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(60, 19);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(312, 19);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 25);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(569, 19);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(696, 25);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 6;
            label4.Text = "Top productos:";
            // 
            // nudTop
            // 
            nudTop.Location = new Point(789, 19);
            nudTop.Name = "nudTop";
            nudTop.Size = new Size(120, 23);
            nudTop.TabIndex = 7;
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.Location = new Point(924, 14);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(84, 37);
            btnGenerarPdf.TabIndex = 8;
            btnGenerarPdf.Text = "Generar PDF";
            btnGenerarPdf.UseVisualStyleBackColor = true;
            btnGenerarPdf.Click += btnGenerarPdf_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1014, 14);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(84, 37);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnVerInforme
            // 
            btnVerInforme.Location = new Point(1104, 14);
            btnVerInforme.Name = "btnVerInforme";
            btnVerInforme.Size = new Size(84, 37);
            btnVerInforme.TabIndex = 10;
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
            lblFiltrosAplicados.TabIndex = 11;
            // 
            // tabInforme
            // 
            tabInforme.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabInforme.Controls.Add(tabResumen);
            tabInforme.Controls.Add(tabPorMes);
            tabInforme.Controls.Add(tabTopProductos);
            tabInforme.Controls.Add(tabPorMarca);
            tabInforme.Location = new Point(16, 78);
            tabInforme.Name = "tabInforme";
            tabInforme.SelectedIndex = 0;
            tabInforme.Size = new Size(1172, 544);
            tabInforme.TabIndex = 12;
            // 
            // tabResumen
            // 
            tabResumen.Controls.Add(tlpResumen);
            tabResumen.Location = new Point(4, 24);
            tabResumen.Name = "tabResumen";
            tabResumen.Padding = new Padding(3);
            tabResumen.Size = new Size(1164, 516);
            tabResumen.TabIndex = 0;
            tabResumen.Text = "Resumen";
            tabResumen.UseVisualStyleBackColor = true;
            // 
            // tabPorMes
            // 
            tabPorMes.Controls.Add(splitContainer1);
            tabPorMes.Location = new Point(4, 24);
            tabPorMes.Name = "tabPorMes";
            tabPorMes.Padding = new Padding(3);
            tabPorMes.Size = new Size(1164, 516);
            tabPorMes.TabIndex = 1;
            tabPorMes.Text = "Por mes";
            tabPorMes.UseVisualStyleBackColor = true;
            // 
            // tabTopProductos
            // 
            tabTopProductos.Controls.Add(splitContainer2);
            tabTopProductos.Location = new Point(4, 24);
            tabTopProductos.Name = "tabTopProductos";
            tabTopProductos.Padding = new Padding(3);
            tabTopProductos.Size = new Size(1164, 516);
            tabTopProductos.TabIndex = 2;
            tabTopProductos.Text = "Top productos";
            tabTopProductos.UseVisualStyleBackColor = true;
            // 
            // tabPorMarca
            // 
            tabPorMarca.Controls.Add(splitContainer3);
            tabPorMarca.Location = new Point(4, 24);
            tabPorMarca.Name = "tabPorMarca";
            tabPorMarca.Padding = new Padding(3);
            tabPorMarca.Size = new Size(1164, 516);
            tabPorMarca.TabIndex = 3;
            tabPorMarca.Text = "Por marca";
            tabPorMarca.UseVisualStyleBackColor = true;
            //
            // tlpResumen
            //
            tlpResumen.ColumnCount = 3;
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpResumen.Controls.Add(grpCantidadOrdenes, 0, 0);
            tlpResumen.Controls.Add(grpTotalFacturado, 1, 0);
            tlpResumen.Controls.Add(grpTicketPromedio, 2, 0);
            tlpResumen.Dock = DockStyle.Top;
            tlpResumen.Location = new Point(3, 3);
            tlpResumen.Name = "tlpResumen";
            tlpResumen.RowCount = 1;
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumen.Size = new Size(1158, 120);
            tlpResumen.TabIndex = 0;
            //
            // grpCantidadOrdenes
            //
            grpCantidadOrdenes.Controls.Add(lblCantidadOrdenes);
            grpCantidadOrdenes.Dock = DockStyle.Fill;
            grpCantidadOrdenes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpCantidadOrdenes.Location = new Point(3, 3);
            grpCantidadOrdenes.Name = "grpCantidadOrdenes";
            grpCantidadOrdenes.Size = new Size(380, 114);
            grpCantidadOrdenes.TabIndex = 0;
            grpCantidadOrdenes.TabStop = false;
            grpCantidadOrdenes.Text = "Órdenes";
            //
            // lblCantidadOrdenes
            //
            lblCantidadOrdenes.Dock = DockStyle.Fill;
            lblCantidadOrdenes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadOrdenes.Location = new Point(3, 21);
            lblCantidadOrdenes.Name = "lblCantidadOrdenes";
            lblCantidadOrdenes.Size = new Size(374, 90);
            lblCantidadOrdenes.TabIndex = 0;
            lblCantidadOrdenes.Text = "-";
            lblCantidadOrdenes.TextAlign = ContentAlignment.MiddleCenter;
            //
            // grpTotalFacturado
            //
            grpTotalFacturado.Controls.Add(lblTotalFacturado);
            grpTotalFacturado.Dock = DockStyle.Fill;
            grpTotalFacturado.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpTotalFacturado.Location = new Point(389, 3);
            grpTotalFacturado.Name = "grpTotalFacturado";
            grpTotalFacturado.Size = new Size(380, 114);
            grpTotalFacturado.TabIndex = 1;
            grpTotalFacturado.TabStop = false;
            grpTotalFacturado.Text = "Total facturado";
            //
            // lblTotalFacturado
            //
            lblTotalFacturado.Dock = DockStyle.Fill;
            lblTotalFacturado.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFacturado.Location = new Point(3, 21);
            lblTotalFacturado.Name = "lblTotalFacturado";
            lblTotalFacturado.Size = new Size(374, 90);
            lblTotalFacturado.TabIndex = 0;
            lblTotalFacturado.Text = "-";
            lblTotalFacturado.TextAlign = ContentAlignment.MiddleCenter;
            //
            // grpTicketPromedio
            //
            grpTicketPromedio.Controls.Add(lblTicketPromedio);
            grpTicketPromedio.Dock = DockStyle.Fill;
            grpTicketPromedio.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpTicketPromedio.Location = new Point(775, 3);
            grpTicketPromedio.Name = "grpTicketPromedio";
            grpTicketPromedio.Size = new Size(380, 114);
            grpTicketPromedio.TabIndex = 2;
            grpTicketPromedio.TabStop = false;
            grpTicketPromedio.Text = "Ticket promedio";
            //
            // lblTicketPromedio
            //
            lblTicketPromedio.Dock = DockStyle.Fill;
            lblTicketPromedio.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTicketPromedio.Location = new Point(3, 21);
            lblTicketPromedio.Name = "lblTicketPromedio";
            lblTicketPromedio.Size = new Size(374, 90);
            lblTicketPromedio.TabIndex = 0;
            lblTicketPromedio.Text = "-";
            lblTicketPromedio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(picVentasPorMes);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvVentasPorMes);
            splitContainer1.Size = new Size(1158, 510);
            splitContainer1.SplitterDistance = 259;
            splitContainer1.TabIndex = 0;
            // 
            // picVentasPorMes
            // 
            picVentasPorMes.BackColor = Color.White;
            picVentasPorMes.Dock = DockStyle.Fill;
            picVentasPorMes.Location = new Point(0, 0);
            picVentasPorMes.Name = "picVentasPorMes";
            picVentasPorMes.Size = new Size(1158, 259);
            picVentasPorMes.SizeMode = PictureBoxSizeMode.Zoom;
            picVentasPorMes.TabIndex = 0;
            picVentasPorMes.TabStop = false;
            // 
            // dgvVentasPorMes
            // 
            dgvVentasPorMes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasPorMes.Dock = DockStyle.Fill;
            dgvVentasPorMes.Location = new Point(0, 0);
            dgvVentasPorMes.Name = "dgvVentasPorMes";
            dgvVentasPorMes.Size = new Size(1158, 247);
            dgvVentasPorMes.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(picTopProductos);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvTopProductos);
            splitContainer2.Size = new Size(1158, 510);
            splitContainer2.SplitterDistance = 257;
            splitContainer2.TabIndex = 0;
            // 
            // picTopProductos
            // 
            picTopProductos.BackColor = Color.White;
            picTopProductos.Dock = DockStyle.Fill;
            picTopProductos.Location = new Point(0, 0);
            picTopProductos.Name = "picTopProductos";
            picTopProductos.Size = new Size(1158, 257);
            picTopProductos.SizeMode = PictureBoxSizeMode.Zoom;
            picTopProductos.TabIndex = 0;
            picTopProductos.TabStop = false;
            // 
            // dgvTopProductos
            // 
            dgvTopProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopProductos.Dock = DockStyle.Fill;
            dgvTopProductos.Location = new Point(0, 0);
            dgvTopProductos.Name = "dgvTopProductos";
            dgvTopProductos.Size = new Size(1158, 249);
            dgvTopProductos.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 3);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(picPorMarca);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(dgvPorMarca);
            splitContainer3.Size = new Size(1158, 510);
            splitContainer3.SplitterDistance = 236;
            splitContainer3.TabIndex = 0;
            // 
            // dgvPorMarca
            // 
            dgvPorMarca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPorMarca.Dock = DockStyle.Fill;
            dgvPorMarca.Location = new Point(0, 0);
            dgvPorMarca.Name = "dgvPorMarca";
            dgvPorMarca.Size = new Size(1158, 270);
            dgvPorMarca.TabIndex = 0;
            // 
            // picPorMarca
            // 
            picPorMarca.BackColor = Color.White;
            picPorMarca.Dock = DockStyle.Fill;
            picPorMarca.Location = new Point(0, 0);
            picPorMarca.Name = "picPorMarca";
            picPorMarca.Size = new Size(1158, 236);
            picPorMarca.SizeMode = PictureBoxSizeMode.Zoom;
            picPorMarca.TabIndex = 0;
            picPorMarca.TabStop = false;
            // 
            // InformeVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 661);
            Controls.Add(tabInforme);
            Controls.Add(lblFiltrosAplicados);
            Controls.Add(btnVerInforme);
            Controls.Add(btnSalir);
            Controls.Add(btnGenerarPdf);
            Controls.Add(nudTop);
            Controls.Add(label4);
            Controls.Add(cmbEstado);
            Controls.Add(label3);
            Controls.Add(dtpHasta);
            Controls.Add(label2);
            Controls.Add(dtpDesde);
            Controls.Add(label1);
            Name = "InformeVentas";
            Text = "Informe";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)nudTop).EndInit();
            tabInforme.ResumeLayout(false);
            tabResumen.ResumeLayout(false);
            tlpResumen.ResumeLayout(false);
            grpCantidadOrdenes.ResumeLayout(false);
            grpTotalFacturado.ResumeLayout(false);
            grpTicketPromedio.ResumeLayout(false);
            tabPorMes.ResumeLayout(false);
            tabTopProductos.ResumeLayout(false);
            tabPorMarca.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVentasPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasPorMes).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTopProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopProductos).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPorMarca).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPorMarca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label label3;
        private ComboBox cmbEstado;
        private Label label4;
        private NumericUpDown nudTop;
        private Button btnGenerarPdf;
        private Button btnSalir;
        private Button btnVerInforme;
        private Label lblFiltrosAplicados;
        private TabControl tabInforme;
        private TabPage tabResumen;
        private TabPage tabPorMes;
        private TabPage tabTopProductos;
        private TabPage tabPorMarca;
        private TableLayoutPanel tlpResumen;
        private GroupBox grpCantidadOrdenes;
        private Label lblCantidadOrdenes;
        private GroupBox grpTotalFacturado;
        private Label lblTotalFacturado;
        private GroupBox grpTicketPromedio;
        private Label lblTicketPromedio;
        private SplitContainer splitContainer1;
        private PictureBox picVentasPorMes;
        private DataGridView dgvVentasPorMes;
        private SplitContainer splitContainer2;
        private PictureBox picTopProductos;
        private DataGridView dgvTopProductos;
        private SplitContainer splitContainer3;
        private PictureBox picPorMarca;
        private DataGridView dgvPorMarca;
    }
}