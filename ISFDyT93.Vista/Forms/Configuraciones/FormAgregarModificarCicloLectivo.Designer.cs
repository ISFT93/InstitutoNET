
namespace ISFDyT93.Vista.Forms.Configuraciones
{
    partial class FormAgregarModificarCicloLectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarCicloLectivo));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.epvCicloLectivo = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpFechaDiciembreFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaJunioFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFinFinalDiciembre = new System.Windows.Forms.Label();
            this.lblInicioFinalDiciembre = new System.Windows.Forms.Label();
            this.dtpFechaDiciembreInicio1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaJunioInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFinFinalJunio = new System.Windows.Forms.Label();
            this.lblInicioFinalJunio = new System.Windows.Forms.Label();
            this.dtpFechaMarzoFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaMarzoInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFinFinalMarzo = new System.Windows.Forms.Label();
            this.lblInicioFinalMarzo = new System.Windows.Forms.Label();
            this.dtpFechaInscripcionInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInscripcionFinal = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCantidadSemana = new System.Windows.Forms.TextBox();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeCierre = new System.Windows.Forms.Label();
            this.lblCantidadDeSemana = new System.Windows.Forms.Label();
            this.txtAnioLectivo = new System.Windows.Forms.TextBox();
            this.lblNuevoCicloLectivo = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeApertura = new System.Windows.Forms.Label();
            this.grbDatosCicloLectivo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.grbFinalesMarzo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.grbFinalesJulio = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grbFinalesDiciembre = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.epvCicloLectivo)).BeginInit();
            this.grbDatosCicloLectivo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grbFinalesMarzo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grbFinalesJulio.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grbFinalesDiciembre.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(26)))), ((int)(((byte)(198)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(638, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(119, 44);
            this.btnAceptar.TabIndex = 128;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // epvCicloLectivo
            // 
            this.epvCicloLectivo.ContainerControl = this;
            this.epvCicloLectivo.Icon = ((System.Drawing.Icon)(resources.GetObject("epvCicloLectivo.Icon")));
            // 
            // dtpFechaDiciembreFinal
            // 
            this.dtpFechaDiciembreFinal.CustomFormat = "";
            this.dtpFechaDiciembreFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaDiciembreFinal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDiciembreFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDiciembreFinal.Location = new System.Drawing.Point(391, 25);
            this.dtpFechaDiciembreFinal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaDiciembreFinal.Name = "dtpFechaDiciembreFinal";
            this.dtpFechaDiciembreFinal.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaDiciembreFinal.TabIndex = 143;
            this.dtpFechaDiciembreFinal.ValueChanged += new System.EventHandler(this.dtpFechaDiciembreFinal_ValueChanged);
            // 
            // dtpFechaJunioFinal
            // 
            this.dtpFechaJunioFinal.CustomFormat = "";
            this.dtpFechaJunioFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaJunioFinal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaJunioFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaJunioFinal.Location = new System.Drawing.Point(391, 25);
            this.dtpFechaJunioFinal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaJunioFinal.Name = "dtpFechaJunioFinal";
            this.dtpFechaJunioFinal.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaJunioFinal.TabIndex = 142;
            this.dtpFechaJunioFinal.ValueChanged += new System.EventHandler(this.dtpFechaJunioFinal_ValueChanged);
            // 
            // lblFinFinalDiciembre
            // 
            this.lblFinFinalDiciembre.AutoSize = true;
            this.lblFinFinalDiciembre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinFinalDiciembre.Location = new System.Drawing.Point(391, 0);
            this.lblFinFinalDiciembre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinFinalDiciembre.Name = "lblFinFinalDiciembre";
            this.lblFinFinalDiciembre.Size = new System.Drawing.Size(36, 19);
            this.lblFinFinalDiciembre.TabIndex = 133;
            this.lblFinFinalDiciembre.Text = "Fin:";
            // 
            // lblInicioFinalDiciembre
            // 
            this.lblInicioFinalDiciembre.AutoSize = true;
            this.lblInicioFinalDiciembre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioFinalDiciembre.Location = new System.Drawing.Point(24, 0);
            this.lblInicioFinalDiciembre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicioFinalDiciembre.Name = "lblInicioFinalDiciembre";
            this.lblInicioFinalDiciembre.Size = new System.Drawing.Size(54, 19);
            this.lblInicioFinalDiciembre.TabIndex = 136;
            this.lblInicioFinalDiciembre.Text = "Inicio:";
            // 
            // dtpFechaDiciembreInicio1
            // 
            this.dtpFechaDiciembreInicio1.CustomFormat = "";
            this.dtpFechaDiciembreInicio1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaDiciembreInicio1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaDiciembreInicio1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDiciembreInicio1.Location = new System.Drawing.Point(24, 25);
            this.dtpFechaDiciembreInicio1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaDiciembreInicio1.Name = "dtpFechaDiciembreInicio1";
            this.dtpFechaDiciembreInicio1.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaDiciembreInicio1.TabIndex = 141;
            this.dtpFechaDiciembreInicio1.ValueChanged += new System.EventHandler(this.dtpFechaDiciembreInicio1_ValueChanged);
            // 
            // dtpFechaJunioInicio
            // 
            this.dtpFechaJunioInicio.CustomFormat = "";
            this.dtpFechaJunioInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaJunioInicio.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaJunioInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaJunioInicio.Location = new System.Drawing.Point(24, 25);
            this.dtpFechaJunioInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaJunioInicio.Name = "dtpFechaJunioInicio";
            this.dtpFechaJunioInicio.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaJunioInicio.TabIndex = 139;
            this.dtpFechaJunioInicio.ValueChanged += new System.EventHandler(this.dtpInicioFinalJunio_ValueChanged);
            // 
            // lblFinFinalJunio
            // 
            this.lblFinFinalJunio.AutoSize = true;
            this.lblFinFinalJunio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinFinalJunio.Location = new System.Drawing.Point(391, 0);
            this.lblFinFinalJunio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinFinalJunio.Name = "lblFinFinalJunio";
            this.lblFinFinalJunio.Size = new System.Drawing.Size(36, 19);
            this.lblFinFinalJunio.TabIndex = 132;
            this.lblFinFinalJunio.Text = "Fin:";
            // 
            // lblInicioFinalJunio
            // 
            this.lblInicioFinalJunio.AutoSize = true;
            this.lblInicioFinalJunio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioFinalJunio.Location = new System.Drawing.Point(24, 0);
            this.lblInicioFinalJunio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicioFinalJunio.Name = "lblInicioFinalJunio";
            this.lblInicioFinalJunio.Size = new System.Drawing.Size(54, 19);
            this.lblInicioFinalJunio.TabIndex = 135;
            this.lblInicioFinalJunio.Text = "Inicio:";
            // 
            // dtpFechaMarzoFinal
            // 
            this.dtpFechaMarzoFinal.CustomFormat = "";
            this.dtpFechaMarzoFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaMarzoFinal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaMarzoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMarzoFinal.Location = new System.Drawing.Point(391, 25);
            this.dtpFechaMarzoFinal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaMarzoFinal.Name = "dtpFechaMarzoFinal";
            this.dtpFechaMarzoFinal.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaMarzoFinal.TabIndex = 140;
            this.dtpFechaMarzoFinal.ValueChanged += new System.EventHandler(this.dtpFechaMarzoFinal_ValueChanged);
            // 
            // dtpFechaMarzoInicio
            // 
            this.dtpFechaMarzoInicio.CustomFormat = "";
            this.dtpFechaMarzoInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaMarzoInicio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaMarzoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMarzoInicio.Location = new System.Drawing.Point(24, 25);
            this.dtpFechaMarzoInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaMarzoInicio.Name = "dtpFechaMarzoInicio";
            this.dtpFechaMarzoInicio.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaMarzoInicio.TabIndex = 138;
            this.dtpFechaMarzoInicio.ValueChanged += new System.EventHandler(this.dtpFechaMarzoInicio_ValueChanged);
            // 
            // lblFinFinalMarzo
            // 
            this.lblFinFinalMarzo.AutoSize = true;
            this.lblFinFinalMarzo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinFinalMarzo.Location = new System.Drawing.Point(391, 0);
            this.lblFinFinalMarzo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinFinalMarzo.Name = "lblFinFinalMarzo";
            this.lblFinFinalMarzo.Size = new System.Drawing.Size(36, 19);
            this.lblFinFinalMarzo.TabIndex = 131;
            this.lblFinFinalMarzo.Text = "Fin:";
            // 
            // lblInicioFinalMarzo
            // 
            this.lblInicioFinalMarzo.AutoSize = true;
            this.lblInicioFinalMarzo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioFinalMarzo.Location = new System.Drawing.Point(24, 0);
            this.lblInicioFinalMarzo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicioFinalMarzo.Name = "lblInicioFinalMarzo";
            this.lblInicioFinalMarzo.Size = new System.Drawing.Size(54, 19);
            this.lblInicioFinalMarzo.TabIndex = 130;
            this.lblInicioFinalMarzo.Text = "Inicio:";
            // 
            // dtpFechaInscripcionInicio
            // 
            this.dtpFechaInscripcionInicio.CalendarForeColor = System.Drawing.Color.Aquamarine;
            this.dtpFechaInscripcionInicio.CustomFormat = "";
            this.dtpFechaInscripcionInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInscripcionInicio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInscripcionInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInscripcionInicio.Location = new System.Drawing.Point(24, 195);
            this.dtpFechaInscripcionInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaInscripcionInicio.Name = "dtpFechaInscripcionInicio";
            this.dtpFechaInscripcionInicio.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaInscripcionInicio.TabIndex = 125;
            this.dtpFechaInscripcionInicio.ValueChanged += new System.EventHandler(this.dtpFechaInscripcionInicio_ValueChanged);
            // 
            // dtpFechaInscripcionFinal
            // 
            this.dtpFechaInscripcionFinal.CustomFormat = "";
            this.dtpFechaInscripcionFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInscripcionFinal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInscripcionFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInscripcionFinal.Location = new System.Drawing.Point(391, 195);
            this.dtpFechaInscripcionFinal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaInscripcionFinal.Name = "dtpFechaInscripcionFinal";
            this.dtpFechaInscripcionFinal.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaInscripcionFinal.TabIndex = 127;
            this.dtpFechaInscripcionFinal.ValueChanged += new System.EventHandler(this.dtpFechaInscripcionFinal_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(391, 170);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 19);
            this.label19.TabIndex = 126;
            this.label19.Text = "Fin:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(24, 170);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 19);
            this.label20.TabIndex = 124;
            this.label20.Text = "Inicio:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.label21, 2);
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(4, 135);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(359, 19);
            this.label21.TabIndex = 123;
            this.label21.Text = "Fecha de inscripción anual";
            // 
            // txtCantidadSemana
            // 
            this.txtCantidadSemana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCantidadSemana.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadSemana.Location = new System.Drawing.Point(24, 85);
            this.txtCantidadSemana.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCantidadSemana.MaxLength = 2;
            this.txtCantidadSemana.Name = "txtCantidadSemana";
            this.txtCantidadSemana.Size = new System.Drawing.Size(339, 27);
            this.txtCantidadSemana.TabIndex = 121;
            this.txtCantidadSemana.Text = "0";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.CustomFormat = "";
            this.dtpFechaCierre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaCierre.Enabled = false;
            this.dtpFechaCierre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCierre.Location = new System.Drawing.Point(391, 85);
            this.dtpFechaCierre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaCierre.TabIndex = 120;
            this.dtpFechaCierre.ValueChanged += new System.EventHandler(this.dtpFechaCierre_ValueChanged);
            // 
            // lblFechaDeCierre
            // 
            this.lblFechaDeCierre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDeCierre.AutoSize = true;
            this.lblFechaDeCierre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeCierre.Location = new System.Drawing.Point(393, 60);
            this.lblFechaDeCierre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFechaDeCierre.Name = "lblFechaDeCierre";
            this.lblFechaDeCierre.Size = new System.Drawing.Size(335, 19);
            this.lblFechaDeCierre.TabIndex = 63;
            this.lblFechaDeCierre.Text = "Fecha de cierre:";
            // 
            // lblCantidadDeSemana
            // 
            this.lblCantidadDeSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadDeSemana.AutoSize = true;
            this.lblCantidadDeSemana.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadDeSemana.Location = new System.Drawing.Point(26, 60);
            this.lblCantidadDeSemana.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCantidadDeSemana.Name = "lblCantidadDeSemana";
            this.lblCantidadDeSemana.Size = new System.Drawing.Size(335, 19);
            this.lblCantidadDeSemana.TabIndex = 94;
            this.lblCantidadDeSemana.Text = "Cantidad de semanas:";
            // 
            // txtAnioLectivo
            // 
            this.txtAnioLectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnioLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnioLectivo.Location = new System.Drawing.Point(26, 28);
            this.txtAnioLectivo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtAnioLectivo.MaxLength = 30;
            this.txtAnioLectivo.Name = "txtAnioLectivo";
            this.txtAnioLectivo.Size = new System.Drawing.Size(335, 27);
            this.txtAnioLectivo.TabIndex = 1;
            // 
            // lblNuevoCicloLectivo
            // 
            this.lblNuevoCicloLectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNuevoCicloLectivo.AutoSize = true;
            this.lblNuevoCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoCicloLectivo.Location = new System.Drawing.Point(26, 0);
            this.lblNuevoCicloLectivo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNuevoCicloLectivo.Name = "lblNuevoCicloLectivo";
            this.lblNuevoCicloLectivo.Size = new System.Drawing.Size(335, 19);
            this.lblNuevoCicloLectivo.TabIndex = 65;
            this.lblNuevoCicloLectivo.Text = "Año:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "";
            this.dtpFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(391, 25);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(339, 27);
            this.dtpFechaInicio.TabIndex = 119;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblFechaDeApertura
            // 
            this.lblFechaDeApertura.AutoSize = true;
            this.lblFechaDeApertura.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeApertura.Location = new System.Drawing.Point(393, 0);
            this.lblFechaDeApertura.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFechaDeApertura.Name = "lblFechaDeApertura";
            this.lblFechaDeApertura.Size = new System.Drawing.Size(141, 19);
            this.lblFechaDeApertura.TabIndex = 67;
            this.lblFechaDeApertura.Text = "Fecha de apertura:";
            // 
            // grbDatosCicloLectivo
            // 
            this.grbDatosCicloLectivo.Controls.Add(this.tableLayoutPanel4);
            this.grbDatosCicloLectivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDatosCicloLectivo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDatosCicloLectivo.Location = new System.Drawing.Point(20, 20);
            this.grbDatosCicloLectivo.Name = "grbDatosCicloLectivo";
            this.grbDatosCicloLectivo.Size = new System.Drawing.Size(760, 273);
            this.grbDatosCicloLectivo.TabIndex = 132;
            this.grbDatosCicloLectivo.TabStop = false;
            this.grbDatosCicloLectivo.Text = "Ciclo Lectivo";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.lblFechaDeApertura, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpFechaCierre, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblFechaDeCierre, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.label19, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.label20, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblNuevoCicloLectivo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtAnioLectivo, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.dtpFechaInicio, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtCantidadSemana, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.dtpFechaInscripcionFinal, 3, 6);
            this.tableLayoutPanel4.Controls.Add(this.dtpFechaInscripcionInicio, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.lblCantidadDeSemana, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(754, 247);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // grbFinalesMarzo
            // 
            this.grbFinalesMarzo.Controls.Add(this.tableLayoutPanel3);
            this.grbFinalesMarzo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFinalesMarzo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFinalesMarzo.Location = new System.Drawing.Point(20, 293);
            this.grbFinalesMarzo.Name = "grbFinalesMarzo";
            this.grbFinalesMarzo.Size = new System.Drawing.Size(760, 109);
            this.grbFinalesMarzo.TabIndex = 131;
            this.grbFinalesMarzo.TabStop = false;
            this.grbFinalesMarzo.Text = "Fecha de inscripción Finales Marzo";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lblFinFinalMarzo, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpFechaMarzoFinal, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblInicioFinalMarzo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpFechaMarzoInicio, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(754, 83);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // grbFinalesJulio
            // 
            this.grbFinalesJulio.Controls.Add(this.tableLayoutPanel2);
            this.grbFinalesJulio.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFinalesJulio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFinalesJulio.Location = new System.Drawing.Point(20, 402);
            this.grbFinalesJulio.Name = "grbFinalesJulio";
            this.grbFinalesJulio.Size = new System.Drawing.Size(760, 109);
            this.grbFinalesJulio.TabIndex = 130;
            this.grbFinalesJulio.TabStop = false;
            this.grbFinalesJulio.Text = "Fecha de inscripción Finales Julio";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dtpFechaJunioInicio, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpFechaJunioFinal, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFinFinalJunio, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInicioFinalJunio, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(754, 83);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // grbFinalesDiciembre
            // 
            this.grbFinalesDiciembre.Controls.Add(this.tableLayoutPanel1);
            this.grbFinalesDiciembre.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFinalesDiciembre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFinalesDiciembre.Location = new System.Drawing.Point(20, 511);
            this.grbFinalesDiciembre.Name = "grbFinalesDiciembre";
            this.grbFinalesDiciembre.Size = new System.Drawing.Size(760, 109);
            this.grbFinalesDiciembre.TabIndex = 129;
            this.grbFinalesDiciembre.TabStop = false;
            this.grbFinalesDiciembre.Text = "Fecha de inscripción Finales Diciembre";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblFinFinalDiciembre, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInicioFinalDiciembre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaDiciembreFinal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaDiciembreInicio1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 83);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel5.Controls.Add(this.btnAceptar, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(20, 620);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(760, 56);
            this.tableLayoutPanel5.TabIndex = 133;
            // 
            // FormAgregarModificarCicloLectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 788);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.grbFinalesDiciembre);
            this.Controls.Add(this.grbFinalesJulio);
            this.Controls.Add(this.grbFinalesMarzo);
            this.Controls.Add(this.grbDatosCicloLectivo);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormAgregarModificarCicloLectivo";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "FormAgregarModificarCicloLectivo";
            this.Load += new System.EventHandler(this.FormAgregarModificarCicloLectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epvCicloLectivo)).EndInit();
            this.grbDatosCicloLectivo.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.grbFinalesMarzo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grbFinalesJulio.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.grbFinalesDiciembre.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ErrorProvider epvCicloLectivo;
        private System.Windows.Forms.Label lblFechaDeApertura;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblNuevoCicloLectivo;
        private System.Windows.Forms.TextBox txtAnioLectivo;
        private System.Windows.Forms.Label lblCantidadDeSemana;
        private System.Windows.Forms.Label lblFechaDeCierre;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.TextBox txtCantidadSemana;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpFechaInscripcionFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInscripcionInicio;
        private System.Windows.Forms.Label lblInicioFinalMarzo;
        private System.Windows.Forms.Label lblFinFinalMarzo;
        private System.Windows.Forms.DateTimePicker dtpFechaMarzoInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaMarzoFinal;
        private System.Windows.Forms.Label lblInicioFinalJunio;
        private System.Windows.Forms.Label lblFinFinalJunio;
        private System.Windows.Forms.DateTimePicker dtpFechaJunioInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaDiciembreInicio1;
        private System.Windows.Forms.Label lblInicioFinalDiciembre;
        private System.Windows.Forms.Label lblFinFinalDiciembre;
        private System.Windows.Forms.DateTimePicker dtpFechaJunioFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaDiciembreFinal;
        private System.Windows.Forms.GroupBox grbDatosCicloLectivo;
        private System.Windows.Forms.GroupBox grbFinalesMarzo;
        private System.Windows.Forms.GroupBox grbFinalesDiciembre;
        private System.Windows.Forms.GroupBox grbFinalesJulio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}