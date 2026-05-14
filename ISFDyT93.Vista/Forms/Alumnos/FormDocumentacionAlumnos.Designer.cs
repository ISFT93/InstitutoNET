namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormDocumentacionAlumnos
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
            this.rbCompletos = new System.Windows.Forms.RadioButton();
            this.rbIncompletos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.cmbCarreraId = new System.Windows.Forms.ComboBox();
            this.btnEnviarMail = new FontAwesome.Sharp.IconButton();
            this.txtFiltroAlumno = new System.Windows.Forms.TextBox();
            this.uscPaginacion1 = new CapaPresentacionAdmin.Controls.uscPaginacion();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            //
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82022F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.99438F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.90449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.Controls.Add(this.rbCompletos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbIncompletos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCarreraId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnviarMail, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtFiltroAlumno, 0, 1);
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
            this.tableLayoutPanel1.TabIndex = 54;
            // 
            // rbCompletos
            // 
            this.rbCompletos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCompletos.AutoSize = true;
            this.rbCompletos.Location = new System.Drawing.Point(137, 88);
            this.rbCompletos.Name = "rbCompletos";
            this.rbCompletos.Size = new System.Drawing.Size(115, 23);
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
            this.rbIncompletos.Location = new System.Drawing.Point(3, 88);
            this.rbIncompletos.Name = "rbIncompletos";
            this.rbIncompletos.Size = new System.Drawing.Size(128, 23);
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
            this.rbTodos.Location = new System.Drawing.Point(258, 88);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(93, 23);
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
            this.cmbCarreraId.Location = new System.Drawing.Point(4, 9);
            this.cmbCarreraId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCarreraId.Name = "cmbCarreraId";
            this.cmbCarreraId.Size = new System.Drawing.Size(346, 27);
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
            this.btnEnviarMail.Location = new System.Drawing.Point(555, 83);
            this.btnEnviarMail.Name = "btnEnviarMail";
            this.btnEnviarMail.Size = new System.Drawing.Size(174, 34);
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
            this.txtFiltroAlumno.Location = new System.Drawing.Point(4, 44);
            this.txtFiltroAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroAlumno.Name = "txtFiltroAlumno";
            this.txtFiltroAlumno.Size = new System.Drawing.Size(346, 27);
            this.txtFiltroAlumno.TabIndex = 179;
            this.txtFiltroAlumno.TextChanged += new System.EventHandler(this.txtFiltroAlumno_TextChanged);
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
            this.dgvAlumnos.TabIndex = 61;
            this.dgvAlumnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellDoubleClick);
            this.dgvAlumnos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAlumnos_CellFormatting);
            // 
            // FormDocumentacionAlumnos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.dgvAlumnos);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDocumentacionAlumnos";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormDocumentacionAlumnos";
            this.Load += new System.EventHandler(this.FormDocumentacionAlumnos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
    }
}