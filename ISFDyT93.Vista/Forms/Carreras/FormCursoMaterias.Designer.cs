namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormCursoMaterias
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
            this.cmsCursoMaterias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControlarAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCicloLectivo = new System.Windows.Forms.ComboBox();
            this.dgvCursoMaterias = new System.Windows.Forms.DataGridView();
            this.Acciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsCursoMaterias.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursoMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsCursoMaterias
            // 
            this.cmsCursoMaterias.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsCursoMaterias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerAlumnos,
            this.tsmControlarAsistencia});
            this.cmsCursoMaterias.Name = "cmsAniosCarreras";
            this.cmsCursoMaterias.Size = new System.Drawing.Size(203, 64);
            // 
            // tsmVerAlumnos
            // 
            this.tsmVerAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerAlumnos.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerAlumnos.ForeColor = System.Drawing.Color.White;
            this.tsmVerAlumnos.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerAlumnos.Name = "tsmVerAlumnos";
            this.tsmVerAlumnos.Size = new System.Drawing.Size(202, 30);
            this.tsmVerAlumnos.Text = "Ver Alumnos";
            this.tsmVerAlumnos.Click += new System.EventHandler(this.tsmVerAlumnos_Click);
            // 
            // tsmControlarAsistencia
            // 
            this.tsmControlarAsistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmControlarAsistencia.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmControlarAsistencia.ForeColor = System.Drawing.Color.White;
            this.tsmControlarAsistencia.Image = global::ISFDyT93.Vista.Properties.Resources.list_alt_solid;
            this.tsmControlarAsistencia.Name = "tsmControlarAsistencia";
            this.tsmControlarAsistencia.Size = new System.Drawing.Size(202, 30);
            this.tsmControlarAsistencia.Text = "Controlar Asistencia";
            this.tsmControlarAsistencia.Click += new System.EventHandler(this.tsmControlarAsistencia_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cmbCicloLectivo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvCursoMaterias, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.21118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.18012F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.6087F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 382);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cmbCicloLectivo
            // 
            this.cmbCicloLectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCicloLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCicloLectivo.FormattingEnabled = true;
            this.cmbCicloLectivo.Location = new System.Drawing.Point(3, 33);
            this.cmbCicloLectivo.Name = "cmbCicloLectivo";
            this.cmbCicloLectivo.Size = new System.Drawing.Size(754, 27);
            this.cmbCicloLectivo.Sorted = true;
            this.cmbCicloLectivo.TabIndex = 0;
            this.cmbCicloLectivo.SelectedIndexChanged += new System.EventHandler(this.cmbCicloLectivo_SelectedIndexChanged);
            // 
            // dgvCursoMaterias
            // 
            this.dgvCursoMaterias.AllowUserToAddRows = false;
            this.dgvCursoMaterias.AllowUserToDeleteRows = false;
            this.dgvCursoMaterias.AllowUserToResizeColumns = false;
            this.dgvCursoMaterias.AllowUserToResizeRows = false;
            this.dgvCursoMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursoMaterias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCursoMaterias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCursoMaterias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursoMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCursoMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursoMaterias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Acciones});
            this.dgvCursoMaterias.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursoMaterias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCursoMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursoMaterias.EnableHeadersVisualStyles = false;
            this.dgvCursoMaterias.GridColor = System.Drawing.Color.White;
            this.dgvCursoMaterias.Location = new System.Drawing.Point(3, 68);
            this.dgvCursoMaterias.MultiSelect = false;
            this.dgvCursoMaterias.Name = "dgvCursoMaterias";
            this.dgvCursoMaterias.ReadOnly = true;
            this.dgvCursoMaterias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursoMaterias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCursoMaterias.RowHeadersVisible = false;
            this.dgvCursoMaterias.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCursoMaterias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCursoMaterias.RowTemplate.Height = 28;
            this.dgvCursoMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursoMaterias.Size = new System.Drawing.Size(754, 311);
            this.dgvCursoMaterias.TabIndex = 6;
            this.dgvCursoMaterias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursoMaterias_CellContentClick);
            // 
            // Acciones
            // 
            this.Acciones.FillWeight = 50F;
            this.Acciones.HeaderText = "Acciones";
            this.Acciones.MinimumWidth = 6;
            this.Acciones.Name = "Acciones";
            this.Acciones.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ciclo Lectivo";
            // 
            // FormCursoMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCursoMaterias";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormCursoMaterias";
            this.Load += new System.EventHandler(this.FormCursoMaterias_Load);
            this.cmsCursoMaterias.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursoMaterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsCursoMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmVerAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmControlarAsistencia;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCicloLectivo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvCursoMaterias;
        private System.Windows.Forms.DataGridViewButtonColumn Acciones;
    }
}