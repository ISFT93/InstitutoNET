
namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCursos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsCursos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAsignarCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCursoDarAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbInactivos = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.tsmVerMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCursos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsCursos
            // 
            this.cmsCursos.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAsignarCurso,
            this.tsmModificarCurso,
            this.tsmEliminarCursos,
            this.tsmCursoDarAlta,
            this.tsmVerMaterias});
            this.cmsCursos.Name = "contextMenuStrip1";
            this.cmsCursos.Size = new System.Drawing.Size(219, 182);
            // 
            // tsmAsignarCurso
            // 
            this.tsmAsignarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAsignarCurso.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAsignarCurso.ForeColor = System.Drawing.Color.White;
            this.tsmAsignarCurso.Image = ((System.Drawing.Image)(resources.GetObject("tsmAsignarCurso.Image")));
            this.tsmAsignarCurso.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsmAsignarCurso.Name = "tsmAsignarCurso";
            this.tsmAsignarCurso.Size = new System.Drawing.Size(218, 30);
            this.tsmAsignarCurso.Text = "Asignar ";
            this.tsmAsignarCurso.Click += new System.EventHandler(this.tsmAsignarCurso_Click);
            // 
            // tsmModificarCurso
            // 
            this.tsmModificarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarCurso.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarCurso.ForeColor = System.Drawing.Color.White;
            this.tsmModificarCurso.Image = ((System.Drawing.Image)(resources.GetObject("tsmModificarCurso.Image")));
            this.tsmModificarCurso.Name = "tsmModificarCurso";
            this.tsmModificarCurso.Size = new System.Drawing.Size(218, 30);
            this.tsmModificarCurso.Text = "Modificar ";
            this.tsmModificarCurso.Click += new System.EventHandler(this.tsmModificarCurso_Click);
            // 
            // tsmEliminarCursos
            // 
            this.tsmEliminarCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmEliminarCursos.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEliminarCursos.ForeColor = System.Drawing.Color.White;
            this.tsmEliminarCursos.Image = ((System.Drawing.Image)(resources.GetObject("tsmEliminarCursos.Image")));
            this.tsmEliminarCursos.Name = "tsmEliminarCursos";
            this.tsmEliminarCursos.Size = new System.Drawing.Size(218, 30);
            this.tsmEliminarCursos.Text = "Eliminar ";
            this.tsmEliminarCursos.Click += new System.EventHandler(this.tsmEliminarCursos_Click);
            // 
            // tsmCursoDarAlta
            // 
            this.tsmCursoDarAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmCursoDarAlta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmCursoDarAlta.ForeColor = System.Drawing.Color.White;
            this.tsmCursoDarAlta.Image = ((System.Drawing.Image)(resources.GetObject("tsmCursoDarAlta.Image")));
            this.tsmCursoDarAlta.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsmCursoDarAlta.Name = "tsmCursoDarAlta";
            this.tsmCursoDarAlta.Size = new System.Drawing.Size(218, 30);
            this.tsmCursoDarAlta.Text = "Dar de Alta";
            this.tsmCursoDarAlta.Click += new System.EventHandler(this.tsmCursoDarAlta_Click);
            // 
            // rbActivos
            // 
            this.rbActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(4, 11);
            this.rbActivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(229, 28);
            this.rbActivos.TabIndex = 55;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Activos";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // rbInactivos
            // 
            this.rbInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInactivos.AutoSize = true;
            this.rbInactivos.Location = new System.Drawing.Point(241, 11);
            this.rbInactivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(229, 28);
            this.rbInactivos.TabIndex = 54;
            this.rbInactivos.Text = "Inactivos";
            this.rbInactivos.UseVisualStyleBackColor = true;
            this.rbInactivos.CheckedChanged += new System.EventHandler(this.rbInactivos_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Controls.Add(this.rbActivos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbInactivos, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 86);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeColumns = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCursos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCursos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursos.EnableHeadersVisualStyles = false;
            this.dgvCursos.GridColor = System.Drawing.Color.White;
            this.dgvCursos.Location = new System.Drawing.Point(24, 111);
            this.dgvCursos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCursos.RowHeadersVisible = false;
            this.dgvCursos.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCursos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCursos.RowTemplate.Height = 28;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(951, 552);
            this.dgvCursos.TabIndex = 57;
            this.dgvCursos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCursos_MouseUp);
            // 
            // tsmVerMaterias
            // 
            this.tsmVerMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerMaterias.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerMaterias.ForeColor = System.Drawing.Color.White;
            this.tsmVerMaterias.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerMaterias.Name = "tsmVerMaterias";
            this.tsmVerMaterias.Size = new System.Drawing.Size(218, 30);
            this.tsmVerMaterias.Text = "Ver Materias";
            this.tsmVerMaterias.Click += new System.EventHandler(this.tsmVerMaterias_Click);
            // 
            // FormCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 688);
            this.Controls.Add(this.dgvCursos);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormCursos";
            this.Padding = new System.Windows.Forms.Padding(24, 25, 24, 25);
            this.Text = "FormCursos";
            this.Load += new System.EventHandler(this.FormCursos_Load);
            this.cmsCursos.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmAsignarCurso;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarCurso;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmCursoDarAlta;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.RadioButton rbInactivos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmVerMaterias;
    }
}