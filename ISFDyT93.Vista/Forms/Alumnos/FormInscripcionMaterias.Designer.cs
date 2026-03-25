
namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormInscripcionMaterias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsInscripciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAsignar = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInscripcionAlumnos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.lblAnioCarrera = new System.Windows.Forms.Label();
            this.tmsLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInscripciones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcionAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsInscripciones
            // 
            this.cmsInscripciones.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAsignar,
            this.tmsLimpiar});
            this.cmsInscripciones.Name = "contextMenuStrip1";
            this.cmsInscripciones.Size = new System.Drawing.Size(181, 70);
            // 
            // tsmAsignar
            // 
            this.tsmAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAsignar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAsignar.ForeColor = System.Drawing.Color.White;
            this.tsmAsignar.Name = "tsmAsignar";
            this.tsmAsignar.Size = new System.Drawing.Size(180, 22);
            this.tsmAsignar.Text = "Asignar";
            this.tsmAsignar.Click += new System.EventHandler(this.tsmAsignar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.06734F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.93266F));
            this.tableLayoutPanel1.Controls.Add(this.dgvInscripcionAlumnos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbAnio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioCarrera, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 29);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 566);
            this.tableLayoutPanel1.TabIndex = 122;
            // 
            // dgvInscripcionAlumnos
            // 
            this.dgvInscripcionAlumnos.AllowUserToAddRows = false;
            this.dgvInscripcionAlumnos.AllowUserToDeleteRows = false;
            this.dgvInscripcionAlumnos.AllowUserToResizeColumns = false;
            this.dgvInscripcionAlumnos.AllowUserToResizeRows = false;
            this.dgvInscripcionAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInscripcionAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvInscripcionAlumnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInscripcionAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripcionAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInscripcionAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvInscripcionAlumnos, 4);
            this.dgvInscripcionAlumnos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInscripcionAlumnos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInscripcionAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripcionAlumnos.EnableHeadersVisualStyles = false;
            this.dgvInscripcionAlumnos.GridColor = System.Drawing.Color.White;
            this.dgvInscripcionAlumnos.Location = new System.Drawing.Point(3, 90);
            this.dgvInscripcionAlumnos.MultiSelect = false;
            this.dgvInscripcionAlumnos.Name = "dgvInscripcionAlumnos";
            this.dgvInscripcionAlumnos.ReadOnly = true;
            this.dgvInscripcionAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripcionAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInscripcionAlumnos.RowHeadersVisible = false;
            this.dgvInscripcionAlumnos.RowHeadersWidth = 62;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvInscripcionAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInscripcionAlumnos.RowTemplate.Height = 28;
            this.dgvInscripcionAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripcionAlumnos.Size = new System.Drawing.Size(873, 473);
            this.dgvInscripcionAlumnos.TabIndex = 125;
            this.dgvInscripcionAlumnos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvInscripcionAlumnos_MouseUp);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(743, 33);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.tableLayoutPanel1.SetRowSpan(this.btnGuardar, 2);
            this.btnGuardar.Size = new System.Drawing.Size(132, 50);
            this.btnGuardar.TabIndex = 124;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbAnio
            // 
            this.cmbAnio.BackColor = System.Drawing.Color.White;
            this.cmbAnio.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(139, 4);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(93, 27);
            this.cmbAnio.TabIndex = 126;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(246, 4);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 26);
            this.btnBuscar.TabIndex = 127;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblAnioCarrera
            // 
            this.lblAnioCarrera.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAnioCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnioCarrera.Location = new System.Drawing.Point(4, 0);
            this.lblAnioCarrera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnioCarrera.Name = "lblAnioCarrera";
            this.lblAnioCarrera.Size = new System.Drawing.Size(127, 34);
            this.lblAnioCarrera.TabIndex = 122;
            this.lblAnioCarrera.Text = "Seleccione Año:";
            this.lblAnioCarrera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmsLimpiar
            // 
            this.tmsLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tmsLimpiar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmsLimpiar.ForeColor = System.Drawing.Color.White;
            this.tmsLimpiar.Name = "tmsLimpiar";
            this.tmsLimpiar.Size = new System.Drawing.Size(180, 22);
            this.tmsLimpiar.Text = "Quitar";
            this.tmsLimpiar.Click += new System.EventHandler(this.tmsLimpiar_Click);
            // 
            // FormInscripcionMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormInscripcionMaterias";
            this.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.Text = "FormInscripcionMaterias";
            this.Load += new System.EventHandler(this.FormInscripcionMaterias_Load);
            this.cmsInscripciones.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcionAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsInscripciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAnioCarrera;
        public System.Windows.Forms.DataGridView dgvInscripcionAlumnos;
        private System.Windows.Forms.ComboBox cmbAnio;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.ToolStripMenuItem tsmAsignar;
        private System.Windows.Forms.ToolStripMenuItem tmsLimpiar;
    }
}