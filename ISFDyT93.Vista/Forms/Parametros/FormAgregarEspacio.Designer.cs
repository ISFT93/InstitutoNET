namespace ISFDyT93.Vista.Forms.Parametros
{
    partial class FormAgregarEspacio
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblAcumulador = new System.Windows.Forms.Label();
            this.txtAcumulador = new System.Windows.Forms.TextBox();
            this.chkSumaHoras = new System.Windows.Forms.CheckBox();
            this.chkCalculaPorcentaje = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.panelCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(25, 65);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 15);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(28, 85);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(364, 22);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblAcumulador
            // 
            this.lblAcumulador.AutoSize = true;
            this.lblAcumulador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcumulador.Location = new System.Drawing.Point(25, 122);
            this.lblAcumulador.Name = "lblAcumulador";
            this.lblAcumulador.Size = new System.Drawing.Size(76, 15);
            this.lblAcumulador.TabIndex = 3;
            this.lblAcumulador.Text = "Acumulador:";
            // 
            // txtAcumulador
            // 
            this.txtAcumulador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcumulador.Location = new System.Drawing.Point(28, 140);
            this.txtAcumulador.MaxLength = 100;
            this.txtAcumulador.Name = "txtAcumulador";
            this.txtAcumulador.Size = new System.Drawing.Size(364, 22);
            this.txtAcumulador.TabIndex = 4;
            // 
            // chkSumaHoras
            // 
            this.chkSumaHoras.AutoSize = true;
            this.chkSumaHoras.Checked = true;
            this.chkSumaHoras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSumaHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSumaHoras.Location = new System.Drawing.Point(28, 180);
            this.chkSumaHoras.Name = "chkSumaHoras";
            this.chkSumaHoras.Size = new System.Drawing.Size(95, 19);
            this.chkSumaHoras.TabIndex = 5;
            this.chkSumaHoras.Text = "Suma Horas";
            this.chkSumaHoras.UseVisualStyleBackColor = true;
            this.chkSumaHoras.Visible = false;
            // 
            // chkCalculaPorcentaje
            // 
            this.chkCalculaPorcentaje.AutoSize = true;
            this.chkCalculaPorcentaje.Checked = true;
            this.chkCalculaPorcentaje.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalculaPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalculaPorcentaje.Location = new System.Drawing.Point(160, 180);
            this.chkCalculaPorcentaje.Name = "chkCalculaPorcentaje";
            this.chkCalculaPorcentaje.Size = new System.Drawing.Size(129, 19);
            this.chkCalculaPorcentaje.TabIndex = 6;
            this.chkCalculaPorcentaje.Text = "Calcula Porcentaje";
            this.chkCalculaPorcentaje.UseVisualStyleBackColor = true;
            this.chkCalculaPorcentaje.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(216, 225);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 30);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(307, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(231, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Espacio de Formación";
            // 
            // panelCabecera
            // 
            this.panelCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelCabecera.Controls.Add(this.lblTitulo);
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Location = new System.Drawing.Point(0, 0);
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Size = new System.Drawing.Size(420, 45);
            this.panelCabecera.TabIndex = 0;
            // 
            // FormAgregarEspacio
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(420, 275);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkCalculaPorcentaje);
            this.Controls.Add(this.chkSumaHoras);
            this.Controls.Add(this.txtAcumulador);
            this.Controls.Add(this.lblAcumulador);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.panelCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgregarEspacio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Espacio de Formación";
            this.panelCabecera.ResumeLayout(false);
            this.panelCabecera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblAcumulador;
        private System.Windows.Forms.TextBox txtAcumulador;
        private System.Windows.Forms.CheckBox chkSumaHoras;
        private System.Windows.Forms.CheckBox chkCalculaPorcentaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}