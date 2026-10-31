namespace ISFDyT93.Vista.Forms.Alumnos
{
    partial class FormVerAnalitico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.lblNroFolio = new System.Windows.Forms.Label();
            this.lblNroLibro = new System.Windows.Forms.Label();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblAnioIngreso = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtNomYApe = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dgvAnaliticoDetalle = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnaliticoDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.72095F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.38095F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.55309F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33439F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Controls.Add(this.txtNomYApe, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioIngreso, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDni, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAnio, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMes, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNacimiento, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAlumno, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDia, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLocalidad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDocumento, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDNI, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNroLibro, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNroFolio, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 125);
            this.tableLayoutPanel1.TabIndex = 177;
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Location = new System.Drawing.Point(3, 59);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(109, 19);
            this.lblNacimiento.TabIndex = 182;
            this.lblNacimiento.Text = "Nacido en:";
            // 
            // lblAlumno
            // 
            this.lblAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(3, 14);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(109, 19);
            this.lblAlumno.TabIndex = 174;
            this.lblAlumno.Text = "Alumno/a";
            // 
            // lblNroFolio
            // 
            this.lblNroFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroFolio.AutoSize = true;
            this.lblNroFolio.Location = new System.Drawing.Point(560, 14);
            this.lblNroFolio.Name = "lblNroFolio";
            this.lblNroFolio.Size = new System.Drawing.Size(127, 19);
            this.lblNroFolio.TabIndex = 181;
            this.lblNroFolio.Text = "Folio Nro:";
            // 
            // lblNroLibro
            // 
            this.lblNroLibro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroLibro.AutoSize = true;
            this.lblNroLibro.Location = new System.Drawing.Point(411, 14);
            this.lblNroLibro.Name = "lblNroLibro";
            this.lblNroLibro.Size = new System.Drawing.Size(143, 19);
            this.lblNroLibro.TabIndex = 180;
            this.lblNroLibro.Text = "Libro Nro:";
            // 
            // lblDia
            // 
            this.lblDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(411, 59);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(143, 19);
            this.lblDia.TabIndex = 183;
            this.lblDia.Text = "el día:";
            // 
            // lblMes
            // 
            this.lblMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(560, 59);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(127, 19);
            this.lblMes.TabIndex = 185;
            this.lblMes.Text = "de:";
            // 
            // lblAnio
            // 
            this.lblAnio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(693, 59);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(142, 19);
            this.lblAnio.TabIndex = 186;
            this.lblAnio.Text = "de:";
            // 
            // lblDni
            // 
            this.lblDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(3, 97);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(109, 19);
            this.lblDni.TabIndex = 187;
            this.lblDni.Text = "DNI:";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(693, 89);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(0, 19);
            this.lblDocumento.TabIndex = 188;
            // 
            // lblAnioIngreso
            // 
            this.lblAnioIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnioIngreso.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblAnioIngreso, 2);
            this.lblAnioIngreso.Location = new System.Drawing.Point(411, 97);
            this.lblAnioIngreso.Name = "lblAnioIngreso";
            this.lblAnioIngreso.Size = new System.Drawing.Size(276, 19);
            this.lblAnioIngreso.TabIndex = 189;
            this.lblAnioIngreso.Text = "Año de Ingreso:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalidad.Enabled = false;
            this.txtLocalidad.Location = new System.Drawing.Point(118, 55);
            this.txtLocalidad.MaxLength = 30;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(287, 27);
            this.txtLocalidad.TabIndex = 190;
            // 
            // txtNomYApe
            // 
            this.txtNomYApe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomYApe.Enabled = false;
            this.txtNomYApe.Location = new System.Drawing.Point(118, 10);
            this.txtNomYApe.MaxLength = 30;
            this.txtNomYApe.Name = "txtNomYApe";
            this.txtNomYApe.Size = new System.Drawing.Size(287, 27);
            this.txtNomYApe.TabIndex = 191;
            // 
            // txtDNI
            // 
            this.txtDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(118, 93);
            this.txtDNI.MaxLength = 30;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(287, 27);
            this.txtDNI.TabIndex = 192;
            // 
            // dgvAnaliticoDetalle
            // 
            this.dgvAnaliticoDetalle.AllowUserToAddRows = false;
            this.dgvAnaliticoDetalle.AllowUserToDeleteRows = false;
            this.dgvAnaliticoDetalle.AllowUserToResizeColumns = false;
            this.dgvAnaliticoDetalle.AllowUserToResizeRows = false;
            this.dgvAnaliticoDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnaliticoDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnaliticoDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAnaliticoDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnaliticoDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnaliticoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnaliticoDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAnaliticoDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnaliticoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnaliticoDetalle.EnableHeadersVisualStyles = false;
            this.dgvAnaliticoDetalle.GridColor = System.Drawing.Color.White;
            this.dgvAnaliticoDetalle.Location = new System.Drawing.Point(20, 145);
            this.dgvAnaliticoDetalle.MultiSelect = false;
            this.dgvAnaliticoDetalle.Name = "dgvAnaliticoDetalle";
            this.dgvAnaliticoDetalle.ReadOnly = true;
            this.dgvAnaliticoDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnaliticoDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAnaliticoDetalle.RowHeadersVisible = false;
            this.dgvAnaliticoDetalle.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAnaliticoDetalle.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAnaliticoDetalle.RowTemplate.Height = 28;
            this.dgvAnaliticoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnaliticoDetalle.Size = new System.Drawing.Size(838, 380);
            this.dgvAnaliticoDetalle.TabIndex = 178;
            // 
            // FormVerAnalitico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 545);
            this.Controls.Add(this.dgvAnaliticoDetalle);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormVerAnalitico";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormVerAnalitico";
            this.Load += new System.EventHandler(this.FormVerAnalitico_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnaliticoDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.Label lblNroFolio;
        private System.Windows.Forms.Label lblNroLibro;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblAnioIngreso;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtNomYApe;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDNI;
        public System.Windows.Forms.DataGridView dgvAnaliticoDetalle;
    }
}
