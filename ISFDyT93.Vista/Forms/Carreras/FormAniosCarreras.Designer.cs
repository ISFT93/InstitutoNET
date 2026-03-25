
namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormAniosCarreras
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
            this.cmsAniosCarreras = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCorrelativas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesactivarAnio = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvAniosCarrera = new System.Windows.Forms.DataGridView();
            this.lblCargaHorariaTotal = new System.Windows.Forms.Label();
            this.cmsAniosCarreras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAniosCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsAniosCarreras
            // 
            this.cmsAniosCarreras.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsAniosCarreras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerMaterias,
            this.tsmVerCursos,
            this.tsmVerHorarios,
            this.tsmVerCorrelativas,
            this.tsmDesactivarAnio});
            this.cmsAniosCarreras.Name = "cmsAniosCarreras";
            this.cmsAniosCarreras.Size = new System.Drawing.Size(179, 154);
            // 
            // tsmVerMaterias
            // 
            this.tsmVerMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerMaterias.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerMaterias.ForeColor = System.Drawing.Color.White;
            this.tsmVerMaterias.Image = global::ISFDyT93.Vista.Properties.Resources.list_alt_solid;
            this.tsmVerMaterias.Name = "tsmVerMaterias";
            this.tsmVerMaterias.Size = new System.Drawing.Size(178, 30);
            this.tsmVerMaterias.Text = "Ver Materias";
            this.tsmVerMaterias.Click += new System.EventHandler(this.tsmVerMaterias_Click);
            // 
            // tsmVerCursos
            // 
            this.tsmVerCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCursos.CheckOnClick = true;
            this.tsmVerCursos.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerCursos.ForeColor = System.Drawing.Color.White;
            this.tsmVerCursos.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.tsmVerCursos.Name = "tsmVerCursos";
            this.tsmVerCursos.Size = new System.Drawing.Size(178, 30);
            this.tsmVerCursos.Text = "Ver Cursos";
            this.tsmVerCursos.Click += new System.EventHandler(this.tsmVerCursos_Click);
            // 
            // tsmVerHorarios
            // 
            this.tsmVerHorarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerHorarios.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerHorarios.ForeColor = System.Drawing.Color.White;
            this.tsmVerHorarios.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerHorarios.Name = "tsmVerHorarios";
            this.tsmVerHorarios.Size = new System.Drawing.Size(178, 30);
            this.tsmVerHorarios.Text = "Ver Horarios";
            this.tsmVerHorarios.Click += new System.EventHandler(this.tsmVerHorarios_Click);
            // 
            // tsmVerCorrelativas
            // 
            this.tsmVerCorrelativas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCorrelativas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerCorrelativas.ForeColor = System.Drawing.Color.White;
            this.tsmVerCorrelativas.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerCorrelativas.Name = "tsmVerCorrelativas";
            this.tsmVerCorrelativas.Size = new System.Drawing.Size(178, 30);
            this.tsmVerCorrelativas.Text = "Ver Correlativas";
            this.tsmVerCorrelativas.Click += new System.EventHandler(this.tsmVerCorrelativas_Click);
            // 
            // tsmDesactivarAnio
            // 
            this.tsmDesactivarAnio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDesactivarAnio.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDesactivarAnio.ForeColor = System.Drawing.Color.White;
            this.tsmDesactivarAnio.Image = global::ISFDyT93.Vista.Properties.Resources.eye_slash_solid;
            this.tsmDesactivarAnio.Name = "tsmDesactivarAnio";
            this.tsmDesactivarAnio.Size = new System.Drawing.Size(178, 30);
            this.tsmDesactivarAnio.Text = "Desactivar";
            this.tsmDesactivarAnio.Click += new System.EventHandler(this.tsmDesactivarAnio_Click);
            // 
            // dgvAniosCarrera
            // 
            this.dgvAniosCarrera.AllowUserToAddRows = false;
            this.dgvAniosCarrera.AllowUserToDeleteRows = false;
            this.dgvAniosCarrera.AllowUserToResizeColumns = false;
            this.dgvAniosCarrera.AllowUserToResizeRows = false;
            this.dgvAniosCarrera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAniosCarrera.BackgroundColor = System.Drawing.Color.White;
            this.dgvAniosCarrera.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAniosCarrera.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAniosCarrera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAniosCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAniosCarrera.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAniosCarrera.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAniosCarrera.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAniosCarrera.EnableHeadersVisualStyles = false;
            this.dgvAniosCarrera.GridColor = System.Drawing.Color.White;
            this.dgvAniosCarrera.Location = new System.Drawing.Point(20, 20);
            this.dgvAniosCarrera.MultiSelect = false;
            this.dgvAniosCarrera.Name = "dgvAniosCarrera";
            this.dgvAniosCarrera.ReadOnly = true;
            this.dgvAniosCarrera.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAniosCarrera.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAniosCarrera.RowHeadersVisible = false;
            this.dgvAniosCarrera.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAniosCarrera.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAniosCarrera.RowTemplate.Height = 28;
            this.dgvAniosCarrera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAniosCarrera.Size = new System.Drawing.Size(777, 400);
            this.dgvAniosCarrera.TabIndex = 1;
            this.dgvAniosCarrera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCarreras_MouseUp);
            // 
            // lblCargaHorariaTotal
            // 
            this.lblCargaHorariaTotal.AutoSize = true;
            this.lblCargaHorariaTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCargaHorariaTotal.Location = new System.Drawing.Point(20, 420);
            this.lblCargaHorariaTotal.Name = "lblCargaHorariaTotal";
            this.lblCargaHorariaTotal.Size = new System.Drawing.Size(0, 19);
            this.lblCargaHorariaTotal.TabIndex = 2;
            // 
            // FormAniosCarreras
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.lblCargaHorariaTotal);
            this.Controls.Add(this.dgvAniosCarrera);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAniosCarreras";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAniosCarreras";
            this.Load += new System.EventHandler(this.FormAniosCarreras_Load);
            this.cmsAniosCarreras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAniosCarrera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsAniosCarreras;
        private System.Windows.Forms.ToolStripMenuItem tsmVerMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmVerHorarios;
        public System.Windows.Forms.DataGridView dgvAniosCarrera;
        private System.Windows.Forms.Label lblCargaHorariaTotal;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCorrelativas;
        private System.Windows.Forms.ToolStripMenuItem tsmDesactivarAnio;
    }
}