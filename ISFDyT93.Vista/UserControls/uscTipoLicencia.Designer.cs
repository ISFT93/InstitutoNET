namespace ISFDyT93.Vista.UserControls
{
    partial class uscTipoLicencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscTipoLicencia));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarTipoLicencia = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarTipoLicencia = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarTipoLicencia = new System.Windows.Forms.ToolStripMenuItem();
            this.picMover = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.picMover, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContenedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(209, 30);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Tipo Licencia";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(22, 30);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(215, 60);
            this.pnlContenedor.TabIndex = 7;
            this.pnlContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenedor_Paint);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarTipoLicencia,
            this.habilitarTipoLicencia,
            this.deshabilitarTipoLicencia});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(194, 76);
            // 
            // agregarTipoLicencia
            // 
            this.agregarTipoLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.agregarTipoLicencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarTipoLicencia.ForeColor = System.Drawing.Color.White;
            this.agregarTipoLicencia.Name = "agregarTipoLicencia";
            this.agregarTipoLicencia.Size = new System.Drawing.Size(193, 24);
            this.agregarTipoLicencia.Text = "Agregar Licencia";
            // 
            // habilitarTipoLicencia
            // 
            this.habilitarTipoLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.habilitarTipoLicencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.habilitarTipoLicencia.ForeColor = System.Drawing.Color.White;
            this.habilitarTipoLicencia.Name = "habilitarTipoLicencia";
            this.habilitarTipoLicencia.Size = new System.Drawing.Size(193, 24);
            this.habilitarTipoLicencia.Text = "Habilitar";
            this.habilitarTipoLicencia.Visible = false;
            // 
            // deshabilitarTipoLicencia
            // 
            this.deshabilitarTipoLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.deshabilitarTipoLicencia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deshabilitarTipoLicencia.ForeColor = System.Drawing.Color.White;
            this.deshabilitarTipoLicencia.Name = "deshabilitarTipoLicencia";
            this.deshabilitarTipoLicencia.Size = new System.Drawing.Size(193, 24);
            this.deshabilitarTipoLicencia.Text = "Deshabilitar";
            this.deshabilitarTipoLicencia.Visible = false;
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
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(237, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // uscTipoLicencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscTipoLicencia";
            this.Size = new System.Drawing.Size(259, 100);
            this.Load += new System.EventHandler(this.uscTipoLicencia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picMover;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem agregarTipoLicencia;
        private System.Windows.Forms.ToolStripMenuItem habilitarTipoLicencia;
        private System.Windows.Forms.ToolStripMenuItem deshabilitarTipoLicencia;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}