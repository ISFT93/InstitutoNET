namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormPersonal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonal));
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblSelccFiltro = new System.Windows.Forms.Label();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbInactivos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.cmsPersonal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDarAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDarBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tsmVerLegajo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLicencias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDocumentacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtFiltro, 3);
            this.txtFiltro.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.Black;
            this.txtFiltro.Location = new System.Drawing.Point(3, 46);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(372, 27);
            this.txtFiltro.TabIndex = 3;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltro.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbFiltro, 2);
            this.cmbFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Todos",
            "Numero de Documento",
            "Nombre",
            "Apellido"});
            this.cmbFiltro.Location = new System.Drawing.Point(129, 9);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(246, 27);
            this.cmbFiltro.TabIndex = 41;
            // 
            // lblSelccFiltro
            // 
            this.lblSelccFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelccFiltro.AutoSize = true;
            this.lblSelccFiltro.Location = new System.Drawing.Point(3, 10);
            this.lblSelccFiltro.Name = "lblSelccFiltro";
            this.lblSelccFiltro.Size = new System.Drawing.Size(120, 19);
            this.lblSelccFiltro.TabIndex = 42;
            this.lblSelccFiltro.Text = "Filtro:";
            // 
            // rbActivos
            // 
            this.rbActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbActivos.Location = new System.Drawing.Point(3, 88);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(120, 23);
            this.rbActivos.TabIndex = 52;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Activos";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // rbInactivos
            // 
            this.rbInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInactivos.AutoSize = true;
            this.rbInactivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbInactivos.Location = new System.Drawing.Point(129, 88);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(120, 23);
            this.rbInactivos.TabIndex = 51;
            this.rbInactivos.Text = "Inactivos";
            this.rbInactivos.UseVisualStyleBackColor = true;
            this.rbInactivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbTodos.Location = new System.Drawing.Point(255, 88);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(120, 23);
            this.rbTodos.TabIndex = 53;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeColumns = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            this.dgvPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersonal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPersonal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonal.EnableHeadersVisualStyles = false;
            this.dgvPersonal.GridColor = System.Drawing.Color.White;
            this.dgvPersonal.Location = new System.Drawing.Point(20, 165);
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPersonal.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPersonal.RowTemplate.Height = 28;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.Size = new System.Drawing.Size(777, 360);
            this.dgvPersonal.TabIndex = 54;
            this.dgvPersonal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvPersonal_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.01001F));
            this.tableLayoutPanel1.Controls.Add(this.lblSelccFiltro, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbFiltro, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFiltro, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbActivos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbInactivos, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 145);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBuscar.Location = new System.Drawing.Point(641, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.tableLayoutPanel1.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(133, 50);
            this.btnBuscar.TabIndex = 54;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmsPersonal
            // 
            this.cmsPersonal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsPersonal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarPersonal,
            this.tsmModificarPersonal,
            this.tsmDarAlta,
            this.tsmDarBaja,
            this.tsmSeparador,
            this.tsmVerLegajo,
            this.tsmVerServicios,
            this.tsmHorarios,
            this.tsmLicencias,
            this.tsmDocumentacion,
            this.tsmEliminar});
            this.cmsPersonal.Name = "contextMenuStrip1";
            this.cmsPersonal.Size = new System.Drawing.Size(194, 316);
            // 
            // tsmAgregarPersonal
            // 
            this.tsmAgregarPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarPersonal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAgregarPersonal.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmAgregarPersonal.Image = global::ISFDyT93.Vista.Properties.Resources.user_plus_solid;
            this.tsmAgregarPersonal.Name = "tsmAgregarPersonal";
            this.tsmAgregarPersonal.Size = new System.Drawing.Size(193, 30);
            this.tsmAgregarPersonal.Text = "Agregar";
            this.tsmAgregarPersonal.Click += new System.EventHandler(this.tsmAgregarPersonal_Click);
            // 
            // tsmModificarPersonal
            // 
            this.tsmModificarPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarPersonal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarPersonal.ForeColor = System.Drawing.Color.White;
            this.tsmModificarPersonal.Image = global::ISFDyT93.Vista.Properties.Resources.edit_solid;
            this.tsmModificarPersonal.Name = "tsmModificarPersonal";
            this.tsmModificarPersonal.Size = new System.Drawing.Size(193, 30);
            this.tsmModificarPersonal.Text = "Modificar";
            this.tsmModificarPersonal.Click += new System.EventHandler(this.tsmModificarPersonal_Click);
            // 
            // tsmDarAlta
            // 
            this.tsmDarAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDarAlta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDarAlta.ForeColor = System.Drawing.Color.White;
            this.tsmDarAlta.Image = ((System.Drawing.Image)(resources.GetObject("tsmDarAlta.Image")));
            this.tsmDarAlta.Name = "tsmDarAlta";
            this.tsmDarAlta.Size = new System.Drawing.Size(193, 30);
            this.tsmDarAlta.Text = "Dar de Alta";
            this.tsmDarAlta.Click += new System.EventHandler(this.tsmDarAlta_Click);
            // 
            // tsmDarBaja
            // 
            this.tsmDarBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDarBaja.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDarBaja.ForeColor = System.Drawing.Color.White;
            this.tsmDarBaja.Image = global::ISFDyT93.Vista.Properties.Resources.minus_circle_solid;
            this.tsmDarBaja.Name = "tsmDarBaja";
            this.tsmDarBaja.Size = new System.Drawing.Size(193, 30);
            this.tsmDarBaja.Text = "Dar de Baja";
            this.tsmDarBaja.Click += new System.EventHandler(this.tsmDarBaja_Click);
            // 
            // tsmSeparador
            // 
            this.tsmSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmSeparador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmSeparador.Name = "tsmSeparador";
            this.tsmSeparador.Size = new System.Drawing.Size(190, 6);
            // 
            // tsmVerLegajo
            // 
            this.tsmVerLegajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerLegajo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerLegajo.ForeColor = System.Drawing.Color.White;
            this.tsmVerLegajo.Image = ((System.Drawing.Image)(resources.GetObject("tsmVerLegajo.Image")));
            this.tsmVerLegajo.Name = "tsmVerLegajo";
            this.tsmVerLegajo.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.tsmVerLegajo.Size = new System.Drawing.Size(193, 36);
            this.tsmVerLegajo.Text = "Ver Legajo";
            this.tsmVerLegajo.Click += new System.EventHandler(this.tsmVerLegajo_Click);
            // 
            // tsmVerServicios
            // 
            this.tsmVerServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerServicios.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerServicios.ForeColor = System.Drawing.Color.White;
            this.tsmVerServicios.Image = global::ISFDyT93.Vista.Properties.Resources.briefcase_solid;
            this.tsmVerServicios.Name = "tsmVerServicios";
            this.tsmVerServicios.Size = new System.Drawing.Size(193, 30);
            this.tsmVerServicios.Text = "Ver Servicios";
            this.tsmVerServicios.Click += new System.EventHandler(this.tsmVerServicios_Click);
            // 
            // tsmHorarios
            // 
            this.tsmHorarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmHorarios.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmHorarios.ForeColor = System.Drawing.Color.White;
            this.tsmHorarios.Image = global::ISFDyT93.Vista.Properties.Resources.calendar_alt_solid;
            this.tsmHorarios.Name = "tsmHorarios";
            this.tsmHorarios.Size = new System.Drawing.Size(193, 30);
            this.tsmHorarios.Text = "Horarios";
            this.tsmHorarios.Click += new System.EventHandler(this.tsmHorarios_Click);
            // 
            // tsmLicencias
            // 
            this.tsmLicencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmLicencias.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmLicencias.ForeColor = System.Drawing.Color.White;
            this.tsmLicencias.Image = global::ISFDyT93.Vista.Properties.Resources.car_solid;
            this.tsmLicencias.Name = "tsmLicencias";
            this.tsmLicencias.Size = new System.Drawing.Size(193, 30);
            this.tsmLicencias.Text = "Licencias";
            this.tsmLicencias.Click += new System.EventHandler(this.tsmLicencias_Click);
            // 
            // tsmDocumentacion
            // 
            this.tsmDocumentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDocumentacion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDocumentacion.ForeColor = System.Drawing.Color.White;
            this.tsmDocumentacion.Image = global::ISFDyT93.Vista.Properties.Resources.file_solid;
            this.tsmDocumentacion.Name = "tsmDocumentacion";
            this.tsmDocumentacion.Size = new System.Drawing.Size(193, 30);
            this.tsmDocumentacion.Text = "Documentación";
            this.tsmDocumentacion.Click += new System.EventHandler(this.tsmDocumentacion_Click);
            // 
            // tsmEliminar
            // 
            this.tsmEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmEliminar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tsmEliminar.ForeColor = System.Drawing.Color.White;
            this.tsmEliminar.Image = global::ISFDyT93.Vista.Properties.Resources.trash_alt_solid;
            this.tsmEliminar.Name = "tsmEliminar";
            this.tsmEliminar.Size = new System.Drawing.Size(193, 30);
            this.tsmEliminar.Text = "Eliminar";
            this.tsmEliminar.Click += new System.EventHandler(this.tsmEliminar_Click);
            // 
            // FormPersonal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormPersonal";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormProfesores";
            this.Load += new System.EventHandler(this.FormProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cmsPersonal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblSelccFiltro;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.RadioButton rbInactivos;
        private System.Windows.Forms.RadioButton rbTodos;
        public System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.ContextMenuStrip cmsPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmVerLegajo;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmVerServicios;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmDarAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmLicencias;
        private System.Windows.Forms.ToolStripMenuItem tsmDarBaja;
        private System.Windows.Forms.ToolStripSeparator tsmSeparador;
        private System.Windows.Forms.ToolStripMenuItem tsmDocumentacion;
        private System.Windows.Forms.ToolStripMenuItem tsmHorarios;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminar;
    }
}