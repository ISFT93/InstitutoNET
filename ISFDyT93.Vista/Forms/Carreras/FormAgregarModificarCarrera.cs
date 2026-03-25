using System;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAgregarModificarCarrera : FormBase
    {
        #region Propiedades Publicas
        public TipoAccion Accion { get; set; }
        public int CarreraId { get; set; }
        #endregion

        #region Propiedades Privadas
        private CarrerasLogica CarrerasLogica { get; set; }
        private MateriasLogica MateriasLogica { get; set; }

        private CarrerasModelo Modelo { get; set; }
        #endregion

        public FormAgregarModificarCarrera()
        {
            this.CarrerasLogica = new CarrerasLogica();
            this.MateriasLogica = new MateriasLogica();

            InitializeComponent();
        }

        private void FormAgregarModificarCarrera_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormCarreras>();
            });

            if (this.Accion == TipoAccion.Agregar)
            {
                this.Contenedor.SetTitulo("Agregar Carrera");

                nudAnioInicio.Value = DateTime.Now.Year;
                nudAnioFin.Enabled = false;
            }

            if (this.Accion == TipoAccion.Modificar || this.Accion == TipoAccion.Ver || this.Accion == TipoAccion.Desactivar)
            {
                if (this.CarreraId > 0)
                {
                    this.Modelo = CarrerasLogica.ObtenerCarrera(this.CarreraId);

                    this.MapToForm<CarrerasModelo>(Modelo);

                    //Controlo que el campo duracion no se pueda modificar
                    var existe = MateriasLogica.MateriaAsignada(this.CarreraId);

                    //Solo para cambiar el titulo
                    this.Contenedor.SetTitulo($"Modificar Carrera { Modelo.DescripcionCorta }");

                    if (this.Modelo.CarreraEstadoId == 3)
                    {
                        nudAnioFin.Enabled = false;
                    }

                    this.txtCantidadHoras.Text = this.Modelo.CantidadHoras.ToString();

                    if (existe > 0) //si hay id que concida en la bd
                    {
                        txtCantidadHoras.Enabled = false;
                        Modelo.PoseeMaterias = true;
                    }
                    else //si no hay id que coincida en la bd
                    {
                        txtCantidadHoras.Enabled = true;
                    }

                    this.txtDuracion.Text = this.Modelo.Duracion.ToString();

                    if (existe > 0) //si hay id que concida en la bd
                    {
                        txtDuracion.Enabled = false;
                        Modelo.PoseeMaterias = true;
                    }
                    else //si no hay id que coincida en la bd
                    {
                        txtDuracion.Enabled = true;
                    }
                }

                if (this.Accion == TipoAccion.Ver)
                {
                    this.Contenedor.SetTitulo($"Carrera  { Modelo.DescripcionCorta }");
                    this.DeshabilitarControles();
                    btnGuardar.Visible = false;
                }

                if (this.Accion == TipoAccion.Desactivar || this.Accion == TipoAccion.Modificar)
                {
                    if (this.Accion == TipoAccion.Desactivar)
                    {
                        this.DeshabilitarControles();
                    }
                }
            }

            if (this.Accion == TipoAccion.Desactivar)
            {
                this.nudAnioFin.Value = DateTime.Now.Year;
            }
        }

       

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtTitulo.Text = "";
            txtDescripcionCorta.Text = "";
            txtJefeCatedra.Text = "";
            txtPlanEstudio.Text = "";
            txtResolucion.Text = "";
            txtCorrelatividades.Text = "";
            txtImagenDescriptiva.Text = "";
            txtNumeroExpediente.Text = "";
            txtCantidadHoras.Text = "";
            txtDuracion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var carrera = this.MapToModel<CarrerasModelo>();

            if (carrera.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Desactivar)
                {
                    //Control año para desactivar
                    int AnioActual = Convert.ToInt32(DateTime.Today.Year);
                    //Si el form se abre desde la seleccion modificar en el menu
                    //Modificar a la base de datos
                    if (this.nudAnioFin.Value >= AnioActual)
                    {
                        DialogResult result = MessageBox.Show("Esta por desactivar la carrera '" + txtDescripcionCorta.Text + "', ¿Esta seguro?", "Confirmar desactivacion", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == result)
                        {
                            CarrerasLogica.GuardarCarrera(carrera, TipoAccion.Modificar);

                            Notificar(TipoNotificacion.Success, "Carrera desactivada");
                                Contenedor.AbrirFormulario<FormCarreras>();                            
                        }
                    }
                    else
                    {
                        Notificar(TipoNotificacion.Warning, "No se pudo desactivar\n" +
                            "el año debe ser mayor o igual al año actual");
                    }
                }
                else
                {
                    if (CarrerasLogica.GuardarCarrera(carrera, this.Accion))
                    {
                        Notificar(TipoNotificacion.Success, "Carrera guardada correctamente");

                        Contenedor.AbrirFormulario<FormCarreras>();
                    }
                    else
                    {
                        Notificar(TipoNotificacion.Error, "No se ha podido guardar la carrera");                       
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvCarreras, carrera.Errores);
            }
        }

        private void btnCorrelatividades_Click(object sender, EventArgs e)
        {
            ofdCarreras.Filter = "Archivos PDF|*.pdf";

            if (ofdCarreras.ShowDialog() == DialogResult.OK)
            {
                txtCorrelatividades.Text = ofdCarreras.FileName;
            }
        }

        private void btnResolucion_Click(object sender, EventArgs e)
        {
            ofdCarreras.Filter = "Archivos PDF|*.pdf";

            if (ofdCarreras.ShowDialog() == DialogResult.OK)
            {
                txtResolucion.Text = ofdCarreras.FileName;
            }
        }

        private void btnPlanEstudio_Click(object sender, EventArgs e)
        {
            ofdCarreras.Filter = "Archivos PDF|*.pdf";

            if (ofdCarreras.ShowDialog() == DialogResult.OK)
            {
                txtPlanEstudio.Text = ofdCarreras.FileName;
            }
        }


        private void btnImagenDescriptiva_Click(object sender, EventArgs e)
        {
            ofdCarreras.Filter = "Archivos PNG|*.png|Archivos JPG|*.jpg";

            if (ofdCarreras.ShowDialog() == DialogResult.OK)
            {
                txtImagenDescriptiva.Text = ofdCarreras.FileName;
            }
        }
    }
}