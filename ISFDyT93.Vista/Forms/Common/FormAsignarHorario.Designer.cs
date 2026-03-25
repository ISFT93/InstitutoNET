
namespace ISFDyT93.Vista.Forms.Common
{
    partial class FormAsignarHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsignarHorario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsHorarios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAgregarMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitarMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitarTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.dgvAsignarHorario = new System.Windows.Forms.DataGridView();
            this.ModuloId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picImprimir = new System.Windows.Forms.PictureBox();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblModulos = new System.Windows.Forms.Label();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.cmsHorarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignarHorario)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImprimir)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsHorarios
            // 
            this.cmsHorarios.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsHorarios.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsHorarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarMateria,
            this.tsmQuitarMateria,
            this.tsmQuitarTodo});
            this.cmsHorarios.Name = "contextMenuStrip1";
            this.cmsHorarios.Size = new System.Drawing.Size(196, 94);
            // 
            // tsmAgregarMateria
            // 
            this.tsmAgregarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmAgregarMateria.Font = new System.Drawing.Font("Verdana", 10F);
            this.tsmAgregarMateria.ForeColor = System.Drawing.Color.White;
            this.tsmAgregarMateria.Image = ((System.Drawing.Image)(resources.GetObject("tsmAgregarMateria.Image")));
            this.tsmAgregarMateria.Name = "tsmAgregarMateria";
            this.tsmAgregarMateria.Size = new System.Drawing.Size(195, 30);
            this.tsmAgregarMateria.Text = "Agregar Materia";
            this.tsmAgregarMateria.Click += new System.EventHandler(this.tsmAgregarMateria_Click);
            // 
            // tsmQuitarMateria
            // 
            this.tsmQuitarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmQuitarMateria.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmQuitarMateria.ForeColor = System.Drawing.Color.White;
            this.tsmQuitarMateria.Image = ((System.Drawing.Image)(resources.GetObject("tsmQuitarMateria.Image")));
            this.tsmQuitarMateria.Name = "tsmQuitarMateria";
            this.tsmQuitarMateria.Size = new System.Drawing.Size(195, 30);
            this.tsmQuitarMateria.Text = "Quitar Materia";
            this.tsmQuitarMateria.Click += new System.EventHandler(this.tsmEliminarHorario_Click);
            // 
            // tsmQuitarTodo
            // 
            this.tsmQuitarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmQuitarTodo.Font = new System.Drawing.Font("Verdana", 10F);
            this.tsmQuitarTodo.ForeColor = System.Drawing.Color.White;
            this.tsmQuitarTodo.Image = ((System.Drawing.Image)(resources.GetObject("tsmQuitarTodo.Image")));
            this.tsmQuitarTodo.Name = "tsmQuitarTodo";
            this.tsmQuitarTodo.Size = new System.Drawing.Size(195, 30);
            this.tsmQuitarTodo.Text = "Quitar Todo";
            this.tsmQuitarTodo.Click += new System.EventHandler(this.tsmQuitarTodo_Click);
            // 
            // cmbCursos
            // 
            this.cmbCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(73, 3);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(112, 27);
            this.cmbCursos.TabIndex = 6;
            this.cmbCursos.SelectedIndexChanged += new System.EventHandler(this.cmbCursos_SelectedIndexChanged);
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurso.Location = new System.Drawing.Point(3, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(64, 30);
            this.lblCurso.TabIndex = 7;
            this.lblCurso.Text = "Curso:";
            this.lblCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAsignarHorario
            // 
            this.dgvAsignarHorario.AllowUserToAddRows = false;
            this.dgvAsignarHorario.AllowUserToDeleteRows = false;
            this.dgvAsignarHorario.AllowUserToResizeColumns = false;
            this.dgvAsignarHorario.AllowUserToResizeRows = false;
            this.dgvAsignarHorario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsignarHorario.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignarHorario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsignarHorario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsignarHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignarHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuloId,
            this.Modulo,
            this.Lunes,
            this.Martes,
            this.Miercoles,
            this.Jueves,
            this.Viernes});
            this.dgvAsignarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsignarHorario.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAsignarHorario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignarHorario.EnableHeadersVisualStyles = false;
            this.dgvAsignarHorario.GridColor = System.Drawing.Color.Gray;
            this.dgvAsignarHorario.Location = new System.Drawing.Point(20, 92);
            this.dgvAsignarHorario.MultiSelect = false;
            this.dgvAsignarHorario.Name = "dgvAsignarHorario";
            this.dgvAsignarHorario.ReadOnly = true;
            this.dgvAsignarHorario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsignarHorario.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAsignarHorario.RowHeadersVisible = false;
            this.dgvAsignarHorario.RowHeadersWidth = 62;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAsignarHorario.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAsignarHorario.RowTemplate.Height = 28;
            this.dgvAsignarHorario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAsignarHorario.Size = new System.Drawing.Size(732, 438);
            this.dgvAsignarHorario.TabIndex = 58;
            this.dgvAsignarHorario.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAsignarHorario_MouseUp);
            // 
            // ModuloId
            // 
            this.ModuloId.HeaderText = "ModuloId";
            this.ModuloId.Name = "ModuloId";
            this.ModuloId.ReadOnly = true;
            this.ModuloId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModuloId.Visible = false;
            // 
            // Modulo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Modulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Modulo.HeaderText = "";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            this.Modulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lunes
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lunes.DefaultCellStyle = dataGridViewCellStyle3;
            this.Lunes.HeaderText = "Lunes";
            this.Lunes.Name = "Lunes";
            this.Lunes.ReadOnly = true;
            this.Lunes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Martes
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Martes.DefaultCellStyle = dataGridViewCellStyle4;
            this.Martes.HeaderText = "Martes";
            this.Martes.Name = "Martes";
            this.Martes.ReadOnly = true;
            this.Martes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Miercoles
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Miercoles.DefaultCellStyle = dataGridViewCellStyle5;
            this.Miercoles.HeaderText = "Miércoles";
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.ReadOnly = true;
            this.Miercoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Jueves
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Jueves.DefaultCellStyle = dataGridViewCellStyle6;
            this.Jueves.HeaderText = "Jueves";
            this.Jueves.Name = "Jueves";
            this.Jueves.ReadOnly = true;
            this.Jueves.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Viernes
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Viernes.DefaultCellStyle = dataGridViewCellStyle7;
            this.Viernes.HeaderText = "Viernes";
            this.Viernes.Name = "Viernes";
            this.Viernes.ReadOnly = true;
            this.Viernes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.picImprimir, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCurso, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCursos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbMaterias, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMateria, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModulos, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdmin, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 72);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // picImprimir
            // 
            this.picImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImprimir.Dock = System.Windows.Forms.DockStyle.Right;
            this.picImprimir.Image = ((System.Drawing.Image)(resources.GetObject("picImprimir.Image")));
            this.picImprimir.Location = new System.Drawing.Point(689, 39);
            this.picImprimir.Name = "picImprimir";
            this.picImprimir.Size = new System.Drawing.Size(40, 24);
            this.picImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImprimir.TabIndex = 59;
            this.picImprimir.TabStop = false;
            this.picImprimir.Click += new System.EventHandler(this.picImprimir_Click);
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(293, 3);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(329, 27);
            this.cmbMaterias.TabIndex = 9;
            this.cmbMaterias.SelectedIndexChanged += new System.EventHandler(this.cmbMaterias_SelectedIndexChanged);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMateria.Location = new System.Drawing.Point(211, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(76, 30);
            this.lblMateria.TabIndex = 8;
            this.lblMateria.Text = "Materia:";
            this.lblMateria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModulos
            // 
            this.lblModulos.AutoSize = true;
            this.lblModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModulos.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulos.ForeColor = System.Drawing.Color.Gray;
            this.lblModulos.Location = new System.Drawing.Point(293, 36);
            this.lblModulos.Name = "lblModulos";
            this.lblModulos.Size = new System.Drawing.Size(329, 30);
            this.lblModulos.TabIndex = 57;
            this.lblModulos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 20;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGuardar.Location = new System.Drawing.Point(648, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 30);
            this.btnGuardar.TabIndex = 56;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdmin.Location = new System.Drawing.Point(70, 36);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(118, 30);
            this.btnAdmin.TabIndex = 58;
            this.btnAdmin.Text = "Admin On";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // FormAsignarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.dgvAsignarHorario);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAsignarHorario";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAsignarHorario";
            this.Load += new System.EventHandler(this.FormAsignarHorario_Load);
            this.cmsHorarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignarHorario)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImprimir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsHorarios;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitarMateria;
        public System.Windows.Forms.DataGridView dgvAsignarHorario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Label lblModulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuloId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viernes;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitarTodo;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.PictureBox picImprimir;
    }
}