namespace ISFDyT93.Vista.Forms.Configuraciones
{
    partial class FormCicloLectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCicloLectivo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorCiclo = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmsCicloLectivo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarCicloLectivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModificarCicloLectivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCicloLectivo = new System.Windows.Forms.ToolStripMenuItem();
            //this.tsmInscripcionCicloLectivo = new System.Windows.Forms.ToolStripMenuItem();
            //this.tsmCargaCursadas = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCicloLectivo = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorCiclo)).BeginInit();
            this.cmsCicloLectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicloLectivo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorCiclo
            // 
            this.errorCiclo.ContainerControl = this;
            this.errorCiclo.Icon = ((System.Drawing.Icon)(resources.GetObject("errorCiclo.Icon")));
            // 
            // cmsCicloLectivo
            // 
            this.cmsCicloLectivo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsCicloLectivo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarCicloLectivo,
            this.tsmModificarCicloLectivo,
            this.tsmVerCicloLectivo,
            //this.tsmInscripcionCicloLectivo,
            //this.tsmCargaCursadas
            });
            this.cmsCicloLectivo.Name = "contextMenuStrip1";
            this.cmsCicloLectivo.Size = new System.Drawing.Size(255, 154);
            // 
            // tsmAgregarCicloLectivo
            // 
            this.tsmAgregarCicloLectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAgregarCicloLectivo.ForeColor = System.Drawing.Color.White;
            this.tsmAgregarCicloLectivo.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarCicloLectivo.Image")));
            this.tsmAgregarCicloLectivo.Name = "tsmAgregarCicloLectivo";
            this.tsmAgregarCicloLectivo.Size = new System.Drawing.Size(254, 30);
            this.tsmAgregarCicloLectivo.Text = "Agregar ";
            this.tsmAgregarCicloLectivo.Click += new System.EventHandler(this.tsmAgregarCicloLectivo_Click);
            // 
            // tsmModificarCicloLectivo
            // 
            this.tsmModificarCicloLectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmModificarCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmModificarCicloLectivo.ForeColor = System.Drawing.Color.White;
            this.tsmModificarCicloLectivo.Image = global::ISFDyT93.Vista.Properties.Resources.edit_solid;
            this.tsmModificarCicloLectivo.Name = "tsmModificarCicloLectivo";
            this.tsmModificarCicloLectivo.Size = new System.Drawing.Size(254, 30);
            this.tsmModificarCicloLectivo.Text = "Modificar";
            this.tsmModificarCicloLectivo.Click += new System.EventHandler(this.tsmModificarCicloLectivo_Click);
            // 
            // tsmVerCicloLectivo
            // 
            this.tsmVerCicloLectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmVerCicloLectivo.ForeColor = System.Drawing.Color.White;
            this.tsmVerCicloLectivo.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerCicloLectivo.Name = "tsmVerCicloLectivo";
            this.tsmVerCicloLectivo.Size = new System.Drawing.Size(254, 30);
            this.tsmVerCicloLectivo.Text = "Ver";
            this.tsmVerCicloLectivo.Click += new System.EventHandler(this.tsmVerCicloLectivo_Click);
            // 
            // tsmInscripcionCicloLectivo
            // 
            //this.tsmInscripcionCicloLectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            //this.tsmInscripcionCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.tsmInscripcionCicloLectivo.ForeColor = System.Drawing.Color.White;
            //this.tsmInscripcionCicloLectivo.Image = global::ISFDyT93.Vista.Properties.Resources.user_edit_solid;
            //this.tsmInscripcionCicloLectivo.Name = "tsmInscripcionCicloLectivo";
            //this.tsmInscripcionCicloLectivo.Size = new System.Drawing.Size(254, 30);
            //this.tsmInscripcionCicloLectivo.Text = "Inscripcion Ciclo Lectivo";
            //this.tsmInscripcionCicloLectivo.Visible = false;
            //this.tsmInscripcionCicloLectivo.Click += new System.EventHandler(this.tsmInscripcionCicloLectivo_Click);
            // 
            // tsmCargaCursadas
            // 
            //this.tsmCargaCursadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            //this.tsmCargaCursadas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.tsmCargaCursadas.ForeColor = System.Drawing.Color.White;
            //this.tsmCargaCursadas.Image = global::ISFDyT93.Vista.Properties.Resources.plus_square_solid;
            //this.tsmCargaCursadas.Name = "tsmCargaCursadas";
            //this.tsmCargaCursadas.Size = new System.Drawing.Size(254, 30);
            //this.tsmCargaCursadas.Text = "Cargar Cursadas";
            //this.tsmCargaCursadas.Visible = false;
            //this.tsmCargaCursadas.Click += new System.EventHandler(this.tsmCargaCursadas_Click);
            // 
            // dgvCicloLectivo
            // 
            this.dgvCicloLectivo.AllowUserToAddRows = false;
            this.dgvCicloLectivo.AllowUserToDeleteRows = false;
            this.dgvCicloLectivo.AllowUserToResizeColumns = false;
            this.dgvCicloLectivo.AllowUserToResizeRows = false;
            this.dgvCicloLectivo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCicloLectivo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCicloLectivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCicloLectivo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCicloLectivo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCicloLectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCicloLectivo.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCicloLectivo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCicloLectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCicloLectivo.EnableHeadersVisualStyles = false;
            this.dgvCicloLectivo.GridColor = System.Drawing.Color.White;
            this.dgvCicloLectivo.Location = new System.Drawing.Point(20, 30);
            this.dgvCicloLectivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCicloLectivo.MultiSelect = false;
            this.dgvCicloLectivo.Name = "dgvCicloLectivo";
            this.dgvCicloLectivo.ReadOnly = true;
            this.dgvCicloLectivo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCicloLectivo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCicloLectivo.RowHeadersVisible = false;
            this.dgvCicloLectivo.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCicloLectivo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCicloLectivo.RowTemplate.Height = 28;
            this.dgvCicloLectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCicloLectivo.Size = new System.Drawing.Size(945, 616);
            this.dgvCicloLectivo.TabIndex = 56;
            this.dgvCicloLectivo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCicloLectivo_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(945, 10);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // FormCicloLectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 666);
            this.Controls.Add(this.dgvCicloLectivo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCicloLectivo";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormCicloLectivo";
            this.Load += new System.EventHandler(this.FormCicloLectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorCiclo)).EndInit();
            this.cmsCicloLectivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicloLectivo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorCiclo;
        private System.Windows.Forms.ContextMenuStrip cmsCicloLectivo;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarCicloLectivo;
        private System.Windows.Forms.ToolStripMenuItem tsmModificarCicloLectivo;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCicloLectivo;
        //private System.Windows.Forms.ToolStripMenuItem tsmInscripcionCicloLectivo;
        public System.Windows.Forms.DataGridView dgvCicloLectivo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        //private System.Windows.Forms.ToolStripMenuItem tsmCargaCursadas;
    }
}