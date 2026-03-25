
namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormCargaEvaluaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargaEvaluaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloCargaEvaluaciones = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.dgvEvaluaciones = new System.Windows.Forms.DataGridView();
            this.lblFechaExamen = new System.Windows.Forms.Label();
            this.dtpFechaExamen = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcial1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recuperatorio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcial2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recuperatorio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloCargaEvaluaciones
            // 
            this.lblTituloCargaEvaluaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.lblTituloCargaEvaluaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloCargaEvaluaciones.ForeColor = System.Drawing.Color.White;
            this.lblTituloCargaEvaluaciones.Location = new System.Drawing.Point(0, 0);
            this.lblTituloCargaEvaluaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloCargaEvaluaciones.Name = "lblTituloCargaEvaluaciones";
            this.lblTituloCargaEvaluaciones.Size = new System.Drawing.Size(817, 50);
            this.lblTituloCargaEvaluaciones.TabIndex = 35;
            this.lblTituloCargaEvaluaciones.Text = "Carga de evaluaciones";
            this.lblTituloCargaEvaluaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.InitialImage = null;
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(42, 38);
            this.btnVolver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVolver.TabIndex = 36;
            this.btnVolver.TabStop = false;
            // 
            // dgvEvaluaciones
            // 
            this.dgvEvaluaciones.AllowUserToAddRows = false;
            this.dgvEvaluaciones.AllowUserToDeleteRows = false;
            this.dgvEvaluaciones.AllowUserToResizeColumns = false;
            this.dgvEvaluaciones.AllowUserToResizeRows = false;
            this.dgvEvaluaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvaluaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvaluaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEvaluaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEvaluaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvaluaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEvaluaciones.ColumnHeadersHeight = 34;
            this.dgvEvaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvaluaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Parcial1,
            this.Recuperatorio1,
            this.Informe1,
            this.Parcial2,
            this.Recuperatorio2,
            this.Informe2,
            this.Column9,
            this.Column10,
            this.Column4});
            this.dgvEvaluaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEvaluaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEvaluaciones.EnableHeadersVisualStyles = false;
            this.dgvEvaluaciones.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvEvaluaciones.Location = new System.Drawing.Point(12, 130);
            this.dgvEvaluaciones.MultiSelect = false;
            this.dgvEvaluaciones.Name = "dgvEvaluaciones";
            this.dgvEvaluaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(16)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvaluaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEvaluaciones.RowHeadersVisible = false;
            this.dgvEvaluaciones.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Navy;
            this.dgvEvaluaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEvaluaciones.RowTemplate.Height = 28;
            this.dgvEvaluaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEvaluaciones.Size = new System.Drawing.Size(793, 403);
            this.dgvEvaluaciones.TabIndex = 44;
            this.dgvEvaluaciones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvaluaciones_CellEndEdit);
            // 
            // lblFechaExamen
            // 
            this.lblFechaExamen.AutoSize = true;
            this.lblFechaExamen.Location = new System.Drawing.Point(75, 72);
            this.lblFechaExamen.Name = "lblFechaExamen";
            this.lblFechaExamen.Size = new System.Drawing.Size(77, 19);
            this.lblFechaExamen.TabIndex = 45;
            this.lblFechaExamen.Text = "1° Parcial";
            // 
            // dtpFechaExamen
            // 
            this.dtpFechaExamen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaExamen.Location = new System.Drawing.Point(158, 67);
            this.dtpFechaExamen.Name = "dtpFechaExamen";
            this.dtpFechaExamen.Size = new System.Drawing.Size(200, 27);
            this.dtpFechaExamen.TabIndex = 46;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(388, 63);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 33);
            this.btnGuardar.TabIndex = 70;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CursadaAlumnoCarreraId";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Alumnos";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Condicion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Parcial1
            // 
            this.Parcial1.HeaderText = "Fecha1";
            this.Parcial1.Name = "Parcial1";
            // 
            // Recuperatorio1
            // 
            this.Recuperatorio1.HeaderText = "Fecha2";
            this.Recuperatorio1.Name = "Recuperatorio1";
            this.Recuperatorio1.ReadOnly = true;
            // 
            // Informe1
            // 
            this.Informe1.HeaderText = "1° Informe";
            this.Informe1.Name = "Informe1";
            this.Informe1.ReadOnly = true;
            // 
            // Parcial2
            // 
            this.Parcial2.HeaderText = "Fecha1";
            this.Parcial2.Name = "Parcial2";
            this.Parcial2.ReadOnly = true;
            // 
            // Recuperatorio2
            // 
            this.Recuperatorio2.HeaderText = "Fecha2";
            this.Recuperatorio2.Name = "Recuperatorio2";
            this.Recuperatorio2.ReadOnly = true;
            // 
            // Informe2
            // 
            this.Informe2.HeaderText = "2° Informe";
            this.Informe2.Name = "Informe2";
            this.Informe2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Compensatorio";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Cursada aprobada/recursa";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "CursadaNotasId";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // FormCargaEvaluaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpFechaExamen);
            this.Controls.Add(this.lblFechaExamen);
            this.Controls.Add(this.dgvEvaluaciones);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTituloCargaEvaluaciones);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCargaEvaluaciones";
            this.Text = "FormCargaEvaluaciones";
            this.Load += new System.EventHandler(this.FormCargaEvaluaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTituloCargaEvaluaciones;
        private System.Windows.Forms.PictureBox btnVolver;
        public System.Windows.Forms.DataGridView dgvEvaluaciones;
        private System.Windows.Forms.Label lblFechaExamen;
        private System.Windows.Forms.DateTimePicker dtpFechaExamen;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcial1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recuperatorio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcial2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recuperatorio2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}