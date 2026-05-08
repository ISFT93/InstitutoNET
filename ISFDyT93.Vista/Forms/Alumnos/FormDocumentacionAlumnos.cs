using CapaPresentacionAdmin.Controls;
using ISFDyT93.Entidades.Enums;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Forms.Componentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormDocumentacionAlumnos : FormBase
    {
        #region Propiedades Privadas

        private AlumnosLogica AlumnosLogica { get; set; }
        private InscripcionAlumnoLogica AlumnosInscLogica { get; set; }
        private CarrerasLogica carrerasLogica { get; set; }
        private CargaMasivaLogica CargaMasivaLogica { get; set; }
        private CicloLectivosLogica CicloLectivosLogica { get; set; }

        private int AlumnoId { get; set; }
        private string ApellidoNombre { get; set; }
        private int AlumnoCarreraId { get; set; }

        FormCargaMasivaCsv FormCarMasivaCsv = new FormCargaMasivaCsv();

        #endregion
        public FormDocumentacionAlumnos()
        {
            this.AlumnosLogica = new AlumnosLogica();
            this.AlumnosInscLogica = new InscripcionAlumnoLogica();
            this.CargaMasivaLogica = new CargaMasivaLogica();
            this.CicloLectivosLogica = new CicloLectivosLogica();
            carrerasLogica = new CarrerasLogica();  
            InitializeComponent();
        }

        private void FormDocumentacionAlumnos_Load(object sender, EventArgs e)
        {
            uscPaginacion1.dataGridView = dgvAlumnos; //pasa el datagridview a la paginacion
            cmbCarreraId.SelectedIndex = 0; //por defecto busca todos
            RecargarGrilla();
            uscPaginacion1.BringToFront();

            cmbCarreraId.DataSource = carrerasLogica.ObtenerCarreras();
            cmbCarreraId.ValueMember = "CarreraId";
            cmbCarreraId.DisplayMember = "Descripción";

            this.Contenedor.SetTitulo("Documentación de Alumnos");
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });
        }
        private void RecargarGrilla(string filtro = "")
        {
            dgvAlumnos.ClearSelection();
            var tipo = (TipoFiltroAlumno)cmbCarreraId.SelectedIndex;

            if (rbTodos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro);
            else if (rbIncompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro, "'True'");
            else if (rbCompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro, "'False'");

            EstilosColumnasDGV();
        }
        private void EstilosColumnasDGV()
        {
            if (dgvAlumnos.Columns.Contains("AlumnoId"))
                dgvAlumnos.Columns["AlumnoId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("AlumnoCarreraId"))
                dgvAlumnos.Columns["AlumnoCarreraId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("Inicializado"))
                dgvAlumnos.Columns["Inicializado"].Visible = false;
            if (dgvAlumnos.Columns.Contains("Curso"))
            {
                dgvAlumnos.Columns["Curso"].FillWeight = 50;
                dgvAlumnos.Columns["Curso"].MinimumWidth = 50;
            }
            if (dgvAlumnos.Columns.Contains("Año"))
                dgvAlumnos.Columns["Año"].FillWeight = 50;
            if (dgvAlumnos.Columns.Contains("Carrera"))
                dgvAlumnos.Columns["Carrera"].FillWeight = 100;
            if (dgvAlumnos.Columns.Contains("Activo"))
                dgvAlumnos.Columns["Activo"].FillWeight = 50;
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form =>
            {
                form.Accion = TipoAccion.Documentacion;
                form.AlumnoId = AlumnoId;
            });
        
        }
    }
}
