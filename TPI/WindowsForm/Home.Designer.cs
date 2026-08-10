namespace WindowsForm
{
    partial class Home
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
            mnsPrincipal = new MenuStrip();
            mnuOpciones = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            productoToolStripMenuItem = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            //
            // mnsPrincipal
            //
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuOpciones, usuariosToolStripMenuItem, productoToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(1108, 24);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuOpciones
            // 
            mnuOpciones.DropDownItems.AddRange(new ToolStripItem[] { mnuSalir });
            mnuOpciones.Name = "mnuOpciones";
            mnuOpciones.Size = new Size(69, 20);
            mnuOpciones.Text = "Opciones";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(96, 22);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            //
            // usuariosToolStripMenuItem
            //
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(61, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            //
            // productoToolStripMenuItem
            //
            productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            productoToolStripMenuItem.Size = new Size(68, 20);
            productoToolStripMenuItem.Text = "Producto";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 600);
            Controls.Add(mnsPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            Name = "Home";
            Text = "Inicio";
            WindowState = FormWindowState.Maximized;
            Shown += Home_Shown;
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuOpciones;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem productoToolStripMenuItem;
    }
}