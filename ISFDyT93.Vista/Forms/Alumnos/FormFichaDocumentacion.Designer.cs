namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormFichaDocumentacion
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
            this.btnDocumentacionOk = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbDocumentosEntregar = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.chkFotocopiaTitulo = new System.Windows.Forms.CheckBox();
            this.txtRecibo = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.chkFotocopiaDocumento = new System.Windows.Forms.CheckBox();
            this.chkConstanciaTituloTramite = new System.Windows.Forms.CheckBox();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.chkFotoCarnet = new System.Windows.Forms.CheckBox();
            this.chkVacunaAntitetanica = new System.Windows.Forms.CheckBox();
            this.chkConstanciaAdeudaMaterias = new System.Windows.Forms.CheckBox();
            this.chkCertificadoAptitud = new System.Windows.Forms.CheckBox();
            this.chkVacunaAntihepatitis = new System.Windows.Forms.CheckBox();
            this.chkFotocopiaPartidaNacimiento = new System.Windows.Forms.CheckBox();
            this.txtCantidadAdeudaMaterias = new System.Windows.Forms.TextBox();
            this.lblConstAdeuda = new System.Windows.Forms.Label();
            this.grbDocumentosEntregar.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDocumentacionOk
            // 
            this.btnDocumentacionOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentacionOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnDocumentacionOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocumentacionOk.ForeColor = System.Drawing.Color.White;
            this.btnDocumentacionOk.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnDocumentacionOk.IconColor = System.Drawing.Color.White;
            this.btnDocumentacionOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDocumentacionOk.IconSize = 32;
            this.btnDocumentacionOk.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDocumentacionOk.Location = new System.Drawing.Point(762, 450);
            this.btnDocumentacionOk.Name = "btnDocumentacionOk";
            this.btnDocumentacionOk.Size = new System.Drawing.Size(200, 50);
            this.btnDocumentacionOk.TabIndex = 64;
            this.btnDocumentacionOk.Text = "Documentacion OK";
            this.btnDocumentacionOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDocumentacionOk.UseVisualStyleBackColor = false;
            this.btnDocumentacionOk.Click += new System.EventHandler(this.btnDocumentacionOk_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(623, 450);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 50);
            this.btnGuardar.TabIndex = 63;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(88, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 27);
            this.textBox1.TabIndex = 65;
            // 
            // grbDocumentosEntregar
            // 
            this.grbDocumentosEntregar.Controls.Add(this.tableLayoutPanel4);
            this.grbDocumentosEntregar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grbDocumentosEntregar.Location = new System.Drawing.Point(11, 71);
            this.grbDocumentosEntregar.Name = "grbDocumentosEntregar";
            this.grbDocumentosEntregar.Size = new System.Drawing.Size(961, 361);
            this.grbDocumentosEntregar.TabIndex = 2;
            this.grbDocumentosEntregar.TabStop = false;
            this.grbDocumentosEntregar.Text = "Documentacion solicitada";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Controls.Add(this.lblEnunciado, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMonto, 3, 8);
            this.tableLayoutPanel4.Controls.Add(this.chkFotocopiaTitulo, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtRecibo, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.lblMonto, 3, 7);
            this.tableLayoutPanel4.Controls.Add(this.chkFotocopiaDocumento, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkConstanciaTituloTramite, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblRecibo, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.chkFotoCarnet, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.chkVacunaAntitetanica, 3, 6);
            this.tableLayoutPanel4.Controls.Add(this.chkConstanciaAdeudaMaterias, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.chkCertificadoAptitud, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.chkVacunaAntihepatitis, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.chkFotocopiaPartidaNacimiento, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtCantidadAdeudaMaterias, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblConstAdeuda, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(955, 335);
            this.tableLayoutPanel4.TabIndex = 160;
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnunciado.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.lblEnunciado, 3);
            this.lblEnunciado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnunciado.Location = new System.Drawing.Point(17, 10);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(906, 19);
            this.lblEnunciado.TabIndex = 144;
            this.lblEnunciado.Text = "Se deja constancia de haber recibido del alumno la siguiente documentación:";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(488, 287);
            this.txtMonto.MaxLength = 6;
            this.txtMonto.Multiline = true;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(435, 34);
            this.txtMonto.TabIndex = 47;
            this.txtMonto.Text = "0";
            // 
            // chkFotocopiaTitulo
            // 
            this.chkFotocopiaTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFotocopiaTitulo.AutoSize = true;
            this.chkFotocopiaTitulo.Location = new System.Drawing.Point(17, 48);
            this.chkFotocopiaTitulo.Name = "chkFotocopiaTitulo";
            this.chkFotocopiaTitulo.Size = new System.Drawing.Size(435, 23);
            this.chkFotocopiaTitulo.TabIndex = 36;
            this.chkFotocopiaTitulo.Text = "Fotocopia del Título Secundario";
            this.chkFotocopiaTitulo.UseVisualStyleBackColor = true;
            // 
            // txtRecibo
            // 
            this.txtRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecibo.Location = new System.Drawing.Point(17, 287);
            this.txtRecibo.MaxLength = 10;
            this.txtRecibo.Multiline = true;
            this.txtRecibo.Name = "txtRecibo";
            this.txtRecibo.Size = new System.Drawing.Size(435, 34);
            this.txtRecibo.TabIndex = 46;
            this.txtRecibo.Text = "0";
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(488, 260);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(435, 19);
            this.lblMonto.TabIndex = 159;
            this.lblMonto.Text = "Monto";
            // 
            // chkFotocopiaDocumento
            // 
            this.chkFotocopiaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFotocopiaDocumento.AutoSize = true;
            this.chkFotocopiaDocumento.Location = new System.Drawing.Point(488, 48);
            this.chkFotocopiaDocumento.Name = "chkFotocopiaDocumento";
            this.chkFotocopiaDocumento.Size = new System.Drawing.Size(435, 23);
            this.chkFotocopiaDocumento.TabIndex = 37;
            this.chkFotocopiaDocumento.Text = "Fotocopia del Documento de Identidad";
            this.chkFotocopiaDocumento.UseVisualStyleBackColor = true;
            // 
            // chkConstanciaTituloTramite
            // 
            this.chkConstanciaTituloTramite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConstanciaTituloTramite.AutoSize = true;
            this.chkConstanciaTituloTramite.Location = new System.Drawing.Point(17, 88);
            this.chkConstanciaTituloTramite.Name = "chkConstanciaTituloTramite";
            this.chkConstanciaTituloTramite.Size = new System.Drawing.Size(435, 23);
            this.chkConstanciaTituloTramite.TabIndex = 38;
            this.chkConstanciaTituloTramite.Text = "Constancia de Título en Trámite";
            this.chkConstanciaTituloTramite.UseVisualStyleBackColor = true;
            // 
            // lblRecibo
            // 
            this.lblRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.Location = new System.Drawing.Point(17, 260);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(435, 19);
            this.lblRecibo.TabIndex = 157;
            this.lblRecibo.Text = "Recibo N°";
            // 
            // chkFotoCarnet
            // 
            this.chkFotoCarnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFotoCarnet.AutoSize = true;
            this.chkFotoCarnet.Location = new System.Drawing.Point(488, 88);
            this.chkFotoCarnet.Name = "chkFotoCarnet";
            this.chkFotoCarnet.Size = new System.Drawing.Size(435, 23);
            this.chkFotoCarnet.TabIndex = 39;
            this.chkFotoCarnet.Text = "Foto Carnet 4 x 4 ";
            this.chkFotoCarnet.UseVisualStyleBackColor = true;
            // 
            // chkVacunaAntitetanica
            // 
            this.chkVacunaAntitetanica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVacunaAntitetanica.AutoSize = true;
            this.chkVacunaAntitetanica.Location = new System.Drawing.Point(488, 228);
            this.chkVacunaAntitetanica.Name = "chkVacunaAntitetanica";
            this.chkVacunaAntitetanica.Size = new System.Drawing.Size(435, 23);
            this.chkVacunaAntitetanica.TabIndex = 45;
            this.chkVacunaAntitetanica.Text = "Vacuna Antitetánica";
            this.chkVacunaAntitetanica.UseVisualStyleBackColor = true;
            // 
            // chkConstanciaAdeudaMaterias
            // 
            this.chkConstanciaAdeudaMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConstanciaAdeudaMaterias.AutoSize = true;
            this.chkConstanciaAdeudaMaterias.Location = new System.Drawing.Point(17, 128);
            this.chkConstanciaAdeudaMaterias.Name = "chkConstanciaAdeudaMaterias";
            this.chkConstanciaAdeudaMaterias.Size = new System.Drawing.Size(435, 23);
            this.chkConstanciaAdeudaMaterias.TabIndex = 40;
            this.chkConstanciaAdeudaMaterias.Text = "Constancia Adeuda Materias";
            this.chkConstanciaAdeudaMaterias.UseVisualStyleBackColor = true;
            // 
            // chkCertificadoAptitud
            // 
            this.chkCertificadoAptitud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCertificadoAptitud.AutoSize = true;
            this.chkCertificadoAptitud.Location = new System.Drawing.Point(17, 228);
            this.chkCertificadoAptitud.Name = "chkCertificadoAptitud";
            this.chkCertificadoAptitud.Size = new System.Drawing.Size(435, 23);
            this.chkCertificadoAptitud.TabIndex = 44;
            this.chkCertificadoAptitud.Text = "Certificado de Aptitud Psicofísica";
            this.chkCertificadoAptitud.UseVisualStyleBackColor = true;
            // 
            // chkVacunaAntihepatitis
            // 
            this.chkVacunaAntihepatitis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVacunaAntihepatitis.AutoSize = true;
            this.chkVacunaAntihepatitis.Location = new System.Drawing.Point(488, 188);
            this.chkVacunaAntihepatitis.Name = "chkVacunaAntihepatitis";
            this.chkVacunaAntihepatitis.Size = new System.Drawing.Size(435, 23);
            this.chkVacunaAntihepatitis.TabIndex = 43;
            this.chkVacunaAntihepatitis.Text = "Vacuna Antihepatitis B";
            this.chkVacunaAntihepatitis.UseVisualStyleBackColor = true;
            // 
            // chkFotocopiaPartidaNacimiento
            // 
            this.chkFotocopiaPartidaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFotocopiaPartidaNacimiento.AutoSize = true;
            this.chkFotocopiaPartidaNacimiento.Location = new System.Drawing.Point(488, 128);
            this.chkFotocopiaPartidaNacimiento.Name = "chkFotocopiaPartidaNacimiento";
            this.chkFotocopiaPartidaNacimiento.Size = new System.Drawing.Size(435, 23);
            this.chkFotocopiaPartidaNacimiento.TabIndex = 41;
            this.chkFotocopiaPartidaNacimiento.Text = "Fotocopia de la Partida de Nacimiento";
            this.chkFotocopiaPartidaNacimiento.UseVisualStyleBackColor = true;
            // 
            // txtCantidadAdeudaMaterias
            // 
            this.txtCantidadAdeudaMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadAdeudaMaterias.Enabled = false;
            this.txtCantidadAdeudaMaterias.Location = new System.Drawing.Point(17, 186);
            this.txtCantidadAdeudaMaterias.MaxLength = 2;
            this.txtCantidadAdeudaMaterias.Name = "txtCantidadAdeudaMaterias";
            this.txtCantidadAdeudaMaterias.Size = new System.Drawing.Size(435, 27);
            this.txtCantidadAdeudaMaterias.TabIndex = 42;
            // 
            // lblConstAdeuda
            // 
            this.lblConstAdeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConstAdeuda.AutoSize = true;
            this.lblConstAdeuda.Location = new System.Drawing.Point(17, 160);
            this.lblConstAdeuda.Name = "lblConstAdeuda";
            this.lblConstAdeuda.Size = new System.Drawing.Size(435, 19);
            this.lblConstAdeuda.TabIndex = 150;
            this.lblConstAdeuda.Text = "Cuantas?";
            // 
            // FormFichaDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 511);
            this.Controls.Add(this.grbDocumentosEntregar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDocumentacionOk);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FormFichaDocumentacion";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FichaDocumentacion";
            this.Load += new System.EventHandler(this.FormFichaDocumentacion_Load);
            this.grbDocumentosEntregar.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnDocumentacionOk;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grbDocumentosEntregar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.CheckBox chkFotocopiaTitulo;
        private System.Windows.Forms.TextBox txtRecibo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.CheckBox chkFotocopiaDocumento;
        private System.Windows.Forms.CheckBox chkConstanciaTituloTramite;
        private System.Windows.Forms.Label lblRecibo;
        private System.Windows.Forms.CheckBox chkFotoCarnet;
        private System.Windows.Forms.CheckBox chkVacunaAntitetanica;
        private System.Windows.Forms.CheckBox chkConstanciaAdeudaMaterias;
        private System.Windows.Forms.CheckBox chkCertificadoAptitud;
        private System.Windows.Forms.CheckBox chkVacunaAntihepatitis;
        private System.Windows.Forms.CheckBox chkFotocopiaPartidaNacimiento;
        private System.Windows.Forms.TextBox txtCantidadAdeudaMaterias;
        private System.Windows.Forms.Label lblConstAdeuda;
    }
}