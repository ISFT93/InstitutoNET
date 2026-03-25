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
            this.txtCorrelatividades = new System.Windows.Forms.TextBox();
            this.lblCorrelatividades = new System.Windows.Forms.Label();
            this.txtImagenDescriptiva = new System.Windows.Forms.TextBox();
            this.lblImagenDescriptiva = new System.Windows.Forms.Label();
            this.txtNumeroExpediente = new System.Windows.Forms.TextBox();
            this.lblNumeroExpediente = new System.Windows.Forms.Label();
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
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCorrelatividades = new FontAwesome.Sharp.IconButton();
            this.btnResolucion = new FontAwesome.Sharp.IconButton();
            this.btnImagenDescriptiva = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epvCarreras)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloac
            // 
            this.lblTituloac.AutoSize = true;
            this.lblTituloac.Location = new System.Drawing.Point(3, 60);
            this.lblTituloac.Name = "lblTituloac";
            this.lblTituloac.Size = new System.Drawing.Size(79, 20);
            this.lblTituloac.TabIndex = 3;
            this.lblTituloac.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Location = new System.Drawing.Point(3, 83);
            this.txtTitulo.MaxLength = 150;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(352, 36);
            this.txtTitulo.TabIndex = 2;
            // 
            // txtDescripcionCorta
            // 
            this.txtDescripcionCorta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionCorta.Location = new System.Drawing.Point(391, 26);
            this.txtDescripcionCorta.MaxLength = 30;
            this.txtDescripcionCorta.Multiline = true;
            this.txtDescripcionCorta.Name = "txtDescripcionCorta";
            this.txtDescripcionCorta.Size = new System.Drawing.Size(352, 27);
            this.txtDescripcionCorta.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(391, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(141, 20);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtJefeCatedra
            // 
            this.txtJefeCatedra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJefeCatedra.Enabled = false;
            this.txtJefeCatedra.Location = new System.Drawing.Point(3, 143);
            this.txtJefeCatedra.MaxLength = 100;
            this.txtJefeCatedra.Name = "txtJefeCatedra";
            this.txtJefeCatedra.Size = new System.Drawing.Size(352, 36);
            this.txtJefeCatedra.TabIndex = 4;
            // 
            // lblJefeCatedra
            // 
            this.lblJefeCatedra.AutoSize = true;
            this.lblJefeCatedra.Location = new System.Drawing.Point(3, 120);
            this.lblJefeCatedra.Name = "lblJefeCatedra";
            this.lblJefeCatedra.Size = new System.Drawing.Size(187, 20);
            this.lblJefeCatedra.TabIndex = 7;
            this.lblJefeCatedra.Text = "Jefe de cátedra:";
            // 
            // lblAñoInicio
            // 
            this.lblAñoInicio.AutoSize = true;
            this.lblAñoInicio.Location = new System.Drawing.Point(3, 300);
            this.lblAñoInicio.Name = "lblAñoInicio";
            this.lblAñoInicio.Size = new System.Drawing.Size(155, 20);
            this.lblAñoInicio.TabIndex = 9;
            this.lblAñoInicio.Text = "Año de inicio:";
            // 
            // lblAñoFin
            // 
            this.lblAñoFin.AutoSize = true;
            this.lblAñoFin.Location = new System.Drawing.Point(3, 360);
            this.lblAñoFin.Name = "lblAñoFin";
            this.lblAñoFin.Size = new System.Drawing.Size(129, 20);
            this.lblAñoFin.TabIndex = 11;
            this.lblAñoFin.Text = "Año de fin:";
            // 
            // nudAnioInicio
            // 
            this.nudAnioInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnioInicio.Location = new System.Drawing.Point(3, 323);
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
            this.nudAnioInicio.Size = new System.Drawing.Size(352, 36);
            this.nudAnioInicio.TabIndex = 11;
            this.nudAnioInicio.Value = new decimal(new int[] {
            1972,
            0,
            0,
            0});
            // 
            // nudAnioFin
            // 
            this.nudAnioFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAnioFin.Location = new System.Drawing.Point(3, 383);
            this.nudAnioFin.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.nudAnioFin.Name = "nudAnioFin";
            this.nudAnioFin.ReadOnly = true;
            this.nudAnioFin.Size = new System.Drawing.Size(352, 36);
            this.nudAnioFin.TabIndex = 13;
            // 
            // txtResolucion
            // 
            this.txtResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResolucion.Enabled = false;
            this.txtResolucion.Location = new System.Drawing.Point(3, 263);
            this.txtResolucion.MaxLength = 250;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(352, 36);
            this.txtResolucion.TabIndex = 8;
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new System.Drawing.Point(3, 240);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(133, 20);
            this.lblResolucion.TabIndex = 19;
            this.lblResolucion.Text = "Resolución:";
            // 
            // txtCorrelatividades
            // 
            this.txtCorrelatividades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrelatividades.Enabled = false;
            this.txtCorrelatividades.Location = new System.Drawing.Point(391, 203);
            this.txtCorrelatividades.MaxLength = 250;
            this.txtCorrelatividades.Name = "txtCorrelatividades";
            this.txtCorrelatividades.Size = new System.Drawing.Size(352, 36);
            this.txtCorrelatividades.TabIndex = 7;
            // 
            // lblCorrelatividades
            // 
            this.lblCorrelatividades.AutoSize = true;
            this.lblCorrelatividades.Location = new System.Drawing.Point(391, 180);
            this.lblCorrelatividades.Name = "lblCorrelatividades";
            this.lblCorrelatividades.Size = new System.Drawing.Size(190, 20);
            this.lblCorrelatividades.TabIndex = 21;
            this.lblCorrelatividades.Text = "Correlatividades:";
            // 
            // txtImagenDescriptiva
            // 
            this.txtImagenDescriptiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagenDescriptiva.Enabled = false;
            this.txtImagenDescriptiva.Location = new System.Drawing.Point(3, 203);
            this.txtImagenDescriptiva.MaxLength = 250;
            this.txtImagenDescriptiva.Name = "txtImagenDescriptiva";
            this.txtImagenDescriptiva.Size = new System.Drawing.Size(352, 36);
            this.txtImagenDescriptiva.TabIndex = 6;
            // 
            // lblImagenDescriptiva
            // 
            this.lblImagenDescriptiva.AutoSize = true;
            this.lblImagenDescriptiva.Location = new System.Drawing.Point(3, 180);
            this.lblImagenDescriptiva.Name = "lblImagenDescriptiva";
            this.lblImagenDescriptiva.Size = new System.Drawing.Size(223, 20);
            this.lblImagenDescriptiva.TabIndex = 23;
            this.lblImagenDescriptiva.Text = "Imagen descriptiva:";
            // 
            // txtNumeroExpediente
            // 
            this.txtNumeroExpediente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroExpediente.Location = new System.Drawing.Point(391, 83);
            this.txtNumeroExpediente.MaxLength = 20;
            this.txtNumeroExpediente.Name = "txtNumeroExpediente";
            this.txtNumeroExpediente.Size = new System.Drawing.Size(352, 36);
            this.txtNumeroExpediente.TabIndex = 3;
            // 
            // lblNumeroExpediente
            // 
            this.lblNumeroExpediente.AutoSize = true;
            this.lblNumeroExpediente.Location = new System.Drawing.Point(391, 60);
            this.lblNumeroExpediente.Name = "lblNumeroExpediente";
            this.lblNumeroExpediente.Size = new System.Drawing.Size(206, 20);
            this.lblNumeroExpediente.TabIndex = 25;
            this.lblNumeroExpediente.Text = "N° de expediente:";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Location = new System.Drawing.Point(391, 263);
            this.txtDuracion.MaxLength = 1;
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(352, 36);
            this.txtDuracion.TabIndex = 10;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(391, 240);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(114, 20);
            this.lblDuracion.TabIndex = 27;
            this.lblDuracion.Text = "Duración:";
            // 
            // txtPlanEstudio
            // 
            this.txtPlanEstudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlanEstudio.Enabled = false;
            this.txtPlanEstudio.Location = new System.Drawing.Point(391, 143);
            this.txtPlanEstudio.MaxLength = 250;
            this.txtPlanEstudio.Name = "txtPlanEstudio";
            this.txtPlanEstudio.Size = new System.Drawing.Size(352, 36);
            this.txtPlanEstudio.TabIndex = 5;
            // 
            // lblPlanEstudio
            // 
            this.lblPlanEstudio.AutoSize = true;
            this.lblPlanEstudio.Location = new System.Drawing.Point(391, 120);
            this.lblPlanEstudio.Name = "lblPlanEstudio";
            this.lblPlanEstudio.Size = new System.Drawing.Size(183, 20);
            this.lblPlanEstudio.TabIndex = 38;
            this.lblPlanEstudio.Text = "Plan de estudio:";
            // 
            // txtCantidadHoras
            // 
            this.txtCantidadHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadHoras.Location = new System.Drawing.Point(391, 323);
            this.txtCantidadHoras.MaxLength = 4;
            this.txtCantidadHoras.Name = "txtCantidadHoras";
            this.txtCantidadHoras.Size = new System.Drawing.Size(352, 36);
            this.txtCantidadHoras.TabIndex = 12;
            // 
            // lblCantidadHoras
            // 
            this.lblCantidadHoras.AutoSize = true;
            this.lblCantidadHoras.Location = new System.Drawing.Point(391, 300);
            this.lblCantidadHoras.Name = "lblCantidadHoras";
            this.lblCantidadHoras.Size = new System.Drawing.Size(214, 20);
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
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(3, 23);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(352, 36);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(105, 20);
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
            this.tableLayoutPanel1.Controls.Add(this.txtCantidadHoras, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcionCorta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudAnioFin, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloac, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAñoFin, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.txtTitulo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDuracion, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.nudAnioInicio, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblNumeroExpediente, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDuracion, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblAñoInicio, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroExpediente, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCorrelatividades, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblResolucion, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblCorrelatividades, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblJefeCatedra, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblImagenDescriptiva, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtJefeCatedra, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblPlanEstudio, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadHoras, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.btnCorrelatividades, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnResolucion, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnImagenDescriptiva, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 503);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // btnPlanEstudio
            // 
            this.btnPlanEstudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlanEstudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnPlanEstudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanEstudio.ForeColor = System.Drawing.Color.White;
            this.btnPlanEstudio.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnPlanEstudio.IconColor = System.Drawing.Color.White;
            this.btnPlanEstudio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlanEstudio.IconSize = 32;
            this.btnPlanEstudio.Location = new System.Drawing.Point(746, 146);
            this.btnPlanEstudio.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnPlanEstudio.Name = "btnPlanEstudio";
            this.btnPlanEstudio.Size = new System.Drawing.Size(31, 27);
            this.btnPlanEstudio.TabIndex = 54;
            this.btnPlanEstudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlanEstudio.UseVisualStyleBackColor = false;
            this.btnPlanEstudio.Click += new System.EventHandler(this.btnPlanEstudio_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnGuardar, 2);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(605, 450);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(169, 50);
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCorrelatividades
            // 
            this.btnCorrelatividades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCorrelatividades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnCorrelatividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrelatividades.ForeColor = System.Drawing.Color.White;
            this.btnCorrelatividades.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnCorrelatividades.IconColor = System.Drawing.Color.White;
            this.btnCorrelatividades.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCorrelatividades.IconSize = 32;
            this.btnCorrelatividades.Location = new System.Drawing.Point(746, 206);
            this.btnCorrelatividades.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnCorrelatividades.Name = "btnCorrelatividades";
            this.btnCorrelatividades.Size = new System.Drawing.Size(31, 27);
            this.btnCorrelatividades.TabIndex = 52;
            this.btnCorrelatividades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCorrelatividades.UseVisualStyleBackColor = false;
            this.btnCorrelatividades.Click += new System.EventHandler(this.btnCorrelatividades_Click);
            // 
            // btnResolucion
            // 
            this.btnResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnResolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolucion.ForeColor = System.Drawing.Color.White;
            this.btnResolucion.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnResolucion.IconColor = System.Drawing.Color.White;
            this.btnResolucion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResolucion.IconSize = 32;
            this.btnResolucion.Location = new System.Drawing.Point(358, 266);
            this.btnResolucion.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnResolucion.Name = "btnResolucion";
            this.btnResolucion.Size = new System.Drawing.Size(30, 27);
            this.btnResolucion.TabIndex = 53;
            this.btnResolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResolucion.UseVisualStyleBackColor = false;
            this.btnResolucion.Click += new System.EventHandler(this.btnResolucion_Click);
            // 
            // btnImagenDescriptiva
            // 
            this.btnImagenDescriptiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImagenDescriptiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnImagenDescriptiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagenDescriptiva.ForeColor = System.Drawing.Color.White;
            this.btnImagenDescriptiva.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnImagenDescriptiva.IconColor = System.Drawing.Color.White;
            this.btnImagenDescriptiva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImagenDescriptiva.IconSize = 32;
            this.btnImagenDescriptiva.Location = new System.Drawing.Point(358, 206);
            this.btnImagenDescriptiva.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnImagenDescriptiva.Name = "btnImagenDescriptiva";
            this.btnImagenDescriptiva.Size = new System.Drawing.Size(30, 27);
            this.btnImagenDescriptiva.TabIndex = 56;
            this.btnImagenDescriptiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImagenDescriptiva.UseVisualStyleBackColor = false;
            this.btnImagenDescriptiva.Click += new System.EventHandler(this.btnImagenDescriptiva_Click);
            // 
            // FormAgregarModificarCarrera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAgregarModificarCarrera";
            this.Padding = new System.Windows.Forms.Padding(20);
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
        private System.Windows.Forms.Label lblCorrelatividades;
        private System.Windows.Forms.Label lblImagenDescriptiva;
        private System.Windows.Forms.Label lblNumeroExpediente;
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
        public System.Windows.Forms.TextBox txtCorrelatividades;
        public System.Windows.Forms.TextBox txtImagenDescriptiva;
        public System.Windows.Forms.TextBox txtNumeroExpediente;
        public System.Windows.Forms.TextBox txtDuracion;
        public System.Windows.Forms.TextBox txtPlanEstudio;
        public System.Windows.Forms.TextBox txtCantidadHoras;
        private System.Windows.Forms.ErrorProvider epvCarreras;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCorrelatividades;
        private FontAwesome.Sharp.IconButton btnResolucion;
        private FontAwesome.Sharp.IconButton btnPlanEstudio;
        private FontAwesome.Sharp.IconButton btnImagenDescriptiva;
    }
}