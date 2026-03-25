namespace ISFDyT93.Vista
{
    partial class FormParametros
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.lblAnioCarrera = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.chkTexto = new System.Windows.Forms.CheckBox();
            this.chkNumero = new System.Windows.Forms.CheckBox();
            this.chkHora = new System.Windows.Forms.CheckBox();
            this.chkTabla = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.06734F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.93266F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioCarrera, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBuscar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpContenedor, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 510);
            this.tableLayoutPanel1.TabIndex = 123;
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
            this.btnBuscar.Location = new System.Drawing.Point(348, 4);
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
            this.lblAnioCarrera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnioCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnioCarrera.Location = new System.Drawing.Point(4, 0);
            this.lblAnioCarrera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnioCarrera.Name = "lblAnioCarrera";
            this.lblAnioCarrera.Size = new System.Drawing.Size(143, 34);
            this.lblAnioCarrera.TabIndex = 122;
            this.lblAnioCarrera.Text = "Buscar Parametro:";
            this.lblAnioCarrera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(154, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(187, 27);
            this.txtBuscar.TabIndex = 128;
            // 
            // flpContenedor
            // 
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.BackColor = System.Drawing.Color.White;
            this.flpContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.flpContenedor, 4);
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(2, 99);
            this.flpContenedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(728, 409);
            this.flpContenedor.TabIndex = 129;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 20);
            this.panel1.TabIndex = 130;
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
            this.btnGuardar.Location = new System.Drawing.Point(596, 26);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.tableLayoutPanel1.SetRowSpan(this.btnGuardar, 2);
            this.btnGuardar.Size = new System.Drawing.Size(132, 49);
            this.btnGuardar.TabIndex = 124;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 39);
            this.panel2.TabIndex = 131;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.64078F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.05825F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.30097F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.4466F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.5534F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Controls.Add(this.chkFecha, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkTexto, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkNumero, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkHora, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkTabla, 9, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(555, 39);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Checked = true;
            this.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFecha.Location = new System.Drawing.Point(23, 8);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(68, 23);
            this.chkFecha.TabIndex = 0;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.Check_Changed);
            // 
            // chkTexto
            // 
            this.chkTexto.AutoSize = true;
            this.chkTexto.Checked = true;
            this.chkTexto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTexto.Location = new System.Drawing.Point(119, 8);
            this.chkTexto.Name = "chkTexto";
            this.chkTexto.Size = new System.Drawing.Size(68, 23);
            this.chkTexto.TabIndex = 1;
            this.chkTexto.Text = "Texto";
            this.chkTexto.UseVisualStyleBackColor = true;
            this.chkTexto.CheckedChanged += new System.EventHandler(this.Check_Changed);
            // 
            // chkNumero
            // 
            this.chkNumero.AutoSize = true;
            this.chkNumero.Checked = true;
            this.chkNumero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumero.Location = new System.Drawing.Point(213, 8);
            this.chkNumero.Name = "chkNumero";
            this.chkNumero.Size = new System.Drawing.Size(85, 23);
            this.chkNumero.TabIndex = 2;
            this.chkNumero.Text = "Numero";
            this.chkNumero.UseVisualStyleBackColor = true;
            this.chkNumero.CheckedChanged += new System.EventHandler(this.Check_Changed);
            // 
            // chkHora
            // 
            this.chkHora.AutoSize = true;
            this.chkHora.Checked = true;
            this.chkHora.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHora.Location = new System.Drawing.Point(329, 8);
            this.chkHora.Name = "chkHora";
            this.chkHora.Size = new System.Drawing.Size(62, 23);
            this.chkHora.TabIndex = 3;
            this.chkHora.Text = "Hora";
            this.chkHora.UseVisualStyleBackColor = true;
            this.chkHora.CheckedChanged += new System.EventHandler(this.Check_Changed);
            // 
            // chkTabla
            // 
            this.chkTabla.AutoSize = true;
            this.chkTabla.Location = new System.Drawing.Point(424, 8);
            this.chkTabla.Name = "chkTabla";
            this.chkTabla.Size = new System.Drawing.Size(67, 23);
            this.chkTabla.TabIndex = 4;
            this.chkTabla.Text = "Tabla";
            this.chkTabla.UseVisualStyleBackColor = true;
            this.chkTabla.CheckedChanged += new System.EventHandler(this.Check_Changed);
            // 
            // FormParametros
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormParametros";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormParametros";
            this.Load += new System.EventHandler(this.FormParametros_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Label lblAnioCarrera;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkNumero;
        private System.Windows.Forms.CheckBox chkTexto;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkHora;
        private System.Windows.Forms.CheckBox chkTabla;
    }
}