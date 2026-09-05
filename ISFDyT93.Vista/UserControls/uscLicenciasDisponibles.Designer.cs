namespace ISFDyT93.Vista.UserControls
{
    partial class uscLicenciasDisponibles
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
            this.chkLicencias = new System.Windows.Forms.CheckBox();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkLicencias);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1283, 50);
            this.panelCabecera.TabIndex = 0;
            this.panelCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCabecera_Paint);
            // 
            // chkLicencias
            // 
            this.chkLicencias.AutoSize = true;
            this.chkLicencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLicencias.ForeColor = System.Drawing.Color.White;
            this.chkLicencias.Location = new System.Drawing.Point(13, 13);
            this.chkLicencias.Name = "chkLicencias";
            this.chkLicencias.Size = new System.Drawing.Size(201, 24);
            this.chkLicencias.TabIndex = 0;
            this.chkLicencias.Text = "Licencias Disponibles";
            this.chkLicencias.UseVisualStyleBackColor = true;
            this.chkLicencias.CheckedChanged += new System.EventHandler(this.chkLicencias_CheckedChanged);
            // 
            // flpContenedor
            // 
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.BackColor = System.Drawing.Color.White;
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 50);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1283, 566);
            this.flpContenedor.TabIndex = 1;
            this.flpContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.flpContenedor_Paint);
            // 
            // uscLicenciasDisponibles
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.flpContenedor);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscLicenciasDisponibles";
            this.Size = new System.Drawing.Size(1283, 616);
            this.Load += new System.EventHandler(this.uscMostrarTabla_Load);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkLicencias;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
    }
}