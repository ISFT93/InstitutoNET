
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCantidadAlumnos = new System.Windows.Forms.TextBox();
            this.txtPorcentajePresente = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.cmsPyA.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.ForeColor = System.Drawing.Color.White;
            this.btnDescargar.Location = new System.Drawing.Point(612, 82);
            this.btnDescargar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(296, 54);
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
            this.lblPorcentajeAlumnosI.Location = new System.Drawing.Point(4, 100);
            this.lblPorcentajeAlumnosI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorcentajeAlumnosI.Name = "lblPorcentajeAlumnosI";
            this.lblPorcentajeAlumnosI.Size = new System.Drawing.Size(296, 19);
            this.lblPorcentajeAlumnosI.TabIndex = 70;
            this.lblPorcentajeAlumnosI.Text = "Porcentaje de alumnos presentes:";
            // 
            // lblTotalAlumnosI
            // 
            this.lblTotalAlumnosI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalAlumnosI.AutoSize = true;
            this.lblTotalAlumnosI.BackColor = System.Drawing.Color.White;
            this.lblTotalAlumnosI.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAlumnosI.Location = new System.Drawing.Point(4, 27);
            this.lblTotalAlumnosI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAlumnosI.Name = "lblTotalAlumnosI";
            this.lblTotalAlumnosI.Size = new System.Drawing.Size(138, 19);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsistencias.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistencias.EnableHeadersVisualStyles = false;
            this.dgvAsistencias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.dgvAsistencias.Location = new System.Drawing.Point(6, 6);
            this.dgvAsistencias.Margin = new System.Windows.Forms.Padding(6);
            this.dgvAsistencias.MultiSelect = false;
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.ReadOnly = true;
            this.dgvAsistencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(16)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencias.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAsistencias.RowHeadersVisible = false;
            this.dgvAsistencias.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAsistencias.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAsistencias.RowTemplate.Height = 28;
            this.dgvAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsistencias.Size = new System.Drawing.Size(1204, 288);
            this.dgvAsistencias.TabIndex = 68;
            this.dgvAsistencias.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAsistencias_MouseUp);
            // 
            // dtpFechaAsistencia
            // 
            this.dtpFechaAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaAsistencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAsistencia.Location = new System.Drawing.Point(308, 119);
            this.dtpFechaAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaAsistencia.Name = "dtpFechaAsistencia";
            this.dtpFechaAsistencia.Size = new System.Drawing.Size(296, 27);
            this.dtpFechaAsistencia.TabIndex = 67;
            // 
            // txtNombreMateria
            // 
            this.txtNombreMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreMateria.Enabled = false;
            this.txtNombreMateria.Location = new System.Drawing.Point(308, 10);
            this.txtNombreMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreMateria.Name = "txtNombreMateria";
            this.txtNombreMateria.Size = new System.Drawing.Size(296, 27);
            this.txtNombreMateria.TabIndex = 60;
            // 
            // lblProfesor
            // 
            this.lblProfesor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblProfesor.Location = new System.Drawing.Point(612, 14);
            this.lblProfesor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(296, 19);
            this.lblProfesor.TabIndex = 64;
            this.lblProfesor.Text = "Profesor:";
            // 
            // lblMat
            // 
            this.lblMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMat.AutoSize = true;
            this.lblMat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMat.Location = new System.Drawing.Point(4, 14);
            this.lblMat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(296, 19);
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
            this.btnAceptarAsistencia.Location = new System.Drawing.Point(916, 82);
            this.btnAceptarAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarAsistencia.Name = "btnAceptarAsistencia";
            this.btnAceptarAsistencia.Size = new System.Drawing.Size(296, 54);
            this.btnAceptarAsistencia.TabIndex = 63;
            this.btnAceptarAsistencia.Text = "Aceptar";
            this.btnAceptarAsistencia.UseVisualStyleBackColor = false;
            this.btnAceptarAsistencia.Click += new System.EventHandler(this.btnAceptarAsistencia_Click_1);
            // 
            // txtProfesor
            // 
            this.txtProfesor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfesor.Enabled = false;
            this.txtProfesor.Location = new System.Drawing.Point(916, 10);
            this.txtProfesor.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfesor.Name = "txtProfesor";
            this.txtProfesor.Size = new System.Drawing.Size(296, 27);
            this.txtProfesor.TabIndex = 61;
            // 
            // txtPorcentajeAsistencia
            // 
            this.txtPorcentajeAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcentajeAsistencia.Enabled = false;
            this.txtPorcentajeAsistencia.Location = new System.Drawing.Point(308, 60);
            this.txtPorcentajeAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorcentajeAsistencia.Name = "txtPorcentajeAsistencia";
            this.txtPorcentajeAsistencia.Size = new System.Drawing.Size(296, 27);
            this.txtPorcentajeAsistencia.TabIndex = 59;
            // 
            // txtHoraCatedra
            // 
            this.txtHoraCatedra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoraCatedra.Enabled = false;
            this.txtHoraCatedra.Location = new System.Drawing.Point(916, 60);
            this.txtHoraCatedra.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraCatedra.Name = "txtHoraCatedra";
            this.txtHoraCatedra.Size = new System.Drawing.Size(296, 27);
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
            this.lblPorcentajeAsistencia.Size = new System.Drawing.Size(0, 19);
            this.lblPorcentajeAsistencia.TabIndex = 58;
            // 
            // lblPocAsistencia
            // 
            this.lblPocAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPocAsistencia.AutoSize = true;
            this.lblPocAsistencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPocAsistencia.Location = new System.Drawing.Point(4, 64);
            this.lblPocAsistencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPocAsistencia.Name = "lblPocAsistencia";
            this.lblPocAsistencia.Size = new System.Drawing.Size(296, 19);
            this.lblPocAsistencia.TabIndex = 57;
            this.lblPocAsistencia.Text = "Porc. asistencia:";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(4, 123);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(296, 19);
            this.lblFecha.TabIndex = 56;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblModulos
            // 
            this.lblModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModulos.AutoSize = true;
            this.lblModulos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulos.Location = new System.Drawing.Point(612, 64);
            this.lblModulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModulos.Name = "lblModulos";
            this.lblModulos.Size = new System.Drawing.Size(296, 19);
            this.lblModulos.TabIndex = 66;
            this.lblModulos.Text = "Módulos:";
            // 
            // cmsPyA
            // 
            this.cmsPyA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmP,
            this.tsmA,
            this.tsmHistorialAsistenciasAlumnos});
            this.cmsPyA.Name = "cmsPyA";
            this.cmsPyA.Size = new System.Drawing.Size(119, 70);
            // 
            // tsmP
            // 
            this.tsmP.Name = "tsmP";
            this.tsmP.Size = new System.Drawing.Size(118, 22);
            this.tsmP.Text = "P";
            // 
            // tsmA
            // 
            this.tsmA.Name = "tsmA";
            this.tsmA.Size = new System.Drawing.Size(118, 22);
            this.tsmA.Text = "A";
            // 
            // tsmHistorialAsistenciasAlumnos
            // 
            this.tsmHistorialAsistenciasAlumnos.Name = "tsmHistorialAsistenciasAlumnos";
            this.tsmHistorialAsistenciasAlumnos.Size = new System.Drawing.Size(118, 22);
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
            this.tableLayoutPanel1.Controls.Add(this.lblMat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProfesor, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHoraCatedra, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreMateria, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPocAsistencia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPorcentajeAsistencia, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFecha, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaAsistencia, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProfesor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModulos, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 29);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1216, 165);
            this.tableLayoutPanel1.TabIndex = 72;
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
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 494);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1216, 146);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // txtCantidadAlumnos
            // 
            this.txtCantidadAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadAlumnos.Enabled = false;
            this.txtCantidadAlumnos.Location = new System.Drawing.Point(307, 23);
            this.txtCantidadAlumnos.Name = "txtCantidadAlumnos";
            this.txtCantidadAlumnos.Size = new System.Drawing.Size(298, 27);
            this.txtCantidadAlumnos.TabIndex = 72;
            // 
            // txtPorcentajePresente
            // 
            this.txtPorcentajePresente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcentajePresente.Enabled = false;
            this.txtPorcentajePresente.Location = new System.Drawing.Point(307, 96);
            this.txtPorcentajePresente.Name = "txtPorcentajePresente";
            this.txtPorcentajePresente.Size = new System.Drawing.Size(298, 27);
            this.txtPorcentajePresente.TabIndex = 73;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvAsistencias, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 194);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1216, 300);
            this.tableLayoutPanel3.TabIndex = 74;
            // 
            // FormControlAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 669);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
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
    }
}