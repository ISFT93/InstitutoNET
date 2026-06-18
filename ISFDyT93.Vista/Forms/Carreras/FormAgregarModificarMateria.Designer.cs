namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormAgregarModificarMateria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarMateria));
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.lblCargaHoraria = new System.Windows.Forms.Label();
            this.lblEspacio = new System.Windows.Forms.Label();
            this.cmbEspacioId = new System.Windows.Forms.ComboBox();
            this.epvMaterias = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtModulos = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.lblCantidadModulos = new System.Windows.Forms.Label();
            this.lblFinalPromocion = new System.Windows.Forms.Label();
            this.cmbFinalPromocion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.epvMaterias)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 19);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNombre.Location = new System.Drawing.Point(3, 23);
            this.txtNombre.MaxLength = 200;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(382, 27);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargaHoraria.Location = new System.Drawing.Point(3, 93);
            this.txtCargaHoraria.MaxLength = 5;
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(382, 27);
            this.txtCargaHoraria.TabIndex = 2;
            this.txtCargaHoraria.TextChanged += new System.EventHandler(this.txtCargaHoraria_TextChanged);
            // 
            // lblCargaHoraria
            // 
            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Location = new System.Drawing.Point(3, 70);
            this.lblCargaHoraria.Name = "lblCargaHoraria";
            this.lblCargaHoraria.Size = new System.Drawing.Size(111, 19);
            this.lblCargaHoraria.TabIndex = 9;
            this.lblCargaHoraria.Text = "Carga horaria:";
            // 
            // lblEspacio
            // 
            this.lblEspacio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEspacio.AutoSize = true;
            this.lblEspacio.Location = new System.Drawing.Point(391, 0);
            this.lblEspacio.Name = "lblEspacio";
            this.lblEspacio.Size = new System.Drawing.Size(68, 20);
            this.lblEspacio.TabIndex = 11;
            this.lblEspacio.Text = "Espacio:";
            // 
            // cmbEspacioId
            // 
            this.cmbEspacioId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEspacioId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspacioId.FormattingEnabled = true;
            this.cmbEspacioId.Location = new System.Drawing.Point(391, 23);
            this.cmbEspacioId.Name = "cmbEspacioId";
            this.cmbEspacioId.Size = new System.Drawing.Size(383, 27);
            this.cmbEspacioId.TabIndex = 1;
            // 
            // epvMaterias
            // 
            this.epvMaterias.ContainerControl = this;
            this.epvMaterias.Icon = ((System.Drawing.Icon)(resources.GetObject("epvMaterias.Icon")));
            // 
            // txtModulos
            // 
            this.txtModulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModulos.Enabled = false;
            this.txtModulos.Location = new System.Drawing.Point(391, 93);
            this.txtModulos.Name = "txtModulos";
            this.txtModulos.Size = new System.Drawing.Size(383, 27);
            this.txtModulos.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblFinalPromocion, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadModulos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCargaHoraria, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtModulos, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCargaHoraria, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEspacio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEspacioId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbFinalPromocion, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 409);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(646, 347);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnGuardar.Size = new System.Drawing.Size(128, 59);
            this.btnGuardar.TabIndex = 36;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCantidadModulos
            // 
            this.lblCantidadModulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadModulos.AutoSize = true;
            this.lblCantidadModulos.Location = new System.Drawing.Point(391, 70);
            this.lblCantidadModulos.Name = "lblCantidadModulos";
            this.lblCantidadModulos.Size = new System.Drawing.Size(163, 20);
            this.lblCantidadModulos.TabIndex = 37;
            this.lblCantidadModulos.Text = "Cantidad de Módulos:";
            // 
            // lblFinalPromocion
            // 
            this.lblFinalPromocion.AutoSize = true;
            this.lblFinalPromocion.Location = new System.Drawing.Point(3, 140);
            this.lblFinalPromocion.Name = "lblFinalPromocion";
            this.lblFinalPromocion.Size = new System.Drawing.Size(134, 19);
            this.lblFinalPromocion.TabIndex = 38;
            this.lblFinalPromocion.Text = "Final / Promoción";
            // 
            // cmbFinalPromocion
            // 
            this.cmbFinalPromocion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFinalPromocion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinalPromocion.FormattingEnabled = true;
            this.cmbFinalPromocion.Location = new System.Drawing.Point(3, 163);
            this.cmbFinalPromocion.Name = "cmbFinalPromocion";
            this.cmbFinalPromocion.Size = new System.Drawing.Size(382, 27);
            this.cmbFinalPromocion.TabIndex = 39;
            // 
            // FormAgregarModificarMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 449);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAgregarModificarMateria";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Cantidad Materias:";
            this.Load += new System.EventHandler(this.FormAgregarModificarMateria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epvMaterias)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCargaHoraria;
        private System.Windows.Forms.Label lblCargaHoraria;
        private System.Windows.Forms.Label lblEspacio;
        private System.Windows.Forms.ComboBox cmbEspacioId;
        private System.Windows.Forms.ErrorProvider epvMaterias;
        private System.Windows.Forms.TextBox txtModulos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Label lblCantidadModulos;
        private System.Windows.Forms.Label lblFinalPromocion;
        private System.Windows.Forms.ComboBox cmbFinalPromocion;
    }
}