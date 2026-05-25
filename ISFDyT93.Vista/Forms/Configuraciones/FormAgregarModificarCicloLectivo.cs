using System;
using ISFDyT93.Negocio.Logica;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Forms.Personal;

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
                dtpFechaInicio.Enabled = true;
                dtpFechaCierre.Enabled = true;
                dtpFechaInscripcionInicio.Enabled = true;
                dtpFechaInscripcionFinal.Enabled = true;
                txtCantidadSemana.Enabled = true;
                txtAnioLectivo.Enabled = false;
                txtCantidadSemana.Enabled = false;

                grbInscripcionSuperiores.Visible = true;
                grbInscripcionSuperiores.Enabled = true;


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
                btnGeneraCicloLectivo.Visible = false;
                dtpFechaCierre.Enabled = false;
                dtpFechaInicio.Enabled = false;
                dtpFechaInscripcionInicio.Enabled = false;
                dtpFechaInscripcionFinal.Enabled = false;
                btnAceptar.Visible = false;

                // Habilitamos todos los dtp por defecto, ExistenMesasFinales los deshabilita según corresponda
                dtpFechaInscripcionSuperioresInicio.Enabled = true;
                dtpFechaInscripcionSuperioresFinal.Enabled = true;
                dtpFechaJunioInicio.Enabled = true;
                dtpFechaJunioFinal.Enabled = true;
                dtpFechaDiciembreInicio1.Enabled = true;
                dtpFechaDiciembreFinal.Enabled = true;
                dtpFechaMarzoInicio.Enabled = true;
                dtpFechaMarzoFinal.Enabled = true;
                // btnFechaCierreCicloLectivo.Enabled = DateTime.Today >= dtpFechaCierre.Value.Date;
                btnGeneraCicloLectivo.Enabled = false;
                grbDatosCicloLectivo.Size = new System.Drawing.Size(760, 265);
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
                    txtAnioLectivo.Enabled = false;
                    txtCantidadSemana.Enabled = false;

                    grbFinalesMarzo.Visible = false;
                    grbFinalesJulio.Visible = false;
                    grbFinalesDiciembre.Visible = false;
                    grbInscripcionSuperiores.Visible = false;
                    btnAceptar.Visible = false;
                    btnFechaCierreCicloLectivo.Visible = false;
                    btnGeneraCicloLectivo.Enabled = false;
                    ciclo = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo() + 1;
                    txtAnioLectivo.Text = ciclo == 1 ? (DateTime.Now.Year + 1).ToString() : ciclo.ToString();
                    DateTimePickerEnBlanco();


                }
                else
                    if (this.Accion == TipoAccion.Ver)
                    {
                        this.Contenedor.SetTitulo("Ver Ciclo Lectivo ");
                        dtpFechaInicio.Enabled = false;
                        dtpFechaCierre.Enabled = false;
                        dtpFechaInscripcionInicio.Enabled = false;
                        dtpFechaInscripcionFinal.Enabled = false;
                        dtpFechaMarzoInicio.Enabled = false;
                        dtpFechaMarzoFinal.Enabled = false;
                        dtpFechaJunioInicio.Enabled = false;
                        dtpFechaJunioFinal.Enabled = false;
                        dtpFechaDiciembreInicio1.Enabled = false;
                        dtpFechaDiciembreFinal.Enabled = false;
                        dtpFechaInscripcionSuperioresInicio.Enabled = false;
                        dtpFechaInscripcionSuperioresFinal.Enabled = false;
                        txtCantidadSemana.Enabled = false;
                        txtAnioLectivo.Enabled = false;

                        grbFinalesMarzo.Enabled = true;
                        grbFinalesJulio.Enabled = true;
                        grbFinalesDiciembre.Enabled = true;
                        grbInscripcionSuperiores.Enabled = true;

                        BtnAgregarFinalMarzo.Visible = false;
                        BtnAgregarFinalJulio.Visible = false;
                        BtnAgregarFinalDiciembre.Visible = false;
                        BtnAgregarCursoSuperioresMarzo.Visible = false;
                        btnAceptar.Visible = false;
                        btnFechaCierreCicloLectivo.Visible = false;
                        btnGeneraCicloLectivo.Visible = false;


                        if (CicloLectivoId.ToString() == "0")
                            CicloLectivoId = (cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo());

                        txtAnioLectivo.Text = CicloLectivoId.ToString();
                        CargarDatos(Convert.ToInt32(txtAnioLectivo.Text));

                    }
        }
        public void DateTimePickerEnBlanco()
        {
            this.SetControlConfig(control =>
            {
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

            if (this.Accion == TipoAccion.Agregar)
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
            if (Mensaje != null)
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

                if (dt.Rows[0]["FechaMarzoInicio"] != DBNull.Value)
                {
                    dtpFechaMarzoInicio.Value = Convert.ToDateTime(dt.Rows[0]["FechaMarzoInicio"]);
                    dtpFechaMarzoInicio.CustomFormat = "dd/MM/yyyy";
                    dtpFechaMarzoInicio.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaMarzoInicio.Value = new DateTime(DateTime.Today.Year, 3, 1); //Sirve para que el DateTimePicker abra la fecha en el mes de marzo, aunque no se muestre la fecha hasta que el usuario seleccione una.
                    dtpFechaMarzoInicio.CustomFormat = " ";
                    dtpFechaMarzoInicio.Format = DateTimePickerFormat.Custom;
                }
                if (dt.Rows[0]["FechaMarzoFinal"] != DBNull.Value)
                {
                    dtpFechaMarzoFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaMarzoFinal"]);
                    dtpFechaMarzoFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaMarzoFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaMarzoFinal.Value = new DateTime(DateTime.Today.Year, 3, 1);
                    dtpFechaMarzoFinal.CustomFormat = " ";
                    dtpFechaMarzoFinal.Format = DateTimePickerFormat.Custom;
                }

                if (dt.Columns.Contains("FechaInscripcionSuperioresInicio") && dt.Rows[0]["FechaInscripcionSuperioresInicio"] != DBNull.Value)
                {
                    dtpFechaInscripcionSuperioresInicio.Value = Convert.ToDateTime(dt.Rows[0]["FechaInscripcionSuperioresInicio"]);
                    dtpFechaInscripcionSuperioresInicio.CustomFormat = "dd/MM/yyyy";
                    dtpFechaInscripcionSuperioresInicio.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    // Abre en el mes de abril ya que va después de Marzo
                    dtpFechaInscripcionSuperioresInicio.Value = new DateTime(DateTime.Today.Year, 4, 1);
                    dtpFechaInscripcionSuperioresInicio.CustomFormat = " ";
                    dtpFechaInscripcionSuperioresInicio.Format = DateTimePickerFormat.Custom;
                }

                if (dt.Columns.Contains("FechaInscripcionSuperioresFinal") && dt.Rows[0]["FechaInscripcionSuperioresFinal"] != DBNull.Value)
                {
                    dtpFechaInscripcionSuperioresFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaInscripcionSuperioresFinal"]);
                    dtpFechaInscripcionSuperioresFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaInscripcionSuperioresFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaInscripcionSuperioresFinal.Value = new DateTime(DateTime.Today.Year, 4, 1);
                    dtpFechaInscripcionSuperioresFinal.CustomFormat = " ";
                    dtpFechaInscripcionSuperioresFinal.Format = DateTimePickerFormat.Custom;
                }

                if (dt.Rows[0]["FechaJunioInicio"] != DBNull.Value)
                {
                    dtpFechaJunioInicio.Value = Convert.ToDateTime(dt.Rows[0]["FechaJunioInicio"]);
                    dtpFechaJunioInicio.CustomFormat = "dd/MM/yyyy";
                    dtpFechaJunioInicio.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaJunioInicio.Value = new DateTime(DateTime.Today.Year, 7, 1);
                    dtpFechaJunioInicio.CustomFormat = " ";
                    dtpFechaJunioInicio.Format = DateTimePickerFormat.Custom;
                }
                if (dt.Rows[0]["FechaJunioFinal"] != DBNull.Value)
                {
                    dtpFechaJunioFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaJunioFinal"]);
                    dtpFechaJunioFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaJunioFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaJunioFinal.Value = new DateTime(DateTime.Today.Year, 7, 1);
                    dtpFechaJunioFinal.CustomFormat = " ";
                    dtpFechaJunioFinal.Format = DateTimePickerFormat.Custom;
                }
                if (dt.Rows[0]["FechaDiciembreInicio"] != DBNull.Value)
                {
                    dtpFechaDiciembreInicio1.Value = Convert.ToDateTime(dt.Rows[0]["FechaDiciembreInicio"]);
                    dtpFechaDiciembreInicio1.CustomFormat = "dd/MM/yyyy";
                    dtpFechaDiciembreInicio1.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaDiciembreInicio1.Value = new DateTime(DateTime.Today.Year, 12, 1);
                    dtpFechaDiciembreInicio1.CustomFormat = " ";
                    dtpFechaDiciembreInicio1.Format = DateTimePickerFormat.Custom;
                }
                if (dt.Rows[0]["FechaDiciembreFinal"] != DBNull.Value)
                {
                    dtpFechaDiciembreFinal.Value = Convert.ToDateTime(dt.Rows[0]["FechaDiciembreFinal"]);
                    dtpFechaDiciembreFinal.CustomFormat = "dd/MM/yyyy";
                    dtpFechaDiciembreFinal.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dtpFechaDiciembreFinal.Value = new DateTime(DateTime.Today.Year, 12, 1);
                    dtpFechaDiciembreFinal.CustomFormat = " ";
                    dtpFechaDiciembreFinal.Format = DateTimePickerFormat.Custom;
                }
            }
            catch { }

        }
        public bool ValidarFechasAperturaCicloLectivo()
        {
            bool OK = false;
            if (dtpFechaInicio.Value.Year >= DateTime.Today.Year && Convert.ToInt32(txtAnioLectivo.Text) > Convert.ToInt32(DateTime.Today.Year) && Convert.ToInt32(txtCantidadSemana.Text) > 0 && dtpFechaInicio.Value.Year == Convert.ToInt32(txtAnioLectivo.Text))
            {
                OK = true;
            }
            return OK;
        }
        private bool ValidarAnioFechas()
        {
            if (!int.TryParse(txtAnioLectivo.Text, out int anio)) return false;

            var fechas = new (DateTimePicker dtp, string nombre, int anioEsperado, string mensaje)[]
            {
                (dtpFechaInicio,                      "Fecha Inicio",                      anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaCierre,                      "Fecha Cierre",                      anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaInscripcionInicio,           "Fecha Pre-Inscripción Inicio",          anio - 1, $"el año de la fecha para la pre-inscripción al ciclo lectivo debe ser {anio - 1}"),
                (dtpFechaInscripcionFinal,            "Fecha Pre-Inscripción Final",           anio - 1, $"el año de la fecha para la pre-inscripción al ciclo lectivo debe ser {anio - 1}"),
                (dtpFechaMarzoInicio,                 "Finales Marzo - Inicio",            anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaMarzoFinal,                  "Finales Marzo - Final",             anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaJunioInicio,                 "Finales Julio - Inicio",            anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaJunioFinal,                  "Finales Julio - Final",             anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaDiciembreInicio1,            "Finales Diciembre - Inicio",        anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaDiciembreFinal,              "Finales Diciembre - Final",         anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaInscripcionSuperioresInicio, "Inscripción Superiores - Inicio",   anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
                (dtpFechaInscripcionSuperioresFinal,  "Inscripción Superiores - Final",    anio,     $"el año de la fecha no coincide con el ciclo lectivo {anio}"),
            };

            foreach (var (dtp, nombre, anioEsperado, mensaje) in fechas)
            {
                if (dtp.CustomFormat != "dd/MM/yyyy") continue;
                if (dtp.Value.Year != anioEsperado)
                {
                    Notificar(TipoNotificacion.Information, $"{nombre}: {mensaje}");
                    return false;
                }
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarAnioFechas()) return;

            // Deshabilitamos temporalmente los grupos que no corresponden al turno actual
            // para que MapToModel no los valide
            if (turnoId == 0)
            {
                grbFinalesMarzo.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;
            }
            // Deshabilitamos temporalmente los grupos que no corresponden al turno actual
            // para que MapToModel no los valide
            if (turnoId == 1)
            {
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;
            }
            else if (turnoId == 2)
            {
                grbFinalesDiciembre.Enabled = false;
            }

            // Si Superiores está vacío, igualamos para que MayorQue no falle
            if (dtpFechaInscripcionSuperioresInicio.CustomFormat == " ")
            {
                dtpFechaInscripcionSuperioresInicio.Value = DateTime.Today;
                dtpFechaInscripcionSuperioresFinal.Value = DateTime.Today.AddDays(1);
                dtpFechaInscripcionSuperioresInicio.CustomFormat = " ";
                dtpFechaInscripcionSuperioresFinal.CustomFormat = " ";
            }

            // Si Julio está visualmente vacío, igualamos para que MayorQue no falle
            if (dtpFechaJunioInicio.CustomFormat == " ")
            {
                dtpFechaJunioInicio.Value = DateTime.Today;
                dtpFechaJunioFinal.Value = DateTime.Today.AddDays(1);
                dtpFechaJunioInicio.CustomFormat = " ";
                dtpFechaJunioFinal.CustomFormat = " ";
            }
            // Si Diciembre está visualmente vacío, igualamos para que MayorQue no falle
            if (dtpFechaDiciembreInicio1.CustomFormat == " ")
            {
                dtpFechaDiciembreInicio1.Value = DateTime.Today;
                dtpFechaDiciembreFinal.Value = DateTime.Today.AddDays(1);
                dtpFechaDiciembreInicio1.CustomFormat = " ";
                dtpFechaDiciembreFinal.CustomFormat = " ";
            }



            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
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


            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }
        }

        #region Formateo de fechas
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
            ActualizarEstadoBotonGenerar();
        }



        private void dtpFechaInscripcionInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionInicio.Value != dtpFechaInscripcionInicio.MinDate)
                dtpFechaInscripcionInicio.CustomFormat = "dd/MM/yyyy";
            ActualizarEstadoBotonGenerar();
        }

        private void dtpFechaInscripcionFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionFinal.Value != dtpFechaInscripcionFinal.MinDate)
                dtpFechaInscripcionFinal.CustomFormat = "dd/MM/yyyy";
            ActualizarEstadoBotonGenerar();
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

        private void dtpFechaInscripcionSuperioresInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionSuperioresInicio.Value != dtpFechaInscripcionSuperioresInicio.MinDate)
                dtpFechaInscripcionSuperioresInicio.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaInscripcionSuperioresFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInscripcionSuperioresFinal.Value != dtpFechaInscripcionSuperioresFinal.MinDate)
                dtpFechaInscripcionSuperioresFinal.CustomFormat = "dd/MM/yyyy";
        }

        #endregion

        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaCierre.Value != dtpFechaCierre.MinDate)
            {
                dtpFechaCierre.CustomFormat = "dd/MM/yyyy";

                // Calcula cantidad de semanas entre apertura y cierre
                if (dtpFechaInicio.Value != dtpFechaInicio.MinDate)
                {
                    int dias = (dtpFechaCierre.Value - dtpFechaInicio.Value).Days;
                    txtCantidadSemana.Text = (dias / 7).ToString();
                }
            }

            btnFechaCierreCicloLectivo.Enabled = DateTime.Today >= dtpFechaCierre.Value.Date;
            ActualizarEstadoBotonGenerar();
        }




        private void BtnAgregarCursoSuperioresMarzo_Click(object sender, EventArgs e)
        {
            if (!ValidarAnioFechas()) return;

            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            DialogResult dr;


            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Modificar)
                {
                    dr = MessageBox.Show("¿Desea cargar las fechas de inscripción a finales?", "Inscripción a finales", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        if (turnoId == 0)
                        {
                            // Verifica que los campos de Superiores tengan fecha cargada
                            if (dtpFechaInscripcionSuperioresInicio.CustomFormat == " " ||
                                dtpFechaInscripcionSuperioresFinal.CustomFormat == " ")
                            {
                                Notificar(TipoNotificacion.Information, "Ingrese las fechas de Inscripción a Cursos Superiores");
                                return;
                            }
                            // Valida que las fechas correspondan al mes esperado (feb, mar, abril)
                            if (dtpFechaInscripcionSuperioresInicio.Value.Month < 2 || dtpFechaInscripcionSuperioresFinal.Value.Month > 4)
                            {
                                DialogResult confirm = MessageBox.Show(
                                    "Las fechas ingresadas no corresponden al período de Cursos superiores Marzo.\n¿Desea continuar de todas formas?",
                                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (confirm == DialogResult.No) return;
                            }
                            cicloLectivosLogica.AgregarFechaInscripcionSuperiores(CicloLectivo);
                        }
                        CargaFinal();
                    }
                }

            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }

        }

        private void BtnAgregarFinalMarzo_Click(object sender, EventArgs e)
        {
            if (!ValidarAnioFechas()) return;

            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            DialogResult dr;

            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Modificar)
                {
                    dr = MessageBox.Show("¿Desea cargar las fechas de inscripción a finales?", "Inscripción a finales", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (turnoId == 1)
                        {
                            // Verifica que los campos de Marzo tengan fecha cargada
                            if (dtpFechaMarzoInicio.CustomFormat == " " || dtpFechaMarzoFinal.CustomFormat == " ")
                            {
                                Notificar(TipoNotificacion.Information, "Ingrese las fechas de Finales Marzo");
                                return;
                            }
                            // Valida que las fechas correspondan al mes esperado (feb, mar, abril)
                            if (dtpFechaMarzoInicio.Value.Month < 2 || dtpFechaMarzoInicio.Value.Month > 4)
                            {
                                DialogResult confirm = MessageBox.Show(
                                    "Las fechas ingresadas no corresponden al período de Finales Marzo.\n¿Desea continuar de todas formas?",
                                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (confirm == DialogResult.No) return;
                            }
                            cicloLectivosLogica.AgregarFechaFinalesMarzo(CicloLectivo);
                        }
                        CargaFinal();
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }
        }

        private void BtnAgregarFinalJulio_Click(object sender, EventArgs e)
        {
            if (!ValidarAnioFechas()) return;

            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            DialogResult dr;

            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Modificar)
                {
                    dr = MessageBox.Show("¿Desea cargar las fechas de inscripción a finales?", "Inscripción a finales", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (turnoId == 2)
                        {
                            // Verifica que los campos de Julio tengan fecha cargada
                            if (dtpFechaJunioInicio.CustomFormat == " " || dtpFechaJunioFinal.CustomFormat == " ")
                            {
                                Notificar(TipoNotificacion.Information, "Ingrese las fechas de Finales Julio");
                                return;
                            }
                            // Valida que las fechas correspondan al mes esperado (jun, jul, ago)
                            if (dtpFechaJunioInicio.Value.Month < 6 || dtpFechaJunioInicio.Value.Month > 8)
                            {
                                DialogResult confirm = MessageBox.Show(
                                    "Las fechas ingresadas no corresponden al período de Finales Julio.\n¿Desea continuar de todas formas?",
                                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (confirm == DialogResult.No) return;
                            }
                            cicloLectivosLogica.AgregarFechaFinalesJulio(CicloLectivo);
                        }
                        CargaFinal();
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }


        }

        private void BtnAgregarFinalDiciembre_Click(object sender, EventArgs e)
        {
            if (!ValidarAnioFechas()) return;

            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            DialogResult dr;

            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Modificar)
                {
                    dr = MessageBox.Show("¿Desea cargar las fechas de inscripción a finales?", "Inscripción a finales", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (turnoId == 3)
                        {
                            // Verifica que los campos de Diciembre tengan fecha cargada
                            if (dtpFechaDiciembreInicio1.CustomFormat == " " || dtpFechaDiciembreFinal.CustomFormat == " ")
                            {
                                Notificar(TipoNotificacion.Information, "Ingrese las fechas de Finales Diciembre");
                                return;
                            }
                            // Valida que las fechas correspondan al mes esperado (nov, dic)
                            if (dtpFechaDiciembreInicio1.Value.Month < 11 || dtpFechaDiciembreInicio1.Value.Month > 12)
                            {
                                DialogResult confirm = MessageBox.Show(
                                    "Las fechas ingresadas no corresponden al período de Finales Diciembre.\n¿Desea continuar de todas formas?",
                                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (confirm == DialogResult.No) return;
                            }
                            // Se asigna FechaDiciembreInicio solo cuando realmente se va a guardar Diciembre
                            CicloLectivo.FechaDiciembreInicio = dtpFechaDiciembreInicio1.Value;
                            cicloLectivosLogica.AgregarFechaFinalesDiciembre(CicloLectivo);
                        }
                        CargaFinal();
                    }
                }
            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }

        }

        private void CargaFinal()
        {
            if (cargarFinal)
            {
                var resultMesas = this.mesasFinalesLogica.CargarMesasFinales(this.CicloLectivoId, turnoId);
                if (resultMesas > 0)
                    Notificar(TipoNotificacion.Success, $"Mesas finales generadas con éxito para {tagTurno}, {CicloLectivoId}.", Tiempo: 3000);
                else
                    Notificar(TipoNotificacion.Error, $"Ya hay mesas para {tagTurno}, {CicloLectivoId}", Tiempo: 3000);
            }
            // Primero actualiza el estado de los grupos, después carga las fechas
            ExistenMesasFinales(Convert.ToInt32(txtAnioLectivo.Text));
            CargarDatos(Convert.ToInt32(txtAnioLectivo.Text));
        }

        private void btnFechaCierreCicloLectivo_Click(object sender, EventArgs e)
        {
            Notificar(
                       TipoNotificacion.Information,
                       "Funcionalidad en desarrollo",
                        Tiempo: 3000);
        }

        private void btnGeneraCicloLectivo_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show(
                "¿Desea generar los cursos del ciclo lectivo?",
                "Generar Cursos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No) return;
            if (!ValidarAnioFechas()) return;
            var CicloLectivo = this.MapToModel<CicloLectivoModelo>();
            //DialogResult dr;

            if (CicloLectivo.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Agregar)
                {
                    // dr = MessageBox.Show("Generación de Cursos Lectivos" + txtAnioLectivo.Text, "Ciclo Lectivo", MessageBoxButtons.YesNo);
                    // if (dr == DialogResult.Yes)
                    //{
                    cicloLectivosLogica.AgregarCicloLectivo(CicloLectivo);
                    Notificar(TipoNotificacion.Success, "Ciclo lectivo agregado con exito");
                    txtAnioLectivo.Text = "";
                    txtCantidadSemana.Text = "";
                    DateTimePickerEnBlanco();
                    ciclo = cicloLectivosLogica.ObtenerMaximoAnioCicloLectivo() + 1;
                    txtAnioLectivo.Text = ciclo == 1 ? (DateTime.Now.Year + 1).ToString() : ciclo.ToString();

                    //}
                }


            }
            else
            {
                this.MostrarErrores(epvCicloLectivo, CicloLectivo.Errores);
            }

            //Notificar(
            //    TipoNotificacion.Information,
            //    "Funcionalidad pendiente: generar cursos controlando que estén activos.",
            //    Tiempo: 3000);

        }

        private void ActualizarEstadoBotonGenerar()
        {
            if (this.Accion != TipoAccion.Agregar) return;

            bool todasCompletas =
                dtpFechaInscripcionInicio.CustomFormat == "dd/MM/yyyy" &&
                dtpFechaInscripcionFinal.CustomFormat == "dd/MM/yyyy" &&
                dtpFechaInicio.CustomFormat == "dd/MM/yyyy" &&
                dtpFechaCierre.CustomFormat == "dd/MM/yyyy" &&
                int.TryParse(txtCantidadSemana.Text, out int sem) && sem > 0;

            btnGeneraCicloLectivo.Enabled = todasCompletas;
        }

        private void txtAnioLectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y espacio Anio lectivo
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void ExistenMesasFinales(int cicloLectivo)
        {
            DataTable dt = mesasFinalesLogica.ExistenMesasFinales(cicloLectivo);
            mesasMarzo = Convert.ToInt32(dt.Rows[0]["Marzo"]);
            mesasJulio = Convert.ToInt32(dt.Rows[0]["Julio"]);
            mesasDiciembre = Convert.ToInt32(dt.Rows[0]["Diciembre"]);

            // Verificamos si Cursos Superiores ya fue cargado
            bool superioresCargado = dtpFechaInscripcionSuperioresInicio.CustomFormat == "dd/MM/yyyy";

            if (mesasMarzo == 0 && mesasJulio == 0 && mesasDiciembre == 0)
            {
                // Nada cargado — solo Marzo habilitado
                turnoId = 1;
                cargarFinal = true;
                tagTurno = "Marzo";
                grbFinalesMarzo.Enabled = true;
                grbInscripcionSuperiores.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;

                BtnAgregarFinalMarzo.Visible = true;
                BtnAgregarFinalMarzo.Enabled = true;

                BtnAgregarCursoSuperioresMarzo.Visible = false;
                BtnAgregarCursoSuperioresMarzo.Enabled = false;

                BtnAgregarFinalJulio.Visible = false;
                BtnAgregarFinalJulio.Enabled = false;

                BtnAgregarFinalDiciembre.Visible = false;
                BtnAgregarFinalDiciembre.Enabled = false;
            }
            else if (mesasMarzo == 1 && mesasJulio == 0 && mesasDiciembre == 0 && !superioresCargado)
            {
                // Marzo cargado, Superiores no — solo Superiores habilitado
                turnoId = 0;
                cargarFinal = false;
                grbFinalesMarzo.Enabled = false;
                grbInscripcionSuperiores.Enabled = true;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;

                BtnAgregarFinalMarzo.Visible = false;
                BtnAgregarFinalMarzo.Enabled = false;

                BtnAgregarCursoSuperioresMarzo.Visible = true;
                BtnAgregarCursoSuperioresMarzo.Enabled = true;

                BtnAgregarFinalJulio.Visible = false;
                BtnAgregarFinalJulio.Enabled = false;

                BtnAgregarFinalDiciembre.Visible = false;
                BtnAgregarFinalDiciembre.Enabled = false;
            }
            else if (mesasMarzo == 1 && mesasJulio == 0 && mesasDiciembre == 0 && superioresCargado)
            {
                // Marzo y Superiores cargados — Julio habilitado
                turnoId = 2;
                cargarFinal = true;
                tagTurno = "Julio";
                grbFinalesMarzo.Enabled = false;
                grbInscripcionSuperiores.Enabled = false;
                grbFinalesJulio.Enabled = true;
                grbFinalesDiciembre.Enabled = false;

                BtnAgregarFinalMarzo.Visible = false;
                BtnAgregarFinalMarzo.Enabled = false;

                BtnAgregarCursoSuperioresMarzo.Visible = false;
                BtnAgregarCursoSuperioresMarzo.Enabled = false;

                BtnAgregarFinalJulio.Visible = true;
                BtnAgregarFinalJulio.Enabled = true;

                BtnAgregarFinalDiciembre.Visible = false;
                BtnAgregarFinalDiciembre.Enabled = false;


            }
            else if (mesasMarzo == 1 && mesasJulio == 1 && mesasDiciembre == 0)
            {
                // Julio cargado — Diciembre habilitado
                turnoId = 3;
                cargarFinal = true;
                tagTurno = "Diciembre";
                grbFinalesMarzo.Enabled = false;
                grbInscripcionSuperiores.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = true;

                BtnAgregarFinalMarzo.Visible = false;
                BtnAgregarFinalMarzo.Enabled = false;

                BtnAgregarCursoSuperioresMarzo.Visible = false;
                BtnAgregarCursoSuperioresMarzo.Enabled = false;

                BtnAgregarFinalJulio.Visible = false;
                BtnAgregarFinalJulio.Enabled = false;

                BtnAgregarFinalDiciembre.Visible = true;
                BtnAgregarFinalDiciembre.Enabled = true;
            }
            else
            {
                // Todo cargado
                grbFinalesMarzo.Enabled = false;
                grbInscripcionSuperiores.Enabled = false;
                grbFinalesJulio.Enabled = false;
                grbFinalesDiciembre.Enabled = false;

                BtnAgregarFinalMarzo.Visible = false;
                BtnAgregarFinalMarzo.Enabled = false;

                BtnAgregarCursoSuperioresMarzo.Visible = false;
                BtnAgregarCursoSuperioresMarzo.Enabled = false;

                BtnAgregarFinalJulio.Visible = false;
                BtnAgregarFinalJulio.Enabled = false;

                BtnAgregarFinalDiciembre.Visible = false;
                BtnAgregarFinalDiciembre.Enabled = false;

                btnAceptar.Enabled = true;
                cargarFinal = false;
            }
        }
    }
}
