namespace ISFDyT93.Vista.UserControls
{
    partial class uscHorarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.chkHorarios = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpContenedor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1711, 728);
            this.panel1.TabIndex = 4;
            // 
            // flpContenedor
            // 
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.BackColor = System.Drawing.Color.White;
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 0);
            this.flpContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1711, 728);
            this.flpContenedor.TabIndex = 2;
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkHorarios);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1711, 62);
            this.panelCabecera.TabIndex = 5;
            // 
            // chkHorarios
            // 
            this.chkHorarios.AutoSize = true;
            this.chkHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHorarios.ForeColor = System.Drawing.Color.White;
            this.chkHorarios.Location = new System.Drawing.Point(17, 16);
            this.chkHorarios.Margin = new System.Windows.Forms.Padding(4);
            this.chkHorarios.Name = "chkHorarios";
            this.chkHorarios.Size = new System.Drawing.Size(115, 29);
            this.chkHorarios.TabIndex = 0;
            this.chkHorarios.Text = "Horarios";
            this.chkHorarios.UseVisualStyleBackColor = true;
            this.chkHorarios.CheckedChanged += new System.EventHandler(this.chkHorarios_CheckedChanged);
            // 
            // uscHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscHorarios";
            this.Size = new System.Drawing.Size(1711, 790);
            this.Load += new System.EventHandler(this.uscHorarios_Load);
            this.panel1.ResumeLayout(false);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkHorarios;
    }
}
