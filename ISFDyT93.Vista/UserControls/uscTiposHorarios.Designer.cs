namespace ISFDyT93.Vista.UserControls
{
    partial class uscTiposHorarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcionAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionAgregarHorario = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.picAgregar = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContenedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picAgregar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 538);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(33, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1001, 37);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Turnos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.AutoScroll = true;
            this.pnlContenedor.BackColor = System.Drawing.Color.Gray;
            this.pnlContenedor.Controls.Add(this.dgvTurnos);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(29, 37);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1009, 489);
            this.pnlContenedor.TabIndex = 7;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AllowUserToResizeRows = false;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.ContextMenuStrip = this.menu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 0);
            this.dgvTurnos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTurnos.MultiSelect = false;
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersVisible = false;
            this.dgvTurnos.RowHeadersWidth = 51;
            this.dgvTurnos.RowTemplate.DividerHeight = 1;
            this.dgvTurnos.RowTemplate.Height = 30;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(1009, 489);
            this.dgvTurnos.TabIndex = 5;
            this.dgvTurnos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvTurnos_MouseDown);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionAgregar,
            this.opcionAgregarHorario,
            this.opcionHabilitar,
            this.opcionDeshabilitar});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(287, 124);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // opcionAgregar
            // 
            this.opcionAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionAgregar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionAgregar.ForeColor = System.Drawing.Color.White;
            this.opcionAgregar.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.opcionAgregar.Name = "opcionAgregar";
            this.opcionAgregar.Size = new System.Drawing.Size(286, 30);
            this.opcionAgregar.Text = "Agregar turno nuevo";
            this.opcionAgregar.Click += new System.EventHandler(this.opcionAgregar_Click);
            // 
            // opcionAgregarHorario
            // 
            this.opcionAgregarHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionAgregarHorario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionAgregarHorario.ForeColor = System.Drawing.Color.White;
            this.opcionAgregarHorario.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.opcionAgregarHorario.Name = "opcionAgregarHorario";
            this.opcionAgregarHorario.Size = new System.Drawing.Size(286, 30);
            this.opcionAgregarHorario.Text = "Agregar horario nuevo";
            this.opcionAgregarHorario.Visible = false;
            this.opcionAgregarHorario.Click += new System.EventHandler(this.opcionModificar_Click);
            // 
            // opcionHabilitar
            // 
            this.opcionHabilitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionHabilitar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionHabilitar.ForeColor = System.Drawing.Color.White;
            this.opcionHabilitar.Image = global::ISFDyT93.Vista.Properties.Resources.check_circle_solid;
            this.opcionHabilitar.Name = "opcionHabilitar";
            this.opcionHabilitar.Size = new System.Drawing.Size(286, 30);
            this.opcionHabilitar.Text = "Habilitar";
            this.opcionHabilitar.Visible = false;
            this.opcionHabilitar.Click += new System.EventHandler(this.opcionHabilitar_Click);
            // 
            // opcionDeshabilitar
            // 
            this.opcionDeshabilitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.opcionDeshabilitar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionDeshabilitar.ForeColor = System.Drawing.Color.White;
            this.opcionDeshabilitar.Image = global::ISFDyT93.Vista.Properties.Resources.eye_slash_solid;
            this.opcionDeshabilitar.Name = "opcionDeshabilitar";
            this.opcionDeshabilitar.Size = new System.Drawing.Size(286, 30);
            this.opcionDeshabilitar.Text = "Deshabilitar";
            this.opcionDeshabilitar.Visible = false;
            this.opcionDeshabilitar.Click += new System.EventHandler(this.opcionDeshabilitar_Click);
            // 
            // picAgregar
            // 
            this.picAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregar.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.picAgregar.Location = new System.Drawing.Point(1038, 0);
            this.picAgregar.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.picAgregar.Name = "picAgregar";
            this.picAgregar.Size = new System.Drawing.Size(25, 37);
            this.picAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAgregar.TabIndex = 8;
            this.picAgregar.TabStop = false;
            this.picAgregar.Visible = false;
            // 
            // uscTiposHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscTiposHorarios";
            this.Size = new System.Drawing.Size(1067, 538);
            this.Load += new System.EventHandler(this.uscTiposHorarios_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.PictureBox picAgregar;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem opcionAgregar;
        private System.Windows.Forms.ToolStripMenuItem opcionAgregarHorario;
        private System.Windows.Forms.ToolStripMenuItem opcionHabilitar;
        private System.Windows.Forms.ToolStripMenuItem opcionDeshabilitar;
    }
}
