using System;
using System.Collections.Generic;
using System.ComponentModel;
using ISFDyT93.Datos.Modelos;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;


namespace ISFDyT93.Vista.Forms.Configuraciones
{
    public partial class FormInscripcionCicloLectivo : FormBase
    {
        #region Propiedades Publicas
        public TipoAccion Accion { get; set; }
        
        public int CicloLectivoId { get; set; }
        #endregion
        
        CicloLectivosLogica cicloLectivosLogica;

        DataTable FechaDeCierre;
        
        public FormInscripcionCicloLectivo()
        {
            this.cicloLectivosLogica = new CicloLectivosLogica();
            this.FechaDeCierre = new DataTable();
            InitializeComponent();
            
        }
        int ciclo = 0;
        public void Refrescar()
        {
            //CicloLectivoId = Convert.ToInt32("2029");
            //var CicloLec= (cicloLectivosLogica.ObtenerCicloLectivo());
            dgvInscripcionCicloLectivo.DataSource = this.cicloLectivosLogica.CargarInscripcionAlumnoSP(CicloLectivoId);
            dgvInscripcionCicloLectivo.Columns["Id"].Visible = false;
            dgvInscripcionCicloLectivo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInscripcionCicloLectivo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        } 
       
        private void FormInscripcionCicloLectivo_Load(object sender, EventArgs e)
        {
            Refrescar();
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormCicloLectivo>();
            });           
            this.Contenedor.SetTitulo("Inscripcion Ciclo Lectivo " + CicloLectivoId);
            

            ciclo = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo();//ultimo ciclo lectivo 
            FechaDeCierre = cicloLectivosLogica.ConsultarUnCicloLectivo(ciclo);//Traigo fecha de cierre del Ciclo Lectivo
            var CantAlumnoAnotados = cicloLectivosLogica.ObtenerAlumnoDePrimero(ciclo);

            DateTime FechaDeCierreInscripcion = new DateTime();
            FechaDeCierreInscripcion = (Convert.ToDateTime(FechaDeCierre.Rows[0]["FechaInscripcionFinal"])) ;
            FechaDeCierreInscripcion.ToString("dd-MM-yyyy");
            FechaDeCierreInscripcion = FechaDeCierreInscripcion.AddDays(1);

            if ((DateTime.Today < FechaDeCierreInscripcion) && (0 < CantAlumnoAnotados))
            {
                btnIngresoPrimerAño.Visible = false;                
            }
            else
            {
                btnIngresoPrimerAño.Visible = true;
            }
        }

        private void btnIngresoPrimerAño_Click(object sender, EventArgs e)
        {
            this.cicloLectivosLogica.IngresoCursadaPrimeroSP(CicloLectivoId);
            btnIngresoPrimerAño.Visible = false;
            Refrescar();
        }
    } 
}
