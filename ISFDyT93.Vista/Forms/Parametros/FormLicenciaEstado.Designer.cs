namespace ISFDyT93.Vista.Forms.Parametros
{
    partial class FormLicenciaEstado
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
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblLicencias = new System.Windows.Forms.Label();
            this.cbxLicencias = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelTitulo.Controls.Add(this.lblLicencias);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(401, 37);
            this.panelTitulo.TabIndex = 5;
            // 
            // lblLicencias
            // 
            this.lblLicencias.AutoSize = true;
            this.lblLicencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencias.ForeColor = System.Drawing.Color.White;
            this.lblLicencias.Location = new System.Drawing.Point(115, 9);
            this.lblLicencias.Name = "lblLicencias";
            this.lblLicencias.Size = new System.Drawing.Size(160, 20);
            this.lblLicencias.TabIndex = 0;
            this.lblLicencias.Text = "Inhabilitar Licencia";
            // 
            // cbxLicencias
            // 
            this.cbxLicencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLicencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLicencias.FormattingEnabled = true;
            this.cbxLicencias.Location = new System.Drawing.Point(80, 71);
            this.cbxLicencias.Name = "cbxLicencias";
            this.cbxLicencias.Size = new System.Drawing.Size(221, 28);
            this.cbxLicencias.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Licencia";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnCambiar.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(198)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Location = new System.Drawing.Point(22, 132);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(167, 53);
            this.btnCambiar.TabIndex = 188;
            this.btnCambiar.Text = "Inhabilitar";
            this.btnCambiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(215, 132);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 53);
            this.btnCancelar.TabIndex = 189;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormLicenciaEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 211);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxLicencias);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLicenciaEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormLicenciaEstado";
            this.Load += new System.EventHandler(this.FormLicenciaEstado_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblLicencias;
        private System.Windows.Forms.ComboBox cbxLicencias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Button btnCancelar;
    }
}