namespace ISFDyT93.Vista.UserControls
{
    partial class uscClasificacionCarreras
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.chkClasificacion = new System.Windows.Forms.CheckBox();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvClasificacion = new System.Windows.Forms.DataGridView();
            this.panelCabecera.SuspendLayout();
            this.flpContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.chkClasificacion);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(1283, 50);
            this.panelCabecera.TabIndex = 0;
            // 
            // chkClasificacion
            // 
            this.chkClasificacion.AutoSize = true;
            this.chkClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClasificacion.ForeColor = System.Drawing.Color.White;
            this.chkClasificacion.Location = new System.Drawing.Point(13, 13);
            this.chkClasificacion.Name = "chkClasificacion";
            this.chkClasificacion.Size = new System.Drawing.Size(225, 24);
            this.chkClasificacion.TabIndex = 0;
            this.chkClasificacion.Text = "Clasificación de Carreras";
            this.chkClasificacion.UseVisualStyleBackColor = true;
            this.chkClasificacion.CheckedChanged += new System.EventHandler(this.chkClasificacion_CheckedChanged);
            // 
            // flpContenedor
            // 
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.BackColor = System.Drawing.Color.White;
            this.flpContenedor.Controls.Add(this.dgvClasificacion);
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 50);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(1283, 300);
            this.flpContenedor.TabIndex = 1;
            this.flpContenedor.SizeChanged += new System.EventHandler(this.flpContenedor_SizeChanged);
            // 
            // dgvClasificacion
            // 
            this.dgvClasificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasificacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasificacion.Location = new System.Drawing.Point(0, 0);
            this.dgvClasificacion.Margin = new System.Windows.Forms.Padding(0);
            this.dgvClasificacion.Name = "dgvClasificacion";
            this.dgvClasificacion.Size = new System.Drawing.Size(1283, 300);
            this.dgvClasificacion.TabIndex = 0;
            // 
            // uscClasificacionCarreras
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.flpContenedor);
            this.Controls.Add(this.panelCabecera);
            this.Name = "uscClasificacionCarreras";
            this.Size = new System.Drawing.Size(1283, 350);
            this.Load += new System.EventHandler(this.uscClasificacionCarreras_Load);
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.flpContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.CheckBox chkClasificacion;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.DataGridView dgvClasificacion;
    }
}