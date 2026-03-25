namespace ISFDyT93.Vista.Forms
{
    partial class FormPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.btnOpciones = new FontAwesome.Sharp.IconButton();
            this.btnAlumnos = new FontAwesome.Sharp.IconButton();
            this.btnPersonal = new FontAwesome.Sharp.IconButton();
            this.btnCarreras = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCiclosLectivos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerCiclos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPruebaSP = new System.Windows.Forms.ToolStripMenuItem();
            this.Parametros = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVolver = new FontAwesome.Sharp.IconButton();
            this.btnAsistencia = new FontAwesome.Sharp.IconButton();
            this.pnlIzquierdo.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.cmsOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDerecho.BackColor = System.Drawing.Color.White;
            this.pnlDerecho.Location = new System.Drawing.Point(200, 50);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(772, 550);
            this.pnlDerecho.TabIndex = 1;
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.pnlIzquierdo.Controls.Add(this.btnAsistencia);
            this.pnlIzquierdo.Controls.Add(this.btnOpciones);
            this.pnlIzquierdo.Controls.Add(this.btnAlumnos);
            this.pnlIzquierdo.Controls.Add(this.btnPersonal);
            this.pnlIzquierdo.Controls.Add(this.btnCarreras);
            this.pnlIzquierdo.Controls.Add(this.btnHome);
            this.pnlIzquierdo.Controls.Add(this.pnlLogo);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(200, 600);
            this.pnlIzquierdo.TabIndex = 0;
            // 
            // btnOpciones
            // 
            this.btnOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnOpciones.FlatAppearance.BorderSize = 0;
            this.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpciones.ForeColor = System.Drawing.Color.White;
            this.btnOpciones.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnOpciones.IconColor = System.Drawing.Color.White;
            this.btnOpciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOpciones.IconSize = 46;
            this.btnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpciones.Location = new System.Drawing.Point(12, 552);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.btnOpciones.Size = new System.Drawing.Size(53, 36);
            this.btnOpciones.TabIndex = 12;
            this.btnOpciones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpciones.UseVisualStyleBackColor = true;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlumnos.FlatAppearance.BorderSize = 0;
            this.btnAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlumnos.ForeColor = System.Drawing.Color.White;
            this.btnAlumnos.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnAlumnos.IconColor = System.Drawing.Color.White;
            this.btnAlumnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAlumnos.IconSize = 36;
            this.btnAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlumnos.Location = new System.Drawing.Point(0, 230);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAlumnos.Size = new System.Drawing.Size(200, 60);
            this.btnAlumnos.TabIndex = 11;
            this.btnAlumnos.Text = "Alumnos";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click_1);
            // 
            // btnPersonal
            // 
            this.btnPersonal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPersonal.FlatAppearance.BorderSize = 0;
            this.btnPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonal.ForeColor = System.Drawing.Color.White;
            this.btnPersonal.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnPersonal.IconColor = System.Drawing.Color.White;
            this.btnPersonal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPersonal.IconSize = 36;
            this.btnPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonal.Location = new System.Drawing.Point(0, 170);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnPersonal.Size = new System.Drawing.Size(200, 60);
            this.btnPersonal.TabIndex = 10;
            this.btnPersonal.Text = "Personal";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnCarreras
            // 
            this.btnCarreras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCarreras.FlatAppearance.BorderSize = 0;
            this.btnCarreras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarreras.ForeColor = System.Drawing.Color.White;
            this.btnCarreras.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnCarreras.IconColor = System.Drawing.Color.White;
            this.btnCarreras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCarreras.IconSize = 36;
            this.btnCarreras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarreras.Location = new System.Drawing.Point(0, 110);
            this.btnCarreras.Name = "btnCarreras";
            this.btnCarreras.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCarreras.Size = new System.Drawing.Size(200, 60);
            this.btnCarreras.TabIndex = 9;
            this.btnCarreras.Text = "Carreras";
            this.btnCarreras.UseVisualStyleBackColor = true;
            this.btnCarreras.Click += new System.EventHandler(this.btnCarreras_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            this.btnHome.IconColor = System.Drawing.Color.White;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 36;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 50);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnHome.Size = new System.Drawing.Size(200, 60);
            this.btnHome.TabIndex = 13;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlLogo.Controls.Add(this.lblProyecto);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 50);
            this.pnlLogo.TabIndex = 8;
            // 
            // lblProyecto
            // 
            this.lblProyecto.AutoSize = true;
            this.lblProyecto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyecto.ForeColor = System.Drawing.Color.White;
            this.lblProyecto.Location = new System.Drawing.Point(40, 13);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(138, 29);
            this.lblProyecto.TabIndex = 0;
            this.lblProyecto.Text = "ISFDyT 93";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(200, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(767, 50);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCiclosLectivos,
            this.Parametros});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(180, 64);
            // 
            // tsmCiclosLectivos
            // 
            this.tsmCiclosLectivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmCiclosLectivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerCiclos,
            this.tsmPruebaSP});
            this.tsmCiclosLectivos.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tsmCiclosLectivos.ForeColor = System.Drawing.Color.White;
            this.tsmCiclosLectivos.Image = global::ISFDyT93.Vista.Properties.Resources.calendar_alt_solid;
            this.tsmCiclosLectivos.Name = "tsmCiclosLectivos";
            this.tsmCiclosLectivos.Size = new System.Drawing.Size(179, 30);
            this.tsmCiclosLectivos.Text = "Ciclo Lectivo";
            // 
            // tsmVerCiclos
            // 
            this.tsmVerCiclos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmVerCiclos.ForeColor = System.Drawing.Color.White;
            this.tsmVerCiclos.Image = global::ISFDyT93.Vista.Properties.Resources.eye_solid;
            this.tsmVerCiclos.Name = "tsmVerCiclos";
            this.tsmVerCiclos.Size = new System.Drawing.Size(168, 26);
            this.tsmVerCiclos.Text = "Ver Ciclos";
            this.tsmVerCiclos.Click += new System.EventHandler(this.tsmVerCiclos_Click);
            // 
            // tsmPruebaSP
            // 
            this.tsmPruebaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.tsmPruebaSP.ForeColor = System.Drawing.Color.White;
            this.tsmPruebaSP.Image = global::ISFDyT93.Vista.Properties.Resources.plus_circle_solid;
            this.tsmPruebaSP.Name = "tsmPruebaSP";
            this.tsmPruebaSP.Size = new System.Drawing.Size(168, 26);
            this.tsmPruebaSP.Text = "Prueba SP";
            this.tsmPruebaSP.Click += new System.EventHandler(this.tsmPruebaSP_Click);
            // 
            // Parametros
            // 
            this.Parametros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.Parametros.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Parametros.ForeColor = System.Drawing.Color.White;
            this.Parametros.Image = ((System.Drawing.Image)(resources.GetObject("Parametros.Image")));
            this.Parametros.Name = "Parametros";
            this.Parametros.Size = new System.Drawing.Size(179, 30);
            this.Parametros.Text = "Parametros";
            this.Parametros.Click += new System.EventHandler(this.Parametros_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            this.btnVolver.IconColor = System.Drawing.Color.White;
            this.btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVolver.IconSize = 46;
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(209, 6);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.btnVolver.Size = new System.Drawing.Size(53, 36);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAsistencia.FlatAppearance.BorderSize = 0;
            this.btnAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnAsistencia.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnAsistencia.IconColor = System.Drawing.Color.White;
            this.btnAsistencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAsistencia.IconSize = 36;
            this.btnAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistencia.Location = new System.Drawing.Point(0, 290);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAsistencia.Size = new System.Drawing.Size(200, 60);
            this.btnAsistencia.TabIndex = 14;
            this.btnAsistencia.Text = "Asistencia/Evaluaciones";
            this.btnAsistencia.UseVisualStyleBackColor = true;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 600);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlDerecho);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.cmsOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private FontAwesome.Sharp.IconButton btnAlumnos;
        private FontAwesome.Sharp.IconButton btnPersonal;
        private FontAwesome.Sharp.IconButton btnCarreras;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProyecto;
        private FontAwesome.Sharp.IconButton btnVolver;
        private FontAwesome.Sharp.IconButton btnOpciones;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private FontAwesome.Sharp.IconButton btnHome;
        private System.Windows.Forms.ToolStripMenuItem tsmCiclosLectivos;
        private System.Windows.Forms.ToolStripMenuItem tsmPruebaSP;
        private System.Windows.Forms.ToolStripMenuItem Parametros;
        private System.Windows.Forms.ToolStripMenuItem tsmVerCiclos;
        private FontAwesome.Sharp.IconButton btnAsistencia;
    }
}

