namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormDocumentacionAlumno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.rbCompletos = new System.Windows.Forms.RadioButton();
            this.rbIncompletos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.cmbCarreraId = new System.Windows.Forms.ComboBox();
            this.btnEnviarMail = new FontAwesome.Sharp.IconButton();
            this.txtFiltroAlumno = new System.Windows.Forms.TextBox();
            this.btnCerra = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.uscPaginacion1 = new CapaPresentacionAdmin.Controls.uscPaginacion();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82022F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.99438F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.90449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbCompletos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbIncompletos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCarreraId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnviarMail, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFiltroAlumno, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCerra, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 161);
            this.tableLayoutPanel1.TabIndex = 54;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(371, 94);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(175, 55);
            this.tableLayoutPanel3.TabIndex = 62;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpHora);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(90, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 49);
            this.panel2.TabIndex = 183;
            // 
            // dtpHora
            // 
            this.dtpHora.CustomFormat = "";
            this.dtpHora.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHora.Location = new System.Drawing.Point(0, 19);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(82, 27);
            this.dtpHora.TabIndex = 180;
            this.dtpHora.Value = new System.DateTime(2020, 8, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 181;
            this.label1.Text = "Hora:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.lblFechaNacimiento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 49);
            this.panel1.TabIndex = 182;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(0, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 27);
            this.dtpFecha.TabIndex = 180;
            this.dtpFecha.Value = new System.DateTime(2020, 8, 30, 0, 0, 0, 0);
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(0, 0);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(55, 19);
            this.lblFechaNacimiento.TabIndex = 181;
            this.lblFechaNacimiento.Text = "Fecha:";
            // 
            // rbCompletos
            // 
            this.rbCompletos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCompletos.AutoSize = true;
            this.rbCompletos.Location = new System.Drawing.Point(139, 110);
            this.rbCompletos.Name = "rbCompletos";
            this.rbCompletos.Size = new System.Drawing.Size(117, 23);
            this.rbCompletos.TabIndex = 49;
            this.rbCompletos.Text = "Completos";
            this.rbCompletos.UseVisualStyleBackColor = true;
            this.rbCompletos.CheckedChanged += new System.EventHandler(this.CheckedGrilla);
            // 
            // rbIncompletos
            // 
            this.rbIncompletos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbIncompletos.AutoSize = true;
            this.rbIncompletos.Checked = true;
            this.rbIncompletos.Location = new System.Drawing.Point(3, 110);
            this.rbIncompletos.Name = "rbIncompletos";
            this.rbIncompletos.Size = new System.Drawing.Size(130, 23);
            this.rbIncompletos.TabIndex = 50;
            this.rbIncompletos.TabStop = true;
            this.rbIncompletos.Text = "Incomplentos";
            this.rbIncompletos.UseVisualStyleBackColor = true;
            this.rbIncompletos.CheckedChanged += new System.EventHandler(this.CheckedGrilla);
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(262, 110);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(94, 23);
            this.rbTodos.TabIndex = 51;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.CheckedGrilla);
            // 
            // cmbCarreraId
            // 
            this.cmbCarreraId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCarreraId.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCarreraId, 3);
            this.cmbCarreraId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarreraId.FormattingEnabled = true;
            this.cmbCarreraId.Items.AddRange(new object[] {
            "Todos",
            "Numero de Documento",
            "Nombre",
            "Apellido",
            "Carrera",
            "Año",
            "Curso"});
            this.cmbCarreraId.Location = new System.Drawing.Point(4, 12);
            this.cmbCarreraId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCarreraId.Name = "cmbCarreraId";
            this.cmbCarreraId.Size = new System.Drawing.Size(351, 27);
            this.cmbCarreraId.TabIndex = 46;
            this.cmbCarreraId.SelectedIndexChanged += new System.EventHandler(this.cmbCarreraId_SelectedIndexChanged);
            // 
            // btnEnviarMail
            // 
            this.btnEnviarMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnEnviarMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarMail.ForeColor = System.Drawing.Color.White;
            this.btnEnviarMail.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btnEnviarMail.IconColor = System.Drawing.Color.White;
            this.btnEnviarMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviarMail.IconSize = 32;
            this.btnEnviarMail.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEnviarMail.Location = new System.Drawing.Point(555, 100);
            this.btnEnviarMail.Name = "btnEnviarMail";
            this.btnEnviarMail.Size = new System.Drawing.Size(174, 49);
            this.btnEnviarMail.TabIndex = 178;
            this.btnEnviarMail.Text = "Enviar Mail";
            this.btnEnviarMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviarMail.UseVisualStyleBackColor = false;
            this.btnEnviarMail.Click += new System.EventHandler(this.btnEnviarMail_Click);
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
            this.txtFiltroAlumno.Location = new System.Drawing.Point(4, 55);
            this.txtFiltroAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroAlumno.Name = "txtFiltroAlumno";
            this.txtFiltroAlumno.Size = new System.Drawing.Size(351, 27);
            this.txtFiltroAlumno.TabIndex = 179;
            this.txtFiltroAlumno.TextChanged += new System.EventHandler(this.txtFiltroAlumno_TextChanged);
            // 
            // btnCerra
            // 
            this.btnCerra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnCerra, 2);
            this.btnCerra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerra.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCerra.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCerra.IconColor = System.Drawing.Color.DarkRed;
            this.btnCerra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerra.IconSize = 32;
            this.btnCerra.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCerra.Location = new System.Drawing.Point(371, 3);
            this.btnCerra.Name = "btnCerra";
            this.btnCerra.Size = new System.Drawing.Size(358, 45);
            this.btnCerra.TabIndex = 180;
            this.btnCerra.Text = "CIERRE DE PREINSCRIPSION";
            this.btnCerra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerra.UseVisualStyleBackColor = false;
            this.btnCerra.Click += new System.EventHandler(this.btnCerra_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 460);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 70);
            this.tableLayoutPanel2.TabIndex = 60;
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
            this.dgvAlumnos.Location = new System.Drawing.Point(20, 181);
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
            this.dgvAlumnos.Size = new System.Drawing.Size(732, 279);
            this.dgvAlumnos.TabIndex = 61;
            this.dgvAlumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellContentClick);
            this.dgvAlumnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellDoubleClick);
            this.dgvAlumnos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAlumnos_CellFormatting);
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
            // FormDocumentacionAlumno
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.dgvAlumnos);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDocumentacionAlumno";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormDocumentacionAlumno";
            this.Load += new System.EventHandler(this.FormDocumentacionAlumno_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCarreraId;
        private System.Windows.Forms.RadioButton rbCompletos;
        private System.Windows.Forms.RadioButton rbIncompletos;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.DataGridView dgvAlumnos;
        private CapaPresentacionAdmin.Controls.uscPaginacion uscPaginacion1;
        private FontAwesome.Sharp.IconButton btnEnviarMail;
        private System.Windows.Forms.TextBox txtFiltroAlumno;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private FontAwesome.Sharp.IconButton btnCerra;
    }
}