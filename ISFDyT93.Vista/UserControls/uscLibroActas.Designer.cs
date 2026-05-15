namespace ISFDyT93.Vista.UserControls
{
    partial class uscLibroActas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.cmnuLibroActasGrilla = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarMenuContx = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.chkLibros = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.cmnuLibroActasGrilla.SuspendLayout();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLibros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1413, 2);
            this.panel1.TabIndex = 4;
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToDeleteRows = false;
            this.dgvLibros.AllowUserToResizeColumns = false;
            this.dgvLibros.AllowUserToResizeRows = false;
            this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.ContextMenuStrip = this.cmnuLibroActasGrilla;
            this.dgvLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibros.Location = new System.Drawing.Point(0, 0);
            this.dgvLibros.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.RowHeadersVisible = false;
            this.dgvLibros.RowHeadersWidth = 51;
            this.dgvLibros.Size = new System.Drawing.Size(1413, 2);
            this.dgvLibros.TabIndex = 6;
            // 
            // cmnuLibroActasGrilla
            // 
            this.cmnuLibroActasGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.cmnuLibroActasGrilla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuLibroActasGrilla.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnuLibroActasGrilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMenuContx});
            this.cmnuLibroActasGrilla.Name = "cmnuLibroActasGrilla";
            this.cmnuLibroActasGrilla.Size = new System.Drawing.Size(156, 36);
            this.cmnuLibroActasGrilla.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuLibroActasGrilla_Opening);
            // 
            // agregarMenuContx
            // 
            this.agregarMenuContx.Name = "agregarMenuContx";
            this.agregarMenuContx.Size = new System.Drawing.Size(155, 32);
            this.agregarMenuContx.Text = "Agregar";
            this.agregarMenuContx.Click += new System.EventHandler(this.agregarMenuContx_Click_1);
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkLibros);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1413, 58);
            this.panelCabecera.TabIndex = 5;
            // 
            // chkLibros
            // 
            this.chkLibros.AutoSize = true;
            this.chkLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLibros.ForeColor = System.Drawing.Color.White;
            this.chkLibros.Location = new System.Drawing.Point(17, 16);
            this.chkLibros.Margin = new System.Windows.Forms.Padding(4);
            this.chkLibros.Name = "chkLibros";
            this.chkLibros.Size = new System.Drawing.Size(173, 29);
            this.chkLibros.TabIndex = 0;
            this.chkLibros.Text = "Libro de Actas";
            this.chkLibros.UseVisualStyleBackColor = true;
            this.chkLibros.CheckedChanged += new System.EventHandler(this.chkLibros_CheckedChanged);
            // 
            // uscLibroActas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscLibroActas";
            this.Size = new System.Drawing.Size(1413, 60);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.cmnuLibroActasGrilla.ResumeLayout(false);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkLibros;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.ContextMenuStrip cmnuLibroActasGrilla;
        private System.Windows.Forms.ToolStripMenuItem agregarMenuContx;
    }
}
