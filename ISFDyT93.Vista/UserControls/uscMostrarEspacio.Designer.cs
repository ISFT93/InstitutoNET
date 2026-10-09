namespace ISFDyT93.Vista.UserControls
{
    partial class uscMostrarEspacio
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
            this.chkEspacios = new System.Windows.Forms.CheckBox();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkEspacios);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1284, 50);
            this.panelCabecera.TabIndex = 1;
            this.panelCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCabecera_Paint);
            // 
            // chkEspacios
            // 
            this.chkEspacios.AutoSize = true;
            this.chkEspacios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEspacios.ForeColor = System.Drawing.Color.White;
            this.chkEspacios.Location = new System.Drawing.Point(13, 13);
            this.chkEspacios.Name = "chkEspacios";
            this.chkEspacios.Size = new System.Drawing.Size(199, 24);
            this.chkEspacios.TabIndex = 0;
            this.chkEspacios.Text = "Espacios Disponibles";
            this.chkEspacios.UseVisualStyleBackColor = true;
            this.chkEspacios.CheckedChanged += new System.EventHandler(this.chkEspacios_CheckedChanged);
            // 
            // flpContenedor
            // 
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 50);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1284, 310);
            this.flpContenedor.TabIndex = 2;
            this.flpContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.flpContenedor_Paint);
            // 
            // uscMostrarEspacio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpContenedor);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscMostrarEspacio";
            this.Size = new System.Drawing.Size(1284, 360);
            this.Load += new System.EventHandler(this.uscMostrarTabla_Load);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkEspacios;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
    }
}
