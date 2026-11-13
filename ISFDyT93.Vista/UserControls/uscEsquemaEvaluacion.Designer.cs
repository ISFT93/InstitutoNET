namespace ISFDyT93.Vista.UserControls
{
    partial class uscEsquemaEvaluacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscEsquemaEvaluacion));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picMover = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.picAgregar = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarEsquema = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarEsquema = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarEsquema = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(255, 96);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseDown);
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
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(205, 30);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Esquemas Disponibles";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(22, 30);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(211, 56);
            this.pnlContenedor.TabIndex = 7;
            this.pnlContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenedor_Paint);
            this.pnlContenedor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlContenedor_MouseDown);
            // 
            // picAgregar
            // 
            this.picAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregar.Image = ((System.Drawing.Image)(resources.GetObject("picAgregar.Image")));
            this.picAgregar.Location = new System.Drawing.Point(233, 0);
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
            this.agregarEsquema,
            this.habilitarEsquema,
            this.deshabilitarEsquema});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(237, 116);
            // 
            // agregarEsquema
            // 
            this.agregarEsquema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.agregarEsquema.Font = new System.Drawing.Font("Tahoma", 12F);
            this.agregarEsquema.ForeColor = System.Drawing.Color.White;
            this.agregarEsquema.Name = "agregarEsquema";
            this.agregarEsquema.Size = new System.Drawing.Size(236, 30);
            this.agregarEsquema.Text = "Agregar Esquema";
            // 
            // habilitarEsquema
            // 
            this.habilitarEsquema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.habilitarEsquema.Font = new System.Drawing.Font("Tahoma", 12F);
            this.habilitarEsquema.ForeColor = System.Drawing.Color.White;
            this.habilitarEsquema.Image = global::ISFDyT93.Vista.Properties.Resources.check_circle_solid;
            this.habilitarEsquema.Name = "habilitarEsquema";
            this.habilitarEsquema.Size = new System.Drawing.Size(236, 30);
            this.habilitarEsquema.Text = "Habilitar Esquema";
            // 
            // deshabilitarEsquema
            // 
            this.deshabilitarEsquema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.deshabilitarEsquema.Font = new System.Drawing.Font("Tahoma", 12F);
            this.deshabilitarEsquema.ForeColor = System.Drawing.Color.White;
            this.deshabilitarEsquema.Image = global::ISFDyT93.Vista.Properties.Resources.minus_circle_solid;
            this.deshabilitarEsquema.Name = "deshabilitarEsquema";
            this.deshabilitarEsquema.Size = new System.Drawing.Size(236, 30);
            this.deshabilitarEsquema.Text = "Deshabilitar Esquema";
            // 
            // uscEsquemaEvaluacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscEsquemaEvaluacion";
            this.Size = new System.Drawing.Size(255, 96);
            this.Load += new System.EventHandler(this.uscEsquemaEvaluacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem agregarEsquema;
        private System.Windows.Forms.ToolStripMenuItem habilitarEsquema;
        private System.Windows.Forms.ToolStripMenuItem deshabilitarEsquema;
    }
}
