using System;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Configuraciones
{
    public partial class FormAgregarModificarCicloLectivo : FormBase
    {

        #region Propuedades Públicas
        public int CicloLectivoId { get; set; }
        public TipoAccion Accion { get; set; }
        #endregion
        #region Propiedades Privadas
        private DateTime FechaAlta { get; set; }
        private bool PermiteAgregar { get; set; } = true;
        private bool CicloYaCreado => cicloLectivosLogica.ExisteUnCicloCreado();
        #endregion

        CicloLectivosLogica cicloLectivosLogica;
        MesasFinalesLogica mesasFinalesLogica;
        private int ciclo = 0;
        private int turnoId = 0;
        private int mesasMarzo, mesasJulio, mesasDiciembre;
        private string tagTurno;
        private bool cargarFinal;
        
        public FormAgregarModificarCicloLectivo()
        {
            this.cicloLectivosLogica = new CicloLectivosLogica();
            this.mesasFinalesLogica = new MesasFinalesLogica();
            InitializeComponent();
        }
        
        private void FormAgregarModificarCicloLectivo_Load(object sender, EventArgs e)
        {
            VerificarAltaCicloLectivo();

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormCicloLectivo>();
            });
            
            if (this.Accion == TipoAccion.Modificar)
            {
                this.Contenedor.SetTitulo("Modificar Ciclo Lectivo");
                dtpFechaInicio.Enabled = false;
                dtpFechaCierre.Enabled = false;
                dtpFechaInscripcionInicio.Enabled = false;
                dtpFechaInscripcionFinal.Enabled = false;
                txtCantidadSemana.Enabled = false;
                txtAnioLectivo.Enabled = false;
                

                lblFinFinalDiciembre.Visible = true;
                lblFinFinalJunio.Visible = true;
                lblFinFinalMarzo.Visible = true;
                lblInicioFinalDiciembre.Visible = true;
                lblInicioFinalJunio.Visible = true;
                lblInicioFinalMarzo.Visible = true;
                dtpFechaDiciembreFinal.Visible = true;
                dtpFechaDiciembreInicio1.Visible = true;
                dtpFechaMarzoFinal.Visible = true;
                dtpFechaJunioFinal.Visible = true;
                dtpFechaJunioInicio.Visible = true;
                dtpFechaMarzoInicio.Visible = true;

                txtAnioLectivo.Text = this.CicloLectivoId.ToString();
                CargarDatos(this.CicloLectivoId);
                ExistenMesasFinales(this.CicloLectivoId);
            }
            else
            if (this.Accion == TipoAccion.Agregar)
            {
                this.Contenedor.SetTitulo("Agregar Ciclo Lectivo");
                dtpFechaInicio.Enabled = true;
                dtpFechaCierre.Enabled = true;
                dtpFechaInscripcionInicio.Enabled = true;
                dtpFechaInscripcionFinal.Enabled = true;
                txtCantidadSemana.Enabled = true;
                txtAnioLectivo.Enabled = true;

                grbFinalesMarzo.Visible = false;
                grbFinalesJulio.Visible = false;
                grbFinalesDiciembre.Visible = false;

                ciclo = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo() + 1;
                txtAnioLectivo.Text = ciclo == 1 ? (DateTime.Now.Year + 1).ToString() : ciclo.ToString();
                DateTimePickerEnBlanco();              


            }
               else
                if (this.Accion == TipoAccion.Ver)
            {
                this.Contenedor.SetTitulo("Ver Ciclo Lectivo ");
                dtpFechaInicio.Enabled = true;
                dtpFechaCierre.Enabled = true;
                dtpFechaInscripcionInicio.Enabled = true;
                dtpFechaInscripcionFinal.Enabled = true;
                txtCantidadSemana.Enabled = true;
                txtAnioLectivo.Enabled = false;

                grbFinalesMarzo.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;

                if (CicloLectivoId.ToString()== "0" )
                    CicloLectivoId = (cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo());

                txtAnioLectivo.Text = CicloLectivoId.ToString();
                CargarDatos(Convert.ToInt32(txtAnioLectivo.Text));

            }
        }
        public void DateTimePickerEnBlanco()
        {
            this.SetControlConfig(control => {
                if (control is DateTimePicker dtp)
                {
                    dtp.CustomFormat = " ";
                    dtp.Format = DateTimePickerFormat.Custom;
                }
            });
        }

        private void VerificarAltaCicloLectivo()
        {
            string Mensaje = null;

            if(this.Accion == TipoAccion.Agregar)
            {
                ParametrosModelo parametro = new ParametrosLogica().ObtenerParametro(NombreParametro.NuevoCicloLectivo);
                if (parametro != null)
                {
                    FechaAlta = Convert.ToDateTime(parametro.Valor);
                    PermiteAgregar = (DateTime.Now >= FechaAlta);
                    if (!PermiteAgregar) Mensaje = $"La fecha para dar de alta\nun nuevo ciclo lectivo es\n {FechaAlta.ToString("dd-MMMM-yyyy")} en adelante";
                }

                btnAceptar.Enabled = (!CicloYaCreado && PermiteAgregar);
                if (CicloYaCreado) Mensaje = $"Ya existe un ciclo lectivo\nposterior al actual: 'ciclo {cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo()}'";
            }
            if(Mensaje != null)
                Notificar(TipoNotificacion.Information, Mensaje, Tiempo: 5000);
        }
        private void CargarDatos(int anio)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cicloLectivosLogica.ConsultarUnCicloLectivo(anio);
                dtpFechaInicio.Text = dt.Rows[0]["FechaInicio"].ToString();
                dtpFechaCierre.Text = dt.Rows[0]["FechaCierre"].ToString();
                dtpFechaInscripcionInicio.Text = dt.Rows[0]["FechaInscripcionInicio"].ToString();
                dtpFechaInscripcionFinal.Text = dt.Rows[0]["FechaInscripcionFinal"].ToString();
                txtCantidadSemana.Text = dt.Rows[0]["CantidadSemana"].ToString();

                if ((dt.Rows[0]["FechaMarzoInicio"].ToString()) != ("01/01/1900 0:00:00").ToString())
                {
                    dtpFechaMarzoInicio.Value = Convert.ToDateTime(dt.Rows[0]["FechaMarzoInicio"]);
                    dtpFechaMarzoInicio.CustomFormat = "dd/MM/yyyy";
                    dtpFechaMarzoInicio.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaMarzoInicio.CustomFormat = " ";
                    dtpFechaMarzoInicio.Format = DateTimePickerFormat.Custom;
                }
                if ((dt.Rows[0]["FechaMarzoFinal"].ToString()) != ("01/01/1900 0:00:00").ToString()) 
                {
                    dtpFechaMarzoFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaMarzoFinal"]);
                    dtpFechaMarzoFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaMarzoFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaMarzoFinal.CustomFormat = " ";
                    dtpFechaMarzoFinal.Format = DateTimePickerFormat.Custom;
                }
                if ((dt.Rows[0]["FechaJunioInicio"].ToString()) != ("01/01/1900 0:00:00").ToString())
                {
                    dtpFechaJunioInicio.Value = Convert.ToDateTime(dt.Rows[0]["FechaJunioInicio"]);
                    dtpFechaJunioInicio.CustomFormat = "dd/MM/yyyy";
                    dtpFechaJunioInicio.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaJunioInicio.CustomFormat = " ";
                    dtpFechaJunioInicio.Format = DateTimePickerFormat.Custom;
                }
                if ((dt.Rows[0]["FechaJunioFinal"].ToString()) != ("01/01/1900 0:00:00").ToString())
                {
                    dtpFechaJunioFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaJunioFinal"]);
                    dtpFechaJunioFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaJunioFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaJunioFinal.CustomFormat = " ";
                    dtpFechaJunioFinal.Format = DateTimePickerFormat.Custom;
                }
                if ((dt.Rows[0]["FechaDiciembreInicio"].ToString()) != ("01/01/1900 0:00:00").ToString())
                {
                    dtpFechaDiciembreInicio1.Value = Convert.ToDateTime(dt.Rows[0]["FechaDiciembreInicio"]);
                    dtpFechaDiciembreInicio1.CustomFormat = "dd/MM/yyyy";
                    dtpFechaDiciembreInicio1.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaDiciembreInicio1.CustomFormat = " ";
                    dtpFechaDiciembreInicio1.Format = DateTimePickerFormat.Custom;
                }
                if ((dt.Rows[0]["FechaDiciembreFinal"].ToString()) != ("01/01/1900 0:00:00").ToString())
                {
                    dtpFechaDiciembreFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaDiciembreFinal"]);
                    dtpFechaDiciembreFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaDiciembreFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaDiciembreFinal.CustomFormat = " ";
                    dtpFechaDiciembreFinal.Format = DateTimePickerFormat.Custom;
                }
            }
            catch { }

        }
        public bool ValidarFechasAperturaCicloLectivo()
        {
            bool OK = false;
           if (dtpFechaInicio.Value.Year >= DateTime.Today.Year && Convert.ToInt32(txtAnioLectivo.Text) > Convert.ToInt32(DateTime.Today.Year) && Convert.ToInt32(txtCantidadSemana.Text) > 0)
            {
                OK = true;
            }
            return OK;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            CicloLectivo.FechaDiciembreInicio = dtpFechaDiciembreInicio1.Value;
                DialogResult dr;
            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Agregar)
                {
                    
                    dr = MessageBox.Show("Generación de Cursos Lectivos" + txtAnioLectivo.Text, "Ciclo Lectivo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        cicloLectivosLogica.AgregarCicloLectivo(CicloLectivo);
                        Notificar(TipoNotificacion.Success, "Ciclo lectivo agregado con exito");
                        txtAnioLectivo.Text = "";
                        txtCantidadSemana.Text = "";
                        DateTimePickerEnBlanco();
                        ciclo = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo() + 1;
                        txtAnioLectivo.Text = ciclo == 1 ? (DateTime.Now.Year + 1).ToString() : ciclo.ToString();
                    }
                }
                else
                {
                    if (this.Accion == TipoAccion.Modificar)
                    {
                        dr = MessageBox.Show("¿Desea cargar las fechas de inscripción a finales?", "Inscripción a finales", MessageBoxButtons.YesNo);
                        if ((dtpFechaMarzoInicio.CustomFormat != " ") && (dtpFechaMarzoFinal.CustomFormat != null) && (dtpFechaJunioInicio.CustomFormat != null) && (dtpFechaDiciembreInicio1.CustomFormat != null) && (dtpFechaJunioFinal.CustomFormat != " ") && (dtpFechaDiciembreFinal.CustomFormat != null) && (txtCantidadSemana.Text != "0"))
                        {
                            if (turnoId == 1)
                                cicloLectivosLogica.AgregarFechaFinalesMarzo(CicloLectivo);
                            if (turnoId == 2)
                                cicloLectivosLogica.AgregarFechaFinalesJulio(CicloLectivo);
                            if (turnoId == 3)
                                cicloLectivosLogica.AgregarFechaFinalesDiciembre(CicloLectivo);
                            if (cargarFinal)
                            {
                                var resultMesas = this.mesasFinalesLogica.CargarMesasFinales(this.CicloLectivoId, turnoId);
                                if (resultMesas > 0)
                                    Notificar(TipoNotificacion.Success, $"Mesas finales generadas con éxito para {tagTurno}, {CicloLectivoId}.", Tiempo: 3000);
                                else
                                    Notificar(TipoNotificacion.Error, $"Ya hay mesas para {tagTurno}, {CicloLectivoId}", Tiempo: 3000);
                            }
                            CargarDatos(Convert.ToInt32(txtAnioLectivo.Text));
                        }
                        else
                        {
                            Notificar(TipoNotificacion.Information, "Verifique que todos los campos\nde finales esten completos");
                        }
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }
        }
        private void dtpInicioFinalJunio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaJunioInicio.Value != dtpFechaJunioInicio.MinDate)
                dtpFechaJunioInicio.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaDiciembreInicio1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDiciembreInicio1.Value != dtpFechaDiciembreInicio1.MinDate)
                dtpFechaDiciembreInicio1.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaJunioFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaJunioFinal.Value != dtpFechaJunioFinal.MinDate)
                dtpFechaJunioFinal.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaDiciembreFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDiciembreFinal.Value != dtpFechaDiciembreFinal.MinDate)
                dtpFechaDiciembreFinal.CustomFormat = "dd/MM/yyyy";
        }


        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value != dtpFechaInicio.MinDate)
                dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaCierre.Value != dtpFechaCierre.MinDate)
                dtpFechaCierre.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaInscripcionInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionInicio.Value != dtpFechaInscripcionInicio.MinDate)
                dtpFechaInscripcionInicio.CustomFormat = "dd/MM/yyyy";

        }

        private void dtpFechaInscripcionFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionFinal.Value != dtpFechaInscripcionFinal.MinDate)
                dtpFechaInscripcionFinal.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaMarzoInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaMarzoInicio.Value != dtpFechaMarzoInicio.MinDate)
                dtpFechaMarzoInicio.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaMarzoFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaMarzoFinal.Value != dtpFechaMarzoFinal.MinDate)
                dtpFechaMarzoFinal.CustomFormat = "dd/MM/yyyy";
        }

        private void ExistenMesasFinales(int cicloLectivo)
        {
            DataTable dt = mesasFinalesLogica.ExistenMesasFinales(cicloLectivo);
            mesasMarzo = Convert.ToInt32(dt.Rows[0]["Marzo"]);
            mesasJulio = Convert.ToInt32(dt.Rows[0]["Julio"]);
            mesasDiciembre = Convert.ToInt32(dt.Rows[0]["Diciembre"]);
            if (mesasMarzo == 0 && mesasJulio == 0 && mesasDiciembre == 0)
            {
                turnoId = 1;
                cargarFinal = true;
                tagTurno = "Marzo";
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;

            }
            else if (mesasMarzo == 1 && mesasJulio == 0 && mesasDiciembre == 0)
            {
                turnoId = 2;
                cargarFinal = true;
                tagTurno = "Julio";
                grbFinalesMarzo.Enabled = false;
                grbFinalesDiciembre .Enabled = false;
            }
            else if (mesasMarzo == 1 && mesasJulio == 1 && mesasDiciembre == 0)
            {
                turnoId = 3;
                cargarFinal = true;
                tagTurno = "Diciembre";
                grbFinalesMarzo.Enabled = false;
                grbFinalesJulio.Enabled = false;
            }
            else
            {
                grbFinalesMarzo.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;
                btnAceptar.Enabled = false;
                cargarFinal = false;
            }
        }
    }
}
