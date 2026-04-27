using System;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.Core;
using System.Linq;
using System.Data;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAgregarModificarMateria : FormBase
    {
        #region Propiedades Públicas
        public int AnioCarreraId { get; set; }
        public int MateriaId { get; set; }
        public TipoAccion Accion { get; set; }
        #endregion

        #region Propiedades Privadas
        private MateriasModelo materia { get; set; }
        private AniosCarrerasModelo anioCarrera { get; set; }
        private MateriasLogica materiasLogica { get; set; }
        private AniosCarreraLogica aniosLogica { get; set; }
        private AutoCompleteStringCollection NombreAutoComplete { get; set; }
        #endregion

        public FormAgregarModificarMateria()
        {
            this.materiasLogica = new MateriasLogica();
            this.aniosLogica = new AniosCarreraLogica();

            InitializeComponent();
        }

        private void txtCargaHoraria_TextChanged(object sender, EventArgs e)
        {
            if (txtCargaHoraria.Text == "" || txtCargaHoraria.Text == null)
            {
                txtModulos.Text = 0.ToString();
            }
            else
            {
                try
                {
                    int CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);

                    if (CargaHoraria % 32 == 0)
                    {
                        txtModulos.Text = (CargaHoraria / 32).ToString();
                    }
                    else
                    {
                        txtModulos.Text = 0.ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
                
        }

        private void FormAgregarModificarMateria_Load(object sender, EventArgs e)
        {
            this.anioCarrera = this.aniosLogica.ObtenerAnioCarrera(this.AnioCarreraId);

            //Cargo el combo de Espacios
            cmbEspacioId.DataSource = materiasLogica.ObtnenerEspacios();
            cmbEspacioId.ValueMember = "EspacioId";
            cmbEspacioId.DisplayMember = "Descripcion";

            this.Contenedor.SetVolver(() => {
                Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form => {
                    form.AnioCarreraId = this.AnioCarreraId;
                });
            });

            if (this.Accion == TipoAccion.Agregar)
            {
                this.Contenedor.SetTitulo($"Agregar Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                this.ActualizarAutoComplete();
            }

            if (this.Accion == TipoAccion.Modificar || this.Accion == TipoAccion.Ver)
            {
                if (this.MateriaId > 0)
                {
                    this.materia = materiasLogica.ObtenerMateria(this.MateriaId);

                    this.MapToForm<MateriasModelo>(this.materia);
                }

                if (this.Accion == TipoAccion.Ver)
                {
                    this.DeshabilitarControles();

                    this.Contenedor.SetTitulo($"Detalle Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                }
                else
                {
                    this.Contenedor.SetTitulo($"Modificar Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.materia = this.MapToModel<MateriasModelo>(this.materia);

            //Validacion para descripcion
            if (this.materia.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Agregar)
                {
                    this.materia.Activo = true;
                    this.materia.AnioCarreraId = this.AnioCarreraId;

                    //Alta a la base de datos
                    int estado = materiasLogica.AgregarMaterias(this.materia);

                    if (estado != -1)
                    {
                        //Refrescar grilla
                        FormNotificacion.Mensaje(TipoNotificacion.Success , "Carga exitosa");

                            this.LimpiarControlles();

                            this.txtNombre.AutoCompleteCustomSource.Add(this.materia.Nombre);

                            txtNombre.Focus();

                            this.ActualizarAutoComplete();                        
                    }
                }
                if (this.Accion == TipoAccion.Modificar || this.Accion == TipoAccion.Ver)
                {
                    //Alta a la base de datos
                    int resultado = materiasLogica.ModificarMateria(this.materia);

                    if (resultado != -1)
                    {
                        if (this.Accion == TipoAccion.Modificar)
                        {
                            FormNotificacion.Mensaje(TipoNotificacion.Success, "Modificada correctamente");
                        }

                        Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form => {
                            form.AnioCarreraId = this.AnioCarreraId;
                        });
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvMaterias, this.materia.Errores);
            }
        }

        private void ActualizarAutoComplete()
        {
            var materias = materiasLogica.ObtenerNombresMaterias();
            var listaMaterias = materias.Rows.Cast<DataRow>().Select(r => r.Field<String>("Nombre")).ToArray();

            txtNombre.AutoCompleteCustomSource.AddRange(listaMaterias);
        }
    }
}

