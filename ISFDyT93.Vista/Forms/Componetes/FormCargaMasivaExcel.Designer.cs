
namespace ISFDyT93.Vista.Forms.Componentes
{
    partial class FormCargaMasivaExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargaMasivaExcel));
            this.dgvCargaMasiva = new System.Windows.Forms.DataGridView();
            this.lblTituloCargaMasiva = new System.Windows.Forms.Label();
            this.btnAceptarCargaMasiva = new System.Windows.Forms.Button();
            this.btnBuscarArchivoExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargaMasiva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCargaMasiva
            // 
            this.dgvCargaMasiva.AllowUserToAddRows = false;
            this.dgvCargaMasiva.AllowUserToDeleteRows = false;
            this.dgvCargaMasiva.AllowUserToResizeColumns = false;
            this.dgvCargaMasiva.AllowUserToResizeRows = false;
            this.dgvCargaMasiva.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargaMasiva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvCargaMasiva.BackgroundColor = System.Drawing.Color.White;
            this.dgvCargaMasiva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCargaMasiva.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCargaMasiva.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargaMasiva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargaMasiva.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargaMasiva.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargaMasiva.EnableHeadersVisualStyles = false;
            this.dgvCargaMasiva.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvCargaMasiva.Location = new System.Drawing.Point(35, 59);
            this.dgvCargaMasiva.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCargaMasiva.MultiSelect = false;
            this.dgvCargaMasiva.Name = "dgvCargaMasiva";
            this.dgvCargaMasiva.ReadOnly = true;
            this.dgvCargaMasiva.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCargaMasiva.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(16)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargaMasiva.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargaMasiva.RowHeadersVisible = false;
            this.dgvCargaMasiva.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Navy;
            this.dgvCargaMasiva.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCargaMasiva.RowTemplate.Height = 28;
            this.dgvCargaMasiva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargaMasiva.Size = new System.Drawing.Size(747, 355);
            this.dgvCargaMasiva.TabIndex = 49;
            // 
            // lblTituloCargaMasiva
            // 
            this.lblTituloCargaMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.lblTituloCargaMasiva.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloCargaMasiva.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCargaMasiva.ForeColor = System.Drawing.Color.White;
            this.lblTituloCargaMasiva.Location = new System.Drawing.Point(0, 0);
            this.lblTituloCargaMasiva.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTituloCargaMasiva.Name = "lblTituloCargaMasiva";
            this.lblTituloCargaMasiva.Size = new System.Drawing.Size(817, 50);
            this.lblTituloCargaMasiva.TabIndex = 50;
            this.lblTituloCargaMasiva.Text = "Carga Masiva de Datos";
            this.lblTituloCargaMasiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptarCargaMasiva
            // 
            this.btnAceptarCargaMasiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarCargaMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnAceptarCargaMasiva.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnAceptarCargaMasiva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnAceptarCargaMasiva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(198)))));
            this.btnAceptarCargaMasiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarCargaMasiva.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarCargaMasiva.ForeColor = System.Drawing.Color.White;
            this.btnAceptarCargaMasiva.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptarCargaMasiva.Image")));
            this.btnAceptarCargaMasiva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarCargaMasiva.Location = new System.Drawing.Point(690, 485);
            this.btnAceptarCargaMasiva.Name = "btnAceptarCargaMasiva";
            this.btnAceptarCargaMasiva.Size = new System.Drawing.Size(115, 48);
            this.btnAceptarCargaMasiva.TabIndex = 51;
            this.btnAceptarCargaMasiva.Text = " Aceptar";
            this.btnAceptarCargaMasiva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarCargaMasiva.UseVisualStyleBackColor = false;
            this.btnAceptarCargaMasiva.Click += new System.EventHandler(this.btnAceptarCargaMasiva_Click);
            // 
            // btnBuscarArchivoExcel
            // 
            this.btnBuscarArchivoExcel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscarArchivoExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            this.btnBuscarArchivoExcel.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnBuscarArchivoExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnBuscarArchivoExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(198)))));
            this.btnBuscarArchivoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarArchivoExcel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArchivoExcel.ForeColor = System.Drawing.Color.White;
            this.btnBuscarArchivoExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArchivoExcel.Image")));
            this.btnBuscarArchivoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarArchivoExcel.Location = new System.Drawing.Point(13, 481);
            this.btnBuscarArchivoExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarArchivoExcel.Name = "btnBuscarArchivoExcel";
            this.btnBuscarArchivoExcel.Size = new System.Drawing.Size(106, 51);
            this.btnBuscarArchivoExcel.TabIndex = 52;
            this.btnBuscarArchivoExcel.Text = "Buscar";
            this.btnBuscarArchivoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarArchivoExcel.UseVisualStyleBackColor = false;
            this.btnBuscarArchivoExcel.Click += new System.EventHandler(this.btnBuscarArchivoExcel_Click);
            // 
            // FormCargaMasivaExcel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.btnBuscarArchivoExcel);
            this.Controls.Add(this.btnAceptarCargaMasiva);
            this.Controls.Add(this.lblTituloCargaMasiva);
            this.Controls.Add(this.dgvCargaMasiva);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCargaMasivaExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormCargaMasiva";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargaMasiva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCargaMasiva;
        public System.Windows.Forms.Label lblTituloCargaMasiva;
        private System.Windows.Forms.Button btnAceptarCargaMasiva;
        public System.Windows.Forms.Button btnBuscarArchivoExcel;
    }
}