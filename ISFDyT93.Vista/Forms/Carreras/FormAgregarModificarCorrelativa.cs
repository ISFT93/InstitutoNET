using ISFDyT93.Negocio.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Vista.Core;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAgregarModificarCorrelativa : FormBase
    {
        #region Propiedades Públicas
        public int MateriaId { get; set; }
        public string DescripcionCarrera { get; set; }
        #endregion

        #region Propiedades Privadas
        private CorrelativasLogica correlativasLogica { get; set; }
        private MateriasLogica materiasLogica { get; set; }
        private MateriasModelo materiaModelo { get; set; }
        #endregion

        public FormAgregarModificarCorrelativa()
        {
            this.correlativasLogica = new CorrelativasLogica();
            this.materiasLogica = new MateriasLogica();
            InitializeComponent();
        }

        private void FormAgregarModificarCorrelativa_Load(object sender, EventArgs e)
        {
            this.materiaModelo = materiasLogica.ObtenerMateria(MateriaId);
            var Carrera = materiasLogica.ObtenerCarreraDeAnio(this.materiaModelo.AnioCarreraId);

            this.Contenedor.SetVolver(() => {
               this.Contenedor.AbrirFormulario<FormMateriasAnioCarrera>((form) =>
               {
                   form.AnioCarreraId = materiaModelo.AnioCarreraId;
               });
            });

            //ACTIVA o INACTIVA
            if (Convert.ToInt32(Carrera["CarreraEstadoId"]) == 1 || Convert.ToInt32(Carrera["CarreraEstadoId"]) == 2)
            {
                btnAgregarMateria.Visible = false;
                btnAgregarTodos.Visible = false;
                btnQuitarMateria.Visible = false;
                btnQuitarTodos.Visible = false;
                this.Contenedor.SetTitulo($"Materias correlativas a {this.materiaModelo.Nombre} - {DescripcionCarrera}");
            }//BORRADOR
            else if (Convert.ToInt32(Carrera["CarreraEstadoId"]) == 3)
            {
                btnAgregarMateria.Visible = true;
                btnAgregarTodos.Visible = true;
                btnQuitarMateria.Visible = true;
                btnQuitarTodos.Visible = true;
                this.Contenedor.SetTitulo($"Asignar materias correlativas a {this.materiaModelo.Nombre} - {DescripcionCarrera}");
            } 

            this.ActualizarListas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var materiaDatos = materiasLogica.ObtenerMateria(MateriaId);
            int AnioCarreraId = materiaDatos.AnioCarreraId;

            Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form => {
                form.AnioCarreraId = AnioCarreraId;
            });
        }

        private void ActualizarListas()
        {
            var DatosMateria = correlativasLogica.ObtenerCorreltividades(this.MateriaId, this.materiaModelo.CarreraId);
            var DatoCorrelativas = correlativasLogica.ObtenerMateriasCorrelativas(this.MateriaId);

            lstCorrelativas.DataSource = DatoCorrelativas;
            lstCorrelativas.DisplayMember = "Materia";
            lstCorrelativas.ValueMember = "CorrelativaId";

            lstMaterias.DataSource = DatosMateria;
            lstMaterias.DisplayMember = "Materia";
            lstMaterias.ValueMember = "MateriaId";
        }

        private void btnAgregarMateria_Click(object sender, EventArgs e)
        {
            int CorrelativaId = -1;

            if (int.TryParse(lstMaterias.SelectedValue?.ToString(), out CorrelativaId))
            {
                this.correlativasLogica.AgregarCorrelativa(this.MateriaId, CorrelativaId);
                this.ActualizarListas();
            }
        }

        private void btnQuitarMateria_Click(object sender, EventArgs e)
        {
            int CorrelativaId = -1;

            if (int.TryParse(lstCorrelativas.SelectedValue?.ToString(), out CorrelativaId))
            {
                this.correlativasLogica.EliminarCorrelativa(CorrelativaId);
                this.ActualizarListas();
            }
        }
        private void btnAgregarTodos_Click_1(object sender, EventArgs e)
        {
            var tabla = (DataTable)lstMaterias.DataSource;

            if (tabla.Rows.Count > 0)
            {
                var Correlativas = new List<CorrelatividadModel>();

                foreach (DataRow fila in tabla.Rows)
                {
                    var model = new CorrelatividadModel()
                    {
                        MateriaId = this.MateriaId,
                        CorrelatividadId = Convert.ToInt32(fila["MateriaId"])
                    };

                    Correlativas.Add(model);
                }

                correlativasLogica.GuardarCorrelatividades(Correlativas);
                ActualizarListas();
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            var tabla = (DataTable)lstCorrelativas.DataSource;

            if(tabla.Rows.Count > 0)
            {
                this.correlativasLogica.EliminarCorrelativas(this.MateriaId);
                this.ActualizarListas();
            }
        }
    }
}
