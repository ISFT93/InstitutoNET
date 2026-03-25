namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormProfesorMaterias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfesorMaterias));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.lblCursos = new System.Windows.Forms.Label();
            this.lblAniosCarrera = new System.Windows.Forms.Label();
            this.lblCarreras = new System.Windows.Forms.Label();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.cmbAniosCarrera = new System.Windows.Forms.ComboBox();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.epvProfesorMateria = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbxVolver = new System.Windows.Forms.PictureBox();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.lblFechaBaja = new System.Windows.Forms.Label();
            this.cmbSituacionRevista = new System.Windows.Forms.ComboBox();
            this.lblSituacionRevista = new System.Windows.Forms.Label();
            this.epvProfesores = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesorMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(817, 50);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Profesores Materias ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(198)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(629, 382);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(115, 43);
            this.btnAceptar.TabIndex = 186;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMaterias
            // 
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterias.Location = new System.Drawing.Point(40, 281);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(163, 19);
            this.lblMaterias.TabIndex = 185;
            this.lblMaterias.Text = "Seleccione la materia:";
            // 
            // lblCursos
            // 
            this.lblCursos.AutoSize = true;
            this.lblCursos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursos.Location = new System.Drawing.Point(40, 360);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Size = new System.Drawing.Size(148, 19);
            this.lblCursos.TabIndex = 184;
            this.lblCursos.Text = "Seleccione el curso:";
            // 
            // lblAniosCarrera
            // 
            this.lblAniosCarrera.AutoSize = true;
            this.lblAniosCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAniosCarrera.Location = new System.Drawing.Point(40, 204);
            this.lblAniosCarrera.Name = "lblAniosCarrera";
            this.lblAniosCarrera.Size = new System.Drawing.Size(139, 19);
            this.lblAniosCarrera.TabIndex = 183;
            this.lblAniosCarrera.Text = "Seleccione el Año:";
            // 
            // lblCarreras
            // 
            this.lblCarreras.AutoSize = true;
            this.lblCarreras.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarreras.Location = new System.Drawing.Point(40, 130);
            this.lblCarreras.Name = "lblCarreras";
            this.lblCarreras.Size = new System.Drawing.Size(162, 19);
            this.lblCarreras.TabIndex = 182;
            this.lblCarreras.Text = "Seleccione la Carrera:";
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterias.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(44, 303);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(383, 27);
            this.cmbMaterias.TabIndex = 181;
            this.cmbMaterias.SelectionChangeCommitted += new System.EventHandler(this.cmbMaterias_SelectionChangeCommitted);
            // 
            // cmbCursos
            // 
            this.cmbCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCursos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(44, 382);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(124, 27);
            this.cmbCursos.TabIndex = 180;
            this.cmbCursos.SelectionChangeCommitted += new System.EventHandler(this.cmbCursos_SelectionChangeCommitted);
            // 
            // cmbAniosCarrera
            // 
            this.cmbAniosCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAniosCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAniosCarrera.FormattingEnabled = true;
            this.cmbAniosCarrera.Location = new System.Drawing.Point(44, 226);
            this.cmbAniosCarrera.Name = "cmbAniosCarrera";
            this.cmbAniosCarrera.Size = new System.Drawing.Size(124, 27);
            this.cmbAniosCarrera.TabIndex = 179;
            this.cmbAniosCarrera.SelectionChangeCommitted += new System.EventHandler(this.cmbAniosCarrera_SelectionChangeCommitted);
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(44, 152);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(383, 27);
            this.cmbCarrera.TabIndex = 178;
            this.cmbCarrera.SelectionChangeCommitted += new System.EventHandler(this.cmbCarrera_SelectionChangeCommitted);
            // 
            // epvProfesorMateria
            // 
            this.epvProfesorMateria.ContainerControl = this;
            this.epvProfesorMateria.Icon = ((System.Drawing.Icon)(resources.GetObject("epvProfesorMateria.Icon")));
            // 
            // pbxVolver
            // 
            this.pbxVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.pbxVolver.Image = ((System.Drawing.Image)(resources.GetObject("pbxVolver.Image")));
            this.pbxVolver.InitialImage = null;
            this.pbxVolver.Location = new System.Drawing.Point(21, 12);
            this.pbxVolver.Name = "pbxVolver";
            this.pbxVolver.Size = new System.Drawing.Size(42, 38);
            this.pbxVolver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxVolver.TabIndex = 187;
            this.pbxVolver.TabStop = false;
            this.pbxVolver.Click += new System.EventHandler(this.pbxVolver_Click);
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.CustomFormat = "";
            this.dtpFechaAlta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAlta.Location = new System.Drawing.Point(492, 152);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(252, 27);
            this.dtpFechaAlta.TabIndex = 188;
            this.dtpFechaAlta.Value = new System.DateTime(2020, 8, 30, 0, 0, 0, 0);
            this.dtpFechaAlta.CloseUp += new System.EventHandler(this.dtpFechaAlta_CloseUp);
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.CustomFormat = "";
            this.dtpFechaBaja.Enabled = false;
            this.dtpFechaBaja.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBaja.Location = new System.Drawing.Point(492, 226);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(252, 27);
            this.dtpFechaBaja.TabIndex = 189;
            this.dtpFechaBaja.Value = new System.DateTime(2020, 8, 30, 0, 0, 0, 0);
            this.dtpFechaBaja.CloseUp += new System.EventHandler(this.dtpFechaBaja_CloseUp);
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAlta.Location = new System.Drawing.Point(488, 130);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(110, 19);
            this.lblFechaAlta.TabIndex = 190;
            this.lblFechaAlta.Text = "Fecha de Alta:";
            // 
            // lblFechaBaja
            // 
            this.lblFechaBaja.AutoSize = true;
            this.lblFechaBaja.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaBaja.Location = new System.Drawing.Point(488, 204);
            this.lblFechaBaja.Name = "lblFechaBaja";
            this.lblFechaBaja.Size = new System.Drawing.Size(112, 19);
            this.lblFechaBaja.TabIndex = 191;
            this.lblFechaBaja.Text = "Fecha de Baja:";
            // 
            // cmbSituacionRevista
            // 
            this.cmbSituacionRevista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacionRevista.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacionRevista.FormattingEnabled = true;
            this.cmbSituacionRevista.Location = new System.Drawing.Point(44, 461);
            this.cmbSituacionRevista.Name = "cmbSituacionRevista";
            this.cmbSituacionRevista.Size = new System.Drawing.Size(124, 27);
            this.cmbSituacionRevista.TabIndex = 192;
            // 
            // lblSituacionRevista
            // 
            this.lblSituacionRevista.AutoSize = true;
            this.lblSituacionRevista.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacionRevista.Location = new System.Drawing.Point(40, 439);
            this.lblSituacionRevista.Name = "lblSituacionRevista";
            this.lblSituacionRevista.Size = new System.Drawing.Size(156, 19);
            this.lblSituacionRevista.TabIndex = 193;
            this.lblSituacionRevista.Text = "Situación de Revista:";
            // 
            // epvProfesores
            // 
            this.epvProfesores.ContainerControl = this;
            this.epvProfesores.Icon = ((System.Drawing.Icon)(resources.GetObject("epvProfesores.Icon")));
            // 
            // FormProfesorMaterias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.lblSituacionRevista);
            this.Controls.Add(this.cmbSituacionRevista);
            this.Controls.Add(this.lblFechaBaja);
            this.Controls.Add(this.lblFechaAlta);
            this.Controls.Add(this.dtpFechaBaja);
            this.Controls.Add(this.dtpFechaAlta);
            this.Controls.Add(this.pbxVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMaterias);
            this.Controls.Add(this.lblCursos);
            this.Controls.Add(this.lblAniosCarrera);
            this.Controls.Add(this.lblCarreras);
            this.Controls.Add(this.cmbMaterias);
            this.Controls.Add(this.cmbCursos);
            this.Controls.Add(this.cmbAniosCarrera);
            this.Controls.Add(this.cmbCarrera);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProfesorMaterias";
            this.Text = "FormProfesorMaterias";
            this.Load += new System.EventHandler(this.FormProfesorMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesorMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.Label lblCursos;
        private System.Windows.Forms.Label lblAniosCarrera;
        private System.Windows.Forms.Label lblCarreras;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.ComboBox cmbAniosCarrera;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.ErrorProvider epvProfesorMateria;
        private System.Windows.Forms.PictureBox pbxVolver;
        public System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.Label lblSituacionRevista;
        private System.Windows.Forms.ComboBox cmbSituacionRevista;
        private System.Windows.Forms.Label lblFechaBaja;
        private System.Windows.Forms.Label lblFechaAlta;
        public System.Windows.Forms.DateTimePicker dtpFechaBaja;
        private System.Windows.Forms.ErrorProvider epvProfesores;
    }
}