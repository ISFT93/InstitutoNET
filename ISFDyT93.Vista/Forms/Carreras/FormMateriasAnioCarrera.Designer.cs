
namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormMateriasAnioCarrera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMateriasAnioCarrera));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsMaterias = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCorrelatividades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.dgvMatAnioCarrera = new System.Windows.Forms.DataGridView();
            this.cmsMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatAnioCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMaterias
            // 
            this.cmsMaterias.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMaterias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarMateria,
            this.tsmModificarMateria,
            this.tsmVerCorrelatividades,
            this.tsmEliminarMateria});
            this.cmsMaterias.Name = "cmsMaterias";
            this.cmsMaterias.Size = new System.Drawing.Size(227, 124);
            // 
            // tsmAgregarMateria
            // 
            this.tsmAgregarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarMateria.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAgregarMateria.ForeColor = System.Drawing.Color.White;
            this.tsmAgregarMateria.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarMateria.Image")));
            this.tsmAgregarMateria.Name = "tsmAgregarMateria";
            this.tsmAgregarMateria.Size = new System.Drawing.Size(226, 30);
            this.tsmAgregarMateria.Text = "Agregar";
            this.tsmAgregarMateria.Click += new System.EventHandler(this.tsmAgregarMateria_Click);
            // 
            // tsmModificarMateria
            // 
            this.tsmModificarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarMateria.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarMateria.ForeColor = System.Drawing.Color.White;
            this.tsmModificarMateria.Image = ((System.Drawing.Image)(resources.GetObject("tsmModificarMateria.Image")));
            this.tsmModificarMateria.Name = "tsmModificarMateria";
            this.tsmModificarMateria.Size = new System.Drawing.Size(226, 30);
            this.tsmModificarMateria.Text = "Modificar";
            this.tsmModificarMateria.Click += new System.EventHandler(this.tsmModificarMateria_Click);
            // 
            // tsmVerCorrelatividades
            // 
            this.tsmVerCorrelatividades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCorrelatividades.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerCorrelatividades.ForeColor = System.Drawing.Color.White;
            this.tsmVerCorrelatividades.Image = ((System.Drawing.Image)(resources.GetObject("tsmVerCorrelatividades.Image")));
            this.tsmVerCorrelatividades.Name = "tsmVerCorrelatividades";
            this.tsmVerCorrelatividades.Size = new System.Drawing.Size(226, 30);
            this.tsmVerCorrelatividades.Text = "Ver Correlatividades";
            this.tsmVerCorrelatividades.Click += new System.EventHandler(this.tsmVerCorrelatividades_Click);
            // 
            // tsmEliminarMateria
            // 
            this.tsmEliminarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmEliminarMateria.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEliminarMateria.ForeColor = System.Drawing.Color.White;
            this.tsmEliminarMateria.Image = ((System.Drawing.Image)(resources.GetObject("tsmEliminarMateria.Image")));
            this.tsmEliminarMateria.Name = "tsmEliminarMateria";
            this.tsmEliminarMateria.Size = new System.Drawing.Size(226, 30);
            this.tsmEliminarMateria.Text = "Eliminar";
            this.tsmEliminarMateria.Click += new System.EventHandler(this.tsmEliminarMateria_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 320);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(777, 86);
            this.lblDescripcion.TabIndex = 33;
            this.lblDescripcion.Text = "-";
            // 
            // dgvMatAnioCarrera
            // 
            this.dgvMatAnioCarrera.AllowUserToAddRows = false;
            this.dgvMatAnioCarrera.AllowUserToDeleteRows = false;
            this.dgvMatAnioCarrera.AllowUserToResizeColumns = false;
            this.dgvMatAnioCarrera.AllowUserToResizeRows = false;
            this.dgvMatAnioCarrera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatAnioCarrera.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatAnioCarrera.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMatAnioCarrera.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatAnioCarrera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatAnioCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatAnioCarrera.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatAnioCarrera.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatAnioCarrera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatAnioCarrera.EnableHeadersVisualStyles = false;
            this.dgvMatAnioCarrera.GridColor = System.Drawing.Color.White;
            this.dgvMatAnioCarrera.Location = new System.Drawing.Point(20, 20);
            this.dgvMatAnioCarrera.MultiSelect = false;
            this.dgvMatAnioCarrera.Name = "dgvMatAnioCarrera";
            this.dgvMatAnioCarrera.ReadOnly = true;
            this.dgvMatAnioCarrera.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatAnioCarrera.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMatAnioCarrera.RowHeadersVisible = false;
            this.dgvMatAnioCarrera.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvMatAnioCarrera.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMatAnioCarrera.RowTemplate.Height = 28;
            this.dgvMatAnioCarrera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatAnioCarrera.Size = new System.Drawing.Size(777, 300);
            this.dgvMatAnioCarrera.TabIndex = 34;
            this.dgvMatAnioCarrera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvMatAnioCarrera_MouseUp);
            // 
            // FormMateriasAnioCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 426);
            this.Controls.Add(this.dgvMatAnioCarrera);
            this.Controls.Add(this.lblDescripcion);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(43, 141);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMateriasAnioCarrera";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormMateriasAnioCarrera";
            this.Load += new System.EventHandler(this.FormMateriasAnioCarrera_Load);
            this.cmsMaterias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatAnioCarrera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarMateria;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarMateria;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCorrelatividades;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarMateria;
        private System.Windows.Forms.Label lblDescripcion;
        public System.Windows.Forms.DataGridView dgvMatAnioCarrera;
    }
}