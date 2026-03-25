
namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormAgregarModificarServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarServicios));
            this.lblPersonalReemplazar = new System.Windows.Forms.Label();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.cmbSituacionRevistaId = new System.Windows.Forms.ComboBox();
            this.lblSituacion = new System.Windows.Forms.Label();
            this.cmbCargoId = new System.Windows.Forms.ComboBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.cmbCarreraId = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbAnioId = new System.Windows.Forms.ComboBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.cmbCursoId = new System.Windows.Forms.ComboBox();
            this.cmbCursoMateriaId = new System.Windows.Forms.ComboBox();
            this.lblMateriasDisponibles = new System.Windows.Forms.Label();
            this.lstCargosAsignados = new System.Windows.Forms.ListBox();
            this.lblCargosAsignados = new System.Windows.Forms.Label();
            this.txtLibro = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.tlpContenedor = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.epvServicios = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersonalReemplazar
            // 
            this.lblPersonalReemplazar.AutoSize = true;
            this.tlpContenedor.SetColumnSpan(this.lblPersonalReemplazar, 3);
            this.lblPersonalReemplazar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPersonalReemplazar.Location = new System.Drawing.Point(405, 60);
            this.lblPersonalReemplazar.Name = "lblPersonalReemplazar";
            this.lblPersonalReemplazar.Size = new System.Drawing.Size(171, 19);
            this.lblPersonalReemplazar.TabIndex = 65;
            this.lblPersonalReemplazar.Text = "Personal a reemplazar:";
            this.lblPersonalReemplazar.Visible = false;
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContenedor.SetColumnSpan(this.cmbPersonal, 3);
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(405, 86);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(369, 27);
            this.cmbPersonal.TabIndex = 63;
            this.cmbPersonal.Visible = false;
            // 
            // cmbSituacionRevistaId
            // 
            this.cmbSituacionRevistaId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContenedor.SetColumnSpan(this.cmbSituacionRevistaId, 3);
            this.cmbSituacionRevistaId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacionRevistaId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbSituacionRevistaId.FormattingEnabled = true;
            this.cmbSituacionRevistaId.Location = new System.Drawing.Point(3, 86);
            this.cmbSituacionRevistaId.Name = "cmbSituacionRevistaId";
            this.cmbSituacionRevistaId.Size = new System.Drawing.Size(366, 27);
            this.cmbSituacionRevistaId.TabIndex = 64;
            this.cmbSituacionRevistaId.SelectedIndexChanged += new System.EventHandler(this.cmbSituacionRevista_SelectedIndexChanged);
            // 
            // lblSituacion
            // 
            this.lblSituacion.AutoSize = true;
            this.lblSituacion.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSituacion.Location = new System.Drawing.Point(3, 60);
            this.lblSituacion.Name = "lblSituacion";
            this.lblSituacion.Size = new System.Drawing.Size(152, 19);
            this.lblSituacion.TabIndex = 62;
            this.lblSituacion.Text = "Situacion de revista:";
            // 
            // cmbCargoId
            // 
            this.cmbCargoId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContenedor.SetColumnSpan(this.cmbCargoId, 3);
            this.cmbCargoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargoId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbCargoId.FormattingEnabled = true;
            this.cmbCargoId.Location = new System.Drawing.Point(3, 26);
            this.cmbCargoId.Name = "cmbCargoId";
            this.cmbCargoId.Size = new System.Drawing.Size(366, 27);
            this.cmbCargoId.TabIndex = 61;
            this.cmbCargoId.SelectedIndexChanged += new System.EventHandler(this.cmbCargo_SelectedIndexChanged);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCargo.Location = new System.Drawing.Point(3, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(122, 19);
            this.lblCargo.TabIndex = 60;
            this.lblCargo.Text = "Cargo Servicio: ";
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCarrera.Location = new System.Drawing.Point(3, 120);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(61, 19);
            this.lblCarrera.TabIndex = 62;
            this.lblCarrera.Text = "Carrera";
            this.lblCarrera.Visible = false;
            // 
            // cmbCarreraId
            // 
            this.cmbCarreraId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContenedor.SetColumnSpan(this.cmbCarreraId, 3);
            this.cmbCarreraId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarreraId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbCarreraId.FormattingEnabled = true;
            this.cmbCarreraId.Location = new System.Drawing.Point(3, 146);
            this.cmbCarreraId.Name = "cmbCarreraId";
            this.cmbCarreraId.Size = new System.Drawing.Size(366, 27);
            this.cmbCarreraId.TabIndex = 64;
            this.cmbCarreraId.Visible = false;
            this.cmbCarreraId.SelectedIndexChanged += new System.EventHandler(this.cmbCarrera_SelectedIndexChanged);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAnio.Location = new System.Drawing.Point(3, 180);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(38, 19);
            this.lblAnio.TabIndex = 62;
            this.lblAnio.Text = "Año";
            this.lblAnio.Visible = false;
            // 
            // cmbAnioId
            // 
            this.cmbAnioId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnioId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbAnioId.FormattingEnabled = true;
            this.cmbAnioId.Location = new System.Drawing.Point(3, 206);
            this.cmbAnioId.Name = "cmbAnioId";
            this.cmbAnioId.Size = new System.Drawing.Size(165, 27);
            this.cmbAnioId.TabIndex = 64;
            this.cmbAnioId.Visible = false;
            this.cmbAnioId.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCurso.Location = new System.Drawing.Point(204, 180);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(50, 19);
            this.lblCurso.TabIndex = 62;
            this.lblCurso.Text = "Curso";
            this.lblCurso.Visible = false;
            // 
            // cmbCursoId
            // 
            this.cmbCursoId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCursoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCursoId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbCursoId.FormattingEnabled = true;
            this.cmbCursoId.Location = new System.Drawing.Point(204, 206);
            this.cmbCursoId.Name = "cmbCursoId";
            this.cmbCursoId.Size = new System.Drawing.Size(165, 27);
            this.cmbCursoId.TabIndex = 64;
            this.cmbCursoId.Visible = false;
            this.cmbCursoId.SelectedIndexChanged += new System.EventHandler(this.cmbCurso_SelectedIndexChanged);
            // 
            // cmbCursoMateriaId
            // 
            this.cmbCursoMateriaId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContenedor.SetColumnSpan(this.cmbCursoMateriaId, 3);
            this.cmbCursoMateriaId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCursoMateriaId.FormattingEnabled = true;
            this.cmbCursoMateriaId.Location = new System.Drawing.Point(3, 269);
            this.cmbCursoMateriaId.Name = "cmbCursoMateriaId";
            this.cmbCursoMateriaId.Size = new System.Drawing.Size(366, 27);
            this.cmbCursoMateriaId.TabIndex = 70;
            this.cmbCursoMateriaId.Visible = false;
            this.cmbCursoMateriaId.SelectedIndexChanged += new System.EventHandler(this.cmbCursoMateriaId_SelectedIndexChanged);
            // 
            // lblMateriasDisponibles
            // 
            this.lblMateriasDisponibles.AutoSize = true;
            this.lblMateriasDisponibles.Location = new System.Drawing.Point(3, 240);
            this.lblMateriasDisponibles.Name = "lblMateriasDisponibles";
            this.lblMateriasDisponibles.Size = new System.Drawing.Size(151, 19);
            this.lblMateriasDisponibles.TabIndex = 71;
            this.lblMateriasDisponibles.Text = "Materias disponibles";
            this.lblMateriasDisponibles.Visible = false;
            // 
            // lstCargosAsignados
            // 
            this.lstCargosAsignados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpContenedor.SetColumnSpan(this.lstCargosAsignados, 3);
            this.lstCargosAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCargosAsignados.FormattingEnabled = true;
            this.lstCargosAsignados.HorizontalScrollbar = true;
            this.lstCargosAsignados.ItemHeight = 19;
            this.lstCargosAsignados.Location = new System.Drawing.Point(405, 143);
            this.lstCargosAsignados.Name = "lstCargosAsignados";
            this.tlpContenedor.SetRowSpan(this.lstCargosAsignados, 5);
            this.lstCargosAsignados.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstCargosAsignados.Size = new System.Drawing.Size(369, 154);
            this.lstCargosAsignados.TabIndex = 72;
            this.lstCargosAsignados.Visible = false;
            // 
            // lblCargosAsignados
            // 
            this.lblCargosAsignados.AutoSize = true;
            this.lblCargosAsignados.Location = new System.Drawing.Point(405, 120);
            this.lblCargosAsignados.Name = "lblCargosAsignados";
            this.lblCargosAsignados.Size = new System.Drawing.Size(136, 19);
            this.lblCargosAsignados.TabIndex = 73;
            this.lblCargosAsignados.Text = "Cargos Asignados";
            this.lblCargosAsignados.Visible = false;
            // 
            // txtLibro
            // 
            this.txtLibro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLibro.Enabled = false;
            this.txtLibro.Location = new System.Drawing.Point(405, 26);
            this.txtLibro.Name = "txtLibro";
            this.txtLibro.ReadOnly = true;
            this.txtLibro.Size = new System.Drawing.Size(165, 27);
            this.txtLibro.TabIndex = 74;
            // 
            // txtFolio
            // 
            this.txtFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolio.Enabled = false;
            this.txtFolio.Location = new System.Drawing.Point(606, 26);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(168, 27);
            this.txtFolio.TabIndex = 75;
            // 
            // lblLibro
            // 
            this.lblLibro.AutoSize = true;
            this.lblLibro.Location = new System.Drawing.Point(405, 0);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(45, 19);
            this.lblLibro.TabIndex = 76;
            this.lblLibro.Text = "Libro";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Location = new System.Drawing.Point(606, 0);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(43, 19);
            this.lblFolio.TabIndex = 77;
            this.lblFolio.Text = "Folio";
            // 
            // tlpContenedor
            // 
            this.tlpContenedor.ColumnCount = 7;
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenedor.Controls.Add(this.lblCargo, 0, 0);
            this.tlpContenedor.Controls.Add(this.cmbCargoId, 0, 1);
            this.tlpContenedor.Controls.Add(this.lblSituacion, 0, 2);
            this.tlpContenedor.Controls.Add(this.cmbSituacionRevistaId, 0, 3);
            this.tlpContenedor.Controls.Add(this.lblCarrera, 0, 4);
            this.tlpContenedor.Controls.Add(this.cmbCarreraId, 0, 5);
            this.tlpContenedor.Controls.Add(this.lblMateriasDisponibles, 0, 8);
            this.tlpContenedor.Controls.Add(this.cmbCursoMateriaId, 0, 9);
            this.tlpContenedor.Controls.Add(this.lblAnio, 0, 6);
            this.tlpContenedor.Controls.Add(this.cmbAnioId, 0, 7);
            this.tlpContenedor.Controls.Add(this.lblCurso, 2, 6);
            this.tlpContenedor.Controls.Add(this.cmbCursoId, 2, 7);
            this.tlpContenedor.Controls.Add(this.lblCargosAsignados, 4, 4);
            this.tlpContenedor.Controls.Add(this.lstCargosAsignados, 4, 5);
            this.tlpContenedor.Controls.Add(this.lblLibro, 4, 0);
            this.tlpContenedor.Controls.Add(this.txtLibro, 4, 1);
            this.tlpContenedor.Controls.Add(this.lblFolio, 6, 0);
            this.tlpContenedor.Controls.Add(this.txtFolio, 6, 1);
            this.tlpContenedor.Controls.Add(this.lblPersonalReemplazar, 4, 2);
            this.tlpContenedor.Controls.Add(this.cmbPersonal, 4, 3);
            this.tlpContenedor.Controls.Add(this.btnGuardar, 6, 12);
            this.tlpContenedor.Controls.Add(this.lblModulo, 0, 10);
            this.tlpContenedor.Controls.Add(this.txtModulo, 0, 11);
            this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedor.Location = new System.Drawing.Point(20, 20);
            this.tlpContenedor.Name = "tlpContenedor";
            this.tlpContenedor.RowCount = 13;
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.Size = new System.Drawing.Size(777, 505);
            this.tlpContenedor.TabIndex = 78;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.Location = new System.Drawing.Point(639, 452);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(135, 50);
            this.btnGuardar.TabIndex = 78;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(3, 300);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(68, 19);
            this.lblModulo.TabIndex = 79;
            this.lblModulo.Text = "Modulos";
            // 
            // txtModulo
            // 
            this.tlpContenedor.SetColumnSpan(this.txtModulo, 3);
            this.txtModulo.Location = new System.Drawing.Point(3, 323);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.ReadOnly = true;
            this.txtModulo.Size = new System.Drawing.Size(366, 27);
            this.txtModulo.TabIndex = 80;
            // 
            // epvServicios
            // 
            this.epvServicios.ContainerControl = this;
            this.epvServicios.Icon = ((System.Drawing.Icon)(resources.GetObject("epvServicios.Icon")));
            // 
            // FormAgregarModificarServicios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.tlpContenedor);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Name = "FormAgregarModificarServicios";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAgregarModificarServicios";
            this.Load += new System.EventHandler(this.FormAgregarModificarServicios_Load);
            this.tlpContenedor.ResumeLayout(false);
            this.tlpContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPersonalReemplazar;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.ComboBox cmbSituacionRevistaId;
        private System.Windows.Forms.Label lblSituacion;
        private System.Windows.Forms.ComboBox cmbCargoId;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.ComboBox cmbCarreraId;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbAnioId;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cmbCursoId;
        private System.Windows.Forms.ComboBox cmbCursoMateriaId;
        private System.Windows.Forms.Label lblMateriasDisponibles;
        private System.Windows.Forms.ListBox lstCargosAsignados;
        private System.Windows.Forms.Label lblCargosAsignados;
        private System.Windows.Forms.TextBox txtLibro;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TableLayoutPanel tlpContenedor;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.ErrorProvider epvServicios;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.TextBox txtModulo;
    }
}