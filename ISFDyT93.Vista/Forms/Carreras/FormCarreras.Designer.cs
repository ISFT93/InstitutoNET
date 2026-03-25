namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FormCarreras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarreras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsCarreras = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarCarrera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarCarrera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerAnios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCorrelativas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerFinales = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerEquivalencias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarCarrera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmActivar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDarAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCarreras = new System.Windows.Forms.DataGridView();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbInactivos = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbBorrador = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.tmrRetrasoForm = new System.Windows.Forms.Timer(this.components);
            this.cmsCarreras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsCarreras
            // 
            this.cmsCarreras.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsCarreras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarCarrera,
            this.tsmModificarCarrera,
            this.tsmVerAnios,
            this.tsmVerCorrelativas,
            this.tsmVerFinales,
            this.tsmVerEquivalencias,
            this.tsmEliminarCarrera,
            this.tsmActivar,
            this.tsmDarAlta});
            this.cmsCarreras.Name = "contextMenuStrip1";
            this.cmsCarreras.Size = new System.Drawing.Size(209, 296);
            // 
            // tsmAgregarCarrera
            // 
            this.tsmAgregarCarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAgregarCarrera.ForeColor = System.Drawing.Color.White;
            this.tsmAgregarCarrera.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarCarrera.Image")));
            this.tsmAgregarCarrera.Name = "tsmAgregarCarrera";
            this.tsmAgregarCarrera.Size = new System.Drawing.Size(208, 30);
            this.tsmAgregarCarrera.Text = "Agregar ";
            this.tsmAgregarCarrera.Click += new System.EventHandler(this.tsmAgregarCarreras_Click);
            // 
            // tsmModificarCarrera
            // 
            this.tsmModificarCarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarCarrera.ForeColor = System.Drawing.Color.White;
            this.tsmModificarCarrera.Image = global::ISFDyT93.Vista.Properties.Resources.edit_solid;
            this.tsmModificarCarrera.Name = "tsmModificarCarrera";
            this.tsmModificarCarrera.Size = new System.Drawing.Size(208, 30);
            this.tsmModificarCarrera.Text = "Modificar";
            this.tsmModificarCarrera.Click += new System.EventHandler(this.tsmModificarCarrera_Click);
            // 
            // tsmVerAnios
            // 
            this.tsmVerAnios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerAnios.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerAnios.ForeColor = System.Drawing.Color.White;
            this.tsmVerAnios.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerAnios.Name = "tsmVerAnios";
            this.tsmVerAnios.Size = new System.Drawing.Size(208, 30);
            this.tsmVerAnios.Text = "Ver Años";
            this.tsmVerAnios.Click += new System.EventHandler(this.tsmVerAnios_Click);
            // 
            // tsmVerCorrelativas
            // 
            this.tsmVerCorrelativas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCorrelativas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerCorrelativas.ForeColor = System.Drawing.Color.White;
            this.tsmVerCorrelativas.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerCorrelativas.Name = "tsmVerCorrelativas";
            this.tsmVerCorrelativas.Size = new System.Drawing.Size(208, 30);
            this.tsmVerCorrelativas.Text = "Ver Correlativas";
            this.tsmVerCorrelativas.Click += new System.EventHandler(this.tsmVerCorrelativas_Click);
            // 
            // tsmVerFinales
            // 
            this.tsmVerFinales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerFinales.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tsmVerFinales.ForeColor = System.Drawing.Color.White;
            this.tsmVerFinales.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerFinales.Name = "tsmVerFinales";
            this.tsmVerFinales.Size = new System.Drawing.Size(208, 30);
            this.tsmVerFinales.Text = "Ver Mesas Finales";
            this.tsmVerFinales.Click += new System.EventHandler(this.tsmVerFinales_Click);
            // 
            // tsmVerEquivalencias
            // 
            this.tsmVerEquivalencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerEquivalencias.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tsmVerEquivalencias.ForeColor = System.Drawing.Color.White;
            this.tsmVerEquivalencias.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerEquivalencias.Name = "tsmVerEquivalencias";
            this.tsmVerEquivalencias.Size = new System.Drawing.Size(208, 30);
            this.tsmVerEquivalencias.Text = "Ver Equivalencias";
            this.tsmVerEquivalencias.Click += new System.EventHandler(this.tsmVerEquivalencias_Click);
            // 
            // tsmEliminarCarrera
            // 
            this.tsmEliminarCarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmEliminarCarrera.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEliminarCarrera.ForeColor = System.Drawing.Color.White;
            this.tsmEliminarCarrera.Image = global::ISFDyT93.Vista.Properties.Resources.trash_alt_solid;
            this.tsmEliminarCarrera.Name = "tsmEliminarCarrera";
            this.tsmEliminarCarrera.Size = new System.Drawing.Size(208, 30);
            this.tsmEliminarCarrera.Text = "Eliminar";
            this.tsmEliminarCarrera.Click += new System.EventHandler(this.tsmEliminarCarrera_Click);
            // 
            // tsmActivar
            // 
            this.tsmActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmActivar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmActivar.ForeColor = System.Drawing.Color.White;
            this.tsmActivar.Image = global::ISFDyT93.Vista.Properties.Resources.check_circle_solid;
            this.tsmActivar.Name = "tsmActivar";
            this.tsmActivar.Size = new System.Drawing.Size(208, 30);
            this.tsmActivar.Text = "Activar";
            this.tsmActivar.Click += new System.EventHandler(this.tsmActivar_Click);
            // 
            // tsmDarAlta
            // 
            this.tsmDarAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmDarAlta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDarAlta.ForeColor = System.Drawing.Color.White;
            this.tsmDarAlta.Image = global::ISFDyT93.Vista.Properties.Resources.calendar_alt_solid;
            this.tsmDarAlta.Name = "tsmDarAlta";
            this.tsmDarAlta.Size = new System.Drawing.Size(208, 30);
            this.tsmDarAlta.Text = "Dar de Alta";
            this.tsmDarAlta.Click += new System.EventHandler(this.tsmDarAlta_Click);
            // 
            // dgvCarreras
            // 
            this.dgvCarreras.AllowUserToAddRows = false;
            this.dgvCarreras.AllowUserToDeleteRows = false;
            this.dgvCarreras.AllowUserToResizeColumns = false;
            this.dgvCarreras.AllowUserToResizeRows = false;
            this.dgvCarreras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarreras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarreras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarreras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarreras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarreras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarreras.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarreras.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarreras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarreras.EnableHeadersVisualStyles = false;
            this.dgvCarreras.GridColor = System.Drawing.Color.White;
            this.dgvCarreras.Location = new System.Drawing.Point(20, 89);
            this.dgvCarreras.MultiSelect = false;
            this.dgvCarreras.Name = "dgvCarreras";
            this.dgvCarreras.ReadOnly = true;
            this.dgvCarreras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarreras.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarreras.RowHeadersVisible = false;
            this.dgvCarreras.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCarreras.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCarreras.RowTemplate.Height = 28;
            this.dgvCarreras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarreras.Size = new System.Drawing.Size(777, 436);
            this.dgvCarreras.TabIndex = 0;
            this.dgvCarreras.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCarreras_MouseUp);
            // 
            // rbActivos
            // 
            this.rbActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(3, 23);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(188, 23);
            this.rbActivos.TabIndex = 52;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Activos";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // rbInactivos
            // 
            this.rbInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInactivos.AutoSize = true;
            this.rbInactivos.Location = new System.Drawing.Point(391, 23);
            this.rbInactivos.Name = "rbInactivos";
            this.rbInactivos.Size = new System.Drawing.Size(188, 23);
            this.rbInactivos.TabIndex = 51;
            this.rbInactivos.Text = "Inactivos";
            this.rbInactivos.UseVisualStyleBackColor = true;
            this.rbInactivos.CheckedChanged += new System.EventHandler(this.rbInactivos_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.rbBorrador, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbActivos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbInactivos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbTodos, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 69);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // rbBorrador
            // 
            this.rbBorrador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBorrador.AutoSize = true;
            this.rbBorrador.Location = new System.Drawing.Point(197, 23);
            this.rbBorrador.Name = "rbBorrador";
            this.rbBorrador.Size = new System.Drawing.Size(188, 23);
            this.rbBorrador.TabIndex = 54;
            this.rbBorrador.Text = "Borrador";
            this.rbBorrador.UseVisualStyleBackColor = true;
            this.rbBorrador.CheckedChanged += new System.EventHandler(this.rbBorrador_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(585, 23);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(189, 23);
            this.rbTodos.TabIndex = 53;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // tmrRetrasoForm
            // 
            this.tmrRetrasoForm.Tick += new System.EventHandler(this.tmrRetrasoForm_Tick);
            // 
            // FormCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 545);
            this.Controls.Add(this.dgvCarreras);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCarreras";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormCarreras";
            this.Load += new System.EventHandler(this.FormCarreras_Load);
            this.cmsCarreras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsCarreras;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarCarrera;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarCarrera;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCorrelativas;
        public System.Windows.Forms.DataGridView dgvCarreras;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarCarrera;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.RadioButton rbInactivos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tsmActivar;
        private System.Windows.Forms.ToolStripMenuItem tsmDarAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmVerAnios;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbBorrador;
        private System.Windows.Forms.Timer tmrRetrasoForm;
        private System.Windows.Forms.ToolStripMenuItem tsmVerEquivalencias;
        private System.Windows.Forms.ToolStripMenuItem tsmVerFinales;
    }
}