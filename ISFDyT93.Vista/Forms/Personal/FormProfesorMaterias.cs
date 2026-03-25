using System;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormProfesorMaterias : Form
    {
        public FormPrincipal Contenedor {get;set;}
        CarrerasLogica carrerasLogica;
        AniosCarreraLogica aniosLogica;
        MateriasLogica materiasLogica;
        CursosLogica cursosLogica;
        PersonalLogica profesoresLogica;
        string Accion,CarreraId, Titulo;
        int ProfesorId, AnioCarreraId, MateriaId, CursoId;
        public FormProfesorMaterias(string Accion, int ProfesorId, string Titulo)
        {
            this.Titulo = Titulo;
            this.Accion = Accion;
            this.ProfesorId = ProfesorId;
            this.carrerasLogica = new CarrerasLogica();
            this.aniosLogica = new AniosCarreraLogica();
            this.materiasLogica = new MateriasLogica();
            this.cursosLogica = new CursosLogica();
            this.profesoresLogica = new PersonalLogica();
            InitializeComponent();           
        }


        private void FormProfesorMaterias_Load(object sender, EventArgs e)
        {
            CargarCarerras(); 
            CarreraId = cmbCarrera.SelectedValue.ToString();
            CargarAnios(CarreraId);
            CargarMateriaCurso();
            CargarSituacionRevista();
        }

        public void CargarCarerras()
        {
            cmbCarrera.DataSource = carrerasLogica.ObtenerCarreras();
            cmbCarrera.ValueMember = "CarreraId";
            cmbCarrera.DisplayMember = "Nombre";        
        }

        public void CargarSituacionRevista()
        {
            cmbSituacionRevista.DataSource = profesoresLogica.ObtenerSituacionRevista();
            cmbSituacionRevista.ValueMember = "SituacionRevistaId";
            cmbSituacionRevista.DisplayMember = "Descripcion";
        }

        private void cmbMaterias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MateriaId = Convert.ToInt32(cmbMaterias.SelectedValue);
        }

        private void cmbCursos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CursoId = Convert.ToInt32(cmbCursos.SelectedValue);
        }

        private void pbxVolver_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormPersonal>();
        }

        private void dtpFechaAlta_CloseUp(object sender, EventArgs e)
        {
            var FecAlta = dtpFechaAlta.Value.Date.ToString("dd/MM/yyyy");
        }

        private void dtpFechaBaja_CloseUp(object sender, EventArgs e)
        {
            var FecBaja = dtpFechaBaja.Value.Date.ToString("dd/MM/yyyy");
        }

        public void CargarAnios(string CarreraId)
        {
            var carreraId = Convert.ToInt32(CarreraId);
            cmbAniosCarrera.DataSource = aniosLogica.ObtenerAnioCarrera(carreraId);
            cmbAniosCarrera.ValueMember = "AnioCarreraId";
            cmbAniosCarrera.DisplayMember = "Año";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarPM())
            {
                string FechaActual = DateTime.Now.ToString("yyyy-MM-dd");
                profesoresLogica.AsignarProfesorMateria(MateriaId, CursoId, ProfesorId, FechaActual);

                FormNotificacion.Mensaje(TipoNotificacion.Success, "Profesor asignado exitosamente");
                Contenedor.AbrirFormulario<FormPersonal>();

            }
            else
            {
                epvProfesorMateria.SetError(btnAceptar, "Debe seleccionar");
            }
        }


        private void cmbAniosCarrera_SelectionChangeCommitted(object sender, EventArgs e)
        {

            CargarMateriaCurso();

        }

        private void cmbCarrera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarreraId = cmbCarrera.SelectedValue.ToString();
            CargarAnios(CarreraId);
        }

        public void CargarMateriaCurso()
        {
            AnioCarreraId = Convert.ToInt32(cmbAniosCarrera.SelectedValue);
            cmbMaterias.DataSource = materiasLogica.CargarMaterias(AnioCarreraId);
            if (cmbMaterias.Text == "")
            {
                FormNotificacion.Mensaje(TipoNotificacion.Warning, "No posee Materias para asignar...");
            }
            else
            {
                // ¿?
            }
            cmbMaterias.ValueMember = "MateriaId";
            cmbMaterias.DisplayMember = "Nombre";
            MateriaId = Convert.ToInt32(cmbMaterias.SelectedValue);


            cmbCursos.DataSource = cursosLogica.ConsultarCursos(AnioCarreraId);
            cmbCursos.ValueMember = "CursoId";
            cmbCursos.DisplayMember = "NombreCurso";
            CursoId = Convert.ToInt32(cmbCursos.SelectedValue);
        }

        private bool ValidarPM()
        {
            bool ok = true;
            epvProfesores.Clear();
            if (MateriaId == 0)
            {
                epvProfesores.SetError(cmbMaterias, "Materias obligatorias");
                ok = false;
            }
            if (CursoId == 0)
            {
                epvProfesores.SetError(cmbCursos, "Curso obligatorio");
                ok = false;
            }

            if (ProfesorId == 0)
            {
                epvProfesores.SetError(btnAceptar, "test");
                ok = false;
            }
            if ((ProfesorId != 0) && (MateriaId != 0))
            {
                if (profesoresLogica.PoseeMaterias(ProfesorId, MateriaId))
                {
                    epvProfesores.SetError(cmbMaterias, "El profesor ya tiene asignada esta materia.");
                    ok = false;
                }
            }

            return ok;
        }
    }
}
