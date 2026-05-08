namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class ControlDocumentacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uscPaginacion1 = new CapaPresentacionAdmin.Controls.uscPaginacion();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelccFiltroAlum = new System.Windows.Forms.Label();
            this.cmbFiltroAlum = new System.Windows.Forms.ComboBox();
            this.rbICompleto = new System.Windows.Forms.RadioButton();
            this.rblIncompleto = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnEnvioMail = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.EnableHeadersVisualStyles = false;
            this.dgvAlumnos.GridColor = System.Drawing.Color.White;
            this.dgvAlumnos.Location = new System.Drawing.Point(20, 166);
            this.dgvAlumnos.MultiSelect = false;
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.ReadOnly = true;
            this.dgvAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.RowHeadersWidth = 62;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAlumnos.RowTemplate.Height = 28;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(732, 294);
            this.dgvAlumnos.TabIndex = 63;
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
            this.tableLayoutPanel2.TabIndex = 62;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.665F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.Controls.Add(this.lblSelccFiltroAlum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbFiltroAlum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbICompleto, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rblIncompleto, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnEnvioMail, 4, 1);
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
            this.tableLayoutPanel1.TabIndex = 61;
            // 
            // lblSelccFiltroAlum
            // 
            this.lblSelccFiltroAlum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelccFiltroAlum.AutoSize = true;
            this.lblSelccFiltroAlum.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSelccFiltroAlum.Location = new System.Drawing.Point(4, 10);
            this.lblSelccFiltroAlum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelccFiltroAlum.Name = "lblSelccFiltroAlum";
            this.lblSelccFiltroAlum.Size = new System.Drawing.Size(110, 19);
            this.lblSelccFiltroAlum.TabIndex = 47;
            this.lblSelccFiltroAlum.Text = "Carrera:";
            // 
            // cmbFiltroAlum
            // 
            this.cmbFiltroAlum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroAlum.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbFiltroAlum, 2);
            this.cmbFiltroAlum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroAlum.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbFiltroAlum.FormattingEnabled = true;
            this.cmbFiltroAlum.Items.AddRange(new object[] {
            "Todos",
            "Numero de Documento",
            "Nombre",
            "Apellido",
            "Carrera",
            "Año",
            "Curso"});
            this.cmbFiltroAlum.Location = new System.Drawing.Point(122, 6);
            this.cmbFiltroAlum.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltroAlum.Name = "cmbFiltroAlum";
            this.cmbFiltroAlum.Size = new System.Drawing.Size(228, 27);
            this.cmbFiltroAlum.TabIndex = 46;
            // 
            // rbICompleto
            // 
            this.rbICompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbICompleto.AutoSize = true;
            this.rbICompleto.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbICompleto.Location = new System.Drawing.Point(121, 88);
            this.rbICompleto.Name = "rbICompleto";
            this.rbICompleto.Size = new System.Drawing.Size(112, 23);
            this.rbICompleto.TabIndex = 49;
            this.rbICompleto.Text = "Completo";
            this.rbICompleto.UseVisualStyleBackColor = true;
            // 
            // rblIncompleto
            // 
            this.rblIncompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rblIncompleto.AutoSize = true;
            this.rblIncompleto.Checked = true;
            this.rblIncompleto.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rblIncompleto.Location = new System.Drawing.Point(3, 88);
            this.rblIncompleto.Name = "rblIncompleto";
            this.rblIncompleto.Size = new System.Drawing.Size(112, 23);
            this.rblIncompleto.TabIndex = 50;
            this.rblIncompleto.TabStop = true;
            this.rblIncompleto.Text = "Incompleto";
            this.rblIncompleto.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbTodos.Location = new System.Drawing.Point(239, 88);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(112, 23);
            this.rbTodos.TabIndex = 51;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // btnEnvioMail
            // 
            this.btnEnvioMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnvioMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnEnvioMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnvioMail.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnEnvioMail.ForeColor = System.Drawing.Color.White;
            this.btnEnvioMail.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnEnvioMail.IconColor = System.Drawing.Color.White;
            this.btnEnvioMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnvioMail.IconSize = 32;
            this.btnEnvioMail.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEnvioMail.Location = new System.Drawing.Point(416, 67);
            this.btnEnvioMail.Name = "btnEnvioMail";
            this.tableLayoutPanel1.SetRowSpan(this.btnEnvioMail, 2);
            this.btnEnvioMail.Size = new System.Drawing.Size(133, 50);
            this.btnEnvioMail.TabIndex = 56;
            this.btnEnvioMail.Text = "Envio Mail";
            this.btnEnvioMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnvioMail.UseVisualStyleBackColor = false;
            // 
            // ControlDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.dgvAlumnos);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlDocumentacion";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "ControlDocumentacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        public System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CapaPresentacionAdmin.Controls.uscPaginacion uscPaginacion1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSelccFiltroAlum;
        private System.Windows.Forms.ComboBox cmbFiltroAlum;
        private System.Windows.Forms.RadioButton rbICompleto;
        private System.Windows.Forms.RadioButton rblIncompleto;
        private System.Windows.Forms.RadioButton rbTodos;
        private FontAwesome.Sharp.IconButton btnEnvioMail;
    }
}