
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
            this.cboHojasExcel = new System.Windows.Forms.ComboBox();
            this.lblHojaExcel = new System.Windows.Forms.Label();
            this.lblCamposFaltantes = new System.Windows.Forms.Label();
            this.btnCrearCamposFaltantes = new System.Windows.Forms.Button();
            this.pnlOpcionesCarga = new System.Windows.Forms.Panel();
            this.pnlAccionesCarga = new System.Windows.Forms.Panel();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargaMasiva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargaMasiva.ColumnHeadersHeight = 29;
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
            this.dgvCargaMasiva.ReadOnly = false;
            this.dgvCargaMasiva.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.lblTituloCargaMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
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
            this.btnAceptarCargaMasiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarCargaMasiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnAceptarCargaMasiva.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnAceptarCargaMasiva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnAceptarCargaMasiva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAceptarCargaMasiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarCargaMasiva.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarCargaMasiva.ForeColor = System.Drawing.Color.White;
            this.btnAceptarCargaMasiva.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptarCargaMasiva.Image")));
            this.btnAceptarCargaMasiva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarCargaMasiva.Location = new System.Drawing.Point(678, 2);
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
            this.btnBuscarArchivoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarArchivoExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBuscarArchivoExcel.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnBuscarArchivoExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnBuscarArchivoExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBuscarArchivoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarArchivoExcel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArchivoExcel.ForeColor = System.Drawing.Color.White;
            this.btnBuscarArchivoExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArchivoExcel.Image")));
            this.btnBuscarArchivoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarArchivoExcel.Location = new System.Drawing.Point(0, 1);
            this.btnBuscarArchivoExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarArchivoExcel.Name = "btnBuscarArchivoExcel";
            this.btnBuscarArchivoExcel.Size = new System.Drawing.Size(106, 51);
            this.btnBuscarArchivoExcel.TabIndex = 52;
            this.btnBuscarArchivoExcel.Text = "Buscar";
            this.btnBuscarArchivoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarArchivoExcel.UseVisualStyleBackColor = false;
            this.btnBuscarArchivoExcel.Click += new System.EventHandler(this.btnBuscarArchivoExcel_Click);
            //
            // cboHojasExcel
            //
            this.cboHojasExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cboHojasExcel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHojasExcel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHojasExcel.FormattingEnabled = true;
            this.cboHojasExcel.Location = new System.Drawing.Point(55, 10);
            this.cboHojasExcel.Name = "cboHojasExcel";
            this.cboHojasExcel.Size = new System.Drawing.Size(180, 30);
            this.cboHojasExcel.TabIndex = 54;
            this.cboHojasExcel.Visible = false;
            this.cboHojasExcel.SelectedIndexChanged += new System.EventHandler(this.cboHojasExcel_SelectedIndexChanged);
            //
            // lblHojaExcel
            //
            this.lblHojaExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHojaExcel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHojaExcel.Location = new System.Drawing.Point(10, 11);
            this.lblHojaExcel.Name = "lblHojaExcel";
            this.lblHojaExcel.Size = new System.Drawing.Size(40, 28);
            this.lblHojaExcel.TabIndex = 55;
            this.lblHojaExcel.Text = "Hoja";
            this.lblHojaExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHojaExcel.Visible = false;
            //
            // lblCamposFaltantes
            //
            this.lblCamposFaltantes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCamposFaltantes.AutoSize = false;
            this.lblCamposFaltantes.BackColor = System.Drawing.Color.MistyRose;
            this.lblCamposFaltantes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCamposFaltantes.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCamposFaltantes.Location = new System.Drawing.Point(245, 2);
            this.lblCamposFaltantes.Margin = new System.Windows.Forms.Padding(4);
            this.lblCamposFaltantes.Name = "lblCamposFaltantes";
            this.lblCamposFaltantes.Size = new System.Drawing.Size(405, 48);
            this.lblCamposFaltantes.TabIndex = 53;
            this.lblCamposFaltantes.Text = "";
            this.lblCamposFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCamposFaltantes.Visible = false;
            //
            // btnCrearCamposFaltantes
            //
            this.btnCrearCamposFaltantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearCamposFaltantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnCrearCamposFaltantes.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnCrearCamposFaltantes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnCrearCamposFaltantes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnCrearCamposFaltantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCamposFaltantes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCamposFaltantes.ForeColor = System.Drawing.Color.White;
            this.btnCrearCamposFaltantes.Location = new System.Drawing.Point(655, 2);
            this.btnCrearCamposFaltantes.Name = "btnCrearCamposFaltantes";
            this.btnCrearCamposFaltantes.Size = new System.Drawing.Size(125, 48);
            this.btnCrearCamposFaltantes.TabIndex = 56;
            this.btnCrearCamposFaltantes.Text = "Crear faltantes";
            this.btnCrearCamposFaltantes.UseVisualStyleBackColor = false;
            this.btnCrearCamposFaltantes.Visible = false;
            this.btnCrearCamposFaltantes.Click += new System.EventHandler(this.btnCrearCamposFaltantes_Click);
            //
            // pnlOpcionesCarga
            //
            this.pnlOpcionesCarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesCarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlOpcionesCarga.Location = new System.Drawing.Point(12, 422);
            this.pnlOpcionesCarga.Name = "pnlOpcionesCarga";
            this.pnlOpcionesCarga.Size = new System.Drawing.Size(793, 52);
            this.pnlOpcionesCarga.TabIndex = 57;
            //
            // pnlAccionesCarga
            //
            this.pnlAccionesCarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAccionesCarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlAccionesCarga.Location = new System.Drawing.Point(12, 480);
            this.pnlAccionesCarga.Name = "pnlAccionesCarga";
            this.pnlAccionesCarga.Size = new System.Drawing.Size(793, 54);
            this.pnlAccionesCarga.TabIndex = 58;
            //
            // FormCargaMasivaExcel
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.pnlOpcionesCarga.Controls.Add(this.cboHojasExcel);
            this.pnlOpcionesCarga.Controls.Add(this.lblHojaExcel);
            this.pnlOpcionesCarga.Controls.Add(this.lblCamposFaltantes);
            this.pnlOpcionesCarga.Controls.Add(this.btnCrearCamposFaltantes);
            this.pnlAccionesCarga.Controls.Add(this.btnBuscarArchivoExcel);
            this.pnlAccionesCarga.Controls.Add(this.btnAceptarCargaMasiva);
            this.Controls.Add(this.pnlOpcionesCarga);
            this.Controls.Add(this.pnlAccionesCarga);
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
        public System.Windows.Forms.ComboBox cboHojasExcel;
        public System.Windows.Forms.Label lblHojaExcel;
        public System.Windows.Forms.Label lblCamposFaltantes;
        private System.Windows.Forms.Button btnCrearCamposFaltantes;
        private System.Windows.Forms.Panel pnlOpcionesCarga;
        private System.Windows.Forms.Panel pnlAccionesCarga;
    }
}
