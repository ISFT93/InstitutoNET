using ISFDyT93.Negocio.Logica;
using System;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.Core;
using ISFDyT93.Datos.Enums;
using System.Data;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormAgregarModificarServicios : FormBase
    {
        #region Propiedades Públicas
        public int PersonalId { get; set; }

        #endregion

        #region Propiedades Privadas
        private ServiciosLogica ServiciosLogica { get; set; }
        private PersonalLogica PersonalLogica { get; set; }
        private PersonalModelo Personal { get; set; }
        private LibroActasModelo LibroActa { get; set; }
        private DataTable TablaCargos { get; set; }
        private int CargoId 
        {
            get
            {
                return  Convert.ToInt32(cmbCargoId.SelectedValue);
            }
        }
        private int CursoId
        {
            get { return Convert.ToInt32(cmbCursoId.SelectedValue); }
        }
        private int SituacionRevistaId
        {
            get { return Convert.ToInt32(cmbSituacionRevistaId.SelectedValue); }
        }
        private int TipoAsignacionId
        {
            get { return BuscarTipoAsignacion(CargoId); }
        } 
        #endregion

        //Constructor y Load
        public FormAgregarModificarServicios()
        {
            this.PersonalId = PersonalId;
            this.ServiciosLogica = new ServiciosLogica();
            this.PersonalLogica = new PersonalLogica();

            InitializeComponent();
        }       
        private void FormAgregarModificarServicios_Load(object sender, EventArgs e)
        {
            this.Personal = this.PersonalLogica.ObtenerPersonal(this.PersonalId);
            
            txtLibro.Enabled = false;
            txtFolio.Enabled = false;
            
            cmbCargoId.ValueMember = "CargoId";
            cmbCargoId.DisplayMember = "Descripcion";
            TablaCargos = this.ServiciosLogica.ObtenerCargos(PersonalId);
            cmbCargoId.DataSource = TablaCargos;            
           
            cmbSituacionRevistaId.ValueMember = "SituacionRevistaId";
            cmbSituacionRevistaId.DisplayMember = "Descripcion";
            cmbSituacionRevistaId.DataSource = this.ServiciosLogica.ObtenerSituacionRevista();

            this.Contenedor.SetTitulo($"Agregar Servicio a { this.Personal.Nombre } { this.Personal.Apellido }");

            this.Contenedor.SetVolver( () => 
            {
                this.Contenedor.AbrirFormulario<FormServicios>(form =>
                {
                    form.PersonalId = this.PersonalId;
                });
            });
            
            LibroFolio();
            VisibilidadDeControles();
        }

        //Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var modelo = this.MapToModel<ServiciosModelo>();

            if (modelo.Errores.Count == 0)
            {
                modelo.PersonalId = this.PersonalId;

                this.ServiciosLogica.AgregarServicio(modelo, this.Personal, this.LibroActa);
                Notificar(TipoNotificacion.Success, "Servicio generado correctamente");

                Contenedor.AbrirFormulario<FormServicios>(form =>
                {
                    form.PersonalId = this.PersonalId;
                });
            }
            else
            {
                this.MostrarErrores(this.epvServicios, modelo.Errores);
            }
        }

        //Index Clanges de los ComboBox
        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (TipoAsignacionId == (int)TipoAsignacion.AsignarMateria || TipoAsignacionId == (int)TipoAsignacion.AsignarCarrera) 
                ActualizarCarreras();
            if (BuscarRepetibles(CargoId))
                ActualizarCargosAsignados();
            VisibilidadDeControles();
        }
        private void cmbSituacionRevista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarAnios();
            ActualizarCursos();
            ActualizarMateriasDisponibles();
            ActualizarModulo();
            VisibilidadDeControles();
        }
        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarAnios();
            ActualizarCursos();
            ActualizarMateriasDisponibles();
            ActualizarModulo();
        }
        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCursos();
            ActualizarMateriasDisponibles();
            ActualizarModulo();
        }
        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMateriasDisponibles();
            ActualizarModulo();
        }        
        private void cmbCursoMateriaId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarModulo();
        }


        //Funciones        
        public void VisibilidadDeControles()
        {            
            bool repetibles = BuscarRepetibles(CargoId);
            
            //Habilitar Visibles

            CarreraVisible((TipoAsignacionId == (int)TipoAsignacion.AsignarMateria || TipoAsignacionId == (int)TipoAsignacion.AsignarCarrera));
            CursoVisible((TipoAsignacionId == (int)TipoAsignacion.AsignarMateria));
            MateriasDisponiblesVisible((TipoAsignacionId == (int)TipoAsignacion.AsignarMateria));
            AnioVisible((TipoAsignacionId == (int)TipoAsignacion.AsignarMateria));
            CargosAsignadosVisible(repetibles);
            ModuloVisible(TipoAsignacionId == (int)TipoAsignacion.AsignarMateria);
            ReemplazoVisible(SituacionRevistaId == (int)SituacionRevista.Suplente);

            //SubFunciones
            void ReemplazoVisible(bool estado)
            {
                lblPersonalReemplazar.Visible = estado;
                cmbPersonal.Visible = estado;
            }
            void CarreraVisible(bool estado)
            {
                lblCarrera.Visible = estado;
                cmbCarreraId.Visible = estado;
            }
            void AnioVisible(bool estado)
            {
                lblAnio.Visible = estado;
                cmbAnioId.Visible = estado;
            }
            void CursoVisible(bool estado)
            {
                lblCurso.Visible = estado;
                cmbCursoId.Visible = estado;
            }
            void MateriasDisponiblesVisible(bool estado)
            {
                lblMateriasDisponibles.Visible = estado;
                cmbCursoMateriaId.Visible = estado;
            }
            void CargosAsignadosVisible(bool estado)
            {
                lblCargosAsignados.Visible = estado;
                lstCargosAsignados.Visible = estado;
            }
            void ModuloVisible(bool estado)
            {
                txtModulo.Visible = estado;
                lblModulo.Visible = estado;
            }
        }
        private void ActualizarCarreras()
        {
            cmbCarreraId.ValueMember = "CarreraId";
            cmbCarreraId.DisplayMember = "DescripcionCorta";
            cmbCarreraId.DataSource = this.ServiciosLogica.ObtenerCarreras(TipoAsignacionId, SituacionRevistaId);
        }
        private void ActualizarAnios()
        {
            if (Convert.ToInt32(cmbCarreraId.SelectedValue) > 0)
            {
                cmbAnioId.ValueMember = "AnioCarreraId";
                cmbAnioId.DisplayMember = "AnioCarrera";
                cmbAnioId.DataSource = this.ServiciosLogica.ObtenerAnioCarreras((int)cmbCarreraId.SelectedValue);
            }
        }
        private void ActualizarCursos()
        {
            var anioCarreraId = Convert.ToInt32(cmbAnioId.SelectedValue);
            if (anioCarreraId > 0)
            {
                cmbCursoId.ValueMember = "CursoId";
                cmbCursoId.DisplayMember = "NombreCurso";
                cmbCursoId.DataSource = this.ServiciosLogica.ObtenerCursos(anioCarreraId);
            }
            else cmbCursoId.Items.Clear();
        }
        private void ActualizarMateriasDisponibles()
        {
            cmbCursoMateriaId.ValueMember = "CursoMateriaId";
            cmbCursoMateriaId.DisplayMember = "Nombre";
            cmbCursoMateriaId.DataSource = this.ServiciosLogica.ObtenerMateriasLibres(TipoAsignacionId, CursoId, SituacionRevistaId);
        }       
        private void ActualizarModulo()
        {
            if (cmbCursoMateriaId.SelectedIndex != -1)
            {
                int modulo = ServiciosLogica.ObtenerModuloMateria(Convert.ToInt32(cmbCursoMateriaId.SelectedValue));
                if (modulo != -1)
                    txtModulo.Text = modulo.ToString();
                else txtModulo.Text = "";
            }
            else txtModulo.Clear();
        }
        private void LibroFolio()
        {
            this.LibroActa = this.ServiciosLogica.ObtenerUltimoLibro((int)TipoLibro.LibroMatriz);

            txtLibro.Text = this.LibroActa.LibroNumero.ToString();
            txtFolio.Text = this.LibroActa.FolioNumero.ToString();
        }
        private void ActualizarCargosAsignados()
        {
            lstCargosAsignados.DisplayMember = "Cargos";
            lstCargosAsignados.DataSource = this.ServiciosLogica.ObtenerCargosAsignados(CargoId, PersonalId);
        }


        //Buscar o Obtener informacion
        private int BuscarTipoAsignacion(int cargoId)
        {
            DataRow[] rows = TablaCargos.Select("CargoId=" + cargoId);
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                string result = row["TipoAsignacionId"].ToString();
                if(result != null && result != "")
                    return Convert.ToInt32(result);
            }
            return -1;
        }
        private bool BuscarRepetibles(int cargoId)
        {
            DataRow[] rows = TablaCargos.Select("CargoId=" + cargoId);
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                string result = row["TipoAplicacionId"].ToString();
                if (result == "3" || result == "4")
                    return true;
            }
            return false;
        }
        
    }
}
