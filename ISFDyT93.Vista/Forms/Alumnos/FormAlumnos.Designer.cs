namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormAlumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlumnos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSelccFiltroAlum = new System.Windows.Forms.Label();
            this.cmbFiltroAlum = new System.Windows.Forms.ComboBox();
            this.txtFiltroAlumno = new System.Windows.Forms.TextBox();
            this.cmsAlumnos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAsignarMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDarAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCargaMasiva = new System.Windows.Forms.ToolStripMenuItem();
            this.rbInactivos = new System.Windows.Forms.RadioButton();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReporte = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.uscPaginacion1 = new CapaPresentacionAdmin.Controls.uscPaginacion();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.cmsAlumnos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelccFiltroAlum
            // 
            this.lblSelccFiltroAlum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelccFiltroAlum.AutoSize = true;
            this.lblSelccFiltroAlum.Location = new System.Drawing.Point(4, 10);
            this.lblSelccFiltroAlum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelccFiltroAlum.Name = "lblSelccFiltroAlum";
            this.lblSelccFiltroAlum.Size = new System.Drawing.Size(110, 19);
            this.lblSelccFiltroAlum.TabIndex = 47;
            this.lblSelccFiltroAlum.Text = "Filtro:";
            // 
            // cmbFiltroAlum
            // 
            this.cmbFiltroAlum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroAlum.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbFiltroAlum, 2);
            this.cmbFiltroAlum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroAlum.FormattingEnabled = true;
            this.cmbFiltroAlum.Items.AddRange(new object[] {
            "Todos",
            "Numero de Documento",
            "Nombre",
            "Apellido",
            "Carrera",
            "Año",
            "Curso"});
            this.cmbFiltroAlum.Location = new System.Drawing.Point(122, 9);
            this.cmbFiltroAlum.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltroAlum.Name = "cmbFiltroAlum";
            this.cmbFiltroAlum.Size = new System.Drawing.Size(228, 27);
            this.cmbFiltroAlum.TabIndex = 46;
            // 
            // txtFiltroAlumno
            // 
            this.txtFiltroAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroAlumno.BackColor = System.Drawing.Color.White;
            this.txtFiltroAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtFiltroAlumno, 3);
            this.txtFiltroAlumno.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroAlumno.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroAlumno.Location = new System.Drawing.Point(4, 44);
            this.txtFiltroAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroAlumno.Name = "txtFiltroAlumno";
            this.txtFiltroAlumno.Size = new System.Drawing.Size(346, 27);
            this.txtFiltroAlumno.TabIndex = 44;
            // 
            // cmsAlumnos
            // 
            this.cmsAlumnos.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsAlumnos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarAlumno,
            this.tsmModificarAlumno,
            this.tsmEliminarAlumno,
            this.tsmVerAlumno,
            this.tsmAsignarMaterias,
            this.tsmDarAlta,
            this.tsmCargaMasiva});
            this.cmsAlumnos.Name = "contextMenuStrip1";
            this.cmsAlumnos.Size = new System.Drawing.Size(181, 214);
            // 
            // tsmAgregarAlumno
            // 
            this.tsmAgregarAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarAlumno.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAgregarAlumno.ForeColor = System.Drawing.Color.White;
            this.tsmAgregarAlumno.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarAlumno.Image")));
            this.tsmAgregarAlumno.Name = "tsmAgregarAlumno";
            this.tsmAgregarAlumno.Size = new System.Drawing.Size(180, 30);
            this.tsmAgregarAlumno.Text = "Agregar ";
            this.tsmAgregarAlumno.Click += new System.EventHandler(this.tsmAgregarAlumno_Click);
            // 
            // tsmModificarAlumno
            // 
            this.tsmModificarAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarAlumno.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarAlumno.ForeColor = System.Drawing.Color.White;
            this.tsmModificarAlumno.Image = global::ISFDyT93.Vista.Properties.Resources.user_edit_solid;
            this.tsmModificarAlumno.Name = "tsmModificarAlumno";
            this.tsmModificarAlumno.Size = new System.Drawing.Size(180, 30);
            this.tsmModificarAlumno.Text = "Modificar";
            this.tsmModificarAlumno.Click += new System.EventHandler(this.tsmModificarAlumno_Click);
            // 
            // tsmEliminarAlumno
            // 
            this.tsmEliminarAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmEliminarAlumno.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEliminarAlumno.ForeColor = System.Drawing.Color.White;
            this.tsmEliminarAlumno.Image = global::ISFDyT93.Vista.Properties.Resources.minus_circle_solid;
            this.tsmEliminarAlumno.Name = "tsmEliminarAlumno";
            this.tsmEliminarAlumno.Size = new System.Drawing.Size(180, 30);
            this.tsmEliminarAlumno.Text = "Eliminar";
            this.tsmEliminarAlumno.Click += new System.EventHandler(this.tsmEliminarAlumno_Click);
            // 
            // tsmVerAlumno
            // 
            this.tsmVerAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerAlumno.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerAlumno.ForeColor = System.Drawing.Color.White;
            this.tsmVerAlumno.Image = ((System.Drawing.Image)(resources.GetObject("tsmVerAlumno.Image")));
            this.tsmVerAlumno.Name = "tsmVerAlumno";
            this.tsmVerAlumno.Size = new System.Drawing.Size(180, 30);
            this.tsmVerAlumno.Text = "Ver Datos";
            this.tsmVerAlumno.Click += new System.EventHandler(this.tsmVerAlumno_Click);
            // 
            // tsmAsignarMaterias
            // 
            this.tsmAsignarMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAsignarMaterias.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAsignarMaterias.ForeColor = System.Drawing.Color.White;
            this.tsmAsignarMaterias.Image = global::ISFDyT93.Vista.Properties.Resources.arrow_alt_circle_right_solid;
            this.tsmAsignarMaterias.Name = "tsmAsignarMaterias";
            this.tsmAsignarMaterias.Size = new System.Drawing.Size(180, 30);
            this.tsmAsignarMaterias.Text = "Asignar Materias";
            this.tsmAsignarMaterias.Click += new System.EventHandler(this.tsmAsignarMaterias_Click);
            // 
            // tsmDarAlta
            // 
            this.tsmDarAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDarAlta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDarAlta.ForeColor = System.Drawing.Color.White;
            this.tsmDarAlta.Image = global::ISFDyT93.Vista.Properties.Resources.plus_square_solid;
            this.tsmDarAlta.Name = "tsmDarAlta";
            this.tsmDarAlta.Size = new System.Drawing.Size(180, 30);
            this.tsmDarAlta.Text = "Dar de Alta";
            this.tsmDarAlta.Visible = false;
            this.tsmDarAlta.Click += new System.EventHandler(this.tsmDarAlta_Click);
            // 
            // tsmCargaMasiva
            // 
            this.tsmCargaMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmCargaMasiva.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tsmCargaMasiva.ForeColor = System.Drawing.Color.White;
            this.tsmCargaMasiva.Image = ((System.Drawing.Image)(resources.GetObject("tsmCargaMasiva.Image")));
            this.tsmCargaMasiva.Name = "tsmCargaMasiva";
            this.tsmCargaMasiva.Size = new System.Drawing.Size(180, 30);
            this.tsmCargaMasiva.Text = "Carga Masiva";
            this.tsmCargaMasiva.Click += new System.EventHandler(this.tsmCargaMasiva_Click);
            // 
            // rbInactivos
            // 
            this.rbInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInactivos.AutoSize = true;
            this.rbInactivos.Location = new System.Drawing.Point(121, 88);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(112, 23);
            this.rbInactivos.TabIndex = 49;
            this.rbInactivos.Text = "Inactivos";
            this.rbInactivos.UseVisualStyleBackColor = true;
            this.rbInactivos.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // rbActivos
            // 
            this.rbActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(3, 88);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(112, 23);
            this.rbActivos.TabIndex = 50;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Activos";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(239, 88);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(112, 23);
            this.rbTodos.TabIndex = 51;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.Controls.Add(this.lblSelccFiltroAlum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbFiltroAlum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFiltroAlumno, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbInactivos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbActivos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReporte, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 146);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnReporte.IconColor = System.Drawing.Color.White;
            this.btnReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporte.IconSize = 32;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnReporte.Location = new System.Drawing.Point(416, 67);
            this.btnReporte.Name = "btnReporte";
            this.tableLayoutPanel1.SetRowSpan(this.btnReporte, 2);
            this.btnReporte.Size = new System.Drawing.Size(133, 50);
            this.btnReporte.TabIndex = 56;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBuscar.Location = new System.Drawing.Point(596, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.tableLayoutPanel1.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(133, 50);
            this.btnBuscar.TabIndex = 55;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // uscPaginacion1
            // 
            this.uscPaginacion1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uscPaginacion1.BackColor = System.Drawing.Color.Transparent;
            this.uscPaginacion1.dataGridView = null;
            this.uscPaginacion1.EntradaDatos = null;
            this.uscPaginacion1.Location = new System.Drawing.Point(247, 4);
            this.uscPaginacion1.Margin = new System.Windows.Forms.Padding(4);
            this.uscPaginacion1.Name = "uscPaginacion1";
            this.uscPaginacion1.Recargar = null;
            this.uscPaginacion1.SalidaDatos = null;
            this.uscPaginacion1.Size = new System.Drawing.Size(237, 62);
            this.uscPaginacion1.TabIndex = 56;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uscPaginacion1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 460);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 70);
            this.tableLayoutPanel2.TabIndex = 59;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.AllowUserToResizeColumns = false;
            this.dgvAlumnos.AllowUserToResizeRows = false;
            this.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlumnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.EnableHeadersVisualStyles = false;
            this.dgvAlumnos.GridColor = System.Drawing.Color.White;
            this.dgvAlumnos.Location = new System.Drawing.Point(20, 166);
            this.dgvAlumnos.MultiSelect = false;
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.ReadOnly = true;
            this.dgvAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlumnos.RowTemplate.Height = 28;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(732, 294);
            this.dgvAlumnos.TabIndex = 60;
            this.dgvAlumnos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAlumnos_MouseUp);
            // 
            // FormAlumnos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.dgvAlumnos);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAlumnos";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormAlumnos";
            this.Load += new System.EventHandler(this.FormAlumnos_Load);
            this.Resize += new System.EventHandler(this.FormAlumnos_Resize);
            this.cmsAlumnos.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblSelccFiltroAlum;
        private System.Windows.Forms.ComboBox cmbFiltroAlum;
        private System.Windows.Forms.TextBox txtFiltroAlumno;
        private System.Windows.Forms.ContextMenuStrip cmsAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmVerAlumno;
        private System.Windows.Forms.RadioButton rbInactivos;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.ToolStripMenuItem tsmAsignarMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmDarAlta;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.ToolStripMenuItem tsmCargaMasiva;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnReporte;
        private CapaPresentacionAdmin.Controls.uscPaginacion uscPaginacion1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.DataGridView dgvAlumnos;
    }
}