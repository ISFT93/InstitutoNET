namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormAgregarModificarCarrera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarCarrera));
            this.lblTituloac = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDescripcionCorta = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtJefeCatedra = new System.Windows.Forms.TextBox();
            this.lblJefeCatedra = new System.Windows.Forms.Label();
            this.lblAñoInicio = new System.Windows.Forms.Label();
            this.lblAñoFin = new System.Windows.Forms.Label();
            this.nudAnioInicio = new System.Windows.Forms.NumericUpDown();
            this.nudAnioFin = new System.Windows.Forms.NumericUpDown();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.txtImagenDescriptiva = new System.Windows.Forms.TextBox();
            this.lblImagenDescriptiva = new System.Windows.Forms.Label();
            this.txtNumeroResolucion = new System.Windows.Forms.TextBox();
            this.lblNumeroResolucion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.ofdCarreras = new System.Windows.Forms.OpenFileDialog();
            this.txtPlanEstudio = new System.Windows.Forms.TextBox();
            this.lblPlanEstudio = new System.Windows.Forms.Label();
            this.txtCantidadHoras = new System.Windows.Forms.TextBox();
            this.lblCantidadHoras = new System.Windows.Forms.Label();
            this.epvCarreras = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlanEstudio = new FontAwesome.Sharp.IconButton();
            this.btnResolucion = new FontAwesome.Sharp.IconButton();
            this.btnImagenDescriptiva = new FontAwesome.Sharp.IconButton();
            this.lblCarreraReemplazar = new System.Windows.Forms.Label();
            this.txtCarreraReemplazar = new System.Windows.Forms.TextBox();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.lblSectorActividad = new System.Windows.Forms.Label();
            this.cmbSectorActividad = new System.Windows.Forms.ComboBox();
            this.lblFamiliaProfesional = new System.Windows.Forms.Label();
            this.cmbFamiliaProfesional = new System.Windows.Forms.ComboBox();
            this.lblVariante = new System.Windows.Forms.Label();
            this.cmbVariante = new System.Windows.Forms.ComboBox();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.cmbModalidad = new System.Windows.Forms.ComboBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cmbRegimenDefecto = new System.Windows.Forms.ComboBox();
            this.lblCantidadCorrelativas = new System.Windows.Forms.Label();
            this.txtCantidadCorrelativas = new System.Windows.Forms.TextBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvCarreras)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloac
            // 
            this.lblTituloac.AutoSize = true;
            this.lblTituloac.Location = new System.Drawing.Point(3, 41);
            this.lblTituloac.Name = "lblTituloac";
            this.lblTituloac.Size = new System.Drawing.Size(44, 16);
            this.lblTituloac.TabIndex = 3;
            this.lblTituloac.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Location = new System.Drawing.Point(3, 57);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtTitulo.MaxLength = 150;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(364, 23);
            this.txtTitulo.TabIndex = 2;
            // 
            // txtDescripcionCorta
            // 
            this.txtDescripcionCorta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionCorta.Location = new System.Drawing.Point(403, 16);
            this.txtDescripcionCorta.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtDescripcionCorta.MaxLength = 30;
            this.txtDescripcionCorta.Multiline = true;
            this.txtDescripcionCorta.Name = "txtDescripcionCorta";
            this.txtDescripcionCorta.Size = new System.Drawing.Size(364, 24);
            this.txtDescripcionCorta.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(403, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(77, 16);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtJefeCatedra
            // 
            this.txtJefeCatedra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJefeCatedra.Enabled = false;
            this.txtJefeCatedra.Location = new System.Drawing.Point(3, 98);
            this.txtJefeCatedra.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtJefeCatedra.MaxLength = 100;
            this.txtJefeCatedra.Name = "txtJefeCatedra";
            this.txtJefeCatedra.Size = new System.Drawing.Size(364, 23);
            this.txtJefeCatedra.TabIndex = 4;
            // 
            // lblJefeCatedra
            // 
            this.lblJefeCatedra.AutoSize = true;
            this.lblJefeCatedra.Location = new System.Drawing.Point(3, 82);
            this.lblJefeCatedra.Name = "lblJefeCatedra";
            this.lblJefeCatedra.Size = new System.Drawing.Size(100, 16);
            this.lblJefeCatedra.TabIndex = 7;
            this.lblJefeCatedra.Text = "Jefe de cátedra:";
            // 
            // lblAñoInicio
            // 
            this.lblAñoInicio.AutoSize = true;
            this.lblAñoInicio.Location = new System.Drawing.Point(3, 346);
            this.lblAñoInicio.Name = "lblAñoInicio";
            this.lblAñoInicio.Size = new System.Drawing.Size(85, 16);
            this.lblAñoInicio.TabIndex = 9;
            this.lblAñoInicio.Text = "Año de inicio:";
            // 
            // lblAñoFin
            // 
            this.lblAñoFin.AutoSize = true;
            this.lblAñoFin.Location = new System.Drawing.Point(3, 387);
            this.lblAñoFin.Name = "lblAñoFin";
            this.lblAñoFin.Size = new System.Drawing.Size(70, 16);
            this.lblAñoFin.TabIndex = 11;
            this.lblAñoFin.Text = "Año de fin:";
            // 
            // nudAnioInicio
            // 
            this.nudAnioInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnioInicio.Location = new System.Drawing.Point(3, 362);
            this.nudAnioInicio.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.nudAnioInicio.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.nudAnioInicio.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nudAnioInicio.Name = "nudAnioInicio";
            this.nudAnioInicio.Size = new System.Drawing.Size(364, 23);
            this.nudAnioInicio.TabIndex = 11;
            this.nudAnioInicio.Value = new decimal(new int[] {
            1972,
            0,
            0,
            0});
            // 
            // nudAnioFin
            // 
            this.nudAnioFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnioFin.Location = new System.Drawing.Point(3, 403);
            this.nudAnioFin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.nudAnioFin.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.nudAnioFin.Name = "nudAnioFin";
            this.nudAnioFin.ReadOnly = true;
            this.nudAnioFin.Size = new System.Drawing.Size(364, 23);
            this.nudAnioFin.TabIndex = 13;
            // 
            // txtResolucion
            // 
            this.txtResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(3, 180);
            this.txtResolucion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtResolucion.MaxLength = 250;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(364, 23);
            this.txtResolucion.TabIndex = 8;
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new System.Drawing.Point(3, 164);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(73, 16);
            this.lblResolucion.TabIndex = 19;
            this.lblResolucion.Text = "Resolución:";
            // 
            // txtImagenDescriptiva
            // 
            this.txtImagenDescriptiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagenDescriptiva.Enabled = false;
            this.txtImagenDescriptiva.Location = new System.Drawing.Point(3, 139);
            this.txtImagenDescriptiva.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtImagenDescriptiva.MaxLength = 250;
            this.txtImagenDescriptiva.Name = "txtImagenDescriptiva";
            this.txtImagenDescriptiva.Size = new System.Drawing.Size(364, 23);
            this.txtImagenDescriptiva.TabIndex = 6;
            // 
            // lblImagenDescriptiva
            // 
            this.lblImagenDescriptiva.AutoSize = true;
            this.lblImagenDescriptiva.Location = new System.Drawing.Point(3, 123);
            this.lblImagenDescriptiva.Name = "lblImagenDescriptiva";
            this.lblImagenDescriptiva.Size = new System.Drawing.Size(120, 16);
            this.lblImagenDescriptiva.TabIndex = 23;
            this.lblImagenDescriptiva.Text = "Imagen descriptiva:";
            // 
            // txtNumeroResolucion
            // 
            this.txtNumeroResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroResolucion.Location = new System.Drawing.Point(403, 57);
            this.txtNumeroResolucion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtNumeroResolucion.MaxLength = 20;
            this.txtNumeroResolucion.Name = "txtNumeroResolucion";
            this.txtNumeroResolucion.Size = new System.Drawing.Size(364, 23);
            this.txtNumeroResolucion.TabIndex = 3;
            // 
            // lblNumeroResolucion
            // 
            this.lblNumeroResolucion.AutoSize = true;
            this.lblNumeroResolucion.Location = new System.Drawing.Point(403, 41);
            this.lblNumeroResolucion.Name = "lblNumeroResolucion";
            this.lblNumeroResolucion.Size = new System.Drawing.Size(109, 16);
            this.lblNumeroResolucion.TabIndex = 25;
            this.lblNumeroResolucion.Text = "N° de Resolución:";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Location = new System.Drawing.Point(403, 444);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtDuracion.MaxLength = 1;
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(364, 23);
            this.txtDuracion.TabIndex = 10;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(403, 428);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(62, 16);
            this.lblDuracion.TabIndex = 27;
            this.lblDuracion.Text = "Duración:";
            // 
            // txtPlanEstudio
            // 
            this.txtPlanEstudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlanEstudio.Enabled = false;
            this.txtPlanEstudio.Location = new System.Drawing.Point(403, 98);
            this.txtPlanEstudio.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtPlanEstudio.MaxLength = 250;
            this.txtPlanEstudio.Name = "txtPlanEstudio";
            this.txtPlanEstudio.Size = new System.Drawing.Size(364, 23);
            this.txtPlanEstudio.TabIndex = 5;
            // 
            // lblPlanEstudio
            // 
            this.lblPlanEstudio.AutoSize = true;
            this.lblPlanEstudio.Location = new System.Drawing.Point(403, 82);
            this.lblPlanEstudio.Name = "lblPlanEstudio";
            this.lblPlanEstudio.Size = new System.Drawing.Size(99, 16);
            this.lblPlanEstudio.TabIndex = 38;
            this.lblPlanEstudio.Text = "Plan de estudio:";
            // 
            // txtCantidadHoras
            // 
            this.txtCantidadHoras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadHoras.Location = new System.Drawing.Point(403, 362);
            this.txtCantidadHoras.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCantidadHoras.MaxLength = 4;
            this.txtCantidadHoras.Name = "txtCantidadHoras";
            this.txtCantidadHoras.Size = new System.Drawing.Size(364, 23);
            this.txtCantidadHoras.TabIndex = 12;
            // 
            // lblCantidadHoras
            // 
            this.lblCantidadHoras.AutoSize = true;
            this.lblCantidadHoras.Location = new System.Drawing.Point(403, 346);
            this.lblCantidadHoras.Name = "lblCantidadHoras";
            this.lblCantidadHoras.Size = new System.Drawing.Size(116, 16);
            this.lblCantidadHoras.TabIndex = 46;
            this.lblCantidadHoras.Text = "Cantidad de horas:";
            // 
            // epvCarreras
            // 
            this.epvCarreras.ContainerControl = this;
            this.epvCarreras.Icon = ((System.Drawing.Icon)(resources.GetObject("epvCarreras.Icon")));
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(3, 16);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 23);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 49;
            this.lblNombre.Text = "Nombre:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.btnPlanEstudio, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtImagenDescriptiva, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtResolucion, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtPlanEstudio, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcionCorta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloac, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTitulo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNumeroResolucion, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroResolucion, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblResolucion, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblJefeCatedra, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblImagenDescriptiva, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtJefeCatedra, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblPlanEstudio, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnResolucion, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnImagenDescriptiva, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblCarreraReemplazar, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtCarreraReemplazar, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblClasificacion, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblSectorActividad, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.cmbSectorActividad, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblFamiliaProfesional, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.cmbFamiliaProfesional, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblVariante, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.cmbVariante, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.lblModalidad, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.cmbModalidad, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.lblRegimen, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.cmbRegimenDefecto, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblAñoInicio, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.nudAnioInicio, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadHoras, 2, 17);
            this.tableLayoutPanel1.Controls.Add(this.txtCantidadHoras, 2, 18);
            this.tableLayoutPanel1.Controls.Add(this.lblAñoFin, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.nudAnioFin, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadCorrelativas, 2, 19);
            this.tableLayoutPanel1.Controls.Add(this.txtCantidadCorrelativas, 2, 20);
            this.tableLayoutPanel1.Controls.Add(this.lblDuracion, 2, 21);
            this.tableLayoutPanel1.Controls.Add(this.txtDuracion, 2, 22);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 2, 23);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 24;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 529);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // btnPlanEstudio
            // 
            this.btnPlanEstudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlanEstudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnPlanEstudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanEstudio.ForeColor = System.Drawing.Color.White;
            this.btnPlanEstudio.IconChar = FontAwesome.Sharp.IconChar.SortDesc;
            this.btnPlanEstudio.IconColor = System.Drawing.Color.White;
            this.btnPlanEstudio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlanEstudio.IconSize = 24;
            this.btnPlanEstudio.Location = new System.Drawing.Point(770, 98);
            this.btnPlanEstudio.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlanEstudio.Name = "btnPlanEstudio";
            this.btnPlanEstudio.Size = new System.Drawing.Size(31, 25);
            this.btnPlanEstudio.TabIndex = 54;
            this.btnPlanEstudio.UseVisualStyleBackColor = false;
            this.btnPlanEstudio.Click += new System.EventHandler(this.btnPlanEstudio_Click);
            // 
            // btnResolucion
            // 
            this.btnResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnResolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolucion.ForeColor = System.Drawing.Color.White;
            this.btnResolucion.IconChar = FontAwesome.Sharp.IconChar.SortDesc;
            this.btnResolucion.IconColor = System.Drawing.Color.White;
            this.btnResolucion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResolucion.IconSize = 24;
            this.btnResolucion.Location = new System.Drawing.Point(370, 180);
            this.btnResolucion.Margin = new System.Windows.Forms.Padding(0);
            this.btnResolucion.Name = "btnResolucion";
            this.btnResolucion.Size = new System.Drawing.Size(30, 25);
            this.btnResolucion.TabIndex = 53;
            this.btnResolucion.UseVisualStyleBackColor = false;
            this.btnResolucion.Click += new System.EventHandler(this.btnResolucion_Click);
            // 
            // btnImagenDescriptiva
            // 
            this.btnImagenDescriptiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImagenDescriptiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnImagenDescriptiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagenDescriptiva.ForeColor = System.Drawing.Color.White;
            this.btnImagenDescriptiva.IconChar = FontAwesome.Sharp.IconChar.SortDesc;
            this.btnImagenDescriptiva.IconColor = System.Drawing.Color.White;
            this.btnImagenDescriptiva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImagenDescriptiva.IconSize = 24;
            this.btnImagenDescriptiva.Location = new System.Drawing.Point(370, 139);
            this.btnImagenDescriptiva.Margin = new System.Windows.Forms.Padding(0);
            this.btnImagenDescriptiva.Name = "btnImagenDescriptiva";
            this.btnImagenDescriptiva.Size = new System.Drawing.Size(30, 25);
            this.btnImagenDescriptiva.TabIndex = 56;
            this.btnImagenDescriptiva.UseVisualStyleBackColor = false;
            this.btnImagenDescriptiva.Click += new System.EventHandler(this.btnImagenDescriptiva_Click);
            // 
            // lblCarreraReemplazar
            // 
            this.lblCarreraReemplazar.AutoSize = true;
            this.lblCarreraReemplazar.Location = new System.Drawing.Point(403, 123);
            this.lblCarreraReemplazar.Name = "lblCarreraReemplazar";
            this.lblCarreraReemplazar.Size = new System.Drawing.Size(136, 16);
            this.lblCarreraReemplazar.TabIndex = 59;
            this.lblCarreraReemplazar.Text = "Carrera a reemplazar:";
            // 
            // txtCarreraReemplazar
            // 
            this.txtCarreraReemplazar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarreraReemplazar.Enabled = false;
            this.txtCarreraReemplazar.Location = new System.Drawing.Point(403, 139);
            this.txtCarreraReemplazar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCarreraReemplazar.MaxLength = 150;
            this.txtCarreraReemplazar.Name = "txtCarreraReemplazar";
            this.txtCarreraReemplazar.Size = new System.Drawing.Size(364, 23);
            this.txtCarreraReemplazar.TabIndex = 60;
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblClasificacion, 4);
            this.lblClasificacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClasificacion.Location = new System.Drawing.Point(3, 205);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(85, 16);
            this.lblClasificacion.TabIndex = 71;
            this.lblClasificacion.Text = "Clasificación";
            // 
            // lblSectorActividad
            // 
            this.lblSectorActividad.AutoSize = true;
            this.lblSectorActividad.Location = new System.Drawing.Point(3, 223);
            this.lblSectorActividad.Name = "lblSectorActividad";
            this.lblSectorActividad.Size = new System.Drawing.Size(121, 16);
            this.lblSectorActividad.TabIndex = 61;
            this.lblSectorActividad.Text = "Sector de actividad:";
            // 
            // cmbSectorActividad
            // 
            this.cmbSectorActividad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSectorActividad.FormattingEnabled = true;
            this.cmbSectorActividad.Location = new System.Drawing.Point(3, 239);
            this.cmbSectorActividad.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbSectorActividad.Name = "cmbSectorActividad";
            this.cmbSectorActividad.Size = new System.Drawing.Size(364, 24);
            this.cmbSectorActividad.TabIndex = 62;
            // 
            // lblFamiliaProfesional
            // 
            this.lblFamiliaProfesional.AutoSize = true;
            this.lblFamiliaProfesional.Location = new System.Drawing.Point(403, 223);
            this.lblFamiliaProfesional.Name = "lblFamiliaProfesional";
            this.lblFamiliaProfesional.Size = new System.Drawing.Size(120, 16);
            this.lblFamiliaProfesional.TabIndex = 63;
            this.lblFamiliaProfesional.Text = "Familia profesional:";
            // 
            // cmbFamiliaProfesional
            // 
            this.cmbFamiliaProfesional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFamiliaProfesional.FormattingEnabled = true;
            this.cmbFamiliaProfesional.Location = new System.Drawing.Point(403, 239);
            this.cmbFamiliaProfesional.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbFamiliaProfesional.Name = "cmbFamiliaProfesional";
            this.cmbFamiliaProfesional.Size = new System.Drawing.Size(364, 24);
            this.cmbFamiliaProfesional.TabIndex = 64;
            // 
            // lblVariante
            // 
            this.lblVariante.AutoSize = true;
            this.lblVariante.Location = new System.Drawing.Point(3, 264);
            this.lblVariante.Name = "lblVariante";
            this.lblVariante.Size = new System.Drawing.Size(60, 16);
            this.lblVariante.TabIndex = 65;
            this.lblVariante.Text = "Variante:";
            // 
            // cmbVariante
            // 
            this.cmbVariante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVariante.FormattingEnabled = true;
            this.cmbVariante.Location = new System.Drawing.Point(3, 280);
            this.cmbVariante.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbVariante.Name = "cmbVariante";
            this.cmbVariante.Size = new System.Drawing.Size(364, 24);
            this.cmbVariante.TabIndex = 66;
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Location = new System.Drawing.Point(403, 264);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(70, 16);
            this.lblModalidad.TabIndex = 67;
            this.lblModalidad.Text = "Modalidad:";
            // 
            // cmbModalidad
            // 
            this.cmbModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModalidad.FormattingEnabled = true;
            this.cmbModalidad.Location = new System.Drawing.Point(403, 280);
            this.cmbModalidad.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbModalidad.Name = "cmbModalidad";
            this.cmbModalidad.Size = new System.Drawing.Size(364, 24);
            this.cmbModalidad.TabIndex = 68;
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(3, 305);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(62, 16);
            this.lblRegimen.TabIndex = 69;
            this.lblRegimen.Text = "Régimen:";
            // 
            // cmbRegimenDefecto
            // 
            this.cmbRegimenDefecto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegimenDefecto.FormattingEnabled = true;
            this.cmbRegimenDefecto.Location = new System.Drawing.Point(3, 321);
            this.cmbRegimenDefecto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbRegimenDefecto.Name = "cmbRegimenDefecto";
            this.cmbRegimenDefecto.Size = new System.Drawing.Size(364, 24);
            this.cmbRegimenDefecto.TabIndex = 70;
            // 
            // lblCantidadCorrelativas
            // 
            this.lblCantidadCorrelativas.AutoSize = true;
            this.lblCantidadCorrelativas.Location = new System.Drawing.Point(403, 387);
            this.lblCantidadCorrelativas.Name = "lblCantidadCorrelativas";
            this.lblCantidadCorrelativas.Size = new System.Drawing.Size(150, 16);
            this.lblCantidadCorrelativas.TabIndex = 58;
            this.lblCantidadCorrelativas.Text = "Cantidad de correlativas:";
            // 
            // txtCantidadCorrelativas
            // 
            this.txtCantidadCorrelativas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadCorrelativas.Location = new System.Drawing.Point(403, 403);
            this.txtCantidadCorrelativas.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCantidadCorrelativas.MaxLength = 2;
            this.txtCantidadCorrelativas.Name = "txtCantidadCorrelativas";
            this.txtCantidadCorrelativas.Size = new System.Drawing.Size(364, 23);
            this.txtCantidadCorrelativas.TabIndex = 57;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnGuardar, 2);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 24;
            this.btnGuardar.Location = new System.Drawing.Point(659, 487);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(139, 39);
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormAgregarModificarCarrera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAgregarModificarCarrera";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "FormAgregarCarrera";
            this.Load += new System.EventHandler(this.FormAgregarModificarCarrera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvCarreras)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTituloac;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblJefeCatedra;
        private System.Windows.Forms.Label lblAñoInicio;
        private System.Windows.Forms.Label lblAñoFin;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.Label lblImagenDescriptiva;
        private System.Windows.Forms.Label lblNumeroResolucion;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.OpenFileDialog ofdCarreras;
        private System.Windows.Forms.Label lblPlanEstudio;
        private System.Windows.Forms.Label lblCantidadHoras;
        public System.Windows.Forms.TextBox txtTitulo;
        public System.Windows.Forms.TextBox txtDescripcionCorta;
        public System.Windows.Forms.TextBox txtJefeCatedra;
        public System.Windows.Forms.NumericUpDown nudAnioInicio;
        public System.Windows.Forms.NumericUpDown nudAnioFin;
        public System.Windows.Forms.TextBox txtResolucion;
        public System.Windows.Forms.TextBox txtImagenDescriptiva;
        public System.Windows.Forms.TextBox txtNumeroResolucion;
        public System.Windows.Forms.TextBox txtDuracion;
        public System.Windows.Forms.TextBox txtPlanEstudio;
        public System.Windows.Forms.TextBox txtCantidadHoras;
        private System.Windows.Forms.ErrorProvider epvCarreras;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnResolucion;
        private FontAwesome.Sharp.IconButton btnPlanEstudio;
        private FontAwesome.Sharp.IconButton btnImagenDescriptiva;
        public System.Windows.Forms.TextBox txtCantidadCorrelativas;
        private System.Windows.Forms.Label lblCantidadCorrelativas;
        private System.Windows.Forms.Label lblCarreraReemplazar;
        public System.Windows.Forms.TextBox txtCarreraReemplazar;

        // Controles de Clasificación y Régimen
        private System.Windows.Forms.Label lblSectorActividad;
        public System.Windows.Forms.ComboBox cmbSectorActividad;
        private System.Windows.Forms.Label lblFamiliaProfesional;
        public System.Windows.Forms.ComboBox cmbFamiliaProfesional;
        private System.Windows.Forms.Label lblVariante;
        public System.Windows.Forms.ComboBox cmbVariante;
        private System.Windows.Forms.Label lblModalidad;
        public System.Windows.Forms.ComboBox cmbModalidad;
        private System.Windows.Forms.Label lblRegimen;
        public System.Windows.Forms.ComboBox cmbRegimenDefecto;
        private System.Windows.Forms.Label lblClasificacion;
    }
}
