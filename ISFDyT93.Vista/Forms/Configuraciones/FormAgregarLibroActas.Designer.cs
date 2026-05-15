namespace ISFDyT93.Vista.Forms.Configuraciones
{
    partial class FormAgregarLibroActas
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
            this.txtFolioMax = new System.Windows.Forms.TextBox();
            this.cmbTipoLibro = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Carrera = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblCargos = new System.Windows.Forms.Label();
            this.cmbCarreras = new System.Windows.Forms.ComboBox();
            this.txtFechaAlta = new System.Windows.Forms.TextBox();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolioMax
            // 
            this.txtFolioMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolioMax.Location = new System.Drawing.Point(285, 194);
            this.txtFolioMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolioMax.MaxLength = 3;
            this.txtFolioMax.Name = "txtFolioMax";
            this.txtFolioMax.ShortcutsEnabled = false;
            this.txtFolioMax.Size = new System.Drawing.Size(181, 30);
            this.txtFolioMax.TabIndex = 34;
            this.txtFolioMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolioMax_KeyPress);
            // 
            // cmbTipoLibro
            // 
            this.cmbTipoLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoLibro.Enabled = false;
            this.cmbTipoLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoLibro.FormattingEnabled = true;
            this.cmbTipoLibro.Location = new System.Drawing.Point(13, 191);
            this.cmbTipoLibro.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoLibro.Name = "cmbTipoLibro";
            this.cmbTipoLibro.Size = new System.Drawing.Size(252, 33);
            this.cmbTipoLibro.TabIndex = 33;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(425, 264);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(230, 47);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAñadir.FlatAppearance.BorderSize = 0;
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.Location = new System.Drawing.Point(13, 264);
            this.btnAñadir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(230, 47);
            this.btnAñadir.TabIndex = 31;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(470, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Fecha Alta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fólio máximo";
            // 
            // Carrera
            // 
            this.Carrera.AutoSize = true;
            this.Carrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Carrera.Location = new System.Drawing.Point(9, 94);
            this.Carrera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Carrera.Name = "Carrera";
            this.Carrera.Size = new System.Drawing.Size(66, 20);
            this.Carrera.TabIndex = 28;
            this.Carrera.Text = "Carrera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tipo de libro";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelTitulo.Controls.Add(this.lblCargos);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(697, 46);
            this.panelTitulo.TabIndex = 26;
            // 
            // lblCargos
            // 
            this.lblCargos.AutoSize = true;
            this.lblCargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargos.ForeColor = System.Drawing.Color.White;
            this.lblCargos.Location = new System.Drawing.Point(223, 11);
            this.lblCargos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargos.Name = "lblCargos";
            this.lblCargos.Size = new System.Drawing.Size(255, 25);
            this.lblCargos.TabIndex = 0;
            this.lblCargos.Text = "Añadir nuevo Libro Actas";
            // 
            // cmbCarreras
            // 
            this.cmbCarreras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarreras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarreras.FormattingEnabled = true;
            this.cmbCarreras.Location = new System.Drawing.Point(13, 118);
            this.cmbCarreras.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCarreras.Name = "cmbCarreras";
            this.cmbCarreras.Size = new System.Drawing.Size(642, 33);
            this.cmbCarreras.TabIndex = 25;
            this.cmbCarreras.SelectedIndexChanged += new System.EventHandler(this.cmbCarreras_SelectedIndexChanged);
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.Enabled = false;
            this.txtFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaAlta.Location = new System.Drawing.Point(474, 194);
            this.txtFechaAlta.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaAlta.MaxLength = 2;
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.ShortcutsEnabled = false;
            this.txtFechaAlta.Size = new System.Drawing.Size(181, 30);
            this.txtFechaAlta.TabIndex = 24;
            // 
            // FormAgregarLibroActas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 327);
            this.Controls.Add(this.txtFolioMax);
            this.Controls.Add(this.cmbTipoLibro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Carrera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.cmbCarreras);
            this.Controls.Add(this.txtFechaAlta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarLibroActas";
            this.Text = "FormAgregarLibroActas";
            this.Load += new System.EventHandler(this.FormAgregarLibroActas_Load_1);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolioMax;
        private System.Windows.Forms.ComboBox cmbTipoLibro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Carrera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblCargos;
        private System.Windows.Forms.ComboBox cmbCarreras;
        private System.Windows.Forms.TextBox txtFechaAlta;
    }
}