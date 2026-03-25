namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormAgregarModificarEquivalencias
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
            this.btnAsignar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.lstEquivalentes = new System.Windows.Forms.ListBox();
            this.lstMaterias = new System.Windows.Forms.ListBox();
            this.lblEquivalente = new System.Windows.Forms.Label();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCarreras = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvEquivalencias = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquivalencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.btnAsignar.IconColor = System.Drawing.Color.White;
            this.btnAsignar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAsignar.Location = new System.Drawing.Point(343, 124);
            this.btnAsignar.Name = "btnAsignar";
            this.tableLayoutPanel1.SetRowSpan(this.btnAsignar, 2);
            this.btnAsignar.Size = new System.Drawing.Size(74, 50);
            this.btnAsignar.TabIndex = 9;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Asignar";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Eliminar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.Location = new System.Drawing.Point(343, 250);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 49);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lstEquivalentes
            // 
            this.lstEquivalentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstEquivalentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEquivalentes.ForeColor = System.Drawing.Color.White;
            this.lstEquivalentes.FormattingEnabled = true;
            this.lstEquivalentes.ItemHeight = 19;
            this.lstEquivalentes.Location = new System.Drawing.Point(423, 97);
            this.lstEquivalentes.Name = "lstEquivalentes";
            this.tableLayoutPanel1.SetRowSpan(this.lstEquivalentes, 4);
            this.lstEquivalentes.Size = new System.Drawing.Size(334, 120);
            this.lstEquivalentes.TabIndex = 5;
            // 
            // lstMaterias
            // 
            this.lstMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMaterias.ForeColor = System.Drawing.Color.White;
            this.lstMaterias.FormattingEnabled = true;
            this.lstMaterias.ItemHeight = 19;
            this.lstMaterias.Location = new System.Drawing.Point(3, 97);
            this.lstMaterias.Name = "lstMaterias";
            this.tableLayoutPanel1.SetRowSpan(this.lstMaterias, 4);
            this.lstMaterias.Size = new System.Drawing.Size(334, 120);
            this.lstMaterias.TabIndex = 4;
            // 
            // lblEquivalente
            // 
            this.lblEquivalente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEquivalente.AutoSize = true;
            this.lblEquivalente.Location = new System.Drawing.Point(423, 71);
            this.lblEquivalente.Name = "lblEquivalente";
            this.lblEquivalente.Size = new System.Drawing.Size(334, 19);
            this.lblEquivalente.TabIndex = 3;
            this.lblEquivalente.Text = "Materias Equivalentes";
            this.lblEquivalente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaterias
            // 
            this.lblMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Location = new System.Drawing.Point(3, 71);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(334, 19);
            this.lblMaterias.TabIndex = 2;
            this.lblMaterias.Text = "Materias";
            this.lblMaterias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Carrera...";
            // 
            // cmbCarreras
            // 
            this.cmbCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCarreras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarreras.FormattingEnabled = true;
            this.cmbCarreras.Location = new System.Drawing.Point(3, 36);
            this.cmbCarreras.Name = "cmbCarreras";
            this.cmbCarreras.Size = new System.Drawing.Size(334, 27);
            this.cmbCarreras.TabIndex = 1;
            this.cmbCarreras.SelectionChangeCommitted += new System.EventHandler(this.cmbCarreras_SelectionChangeCommitted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvEquivalencias, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbCarreras, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaterias, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEquivalente, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstMaterias, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lstEquivalentes, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAsignar, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 410);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvEquivalencias
            // 
            this.dgvEquivalencias.AllowUserToAddRows = false;
            this.dgvEquivalencias.AllowUserToDeleteRows = false;
            this.dgvEquivalencias.AllowUserToResizeColumns = false;
            this.dgvEquivalencias.AllowUserToResizeRows = false;
            this.dgvEquivalencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquivalencias.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquivalencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEquivalencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquivalencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquivalencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvEquivalencias, 3);
            this.dgvEquivalencias.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquivalencias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquivalencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquivalencias.EnableHeadersVisualStyles = false;
            this.dgvEquivalencias.GridColor = System.Drawing.Color.White;
            this.dgvEquivalencias.Location = new System.Drawing.Point(3, 305);
            this.dgvEquivalencias.MultiSelect = false;
            this.dgvEquivalencias.Name = "dgvEquivalencias";
            this.dgvEquivalencias.ReadOnly = true;
            this.dgvEquivalencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquivalencias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquivalencias.RowHeadersVisible = false;
            this.dgvEquivalencias.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvEquivalencias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEquivalencias.RowTemplate.Height = 28;
            this.dgvEquivalencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquivalencias.Size = new System.Drawing.Size(754, 102);
            this.dgvEquivalencias.TabIndex = 12;
            this.dgvEquivalencias.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquivalencias_CellMouseClick);
            // 
            // FormAgregarModificarEquivalencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAgregarModificarEquivalencias";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAgregarModificarEquivalencias";
            this.Load += new System.EventHandler(this.FormAgregarModificarEquivalencias_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquivalencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCarreras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.Label lblEquivalente;
        private System.Windows.Forms.ListBox lstMaterias;
        private System.Windows.Forms.ListBox lstEquivalentes;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnAsignar;
        public System.Windows.Forms.DataGridView dgvEquivalencias;
    }
}