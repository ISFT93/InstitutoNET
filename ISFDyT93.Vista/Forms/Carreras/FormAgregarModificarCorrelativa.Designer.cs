namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormAgregarModificarCorrelativa
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
            this.lstMaterias = new System.Windows.Forms.ListBox();
            this.lstCorrelativas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuitarTodos = new FontAwesome.Sharp.IconButton();
            this.btnAgregarTodos = new FontAwesome.Sharp.IconButton();
            this.btnQuitarMateria = new FontAwesome.Sharp.IconButton();
            this.btnAgregarMateria = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMaterias
            // 
            this.lstMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstMaterias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMaterias.ForeColor = System.Drawing.Color.White;
            this.lstMaterias.FormattingEnabled = true;
            this.lstMaterias.ItemHeight = 19;
            this.lstMaterias.Location = new System.Drawing.Point(3, 117);
            this.lstMaterias.Name = "lstMaterias";
            this.tableLayoutPanel1.SetRowSpan(this.lstMaterias, 5);
            this.lstMaterias.Size = new System.Drawing.Size(342, 289);
            this.lstMaterias.TabIndex = 4;
            // 
            // lstCorrelativas
            // 
            this.lstCorrelativas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lstCorrelativas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCorrelativas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCorrelativas.ForeColor = System.Drawing.Color.White;
            this.lstCorrelativas.FormattingEnabled = true;
            this.lstCorrelativas.ItemHeight = 19;
            this.lstCorrelativas.Location = new System.Drawing.Point(431, 117);
            this.lstCorrelativas.Name = "lstCorrelativas";
            this.tableLayoutPanel1.SetRowSpan(this.lstCorrelativas, 5);
            this.lstCorrelativas.Size = new System.Drawing.Size(343, 289);
            this.lstCorrelativas.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Materias";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(431, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Correlativas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnQuitarTodos, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarTodos, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lstMaterias, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnQuitarMateria, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarMateria, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstCorrelativas, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 505);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnQuitarTodos.FlatAppearance.BorderSize = 0;
            this.btnQuitarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarTodos.ForeColor = System.Drawing.Color.White;
            this.btnQuitarTodos.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnQuitarTodos.IconColor = System.Drawing.Color.White;
            this.btnQuitarTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuitarTodos.IconSize = 36;
            this.btnQuitarTodos.Location = new System.Drawing.Point(351, 367);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnQuitarTodos.Size = new System.Drawing.Size(74, 34);
            this.btnQuitarTodos.TabIndex = 18;
            this.btnQuitarTodos.UseVisualStyleBackColor = false;
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAgregarTodos.FlatAppearance.BorderSize = 0;
            this.btnAgregarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTodos.ForeColor = System.Drawing.Color.White;
            this.btnAgregarTodos.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnAgregarTodos.IconColor = System.Drawing.Color.White;
            this.btnAgregarTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarTodos.IconSize = 36;
            this.btnAgregarTodos.Location = new System.Drawing.Point(351, 317);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnAgregarTodos.Size = new System.Drawing.Size(74, 34);
            this.btnAgregarTodos.TabIndex = 19;
            this.btnAgregarTodos.UseVisualStyleBackColor = false;
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click_1);
            // 
            // btnQuitarMateria
            // 
            this.btnQuitarMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnQuitarMateria.FlatAppearance.BorderSize = 0;
            this.btnQuitarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarMateria.ForeColor = System.Drawing.Color.White;
            this.btnQuitarMateria.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnQuitarMateria.IconColor = System.Drawing.Color.White;
            this.btnQuitarMateria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuitarMateria.IconSize = 36;
            this.btnQuitarMateria.Location = new System.Drawing.Point(351, 172);
            this.btnQuitarMateria.Name = "btnQuitarMateria";
            this.btnQuitarMateria.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnQuitarMateria.Size = new System.Drawing.Size(74, 34);
            this.btnQuitarMateria.TabIndex = 16;
            this.btnQuitarMateria.UseVisualStyleBackColor = false;
            this.btnQuitarMateria.Click += new System.EventHandler(this.btnQuitarMateria_Click);
            // 
            // btnAgregarMateria
            // 
            this.btnAgregarMateria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAgregarMateria.FlatAppearance.BorderSize = 0;
            this.btnAgregarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMateria.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMateria.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnAgregarMateria.IconColor = System.Drawing.Color.White;
            this.btnAgregarMateria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarMateria.IconSize = 36;
            this.btnAgregarMateria.Location = new System.Drawing.Point(351, 122);
            this.btnAgregarMateria.Name = "btnAgregarMateria";
            this.btnAgregarMateria.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnAgregarMateria.Size = new System.Drawing.Size(74, 34);
            this.btnAgregarMateria.TabIndex = 17;
            this.btnAgregarMateria.UseVisualStyleBackColor = false;
            this.btnAgregarMateria.Click += new System.EventHandler(this.btnAgregarMateria_Click);
            // 
            // FormAgregarModificarCorrelativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAgregarModificarCorrelativa";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAgregarModificarCorrelativa";
            this.Load += new System.EventHandler(this.FormAgregarModificarCorrelativa_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstMaterias;
        private System.Windows.Forms.ListBox lstCorrelativas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnQuitarMateria;
        private FontAwesome.Sharp.IconButton btnAgregarMateria;
        private FontAwesome.Sharp.IconButton btnQuitarTodos;
        private FontAwesome.Sharp.IconButton btnAgregarTodos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}