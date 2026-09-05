namespace ISFDyT93.Vista.UserControls
{
    partial class uscTiposLicencias
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picMover = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvLicencias = new System.Windows.Forms.DataGridView();
            this.picAgregar = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcionAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).BeginInit();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.picMover, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContenedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picAgregar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 437);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // picMover
            // 
            this.picMover.Cursor = System.Windows.Forms.Cursors.Help;
            this.picMover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMover.Image = global::ISFDyT93.Vista.Properties.Resources.file_alt_solid;
            this.picMover.Location = new System.Drawing.Point(3, 3);
            this.picMover.Name = "picMover";
            this.picMover.Size = new System.Drawing.Size(16, 24);
            this.picMover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMover.TabIndex = 5;
            this.picMover.TabStop = false;
            this.picMover.Click += new System.EventHandler(this.picMover_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(750, 30);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Tipos de licencias";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.AutoScroll = true;
            this.pnlContenedor.BackColor = System.Drawing.Color.Gray;
            this.pnlContenedor.Controls.Add(this.dgvLicencias);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(22, 30);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(756, 397);
            this.pnlContenedor.TabIndex = 7;
            // 
            // dgvLicencias
            // 
            this.dgvLicencias.AllowUserToAddRows = false;
            this.dgvLicencias.AllowUserToDeleteRows = false;
            this.dgvLicencias.AllowUserToResizeRows = false;
            this.dgvLicencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLicencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLicencias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLicencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLicencias.Location = new System.Drawing.Point(0, 0);
            this.dgvLicencias.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLicencias.MultiSelect = false;
            this.dgvLicencias.Name = "dgvLicencias";
            this.dgvLicencias.ReadOnly = true;
            this.dgvLicencias.RowHeadersVisible = false;
            this.dgvLicencias.RowTemplate.DividerHeight = 1;
            this.dgvLicencias.RowTemplate.Height = 30;
            this.dgvLicencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLicencias.Size = new System.Drawing.Size(756, 397);
            this.dgvLicencias.TabIndex = 5;
            this.dgvLicencias.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLicencias_MouseDown);
            // 
            // picAgregar
            // 
            this.picAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregar.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.picAgregar.Location = new System.Drawing.Point(778, 0);
            this.picAgregar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.picAgregar.Name = "picAgregar";
            this.picAgregar.Size = new System.Drawing.Size(19, 30);
            this.picAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAgregar.TabIndex = 8;
            this.picAgregar.TabStop = false;
            this.picAgregar.Visible = false;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionAgregar,
            this.opcionModificar,
            this.opcionHabilitar,
            this.opcionDeshabilitar});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(244, 124);
            // 
            // opcionAgregar
            // 
            this.opcionAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionAgregar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionAgregar.ForeColor = System.Drawing.Color.White;
            this.opcionAgregar.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.opcionAgregar.Name = "opcionAgregar";
            this.opcionAgregar.Size = new System.Drawing.Size(243, 30);
            this.opcionAgregar.Text = "Agregar tipo de licencia";
            // 
            // opcionModificar
            // 
            this.opcionModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionModificar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionModificar.ForeColor = System.Drawing.Color.White;
            this.opcionModificar.Image = global::ISFDyT93.Vista.Properties.Resources.edit_solid;
            this.opcionModificar.Name = "opcionModificar";
            this.opcionModificar.Size = new System.Drawing.Size(243, 30);
            this.opcionModificar.Text = "Modificar";
            this.opcionModificar.Visible = false;
            // 
            // opcionHabilitar
            // 
            this.opcionHabilitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionHabilitar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionHabilitar.ForeColor = System.Drawing.Color.White;
            this.opcionHabilitar.Image = global::ISFDyT93.Vista.Properties.Resources.check_circle_solid;
            this.opcionHabilitar.Name = "opcionHabilitar";
            this.opcionHabilitar.Size = new System.Drawing.Size(243, 30);
            this.opcionHabilitar.Text = "Habilitar";
            this.opcionHabilitar.Visible = false;
            // 
            // opcionDeshabilitar
            // 
            this.opcionDeshabilitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionDeshabilitar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionDeshabilitar.ForeColor = System.Drawing.Color.White;
            this.opcionDeshabilitar.Image = global::ISFDyT93.Vista.Properties.Resources.eye_slash_solid;
            this.opcionDeshabilitar.Name = "opcionDeshabilitar";
            this.opcionDeshabilitar.Size = new System.Drawing.Size(243, 30);
            this.opcionDeshabilitar.Text = "Deshabilitar";
            this.opcionDeshabilitar.Visible = false;
            // 
            // uscTiposLicencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscTiposLicencias";
            this.Size = new System.Drawing.Size(800, 437);
            this.Load += new System.EventHandler(this.uscTiposLicencias_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).EndInit();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).EndInit();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picMover;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.PictureBox picAgregar;
        private System.Windows.Forms.DataGridView dgvLicencias;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem opcionAgregar;
        private System.Windows.Forms.ToolStripMenuItem opcionModificar;
        private System.Windows.Forms.ToolStripMenuItem opcionHabilitar;
        private System.Windows.Forms.ToolStripMenuItem opcionDeshabilitar;
    }
}
