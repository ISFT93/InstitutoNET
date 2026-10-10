using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
        private CarrerasLogica carrerasLogica { get; set; } // <--- AGREGO ESTA LÍNEA PARA LA LÓGICA DE CARRERAS
        private AutoCompleteStringCollection NombreAutoComplete { get; set; }

        // Guarda el último espacio elegido para recordarlo en la siguiente materia
        private static int ultimoEspacioIdSeleccionado = 1; 

        #endregion

        #region Funciones
        private void MostrarMaterias()
        {
            this.anioCarrera = this.aniosLogica.ObtenerAnioCarrera(this.AnioCarreraId);

            //Cargo el combo de Espacios
            cmbEspacioId.DataSource = materiasLogica.ObtnenerEspacios();
            cmbEspacioId.ValueMember = "EspacioId";
            cmbEspacioId.DisplayMember = "Descripcion";

            this.Contenedor.SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form =>
                {
                    form.AnioCarreraId = this.AnioCarreraId;
                });
            });

            switch (this.Accion)
            {
                case TipoAccion.Agregar:
                    this.Contenedor.SetTitulo($"Agregar Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                    this.ActualizarAutoComplete();
                    break;
                case TipoAccion.Modificar:
                    this.ComprobarMateriasId();
                    this.Contenedor.SetTitulo($"Modificar Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                    break;
                case TipoAccion.Ver:
                    this.ComprobarMateriasId();
                    this.DeshabilitarControles();
                    this.Contenedor.SetTitulo($"Detalle Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");
                    break;

            }
        }

        private void ComprobarMateriasId()
        {
            if (this.MateriaId > 0)
            {
                this.materia = materiasLogica.ObtenerMateria(this.MateriaId);
                this.MapToForm<MateriasModelo>(this.materia);
            }
        }
        #endregion
        
        public FormAgregarModificarMateria()
        {
            this.materiasLogica = new MateriasLogica();
            this.aniosLogica = new AniosCarreraLogica();
            this.carrerasLogica = new CarrerasLogica(); // <--- AGREGO ESTA LÍNEA PARA INICIALIZAR LA LÓGICA DE CARRERAS

            InitializeComponent();
        }

        private void txtCargaHoraria_TextChanged(object sender, EventArgs e)
        {
            //if (txtCargaHoraria.Text == "" || txtCargaHoraria.Text == null)
            if (string.IsNullOrEmpty(txtCargaHoraria.Text)) // Se utiliza string.IsNullOrEmpty para verificar si el texto está vacío o nulo
            {
                txtModulos.Text = 0.ToString();
            }
            else
            {
                //    try
                //    {
                //        int CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);

                //        if (CargaHoraria % 32 == 0)
                //        {
                //            txtModulos.Text = (CargaHoraria / 32).ToString();
                //        }
                //        else
                //        {
                //            txtModulos.Text = 0.ToString();
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}

                try
                {
                    int cargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);

                    int modulos = materiasLogica.CalcularModulos(cargaHoraria);

                    txtModulos.Text = modulos.ToString();
                }
                catch
                {
                    txtModulos.Text = "0";
                }
            }

        }

        private void FormAgregarModificarMateria_Load(object sender, EventArgs e)
        {
            this.anioCarrera = this.aniosLogica.ObtenerAnioCarrera(this.AnioCarreraId);

            // 1. Carga de combos principales
            cmbEspacioId.DataSource = materiasLogica.ObtnenerEspacios();
            cmbEspacioId.ValueMember = "EspacioId";
            cmbEspacioId.DisplayMember = "Descripcion";

            cmbRegimen.DataSource = carrerasLogica.ObtenerRegimenes();
            cmbRegimen.ValueMember = "RegimenId";
            cmbRegimen.DisplayMember = "Nombre";

            // 2. Obtenemos la información de la carrera una sola vez (Buenas prácticas: evitar consultas duplicadas)
            int carreraId = aniosLogica.ObtenerIdCarrera(this.AnioCarreraId);
            var carreraModelo = carrerasLogica.ObtenerCarrera(carreraId);
            int regimenCarreraId = (carreraModelo != null) ? carreraModelo.RegimenId : 0;

            // 3. Carga inicial del combo Final / Promoción
            cmbFinalPromocion.Items.Add("F");
            cmbFinalPromocion.Items.Add("P");
            cmbFinalPromocion.SelectedItem = "F";

            this.Contenedor.SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form =>
                {
                    form.AnioCarreraId = this.AnioCarreraId;
                });
            });

            // 4. Lógica según la acción del formulario
            if (this.Accion == TipoAccion.Agregar)
            {
                this.Contenedor.SetTitulo($"Agregar Materia - {this.anioCarrera.AnioCarrera}° {this.anioCarrera.NombreCarrera}");

                cmbEspacioId.SelectedValue = ultimoEspacioIdSeleccionado;

                // Por defecto en Alta, asigna el régimen heredado de la carrera
                if (regimenCarreraId > 0)
                {
                    cmbRegimen.SelectedValue = regimenCarreraId;
                }

                this.ActualizarAutoComplete();
            }
            else if (this.Accion == TipoAccion.Modificar || this.Accion == TipoAccion.Ver)
            {
                if (this.MateriaId > 0)
                {
                    this.materia = materiasLogica.ObtenerMateria(this.MateriaId);
                    this.MapToForm<MateriasModelo>(this.materia);

                    // Si la materia tiene un régimen específico lo usa; caso contrario, usa el de la carrera
                    if (this.materia != null && this.materia.RegimenId > 0)
                    {
                        cmbRegimen.SelectedValue = this.materia.RegimenId;
                    }
                    else if (regimenCarreraId > 0)
                    {
                        cmbRegimen.SelectedValue = regimenCarreraId;
                    }
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

            // 5. Regla de negocio: El régimen siempre se muestra preseleccionado y bloqueado
            cmbRegimen.Enabled = false;
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
                    this.materia.CarreraId = aniosLogica.ObtenerIdCarrera(this.AnioCarreraId); //Obtiene el id de la carrera para insertarlo en la nueva columna de CarreraId de la tabla Materias
                    this.materia.MateriasCodigoBloque = materiasLogica.CreaMateriaCodigoBloque(this.AnioCarreraId);

                    //Guardamos el último espacio seleccionado en la variable estática
                    if (cmbEspacioId.SelectedValue != null)
                    {
                        ultimoEspacioIdSeleccionado = Convert.ToInt32(cmbEspacioId.SelectedValue);
                    }

                    //Alta a la base de datos
                    int estado = materiasLogica.AgregarMaterias(this.materia);

                    if (estado != -1)
                    {
                        //Refrescar grilla
                        FormNotificacion.Mensaje(TipoNotificacion.Success, "Carga exitosa");

                        this.LimpiarControlles();

                        // Reasignamos el último espacio guardado para que permanezca seleccionado
                        cmbEspacioId.SelectedValue = ultimoEspacioIdSeleccionado;

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

                        Contenedor.AbrirFormulario<FormMateriasAnioCarrera>(form =>
                        {
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
            //var materias = materiasLogica.ObtenerNombresMaterias();
            //var listaMaterias = materias.Rows.Cast<DataRow>().Select(r => r.Field<String>("Nombre")).ToArray();

            //txtNombre.AutoCompleteCustomSource.AddRange(listaMaterias);

            var listaMaterias = materiasLogica.ObtenerNombresMateriasLista();

            txtNombre.AutoCompleteCustomSource.AddRange(listaMaterias);
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Elimina saltos de linea invisibles y espacios al principio y final del texto.
            string limpio = LimpiarTexto.QuitarSaltosDeLineaYEspacios(txtNombre.Text);
            txtNombre.Text = limpio;
        }

        private void cmbRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

