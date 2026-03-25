using ISFDyT93.Vista.Core;
using FontAwesome.Sharp;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Vista.Forms.Carreras;
using ISFDyT93.Vista.Forms.Alumnos;
using ISFDyT93.Vista.Forms.Personal;
using ISFDyT93.Vista.Forms.Configuraciones;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Datos;
using ISFDyT93.Datos.Daos;

namespace ISFDyT93.Vista.Forms
{
    public partial class FormPrincipal : Form
    {
        #region Campos Privados

        private IconButton currentBtn;
        private Action actionVolver;
        private MesasFinalesLogica mesasLogica;
        
        #endregion

        public FormPrincipal()
        {
            InitializeComponent();
            mesasLogica = new MesasFinalesLogica();
        }

        //Funcion para abrir otros formulario en el panel
        public void AbrirFormulario<T>(Action<T> func = null) where T : Form, new()
        {
            this.btnVolver.Visible = false;

            var form = new T();

            var tipo = typeof(T);

            var principal = tipo.GetProperties().Where(p => p.Name.Equals("Contenedor")).FirstOrDefault();

            if (principal != null)
            {
                principal.SetValue(form, this);
            }

            func?.Invoke(form);

            pnlDerecho.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlDerecho.Controls.Add(form);
            pnlDerecho.Tag = form;
            form.Show();
        }

        public FormPrincipal SetTitulo(string Titulo)
        {
            this.lblTitulo.Text = Titulo;

            return this;
        }

        public FormPrincipal SetVolver(Action func = null)
        {
            this.btnVolver.Visible = true;
            this.actionVolver = func;

            return this;
        }

        #region Botonera Izquierda
        
        private void ActivarBoton(object sender, Color color)
        {
            if(sender != null && sender != currentBtn)
            {
                this.DesactivarBoton();

                currentBtn = (IconButton)sender;
                currentBtn.BackColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            }
        }

        private void DesactivarBoton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(51, 51, 76);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

                currentBtn = null;
            }
        }

        #endregion
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(sender, ThemeColor.GetColor());
            this.AbrirFormulario<FormHome>();
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(sender, ThemeColor.GetColor());

            this.AbrirFormulario<FormCarreras>();
            
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(sender, ThemeColor.GetColor());

            this.AbrirFormulario<FormPersonal>();
        }

        private void btnAlumnos_Click_1(object sender, EventArgs e)
        {
            this.ActivarBoton(sender, ThemeColor.GetColor());

            this.AbrirFormulario<FormAlumnos>();
        }
        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(sender, ThemeColor.GetColor());

            this.AbrirFormulario<FormControlAsistencias>();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            actionVolver?.Invoke();
        }
        private void tmiVerCiclos_Click(object sender, EventArgs e)
        {
            this.DesactivarBoton();
            this.AbrirFormulario<FormCicloLectivo>();
        }

        
        private void btnOpciones_Click(object sender, EventArgs e)
        {            
            var control = sender as Control;
            cmsOpciones.Show(pnlIzquierdo, control.Right, control.Top);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            btnHome_Click(btnHome, EventArgs.Empty);
            Cache.FormPrincipal = this;

        }      
            
        private void Parametros_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(btnOpciones, ThemeColor.GetColor());
            AbrirFormulario<FormParametros>();
        }
        int Notificacion = 0;

        private void tsmVerCiclos_Click(object sender, EventArgs e)
        {
            this.ActivarBoton(btnOpciones, ThemeColor.GetColor());
            AbrirFormulario<FormCicloLectivo>();
        }

        private void tsmPruebaSP_Click(object sender, EventArgs e)
        {
            DataTable dt = mesasLogica.ExistenMesasFinales(2024);
            int marzo = Convert.ToInt32(dt.Rows[0]["Marzo"]);
            int julio = Convert.ToInt32(dt.Rows[0]["Julio"]);
            int diciembre = Convert.ToInt32(dt.Rows[0]["Diciembre"]);
            MessageBox.Show($"{marzo}, {julio}, {diciembre}");
        }


    }
    }
