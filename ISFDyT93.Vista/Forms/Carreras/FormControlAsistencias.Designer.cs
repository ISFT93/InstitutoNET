
namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormControlAsistencias
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
            this.btnDescargar = new System.Windows.Forms.Button();
            this.lblPorcentajeAlumnosI = new System.Windows.Forms.Label();
            this.lblTotalAlumnosI = new System.Windows.Forms.Label();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.dtpFechaAsistencia = new System.Windows.Forms.DateTimePicker();
            this.txtNombreMateria = new System.Windows.Forms.TextBox();
            this.lblProfesor = new System.Windows.Forms.Label();
            this.lblMat = new System.Windows.Forms.Label();
            this.btnAceptarAsistencia = new System.Windows.Forms.Button();
            this.txtProfesor = new System.Windows.Forms.TextBox();
            this.txtPorcentajeAsistencia = new System.Windows.Forms.TextBox();
            this.txtHoraCatedra = new System.Windows.Forms.TextBox();
            this.lblPorcentajeAsistencia = new System.Windows.Forms.Label();
            this.lblPocAsistencia = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblModulos = new System.Windows.Forms.Label();
            this.cmsPyA = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmA = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHistorialAsistenciasAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCantRecursantes = new System.Windows.Forms.Label();
            this.lblCantAlumnos = new System.Windows.Forms.Label();
            this.lblCantDesertores = new System.Windows.Forms.Label();
            this.lblHorasCátedra = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCantidadAlumnos = new System.Windows.Forms.TextBox();
            this.txtPorcentajePresente = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel0 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.lblCicloLectivo = new System.Windows.Forms.Label();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblProf = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.cmbCicloLectivo = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbProfesor = new System.Windows.Forms.ComboBox();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.cmsPyA.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel0.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.ForeColor = System.Drawing.Color.White;
            this.btnDescargar.Location = new System.Drawing.Point(622, 120);
            this.btnDescargar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(301, 54);
            this.btnDescargar.TabIndex = 71;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // lblPorcentajeAlumnosI
            // 
            this.lblPorcentajeAlumnosI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentajeAlumnosI.AutoSize = true;
            this.lblPorcentajeAlumnosI.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeAlumnosI.Location = new System.Drawing.Point(4, 123);
            this.lblPorcentajeAlumnosI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorcentajeAlumnosI.Name = "lblPorcentajeAlumnosI";
            this.lblPorcentajeAlumnosI.Size = new System.Drawing.Size(301, 48);
            this.lblPorcentajeAlumnosI.TabIndex = 70;
            this.lblPorcentajeAlumnosI.Text = "Porcentaje de alumnos presentes:";
            // 
            // lblTotalAlumnosI
            // 
            this.lblTotalAlumnosI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalAlumnosI.AutoSize = true;
            this.lblTotalAlumnosI.BackColor = System.Drawing.Color.White;
            this.lblTotalAlumnosI.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAlumnosI.Location = new System.Drawing.Point(4, 37);
            this.lblTotalAlumnosI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAlumnosI.Name = "lblTotalAlumnosI";
            this.lblTotalAlumnosI.Size = new System.Drawing.Size(172, 24);
            this.lblTotalAlumnosI.TabIndex = 69;
            this.lblTotalAlumnosI.Text = "Total de alumnos:";
            this.lblTotalAlumnosI.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.AllowUserToAddRows = false;
            this.dgvAsistencias.AllowUserToDeleteRows = false;
            this.dgvAsistencias.AllowUserToResizeColumns = false;
            this.dgvAsistencias.AllowUserToResizeRows = false;
            this.dgvAsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAsistencias.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsistencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsistencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsistencias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistencias.EnableHeadersVisualStyles = false;
            this.dgvAsistencias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.dgvAsistencias.Location = new System.Drawing.Point(6, 6);
            this.dgvAsistencias.Margin = new System.Windows.Forms.Padding(6);
            this.dgvAsistencias.MultiSelect = false;
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.ReadOnly = true;
            this.dgvAsistencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(16)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAsistencias.RowHeadersVisible = false;
            this.dgvAsistencias.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAsistencias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsistencias.RowTemplate.Height = 28;
            this.dgvAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
<<<<<<< HEAD
            this.dgvAsistencias.Size = new System.Drawing.Size(1204, 279);
=======
            this.dgvAsistencias.Size = new System.Drawing.Size(1225, 465);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.dgvAsistencias.TabIndex = 68;
            this.dgvAsistencias.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAsistencias_MouseUp);
            // 
            // dtpFechaAsistencia
            // 
            this.dtpFechaAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaAsistencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
<<<<<<< HEAD
            this.dtpFechaAsistencia.Location = new System.Drawing.Point(308, 75);
=======
            this.dtpFechaAsistencia.Location = new System.Drawing.Point(313, 117);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.dtpFechaAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaAsistencia.Name = "dtpFechaAsistencia";
            this.dtpFechaAsistencia.Size = new System.Drawing.Size(301, 32);
            this.dtpFechaAsistencia.TabIndex = 67;
            // 
            // txtNombreMateria
            // 
            this.txtNombreMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreMateria.Enabled = false;
<<<<<<< HEAD
            this.txtNombreMateria.Location = new System.Drawing.Point(308, 4);
=======
            this.txtNombreMateria.Location = new System.Drawing.Point(313, 7);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.txtNombreMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreMateria.Name = "txtNombreMateria";
            this.txtNombreMateria.Size = new System.Drawing.Size(301, 32);
            this.txtNombreMateria.TabIndex = 60;
            // 
            // lblProfesor
            // 
            this.lblProfesor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Font = new System.Drawing.Font("Tahoma", 12F);
<<<<<<< HEAD
            this.lblProfesor.Location = new System.Drawing.Point(612, 7);
=======
            this.lblProfesor.Location = new System.Drawing.Point(622, 11);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.lblProfesor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(301, 24);
            this.lblProfesor.TabIndex = 64;
            this.lblProfesor.Text = "Profesor:";
            // 
            // lblMat
            // 
            this.lblMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMat.AutoSize = true;
            this.lblMat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.lblMat.Location = new System.Drawing.Point(4, 7);
=======
            this.lblMat.Location = new System.Drawing.Point(4, 11);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.lblMat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(301, 24);
            this.lblMat.TabIndex = 65;
            this.lblMat.Text = "Materia:";
            // 
            // btnAceptarAsistencia
            // 
            this.btnAceptarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarAsistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnAceptarAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarAsistencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnAceptarAsistencia.Location = new System.Drawing.Point(931, 120);
            this.btnAceptarAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarAsistencia.Name = "btnAceptarAsistencia";
            this.btnAceptarAsistencia.Size = new System.Drawing.Size(302, 54);
            this.btnAceptarAsistencia.TabIndex = 63;
            this.btnAceptarAsistencia.Text = "Aceptar";
            this.btnAceptarAsistencia.UseVisualStyleBackColor = false;
            this.btnAceptarAsistencia.Click += new System.EventHandler(this.btnAceptarAsistencia_Click_1);
            // 
            // txtProfesor
            // 
            this.txtProfesor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfesor.Enabled = false;
<<<<<<< HEAD
            this.txtProfesor.Location = new System.Drawing.Point(916, 4);
=======
            this.txtProfesor.Location = new System.Drawing.Point(931, 7);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.txtProfesor.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfesor.Name = "txtProfesor";
            this.txtProfesor.Size = new System.Drawing.Size(302, 32);
            this.txtProfesor.TabIndex = 61;
            // 
            // txtPorcentajeAsistencia
            // 
            this.txtPorcentajeAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcentajeAsistencia.Enabled = false;
<<<<<<< HEAD
            this.txtPorcentajeAsistencia.Location = new System.Drawing.Point(308, 38);
=======
            this.txtPorcentajeAsistencia.Location = new System.Drawing.Point(313, 58);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.txtPorcentajeAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorcentajeAsistencia.Name = "txtPorcentajeAsistencia";
            this.txtPorcentajeAsistencia.Size = new System.Drawing.Size(301, 32);
            this.txtPorcentajeAsistencia.TabIndex = 59;
            // 
            // txtHoraCatedra
            // 
            this.txtHoraCatedra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoraCatedra.Enabled = false;
<<<<<<< HEAD
            this.txtHoraCatedra.Location = new System.Drawing.Point(916, 38);
=======
            this.txtHoraCatedra.Location = new System.Drawing.Point(931, 58);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.txtHoraCatedra.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraCatedra.Name = "txtHoraCatedra";
            this.txtHoraCatedra.Size = new System.Drawing.Size(302, 32);
            this.txtHoraCatedra.TabIndex = 62;
            // 
            // lblPorcentajeAsistencia
            // 
            this.lblPorcentajeAsistencia.AutoSize = true;
            this.lblPorcentajeAsistencia.BackColor = System.Drawing.Color.Transparent;
            this.lblPorcentajeAsistencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeAsistencia.Location = new System.Drawing.Point(772, 396);
            this.lblPorcentajeAsistencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorcentajeAsistencia.Name = "lblPorcentajeAsistencia";
            this.lblPorcentajeAsistencia.Size = new System.Drawing.Size(0, 24);
            this.lblPorcentajeAsistencia.TabIndex = 58;
            // 
            // lblPocAsistencia
            // 
            this.lblPocAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPocAsistencia.AutoSize = true;
            this.lblPocAsistencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.lblPocAsistencia.Location = new System.Drawing.Point(4, 42);
=======
            this.lblPocAsistencia.Location = new System.Drawing.Point(4, 62);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.lblPocAsistencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPocAsistencia.Name = "lblPocAsistencia";
            this.lblPocAsistencia.Size = new System.Drawing.Size(301, 24);
            this.lblPocAsistencia.TabIndex = 57;
            this.lblPocAsistencia.Text = "Porc. Asistencia:";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.lblFecha.Location = new System.Drawing.Point(4, 79);
=======
            this.lblFecha.Location = new System.Drawing.Point(4, 121);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(301, 24);
            this.lblFecha.TabIndex = 56;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblModulos
            // 
            this.lblModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModulos.AutoSize = true;
            this.lblModulos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.lblModulos.Location = new System.Drawing.Point(612, 42);
=======
            this.lblModulos.Location = new System.Drawing.Point(622, 62);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.lblModulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModulos.Name = "lblModulos";
            this.lblModulos.Size = new System.Drawing.Size(301, 24);
            this.lblModulos.TabIndex = 66;
            this.lblModulos.Text = "Módulos:";
            // 
            // cmsPyA
            // 
            this.cmsPyA.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPyA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmP,
            this.tsmA,
            this.tsmHistorialAsistenciasAlumnos});
            this.cmsPyA.Name = "cmsPyA";
            this.cmsPyA.Size = new System.Drawing.Size(135, 76);
            // 
            // tsmP
            // 
            this.tsmP.Name = "tsmP";
            this.tsmP.Size = new System.Drawing.Size(134, 24);
            this.tsmP.Text = "P";
            // 
            // tsmA
            // 
            this.tsmA.Name = "tsmA";
            this.tsmA.Size = new System.Drawing.Size(134, 24);
            this.tsmA.Text = "A";
            // 
            // tsmHistorialAsistenciasAlumnos
            // 
            this.tsmHistorialAsistenciasAlumnos.Name = "tsmHistorialAsistenciasAlumnos";
            this.tsmHistorialAsistenciasAlumnos.Size = new System.Drawing.Size(134, 24);
            this.tsmHistorialAsistenciasAlumnos.Text = "Historial";
            this.tsmHistorialAsistenciasAlumnos.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblCantRecursantes, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProfesor, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHoraCatedra, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreMateria, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPocAsistencia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPorcentajeAsistencia, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaAsistencia, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProfesor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModulos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFecha, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCantAlumnos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCantDesertores, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblHorasCátedra, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 262);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
<<<<<<< HEAD
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1216, 174);
=======
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1237, 165);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.tableLayoutPanel1.TabIndex = 72;
            // 
            // lblCantRecursantes
            // 
            this.lblCantRecursantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantRecursantes.AutoSize = true;
            this.lblCantRecursantes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRecursantes.Location = new System.Drawing.Point(612, 79);
            this.lblCantRecursantes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantRecursantes.Name = "lblCantRecursantes";
            this.lblCantRecursantes.Size = new System.Drawing.Size(296, 19);
            this.lblCantRecursantes.TabIndex = 70;
            this.lblCantRecursantes.Text = "Cant. Recursante:";
            // 
            // lblCantAlumnos
            // 
            this.lblCantAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantAlumnos.AutoSize = true;
            this.lblCantAlumnos.Location = new System.Drawing.Point(3, 115);
            this.lblCantAlumnos.Name = "lblCantAlumnos";
            this.lblCantAlumnos.Size = new System.Drawing.Size(298, 19);
            this.lblCantAlumnos.TabIndex = 68;
            this.lblCantAlumnos.Text = "Cant. Alumnos:";
            // 
            // lblCantDesertores
            // 
            this.lblCantDesertores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantDesertores.AutoSize = true;
            this.lblCantDesertores.Location = new System.Drawing.Point(611, 115);
            this.lblCantDesertores.Name = "lblCantDesertores";
            this.lblCantDesertores.Size = new System.Drawing.Size(298, 19);
            this.lblCantDesertores.TabIndex = 69;
            this.lblCantDesertores.Text = "Cant. Desertores:";
            // 
            // lblHorasCátedra
            // 
            this.lblHorasCátedra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorasCátedra.AutoSize = true;
            this.lblHorasCátedra.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasCátedra.Location = new System.Drawing.Point(4, 148);
            this.lblHorasCátedra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHorasCátedra.Name = "lblHorasCátedra";
            this.lblHorasCátedra.Size = new System.Drawing.Size(296, 19);
            this.lblHorasCátedra.TabIndex = 71;
            this.lblHorasCátedra.Text = "Horas de cátedra:";
            this.lblHorasCátedra.Click += new System.EventHandler(this.label4_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblTotalAlumnosI, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPorcentajeAlumnosI, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptarAsistencia, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDescargar, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCantidadAlumnos, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPorcentajePresente, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 904);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1237, 196);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // txtCantidadAlumnos
            // 
            this.txtCantidadAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadAlumnos.Enabled = false;
            this.txtCantidadAlumnos.Location = new System.Drawing.Point(312, 33);
            this.txtCantidadAlumnos.Name = "txtCantidadAlumnos";
            this.txtCantidadAlumnos.Size = new System.Drawing.Size(303, 32);
            this.txtCantidadAlumnos.TabIndex = 72;
            // 
            // txtPorcentajePresente
            // 
            this.txtPorcentajePresente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcentajePresente.Enabled = false;
            this.txtPorcentajePresente.Location = new System.Drawing.Point(312, 131);
            this.txtPorcentajePresente.Name = "txtPorcentajePresente";
            this.txtPorcentajePresente.Size = new System.Drawing.Size(303, 32);
            this.txtPorcentajePresente.TabIndex = 73;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvAsistencias, 0, 0);
<<<<<<< HEAD
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 203);
=======
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 427);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
<<<<<<< HEAD
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1216, 291);
=======
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1237, 477);
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
            this.tableLayoutPanel3.TabIndex = 74;
            // 
            // tableLayoutPanel0
            // 
            this.tableLayoutPanel0.ColumnCount = 4;
            this.tableLayoutPanel0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel0.Controls.Add(this.cmbMateria, 3, 2);
            this.tableLayoutPanel0.Controls.Add(this.cmbCurso, 3, 1);
            this.tableLayoutPanel0.Controls.Add(this.cmbCarrera, 3, 0);
            this.tableLayoutPanel0.Controls.Add(this.lblCicloLectivo, 0, 0);
            this.tableLayoutPanel0.Controls.Add(this.lblMateria, 2, 2);
            this.tableLayoutPanel0.Controls.Add(this.lblCarrera, 2, 0);
            this.tableLayoutPanel0.Controls.Add(this.lblAnio, 0, 1);
            this.tableLayoutPanel0.Controls.Add(this.lblProf, 0, 2);
            this.tableLayoutPanel0.Controls.Add(this.lblCurso, 2, 1);
            this.tableLayoutPanel0.Controls.Add(this.cmbCicloLectivo, 1, 0);
            this.tableLayoutPanel0.Controls.Add(this.cmbAnio, 1, 1);
            this.tableLayoutPanel0.Controls.Add(this.cmbProfesor, 1, 2);
            this.tableLayoutPanel0.Controls.Add(this.btnAplicarFiltros, 0, 3);
            this.tableLayoutPanel0.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel0.Location = new System.Drawing.Point(30, 29);
            this.tableLayoutPanel0.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.tableLayoutPanel0.Name = "tableLayoutPanel0";
            this.tableLayoutPanel0.RowCount = 4;
            this.tableLayoutPanel0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.41177F));
            this.tableLayoutPanel0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.58823F));
            this.tableLayoutPanel0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel0.Size = new System.Drawing.Size(1237, 189);
            this.tableLayoutPanel0.TabIndex = 75;
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(930, 101);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(293, 32);
            this.cmbMateria.TabIndex = 79;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // cmbCurso
            // 
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(930, 51);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(293, 32);
            this.cmbCurso.TabIndex = 78;
            this.cmbCurso.SelectedIndexChanged += new System.EventHandler(this.cmbCurso_SelectedIndexChanged);
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(930, 3);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(293, 32);
            this.cmbCarrera.TabIndex = 77;
            this.cmbCarrera.DropDown += new System.EventHandler(this.cmbCarrera_DropDown);
            this.cmbCarrera.SelectedIndexChanged += new System.EventHandler(this.cmbCarrera_SelectedIndexChanged);
            // 
            // lblCicloLectivo
            // 
            this.lblCicloLectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCicloLectivo.AutoSize = true;
            this.lblCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCicloLectivo.Location = new System.Drawing.Point(4, 12);
            this.lblCicloLectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCicloLectivo.Name = "lblCicloLectivo";
            this.lblCicloLectivo.Size = new System.Drawing.Size(301, 24);
            this.lblCicloLectivo.TabIndex = 69;
            this.lblCicloLectivo.Text = "Ciclo Lectivo:";
            // 
            // lblMateria
            // 
            this.lblMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMateria.AutoSize = true;
            this.lblMateria.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateria.Location = new System.Drawing.Point(622, 107);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(301, 24);
            this.lblMateria.TabIndex = 68;
            this.lblMateria.Text = "Materia:";
            // 
            // lblCarrera
            // 
            this.lblCarrera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrera.Location = new System.Drawing.Point(622, 12);
            this.lblCarrera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(301, 24);
            this.lblCarrera.TabIndex = 70;
            this.lblCarrera.Text = "Carrera:";
            // 
            // lblAnio
            // 
            this.lblAnio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(4, 61);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(301, 24);
            this.lblAnio.TabIndex = 71;
            this.lblAnio.Text = "Año:";
            // 
            // lblProf
            // 
            this.lblProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProf.AutoSize = true;
            this.lblProf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProf.Location = new System.Drawing.Point(4, 107);
            this.lblProf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(301, 24);
            this.lblProf.TabIndex = 72;
            this.lblProf.Text = "Profesor:";
            // 
            // lblCurso
            // 
            this.lblCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.Location = new System.Drawing.Point(622, 61);
            this.lblCurso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(301, 24);
            this.lblCurso.TabIndex = 73;
            this.lblCurso.Text = "Curso";
            // 
            // cmbCicloLectivo
            // 
            this.cmbCicloLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCicloLectivo.FormattingEnabled = true;
            this.cmbCicloLectivo.Location = new System.Drawing.Point(312, 3);
            this.cmbCicloLectivo.Name = "cmbCicloLectivo";
            this.cmbCicloLectivo.Size = new System.Drawing.Size(292, 32);
            this.cmbCicloLectivo.TabIndex = 74;
            this.cmbCicloLectivo.DropDown += new System.EventHandler(this.cmbCicloLectivo_DropDown);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(312, 51);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(292, 32);
            this.cmbAnio.TabIndex = 75;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(312, 101);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(292, 32);
            this.cmbProfesor.TabIndex = 76;
            this.cmbProfesor.DropDown += new System.EventHandler(this.cmbProfesor_DropDown);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnAplicarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(3, 144);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(282, 42);
            this.btnAplicarFiltros.TabIndex = 80;
            this.btnAplicarFiltros.Text = "Filtrar";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(30, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 44);
            this.panel1.TabIndex = 76;
            // 
            // FormControlAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1318, 933);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel0);
            this.Controls.Add(this.lblPorcentajeAsistencia);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormControlAsistencias";
            this.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.Text = "ControlAsistencias";
            this.Load += new System.EventHandler(this.ControlAsistencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.cmsPyA.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel0.ResumeLayout(false);
            this.tableLayoutPanel0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Label lblPorcentajeAlumnosI;
        private System.Windows.Forms.Label lblTotalAlumnosI;
        public System.Windows.Forms.DataGridView dgvAsistencias;
        private System.Windows.Forms.DateTimePicker dtpFechaAsistencia;
        private System.Windows.Forms.TextBox txtNombreMateria;
        private System.Windows.Forms.Label lblProfesor;
        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Button btnAceptarAsistencia;
        private System.Windows.Forms.TextBox txtProfesor;
        private System.Windows.Forms.TextBox txtPorcentajeAsistencia;
        private System.Windows.Forms.TextBox txtHoraCatedra;
        private System.Windows.Forms.Label lblPorcentajeAsistencia;
        private System.Windows.Forms.Label lblPocAsistencia;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblModulos;
        private System.Windows.Forms.ContextMenuStrip cmsPyA;
        private System.Windows.Forms.ToolStripMenuItem tsmP;
        private System.Windows.Forms.ToolStripMenuItem tsmA;
        private System.Windows.Forms.ToolStripMenuItem tsmHistorialAsistenciasAlumnos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtCantidadAlumnos;
        private System.Windows.Forms.TextBox txtPorcentajePresente;
<<<<<<< HEAD
        private System.Windows.Forms.Label lblCantAlumnos;
        private System.Windows.Forms.Label lblCantDesertores;
        private System.Windows.Forms.Label lblCantRecursantes;
        private System.Windows.Forms.Label lblHorasCátedra;
=======
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel0;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.Label lblCicloLectivo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cmbCicloLectivo;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbProfesor;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Panel panel1;
>>>>>>> 7bbf27b7e298c7d30f563fecea960592a5b47d63
    }
}