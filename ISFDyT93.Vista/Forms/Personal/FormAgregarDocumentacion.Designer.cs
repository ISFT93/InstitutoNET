namespace ISFDyT93.Vista.Forms.Personal
{
    partial class FormAgregarDocumentacion
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
            this.txtAnalitico = new System.Windows.Forms.TextBox();
            this.lblAnalitico = new System.Windows.Forms.Label();
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.ofdAsignarDoc = new System.Windows.Forms.OpenFileDialog();
            this.picVerProyecto = new System.Windows.Forms.PictureBox();
            this.picVerAnalitico = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnAnalitico = new FontAwesome.Sharp.IconButton();
            this.btnProyecto = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.picVerProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerAnalitico)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAnalitico
            // 
            this.txtAnalitico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnalitico.Enabled = false;
            this.txtAnalitico.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnalitico.Location = new System.Drawing.Point(3, 26);
            this.txtAnalitico.MaxLength = 250;
            this.txtAnalitico.Name = "txtAnalitico";
            this.txtAnalitico.Size = new System.Drawing.Size(337, 27);
            this.txtAnalitico.TabIndex = 40;
            // 
            // lblAnalitico
            // 
            this.lblAnalitico.AutoSize = true;
            this.lblAnalitico.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalitico.Location = new System.Drawing.Point(3, 0);
            this.lblAnalitico.Name = "lblAnalitico";
            this.lblAnalitico.Size = new System.Drawing.Size(76, 19);
            this.lblAnalitico.TabIndex = 44;
            this.lblAnalitico.Text = "Analitico:";
            // 
            // txtProyecto
            // 
            this.txtProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProyecto.Enabled = false;
            this.txtProyecto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProyecto.Location = new System.Drawing.Point(406, 26);
            this.txtProyecto.MaxLength = 250;
            this.txtProyecto.Name = "txtProyecto";
            this.txtProyecto.Size = new System.Drawing.Size(337, 27);
            this.txtProyecto.TabIndex = 41;
            // 
            // lblProyecto
            // 
            this.lblProyecto.AutoSize = true;
            this.lblProyecto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyecto.Location = new System.Drawing.Point(406, 0);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(76, 19);
            this.lblProyecto.TabIndex = 42;
            this.lblProyecto.Text = "Proyecto:";
            // 
            // picVerProyecto
            // 
            this.picVerProyecto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picVerProyecto.Image = global::ISFDyT93.Vista.Properties.Resources.pdf_2_60px1;
            this.picVerProyecto.Location = new System.Drawing.Point(549, 63);
            this.picVerProyecto.Name = "picVerProyecto";
            this.picVerProyecto.Size = new System.Drawing.Size(50, 50);
            this.picVerProyecto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVerProyecto.TabIndex = 48;
            this.picVerProyecto.TabStop = false;
            this.picVerProyecto.Visible = false;
            this.picVerProyecto.Click += new System.EventHandler(this.picVerProyecto_Click);
            // 
            // picVerAnalitico
            // 
            this.picVerAnalitico.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picVerAnalitico.Image = global::ISFDyT93.Vista.Properties.Resources.pdf_2_60px;
            this.picVerAnalitico.Location = new System.Drawing.Point(146, 63);
            this.picVerAnalitico.Name = "picVerAnalitico";
            this.picVerAnalitico.Size = new System.Drawing.Size(50, 50);
            this.picVerAnalitico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVerAnalitico.TabIndex = 47;
            this.picVerAnalitico.TabStop = false;
            this.picVerAnalitico.Visible = false;
            this.picVerAnalitico.Click += new System.EventHandler(this.picVerAnalitico_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblAnalitico, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picVerProyecto, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAnalitico, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picVerAnalitico, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtProyecto, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblProyecto, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAnalitico, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProyecto, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 505);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnGuardar, 2);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(641, 452);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 50);
            this.btnGuardar.TabIndex = 53;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAnalitico
            // 
            this.btnAnalitico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalitico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnAnalitico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalitico.ForeColor = System.Drawing.Color.White;
            this.btnAnalitico.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnAnalitico.IconColor = System.Drawing.Color.White;
            this.btnAnalitico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnalitico.IconSize = 32;
            this.btnAnalitico.Location = new System.Drawing.Point(343, 26);
            this.btnAnalitico.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnAnalitico.Name = "btnAnalitico";
            this.btnAnalitico.Size = new System.Drawing.Size(30, 27);
            this.btnAnalitico.TabIndex = 54;
            this.btnAnalitico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnalitico.UseVisualStyleBackColor = false;
            this.btnAnalitico.Click += new System.EventHandler(this.btnAnalitico_Click);
            // 
            // btnProyecto
            // 
            this.btnProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProyecto.ForeColor = System.Drawing.Color.White;
            this.btnProyecto.IconChar = FontAwesome.Sharp.IconChar.SortDown;
            this.btnProyecto.IconColor = System.Drawing.Color.White;
            this.btnProyecto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProyecto.IconSize = 32;
            this.btnProyecto.Location = new System.Drawing.Point(746, 26);
            this.btnProyecto.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnProyecto.Name = "btnProyecto";
            this.btnProyecto.Size = new System.Drawing.Size(31, 27);
            this.btnProyecto.TabIndex = 55;
            this.btnProyecto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProyecto.UseVisualStyleBackColor = false;
            this.btnProyecto.Click += new System.EventHandler(this.btnProyecto_Click);
            // 
            // FormAgregarDocumentacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarDocumentacion";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAgregarDocumentacion";
            this.Load += new System.EventHandler(this.FormAgregarDocumentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVerProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerAnalitico)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtAnalitico;
        private System.Windows.Forms.Label lblAnalitico;
        public System.Windows.Forms.TextBox txtProyecto;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.OpenFileDialog ofdAsignarDoc;
        private System.Windows.Forms.PictureBox picVerAnalitico;
        private System.Windows.Forms.PictureBox picVerProyecto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnAnalitico;
        private FontAwesome.Sharp.IconButton btnProyecto;
    }
}