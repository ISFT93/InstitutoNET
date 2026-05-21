namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormModificacionActa
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvActa = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFechaActa = new System.Windows.Forms.Label();
            this.lblFirma = new System.Windows.Forms.Label();
            this.dtpFechaModiActa = new System.Windows.Forms.DateTimePicker();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Siguiente = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActa)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dgvActa, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 100);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(760, 330);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvActa
            // 
            this.dgvActa.AllowUserToAddRows = false;
            this.dgvActa.AllowUserToDeleteRows = false;
            this.dgvActa.AllowUserToResizeColumns = false;
            this.dgvActa.AllowUserToResizeRows = false;
            this.dgvActa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvActa.BackgroundColor = System.Drawing.Color.White;
            this.dgvActa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvActa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActa.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActa.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvActa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActa.EnableHeadersVisualStyles = false;
            this.dgvActa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.dgvActa.Location = new System.Drawing.Point(6, 6);
            this.dgvActa.Margin = new System.Windows.Forms.Padding(6);
            this.dgvActa.MultiSelect = false;
            this.dgvActa.Name = "dgvActa";
            this.dgvActa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(16)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActa.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvActa.RowHeadersVisible = false;
            this.dgvActa.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvActa.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvActa.RowTemplate.Height = 28;
            this.dgvActa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActa.Size = new System.Drawing.Size(748, 318);
            this.dgvActa.TabIndex = 69;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblFechaActa, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFirma, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaModiActa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFirma, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 90);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFechaActa
            // 
            this.lblFechaActa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaActa.AutoSize = true;
            this.lblFechaActa.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblFechaActa.Location = new System.Drawing.Point(3, 26);
            this.lblFechaActa.Name = "lblFechaActa";
            this.lblFechaActa.Size = new System.Drawing.Size(184, 38);
            this.lblFechaActa.TabIndex = 0;
            this.lblFechaActa.Text = "Fecha del primer llamado :";
            // 
            // lblFirma
            // 
            this.lblFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirma.AutoSize = true;
            this.lblFirma.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblFirma.Location = new System.Drawing.Point(383, 35);
            this.lblFirma.Name = "lblFirma";
            this.lblFirma.Size = new System.Drawing.Size(184, 19);
            this.lblFirma.TabIndex = 1;
            this.lblFirma.Text = "Firma :";
            // 
            // dtpFechaModiActa
            // 
            this.dtpFechaModiActa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaModiActa.CalendarFont = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaModiActa.Location = new System.Drawing.Point(193, 35);
            this.dtpFechaModiActa.Name = "dtpFechaModiActa";
            this.dtpFechaModiActa.Size = new System.Drawing.Size(184, 20);
            this.dtpFechaModiActa.TabIndex = 2;
            // 
            // txtFirma
            // 
            this.txtFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirma.Location = new System.Drawing.Point(573, 35);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(184, 20);
            this.txtFirma.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_Siguiente, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 330);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 100);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btn_Siguiente
            // 
            this.btn_Siguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Siguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btn_Siguiente.FlatAppearance.BorderSize = 0;
            this.btn_Siguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Siguiente.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Siguiente.ForeColor = System.Drawing.Color.White;
            this.btn_Siguiente.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btn_Siguiente.IconColor = System.Drawing.Color.White;
            this.btn_Siguiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Siguiente.IconSize = 25;
            this.btn_Siguiente.Location = new System.Drawing.Point(603, 62);
            this.btn_Siguiente.Name = "btn_Siguiente";
            this.btn_Siguiente.Size = new System.Drawing.Size(154, 35);
            this.btn_Siguiente.TabIndex = 5;
            this.btn_Siguiente.Text = "Siguiente";
            this.btn_Siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Siguiente.UseVisualStyleBackColor = false;
            // 
            // FormModificacionActa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModificacionActa";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.Text = "FormModificacionActa";
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActa)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dgvActa;
        private System.Windows.Forms.Label lblFechaActa;
        private System.Windows.Forms.Label lblFirma;
        private System.Windows.Forms.DateTimePicker dtpFechaModiActa;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton btn_Siguiente;
    }
}