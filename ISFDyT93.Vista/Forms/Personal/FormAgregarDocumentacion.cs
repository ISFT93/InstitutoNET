using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormAgregarDocumentacion : FormBase
    {
        CicloLectivosLogica cicloLectivosLogica;
        DataTable dtPath = new DataTable();
        PersonalLogica profesoresLogica;
                
        public int ProfesorMateriaId { get; set; }
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Materia { get; set; }
        public string Accion { get; set; }

        int CicloLectivoId;
        string Analitico, Proyecto, CicloLectivo;

        private DataRow DocumentacionActual;

        public FormAgregarDocumentacion()
        {
            this.cicloLectivosLogica = new CicloLectivosLogica();
            this.ProfesorMateriaId = ProfesorMateriaId;
            this.profesoresLogica = new PersonalLogica();
            InitializeComponent();
        }

        private void btnVolverMateria_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormPersonal>();
        }

        private void picVerAnalitico_Click(object sender, EventArgs e)
        {
            if(this.DocumentacionActual != null)
            {
                this.DocumentacionActual = profesoresLogica.ObtenerDocumentacion(ProfesorMateriaId, CicloLectivoId);
                string pathAnalitico = this.DocumentacionActual["Analitico"].ToString();
                Process.Start(Application.StartupPath + pathAnalitico);
            }
        }

        private void picVerProyecto_Click(object sender, EventArgs e)
        {
            if (this.DocumentacionActual != null)
            {
                this.DocumentacionActual = profesoresLogica.ObtenerDocumentacion(ProfesorMateriaId, CicloLectivoId);
                string pathAnalitico = this.DocumentacionActual["Proyecto"].ToString();
                Process.Start(Application.StartupPath + pathAnalitico);
            }
        }

        private void picAnalitico_Click(object sender, EventArgs e)
        {
            
        }

        private void FormAgregarDocumentacion_Load(object sender, EventArgs e)
        {
            this.CicloLectivoId = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo();
            CicloLectivo = Convert.ToString(cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo());
            if (Accion == "VerDoc")
            {
                btnGuardar.Visible = false;
                btnAnalitico.Visible = false;
                btnProyecto.Visible = false;
                picVerAnalitico.Visible = true;
                picVerAnalitico.Enabled = true;
                picVerProyecto.Enabled = true;
                picVerProyecto.Visible = true;
             
                dtPath = profesoresLogica.ObtenerPath(ProfesorMateriaId, CicloLectivoId);
                foreach(DataRow fila in dtPath.Rows)
                {
                    Analitico = fila["Analitico"].ToString();
                    Proyecto = fila["Proyecto"].ToString();
                }
                txtAnalitico.Text = Analitico;
                txtProyecto.Text = Proyecto;
                this.DocumentacionActual = profesoresLogica.ObtenerDocumentacion(ProfesorMateriaId, CicloLectivoId);
            }
            else
            {
                this.DocumentacionActual = profesoresLogica.ObtenerDocumentacion(ProfesorMateriaId, CicloLectivoId);
                
                dtPath = profesoresLogica.ObtenerPath(ProfesorMateriaId, CicloLectivoId);
                if (dtPath.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtPath.Rows)
                    {
                        Analitico = fila["Analitico"].ToString();
                        Proyecto = fila["Proyecto"].ToString();
                    }
                    txtAnalitico.Text = Analitico;
                    txtProyecto.Text = Proyecto;
                }
                   

            }
        }

        private void btnAnalitico_Click(object sender, EventArgs e)
        {
            if (Accion != "VerDoc")
            {
                ofdAsignarDoc.Filter = "Archivos PDF|*.pdf";

                if (ofdAsignarDoc.ShowDialog() == DialogResult.OK)
                {
                    txtAnalitico.Text = ofdAsignarDoc.FileName;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DocumentacionActual == null)
            {
                if (txtAnalitico.Text != "")
                {
                    int Id = profesoresLogica.AgregarDocumentacion(txtAnalitico.Text, txtProyecto.Text, ProfesorMateriaId, CicloLectivoId);
                    if (Id != -1)
                    {
                        Notificar(TipoNotificacion.Success, "Documentacion agregada\n correctamente");
                        
                            Contenedor.AbrirFormulario<FormPersonal>();
                        
                    }
                }
            }
            else
            {
                //Modificar
                if (txtAnalitico.Text != "")
                {
                    int Id = profesoresLogica.ModificarDocumentacion(txtAnalitico.Text, txtProyecto.Text, ProfesorMateriaId, CicloLectivoId);
                    
                    Notificar(TipoNotificacion.Success, "Documentacion agregada\n correctamente");

                        Contenedor.AbrirFormulario<FormPersonal>();

                    
                }
            }
        }

        private void btnProyecto_Click(object sender, EventArgs e)
        {
            if (Accion != "VerDoc")
            {
                ofdAsignarDoc.Filter = "Archivos PDF|*.pdf";

                if (ofdAsignarDoc.ShowDialog() == DialogResult.OK)
                {
                    txtProyecto.Text = ofdAsignarDoc.FileName;
                }
            }
        }
    }
}
