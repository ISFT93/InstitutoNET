namespace ISFDyT93.Vista.UserControls
{
    partial class uscLibros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscLibros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picMover = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.picAgregar = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcionAgregarNuevoLibro = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionActualizarLibro = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).BeginInit();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
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
            this.picMover.Image = ((System.Drawing.Image)(resources.GetObject("picMover.Image")));
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
            this.lblTitulo.Text = "Libros de actas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.AutoScroll = true;
            this.pnlContenedor.BackColor = System.Drawing.Color.Gray;
            this.pnlContenedor.Controls.Add(this.dgvLibros);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(22, 30);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(756, 397);
            this.pnlContenedor.TabIndex = 7;
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToResizeRows = false;
            this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLibros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibros.Location = new System.Drawing.Point(0, 0);
            this.dgvLibros.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.RowHeadersVisible = false;
            this.dgvLibros.RowTemplate.DividerHeight = 1;
            this.dgvLibros.RowTemplate.Height = 30;
            this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibros.Size = new System.Drawing.Size(756, 397);
            this.dgvLibros.TabIndex = 5;
            // 
            // picAgregar
            // 
            this.picAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregar.Image = ((System.Drawing.Image)(resources.GetObject("picAgregar.Image")));
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
            this.opcionAgregarNuevoLibro,
            this.opcionActualizarLibro});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(227, 64);
            // 
            // opcionAgregarNuevoLibro
            // 
            this.opcionAgregarNuevoLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionAgregarNuevoLibro.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionAgregarNuevoLibro.ForeColor = System.Drawing.Color.White;
            this.opcionAgregarNuevoLibro.Image = ((System.Drawing.Image)(resources.GetObject("opcionAgregarNuevoLibro.Image")));
            this.opcionAgregarNuevoLibro.Name = "opcionAgregarNuevoLibro";
            this.opcionAgregarNuevoLibro.Size = new System.Drawing.Size(226, 30);
            this.opcionAgregarNuevoLibro.Text = "Agregar nuevo libro";
            this.opcionAgregarNuevoLibro.Visible = false;
            // 
            // opcionActualizarLibro
            // 
            this.opcionActualizarLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionActualizarLibro.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionActualizarLibro.ForeColor = System.Drawing.Color.White;
            this.opcionActualizarLibro.Image = global::ISFDyT93.Vista.Properties.Resources.edit_solid;
            this.opcionActualizarLibro.Name = "opcionActualizarLibro";
            this.opcionActualizarLibro.Size = new System.Drawing.Size(226, 30);
            this.opcionActualizarLibro.Text = "Actualizar libro";
            this.opcionActualizarLibro.Visible = false;
            // 
            // uscLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscLibros";
            this.Size = new System.Drawing.Size(800, 437);
            this.Load += new System.EventHandler(this.uscLibros_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).EndInit();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem opcionAgregarNuevoLibro;
        private System.Windows.Forms.ToolStripMenuItem opcionActualizarLibro;
    }
}
