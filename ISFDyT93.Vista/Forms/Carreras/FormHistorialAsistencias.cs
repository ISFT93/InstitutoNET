using ISFDyT93.Negocio.Logica;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.Core;
using System;
using ISFDyT93.Vista.Forms.Alumnos;
using ISFDyT93.Vista.Forms.Common;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormHistorialAsistencias : FormBase
    {

        #region Propiedades Publicas
        public int Alumno { get; set; }
        public int CursadaAlumnoCarrera { get; set; }
        public int CursadaId { get; set; }
        public int AnioCarreraId { get; set; }
        public int CursoId { get; set; }
        public int CursoMateriaId { get; set; }
        public string NombreAlumno { get; set; }
        public int CursadaAlumnoCarreraId { get; set; }
        public int Modulos { get; set; }
        public decimal PorcentajeAsistencia { get; set; }
        public DateTime UltimoPresentismo { get; set; }
        public string NombreProfesor { get; set; }
        public string Materia { get; set; }
        #endregion

        #region Propiedades Privadas
        private ControlAsistenciasLogica controlAsistenciasLogica;
        private CursadasLogica cursadasLogica;
        #endregion


        public FormHistorialAsistencias()
        {
            this.controlAsistenciasLogica = new ControlAsistenciasLogica();
            this.cursadasLogica = new CursadasLogica();
            InitializeComponent();
        }

        private void FormHistorialAsistencia_Load(object sender, EventArgs e)
        {
           
        }

        private void CargarPropiedadesFormPrincipal()
        {
            var data = this.cursadasLogica.ObtenerCursadaByCursadaAlumnoCarreraId(CursadaAlumnoCarreraId);

            CursadaId = Convert.ToInt32(data.ItemArray[0].ToString());

            this.Contenedor.SetVolver(() =>
               Contenedor.AbrirFormulario<FormCursoMateriasAlumnos>(form =>
               {
                   form.CursadaId = this.CursadaId;
               }));
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {

            var CursadaAlumnoCarreraStr = new AsistenciasModelo
            {
                CursadaAlumnoCarreraId = CursadaAlumnoCarreraId,
            };

            var datos = this.controlAsistenciasLogica.HistorialAsistenciasAlumnos(CursadaAlumnoCarreraStr);

            this.Contenedor.AbrirFormulario<FormReporte>(form => {
                form.SetReporte("Diseño.Reports.HistorialAsistenciasAlumnos.rdlc")
                .AddDataSource(datos, "DSHistorialAsistenciasAlumno")
                .AddParameter("Alumno", txtHistAsistenciaAl.Text)
                .AddParameter("Profesor", txtHistAsistenciaProfe.Text)
                .AddParameter("Materia", txtHistAsistenciaMateria.Text)
                .AddParameter("UltimoPresentismo", txtHistAsistenciaUltimoPresentismo.Text)
                .AddParameter("PorcentajeAsistencia", txtHistAsistenciaPorcAsistencias.Text)
                .AddParameter("Modulos", txtHistAsistenciaModulos.Text);
            });
        }

        private void FormHistorialAsistencias_Load(object sender, EventArgs e)
        {
            var CursadaAlumnoCarreraStr = new AsistenciasModelo
            {
                CursadaAlumnoCarreraId = CursadaAlumnoCarreraId,
            };
            dgvHistorialAsistenciasAl.DataSource = controlAsistenciasLogica.HistorialAsistenciasAlumnos(CursadaAlumnoCarreraStr);
            txtHistAsistenciaAl.Text = NombreAlumno;
            txtHistAsistenciaProfe.Text = NombreProfesor;
            txtHistAsistenciaPorcAsistencias.Text = PorcentajeAsistencia.ToString();
            txtHistAsistenciaMateria.Text = Materia;
            txtHistAsistenciaModulos.Text = Modulos.ToString();
            txtHistAsistenciaUltimoPresentismo.Text = UltimoPresentismo.ToString("dd-MM-yyyy");
           

            this.CargarPropiedadesFormPrincipal();
        }
    }
}
