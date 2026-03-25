namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormAgregarModificarPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarPersonal));
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTituloProf = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.ofdProfesores = new System.Windows.Forms.OpenFileDialog();
            this.epvProfesores = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbTramoPedagogico = new System.Windows.Forms.ComboBox();
            this.lblTramo = new System.Windows.Forms.Label();
            this.cmbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.gbxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFoto = new FontAwesome.Sharp.IconButton();
            this.dbxDireccion = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxDatosProfesionales = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesores)).BeginInit();
            this.gbxDatosPersonales.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.dbxDireccion.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxDatosProfesionales.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(3, 60);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(180, 19);
            this.lblNumeroDocumento.TabIndex = 1;
            this.lblNumeroDocumento.Text = "Número de Documento:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(3, 86);
            this.txtNumeroDocumento.MaxLength = 9;
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(349, 27);
            this.txtNumeroDocumento.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(3, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(349, 27);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 19);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtApellido, 2);
            this.txtApellido.Location = new System.Drawing.Point(388, 26);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(380, 27);
            this.txtApellido.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(388, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(73, 19);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(388, 60);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(161, 19);
            this.lblFechaNacimiento.TabIndex = 7;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dtpFechaNacimiento, 2);
            this.dtpFechaNacimiento.CustomFormat = "";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(388, 86);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(380, 27);
            this.dtpFechaNacimiento.TabIndex = 3;
            this.dtpFechaNacimiento.Value = new System.DateTime(2020, 8, 30, 0, 0, 0, 0);
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(3, 120);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(49, 19);
            this.lblSexo.TabIndex = 9;
            this.lblSexo.Text = "Sexo:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.Location = new System.Drawing.Point(3, 26);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(349, 27);
            this.txtDireccion.TabIndex = 6;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(3, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(49, 19);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Calle:";
            // 
            // txtPiso
            // 
            this.txtPiso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPiso.Location = new System.Drawing.Point(388, 26);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(171, 27);
            this.txtPiso.TabIndex = 8;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(388, 0);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(44, 19);
            this.lblPiso.TabIndex = 14;
            this.lblPiso.Text = "Piso:";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepartamento.Location = new System.Drawing.Point(595, 26);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(173, 27);
            this.txtDepartamento.TabIndex = 10;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(595, 0);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(115, 19);
            this.lblDepartamento.TabIndex = 16;
            this.lblDepartamento.Text = "Departamento:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalidad.Location = new System.Drawing.Point(3, 86);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(349, 27);
            this.txtLocalidad.TabIndex = 12;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(3, 60);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(81, 19);
            this.lblLocalidad.TabIndex = 18;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // txtCelular
            // 
            this.txtCelular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtCelular, 3);
            this.txtCelular.Location = new System.Drawing.Point(388, 149);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(380, 27);
            this.txtCelular.TabIndex = 16;
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(388, 120);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(64, 19);
            this.lblCelular.TabIndex = 20;
            this.lblCelular.Text = "Celular:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.Location = new System.Drawing.Point(3, 149);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(349, 27);
            this.txtTelefono.TabIndex = 14;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(3, 120);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(77, 19);
            this.lblTelefono.TabIndex = 22;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNacionalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNacionalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNacionalidad.Location = new System.Drawing.Point(3, 210);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(349, 27);
            this.txtNacionalidad.TabIndex = 9;
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Location = new System.Drawing.Point(3, 180);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(105, 19);
            this.lblNacionalidad.TabIndex = 24;
            this.lblNacionalidad.Text = "Nacionalidad:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtEmail, 3);
            this.txtEmail.Location = new System.Drawing.Point(388, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(380, 27);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(388, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 26;
            this.lblEmail.Text = "Email:";
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Location = new System.Drawing.Point(388, 120);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(97, 19);
            this.lblEstadoCivil.TabIndex = 28;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Location = new System.Drawing.Point(3, 32);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(349, 27);
            this.txtTitulo.TabIndex = 4;
            // 
            // lblTituloProf
            // 
            this.lblTituloProf.AutoSize = true;
            this.lblTituloProf.Location = new System.Drawing.Point(3, 0);
            this.lblTituloProf.Name = "lblTituloProf";
            this.lblTituloProf.Size = new System.Drawing.Size(56, 19);
            this.lblTituloProf.TabIndex = 30;
            this.lblTituloProf.Text = "Título:";
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(388, 180);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(46, 19);
            this.lblFoto.TabIndex = 33;
            this.lblFoto.Text = "Foto:";
            // 
            // txtFoto
            // 
            this.txtFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFoto.Enabled = false;
            this.txtFoto.Location = new System.Drawing.Point(388, 210);
            this.txtFoto.MaxLength = 250;
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(349, 27);
            this.txtFoto.TabIndex = 11;
            // 
            // ofdProfesores
            // 
            this.ofdProfesores.FileName = "openFileDialog1";
            // 
            // epvProfesores
            // 
            this.epvProfesores.ContainerControl = this;
            this.epvProfesores.Icon = ((System.Drawing.Icon)(resources.GetObject("epvProfesores.Icon")));
            // 
            // cmbTramoPedagogico
            // 
            this.cmbTramoPedagogico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbTramoPedagogico, 2);
            this.cmbTramoPedagogico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramoPedagogico.FormattingEnabled = true;
            this.cmbTramoPedagogico.Location = new System.Drawing.Point(388, 35);
            this.cmbTramoPedagogico.Name = "cmbTramoPedagogico";
            this.cmbTramoPedagogico.Size = new System.Drawing.Size(380, 27);
            this.cmbTramoPedagogico.TabIndex = 15;
            // 
            // lblTramo
            // 
            this.lblTramo.AutoSize = true;
            this.lblTramo.Location = new System.Drawing.Point(388, 0);
            this.lblTramo.Name = "lblTramo";
            this.lblTramo.Size = new System.Drawing.Size(148, 19);
            this.lblTramo.TabIndex = 41;
            this.lblTramo.Text = "Tramo pedagógico:";
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbEstadoCivil, 2);
            this.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Separado/a",
            "Viudo/a"});
            this.cmbEstadoCivil.Location = new System.Drawing.Point(388, 146);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(380, 27);
            this.cmbEstadoCivil.TabIndex = 5;
            // 
            // cmbSexo
            // 
            this.cmbSexo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cmbSexo.Location = new System.Drawing.Point(3, 146);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(349, 27);
            this.cmbSexo.TabIndex = 4;
            // 
            // gbxDatosPersonales
            // 
            this.gbxDatosPersonales.Controls.Add(this.tableLayoutPanel1);
            this.gbxDatosPersonales.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDatosPersonales.Location = new System.Drawing.Point(20, 20);
            this.gbxDatosPersonales.Name = "gbxDatosPersonales";
            this.gbxDatosPersonales.Size = new System.Drawing.Size(777, 273);
            this.gbxDatosPersonales.TabIndex = 42;
            this.gbxDatosPersonales.TabStop = false;
            this.gbxDatosPersonales.Text = "Datos Personales";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.btnFoto, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEstadoCivil, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNacionalidad, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbSexo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaNacimiento, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblApellido, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNumeroDocumento, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEstadoCivil, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroDocumento, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaNacimiento, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSexo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNacionalidad, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblFoto, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtFoto, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 247);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // btnFoto
            // 
            this.btnFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoto.ForeColor = System.Drawing.Color.White;
            this.btnFoto.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnFoto.IconColor = System.Drawing.Color.White;
            this.btnFoto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFoto.IconSize = 32;
            this.btnFoto.Location = new System.Drawing.Point(740, 210);
            this.btnFoto.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(31, 27);
            this.btnFoto.TabIndex = 53;
            this.btnFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoto.UseVisualStyleBackColor = false;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // dbxDireccion
            // 
            this.dbxDireccion.Controls.Add(this.tableLayoutPanel2);
            this.dbxDireccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.dbxDireccion.Location = new System.Drawing.Point(20, 293);
            this.dbxDireccion.Name = "dbxDireccion";
            this.dbxDireccion.Size = new System.Drawing.Size(777, 211);
            this.dbxDireccion.TabIndex = 43;
            this.dbxDireccion.TabStop = false;
            this.dbxDireccion.Text = "Dirección";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblDireccion, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTelefono, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtDireccion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLocalidad, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblLocalidad, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTelefono, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblPiso, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPiso, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblEmail, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCelular, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtEmail, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtCelular, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblDepartamento, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDepartamento, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(771, 185);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // gbxDatosProfesionales
            // 
            this.gbxDatosProfesionales.Controls.Add(this.tableLayoutPanel3);
            this.gbxDatosProfesionales.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDatosProfesionales.Location = new System.Drawing.Point(20, 504);
            this.gbxDatosProfesionales.Name = "gbxDatosProfesionales";
            this.gbxDatosProfesionales.Size = new System.Drawing.Size(777, 98);
            this.gbxDatosProfesionales.TabIndex = 44;
            this.gbxDatosProfesionales.TabStop = false;
            this.gbxDatosProfesionales.Text = "Datos Profesionales";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Controls.Add(this.lblTituloProf, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbTramoPedagogico, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTramo, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTitulo, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(771, 72);
            this.tableLayoutPanel3.TabIndex = 42;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(658, 612);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 50);
            this.btnGuardar.TabIndex = 52;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormAgregarModificarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 685);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbxDatosProfesionales);
            this.Controls.Add(this.dbxDireccion);
            this.Controls.Add(this.gbxDatosPersonales);
            this.Name = "FormAgregarModificarPersonal";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormProfesores";
            this.Load += new System.EventHandler(this.FormAgregarProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epvProfesores)).EndInit();
            this.gbxDatosPersonales.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.dbxDireccion.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbxDatosProfesionales.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTituloProf;
        private System.Windows.Forms.Label lblFoto;
        public System.Windows.Forms.TextBox txtFoto;
        private System.Windows.Forms.OpenFileDialog ofdProfesores;
        private System.Windows.Forms.ErrorProvider epvProfesores;
        private System.Windows.Forms.Label lblTramo;
        private System.Windows.Forms.ComboBox cmbTramoPedagogico;
        private System.Windows.Forms.ComboBox cmbEstadoCivil;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.GroupBox gbxDatosProfesionales;
        private System.Windows.Forms.GroupBox dbxDireccion;
        private System.Windows.Forms.GroupBox gbxDatosPersonales;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnFoto;
    }
}