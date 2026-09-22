namespace ISFDyT93.Vista.UserControls
{
    partial class uscTablaEspacios
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
            this.dgvEspacios = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcionAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.EspacioId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acumulador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaHoras = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CalculaPorcentaje = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspacios)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEspacios
            // 
            this.dgvEspacios.AllowUserToAddRows = false;
            this.dgvEspacios.AllowUserToDeleteRows = false;
            this.dgvEspacios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEspacios.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEspacios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEspacios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspacios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EspacioId,
            this.Descripcion,
            this.Acumulador,
            this.SumaHoras,
            this.CalculaPorcentaje,
            this.Activo});
            this.dgvEspacios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEspacios.Location = new System.Drawing.Point(0, 0);
            this.dgvEspacios.MultiSelect = false;
            this.dgvEspacios.Name = "dgvEspacios";
            this.dgvEspacios.ReadOnly = true;
            this.dgvEspacios.RowHeadersVisible = false;
            this.dgvEspacios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspacios.Size = new System.Drawing.Size(1200, 500);
            this.dgvEspacios.TabIndex = 0;
            this.dgvEspacios.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvEspacios_MouseDown);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionAgregar,
            this.opcionModificar,
            this.opcionHabilitar,
            this.opcionDeshabilitar});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(137, 92);
            // 
            // opcionAgregar
            // 
            this.opcionAgregar.Name = "opcionAgregar";
            this.opcionAgregar.Size = new System.Drawing.Size(136, 22);
            this.opcionAgregar.Text = "Agregar";
            // 
            // opcionModificar
            // 
            this.opcionModificar.Name = "opcionModificar";
            this.opcionModificar.Size = new System.Drawing.Size(136, 22);
            this.opcionModificar.Text = "Modificar";
            // 
            // opcionHabilitar
            // 
            this.opcionHabilitar.Name = "opcionHabilitar";
            this.opcionHabilitar.Size = new System.Drawing.Size(136, 22);
            this.opcionHabilitar.Text = "Habilitar";
            // 
            // opcionDeshabilitar
            // 
            this.opcionDeshabilitar.Name = "opcionDeshabilitar";
            this.opcionDeshabilitar.Size = new System.Drawing.Size(136, 22);
            this.opcionDeshabilitar.Text = "Deshabilitar";
            // 
            // EspacioId
            // 
            this.EspacioId.DataPropertyName = "EspacioId";
            this.EspacioId.HeaderText = "ID";
            this.EspacioId.Name = "EspacioId";
            this.EspacioId.ReadOnly = true;
            this.EspacioId.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Acumulador
            // 
            this.Acumulador.DataPropertyName = "Acumulador";
            this.Acumulador.HeaderText = "Acumulador";
            this.Acumulador.Name = "Acumulador";
            this.Acumulador.ReadOnly = true;
            // 
            // SumaHoras
            // 
            this.SumaHoras.DataPropertyName = "SumaHoras";
            this.SumaHoras.HeaderText = "Suma Horas";
            this.SumaHoras.Name = "SumaHoras";
            this.SumaHoras.ReadOnly = true;
            // 
            // CalculaPorcentaje
            // 
            this.CalculaPorcentaje.DataPropertyName = "CalculaPorcentaje";
            this.CalculaPorcentaje.HeaderText = "Calcula %";
            this.CalculaPorcentaje.Name = "CalculaPorcentaje";
            this.CalculaPorcentaje.ReadOnly = true;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            // 
            // uscTablaEspacios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEspacios);
            this.Name = "uscTablaEspacios";
            this.Size = new System.Drawing.Size(1200, 500);
            this.Load += new System.EventHandler(this.uscTablaEspacios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspacios)).EndInit();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEspacios;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem opcionAgregar;
        private System.Windows.Forms.ToolStripMenuItem opcionModificar;
        private System.Windows.Forms.ToolStripMenuItem opcionHabilitar;
        private System.Windows.Forms.ToolStripMenuItem opcionDeshabilitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspacioId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acumulador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SumaHoras;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CalculaPorcentaje;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
    }
}