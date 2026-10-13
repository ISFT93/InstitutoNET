namespace ISFDyT93.Vista.UserControls
{
    partial class uscEspaciosFormacion
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
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.chkEspaciosFormacion = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
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
            this.flpContenedor.Location = new System.Drawing.Point(0, 50);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1283, 566);
            this.flpContenedor.TabIndex = 3;
            // 
            // chkFormacion
            // 
            this.chkEspaciosFormacion.AutoSize = true;
            this.chkEspaciosFormacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEspaciosFormacion.ForeColor = System.Drawing.Color.White;
            this.chkEspaciosFormacion.Location = new System.Drawing.Point(13, 13);
            this.chkEspaciosFormacion.Name = "chkEspaciosFormacion";
            this.chkEspaciosFormacion.Size = new System.Drawing.Size(299, 24);
            this.chkEspaciosFormacion.TabIndex = 0;
            this.chkEspaciosFormacion.Text = "Espacio de Formación Academica";
            this.chkEspaciosFormacion.UseVisualStyleBackColor = true;
            this.chkEspaciosFormacion.CheckedChanged += new System.EventHandler(this.chkEspaciosFormacion_CheckedChanged);
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkEspaciosFormacion);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1283, 50);
            this.panelCabecera.TabIndex = 2;
            // 
            // uscEspFormacionAcademica
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.flpContenedor);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscEspaciosFormacion";
            this.Size = new System.Drawing.Size(1283, 616);
            this.Load += new System.EventHandler(this.uscEspaciosFormacion_Load);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.CheckBox chkEspaciosFormacion;
        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.Panel panel1;
    }
}
