namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormMesasFinales
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
            this.dgvMesasFinales = new System.Windows.Forms.DataGridView();
            this.btnAgregarMesa = new FontAwesome.Sharp.IconButton();
            this.cmbAnioLectivo = new System.Windows.Forms.ComboBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLlamados = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReporteMesas = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesasFinales)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMesasFinales, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarMesa, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbAnioLectivo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTurno, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbLlamados, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReporteMesas, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 420);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvMesasFinales
            // 
            this.dgvMesasFinales.AllowUserToAddRows = false;
            this.dgvMesasFinales.AllowUserToDeleteRows = false;
            this.dgvMesasFinales.AllowUserToResizeColumns = false;
            this.dgvMesasFinales.AllowUserToResizeRows = false;
            this.dgvMesasFinales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMesasFinales.BackgroundColor = System.Drawing.Color.White;
            this.dgvMesasFinales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMesasFinales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMesasFinales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMesasFinales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvMesasFinales, 4);
            this.dgvMesasFinales.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMesasFinales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMesasFinales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMesasFinales.EnableHeadersVisualStyles = false;
            this.dgvMesasFinales.GridColor = System.Drawing.Color.White;
            this.dgvMesasFinales.Location = new System.Drawing.Point(3, 83);
            this.dgvMesasFinales.MultiSelect = false;
            this.dgvMesasFinales.Name = "dgvMesasFinales";
            this.dgvMesasFinales.ReadOnly = true;
            this.dgvMesasFinales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMesasFinales.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMesasFinales.RowHeadersVisible = false;
            this.dgvMesasFinales.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvMesasFinales.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMesasFinales.RowTemplate.Height = 28;
            this.dgvMesasFinales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMesasFinales.Size = new System.Drawing.Size(754, 334);
            this.dgvMesasFinales.TabIndex = 3;
            this.dgvMesasFinales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMesasFinales_CellDoubleClick);
            // 
            // btnAgregarMesa
            // 
            this.btnAgregarMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnAgregarMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMesa.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMesa.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.btnAgregarMesa.IconColor = System.Drawing.Color.White;
            this.btnAgregarMesa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarMesa.IconSize = 25;
            this.btnAgregarMesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMesa.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarMesa.Name = "btnAgregarMesa";
            this.btnAgregarMesa.Size = new System.Drawing.Size(154, 34);
            this.btnAgregarMesa.TabIndex = 4;
            this.btnAgregarMesa.Text = "    Mesa Especial    ";
            this.btnAgregarMesa.UseVisualStyleBackColor = false;
            this.btnAgregarMesa.Click += new System.EventHandler(this.btnAgregarMesa_Click);
            // 
            // cmbAnioLectivo
            // 
            this.cmbAnioLectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioLectivo.FormattingEnabled = true;
            this.cmbAnioLectivo.Location = new System.Drawing.Point(163, 43);
            this.cmbAnioLectivo.Name = "cmbAnioLectivo";
            this.cmbAnioLectivo.Size = new System.Drawing.Size(193, 27);
            this.cmbAnioLectivo.TabIndex = 5;
            this.cmbAnioLectivo.SelectionChangeCommitted += new System.EventHandler(this.cmbAnioLectivo_SelectionChangeCommitted);
            // 
            // cmbTurno
            // 
            this.cmbTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Location = new System.Drawing.Point(362, 43);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(193, 27);
            this.cmbTurno.TabIndex = 6;
            this.cmbTurno.SelectionChangeCommitted += new System.EventHandler(this.cmbTurno_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Turno:";
            // 
            // cmbLlamados
            // 
            this.cmbLlamados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLlamados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLlamados.FormattingEnabled = true;
            this.cmbLlamados.Location = new System.Drawing.Point(561, 43);
            this.cmbLlamados.Name = "cmbLlamados";
            this.cmbLlamados.Size = new System.Drawing.Size(196, 27);
            this.cmbLlamados.TabIndex = 9;
            this.cmbLlamados.SelectionChangeCommitted += new System.EventHandler(this.cmbLlamados_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Llamado:";
            // 
            // btnReporteMesas
            // 
            this.btnReporteMesas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnReporteMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReporteMesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteMesas.ForeColor = System.Drawing.Color.White;
            this.btnReporteMesas.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnReporteMesas.IconColor = System.Drawing.Color.White;
            this.btnReporteMesas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporteMesas.IconSize = 25;
            this.btnReporteMesas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteMesas.Location = new System.Drawing.Point(3, 43);
            this.btnReporteMesas.Name = "btnReporteMesas";
            this.btnReporteMesas.Size = new System.Drawing.Size(154, 34);
            this.btnReporteMesas.TabIndex = 11;
            this.btnReporteMesas.Text = "Imprimir Mesas";
            this.btnReporteMesas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporteMesas.UseVisualStyleBackColor = false;
            this.btnReporteMesas.Click += new System.EventHandler(this.btnReporteMesas_Click);
            // 
            // FormMesasFinales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMesasFinales";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.Text = "FormMesasFinales";
            this.Load += new System.EventHandler(this.FormMesasFinales_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesasFinales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dgvMesasFinales;
        private FontAwesome.Sharp.IconButton btnAgregarMesa;
        private System.Windows.Forms.ComboBox cmbAnioLectivo;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLlamados;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnReporteMesas;
    }
}