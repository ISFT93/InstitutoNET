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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uscPaginacion1 = new CapaPresentacionAdmin.Controls.uscPaginacion();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbCompletos = new System.Windows.Forms.RadioButton();
            this.rbIncompletos = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnCierre = new FontAwesome.Sharp.IconButton();
            this.cmbCarreraId = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.btnCierre, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCarreraId, 0, 0);
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
            // 
            // btnCierre
            // 
            this.btnCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCierre.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCierre, 2);
            this.btnCierre.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCierre.FlatAppearance.BorderSize = 3;
            this.btnCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierre.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierre.ForeColor = System.Drawing.Color.Red;
            this.btnCierre.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCierre.IconColor = System.Drawing.Color.White;
            this.btnCierre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCierre.IconSize = 32;
            this.btnCierre.Location = new System.Drawing.Point(377, 67);
            this.btnCierre.Name = "btnCierre";
            this.tableLayoutPanel1.SetRowSpan(this.btnCierre, 2);
            this.btnCierre.Size = new System.Drawing.Size(352, 50);
            this.btnCierre.TabIndex = 56;
            this.btnCierre.Text = "CIERRE DE INCRIPCION";
            this.btnCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCierre.UseVisualStyleBackColor = false;
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
            this.cmbCarreraId.Location = new System.Drawing.Point(4, 6);
            this.cmbCarreraId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCarreraId.Name = "cmbCarreraId";
            this.cmbCarreraId.Size = new System.Drawing.Size(346, 27);
            this.cmbCarreraId.TabIndex = 46;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.EnableHeadersVisualStyles = false;
            this.dgvAlumnos.GridColor = System.Drawing.Color.White;
            this.dgvAlumnos.Location = new System.Drawing.Point(20, 166);
            this.dgvAlumnos.MultiSelect = false;
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.ReadOnly = true;
            this.dgvAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.RowHeadersWidth = 62;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAlumnos.RowTemplate.Height = 28;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(732, 294);
            this.dgvAlumnos.TabIndex = 61;
            this.dgvAlumnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellDoubleClick);
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
        private FontAwesome.Sharp.IconButton btnCierre;
        private CapaPresentacionAdmin.Controls.uscPaginacion uscPaginacion1;
    }
}