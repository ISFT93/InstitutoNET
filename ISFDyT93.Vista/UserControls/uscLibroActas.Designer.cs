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
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.chkLibros = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCabecera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkLibros);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1283, 50);
            this.panelCabecera.TabIndex = 2;
            this.panelCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCabecera_Paint);
            // 
            // chkLibros
            // 
            this.chkLibros.AutoSize = true;
            this.chkLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLibros.ForeColor = System.Drawing.Color.White;
            this.chkLibros.Location = new System.Drawing.Point(13, 13);
            this.chkLibros.Name = "chkLibros";
            this.chkLibros.Size = new System.Drawing.Size(144, 24);
            this.chkLibros.TabIndex = 0;
            this.chkLibros.Text = "Libro de Actas";
            this.chkLibros.UseVisualStyleBackColor = true;
            this.chkLibros.CheckedChanged += new System.EventHandler(this.chkCargos_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpContenedor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 592);
            this.panel1.TabIndex = 3;
            // 
            // flpContenedor
            // 
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.BackColor = System.Drawing.Color.White;
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 0);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1283, 592);
            this.flpContenedor.TabIndex = 2;
            // 
            // uscLibroActas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscLibroActas";
            this.Size = new System.Drawing.Size(1283, 642);
            this.Load += new System.EventHandler(this.uscLibroActas_Load);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkLibros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
    }
}
