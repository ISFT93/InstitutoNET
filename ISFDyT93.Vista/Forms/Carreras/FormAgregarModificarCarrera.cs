using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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

        #region funciones
        private void MostrarCarreraExistentes()
        {
            switch (this.Accion)
            {
                case TipoAccion.Agregar:
                    this.Contenedor.SetTitulo("Agregar Carrera");
                    nudAnioInicio.Value = DateTime.Now.Year;
                    nudAnioFin.Enabled = false;
                    break;
                case TipoAccion.Modificar:
                    this.Modelo = CarrerasLogica.ObtenerCarrera(this.CarreraId);
                    if (this.Modelo.JefeCatedra == null)
                        this.Modelo.JefeCatedra = ""; //Le asigna un valor vacio para que no falle al hacer update, ya que JefeCatedra no permite valores nulos en la BD
                    nudAnioFin.Enabled = false;
                    nudAnioInicio.Value = this.Modelo.AnioInicio;
                    this.MapToForm<CarrerasModelo>(Modelo);
                    // Asegura que al modificar se marque el régimen que la carrera ya tenía guardado en la BD
                    cmbRegimen.SelectedValue = this.Modelo.RegimenId;

                    break;
                case TipoAccion.Ver:
                    ComprobarCarreraId();
                    this.Contenedor.SetTitulo($"Carrera  {Modelo.DescripcionCorta}");
                    this.DeshabilitarControles();
                    btnGuardar.Visible = false;
                    break;
                case TipoAccion.Desactivar:
                    ComprobarCarreraId();
                    this.DeshabilitarControles();
                    this.nudAnioFin.Value = DateTime.Now.Year;
                    break;
            }
        }

        private void ComprobarCarreraId()
        {
            if (this.CarreraId > 0)
            {
                this.Modelo = CarrerasLogica.ObtenerCarrera(this.CarreraId);

                this.MapToForm<CarrerasModelo>(Modelo);

                //Controlo que el campo duracion no se pueda modificar
                var existe = MateriasLogica.MateriaAsignada(this.CarreraId);

                //Solo para cambiar el titulo
                this.Contenedor.SetTitulo($"Modificar Carrera {Modelo.DescripcionCorta}");

                nudAnioFin.Enabled = this.Modelo.CarreraEstadoId != 3;

                this.txtCantidadHoras.Text = this.Modelo.CantidadHoras.ToString();

                bool enableOpciones = existe > 0;
                txtCantidadHoras.Enabled = !enableOpciones;
                Modelo.PoseeMaterias = enableOpciones;
                txtDuracion.Enabled = !enableOpciones;

                this.txtDuracion.Text = this.Modelo.Duracion.ToString();
            }
        }

        private void GuardarCarrera()
        {
            var carrera = this.MapToModel<CarrerasModelo>();

            // Asignación explícita de los nuevos ComboBox al modelo para garantizar su guardado
            if (carrera != null)
            {
                carrera.SectorActividad = cmbSectorActividad.SelectedItem?.ToString();
                carrera.FamiliaProfesional = cmbFamiliaProfesional.SelectedItem?.ToString();
                carrera.Variante = cmbVariante.SelectedItem?.ToString();
                carrera.Modalidad = cmbModalidad.SelectedItem?.ToString();
                carrera.RegimenDefecto = cmbRegimenDefecto.SelectedItem?.ToString();
            }

            // Asignamos explícitamente el valor del régimen seleccionado en el ComboBox
            if (cmbRegimen.SelectedValue != null && int.TryParse(cmbRegimen.SelectedValue.ToString(), out int regimenId))
            {
                carrera.RegimenId = regimenId;
            }

            if (carrera.Errores.Count > 0)
            {
                this.MostrarErrores(epvCarreras, carrera.Errores);
                return;
            }

            try
            {
                if (this.Accion == TipoAccion.Desactivar)
                {
                    if (!CarrerasLogica.AnioValidoDesactivar(this.nudAnioFin.Value))
                    {
                        Notificar(TipoNotificacion.Warning, "No se pudo desactivar\n" +
                                "el año debe ser mayor o igual al año actual");
                        return;
                    }

                    DialogResult result = MessageBox.Show("Esta por desactivar la carrera '" + txtDescripcionCorta.Text + "', ¿Esta seguro?", "Confirmar desactivacion", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes != result)
                        return;

                    CarrerasLogica.GuardarCarrera(carrera, TipoAccion.Modificar);
                    Notificar(TipoNotificacion.Success, "Carrera desactivada");
                    Contenedor.AbrirFormulario<FormCarreras>();
                    return;
                }
                else if (this.Accion == TipoAccion.Agregar)
                {
                    if (CarrerasLogica.GuardarCarrera(carrera, this.Accion))
                    {
                        Notificar(TipoNotificacion.Success, "Carrera guardada correctamente");
                        Contenedor.AbrirFormulario<FormCarreras>();
                    }
                }
                else if (this.Accion == TipoAccion.Modificar)
                {
                    carrera.CarreraId = this.Modelo.CarreraId;
                    carrera.CarrerasCodigoBloque = this.Modelo.CarrerasCodigoBloque;
                    carrera.CarreraEstadoId = this.Modelo.CarreraEstadoId;

                    if (CarrerasLogica.GuardarCarrera(carrera, this.Accion))
                    {
                        Notificar(TipoNotificacion.Success, "Carrera modificada correctamente");
                        Contenedor.AbrirFormulario<FormCarreras>();
                    }
                }
                else
                {
                    Notificar(TipoNotificacion.Error, "No se ha podido guardar la carrera");
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (mensaje.Contains("UQ_NumeroResolucion") || mensaje.Contains("2627") || mensaje.Contains("2601") || mensaje.Contains("El numero de resolucion ya existe"))
                {
                    int idActual = (this.Accion == TipoAccion.Modificar) ? this.Modelo.CarreraId : 0;
                    string nombreCarreraExistente = CarrerasLogica.ObtenerNombreCarreraPorResolucion(txtNumeroResolucion.Text.Trim(), idActual);

                    if (!string.IsNullOrEmpty(nombreCarreraExistente))
                    {
                        mensaje = $"El número de Resolución: {txtNumeroResolucion.Text.Trim()} ya existe. Pertenece a la carrera: '{nombreCarreraExistente}'.";
                    }
                    else
                    {
                        mensaje = "El número de Resolución: " + txtNumeroResolucion.Text.Trim() + " ya existe.";
                    }
                }

                Notificar(TipoNotificacion.Warning, mensaje);
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
            txtImagenDescriptiva.Text = "";
            txtNumeroResolucion.Text = "";
            txtCantidadHoras.Text = "";
            txtDuracion.Text = "";
        }
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

            CargarListasDesplegables(); // Inicialización de los nuevos ComboBox
            // Cargar las opciones del ComboBox de Régimen desde la BD
            cmbRegimen.DataSource = CarrerasLogica.ObtenerRegimenes();
            cmbRegimen.ValueMember = "RegimenId";   // ID que se guardará en la base de datos
            cmbRegimen.DisplayMember = "Nombre";    // Texto que verá el usuario ("Anual", "Cuatrimestral", etc.)

            MostrarCarreraExistentes();
        }

        private void CargarListasDesplegables()
        {
            try
            {
                ClasificacionCarrerasLogica clasificacionLogica = new ClasificacionCarrerasLogica();
                DataTable dtClasificacion = clasificacionLogica.ObtenerClasificacion();

                if (dtClasificacion == null) return;

                // Filtramos solo los registros que estén activos
                DataView dvActivos = new DataView(dtClasificacion);
                dvActivos.RowFilter = "Activo = 1";

                // 1. Sector de Actividad (Familias del grupo Sector de Actividad o equivalentes)
                if (cmbSectorActividad != null)
                {
                    cmbSectorActividad.Items.Clear();
                    DataView dvSector = new DataView(dtClasificacion);
                    dvSector.RowFilter = "Activo = 1 AND Descripcion = 'Sector de Actividad'";
                    foreach (DataRowView row in dvSector)
                    {
                        string valor = row["DescripcionCorta"]?.ToString();
                        if (!string.IsNullOrEmpty(valor) && !cmbSectorActividad.Items.Contains(valor))
                        {
                            cmbSectorActividad.Items.Add(valor);
                        }
                    }
                }

                // 2. Familia Profesional
                if (cmbFamiliaProfesional != null)
                {
                    cmbFamiliaProfesional.Items.Clear();
                    DataView dvFamilia = new DataView(dtClasificacion);
                    dvFamilia.RowFilter = "Activo = 1 AND (Descripcion = 'Familia Profesional' OR Descripcion = 'Sector de Actividad')";
                    foreach (DataRowView row in dvFamilia)
                    {
                        string valor = row["DescripcionCorta"]?.ToString();
                        if (!string.IsNullOrEmpty(valor) && !cmbFamiliaProfesional.Items.Contains(valor))
                        {
                            cmbFamiliaProfesional.Items.Add(valor);
                        }
                    }
                }

                // 3. Modalidad (Presencial, Virtual, Híbrido, etc. configurados)
                if (cmbModalidad != null)
                {
                    cmbModalidad.Items.Clear();
                    DataView dvModalidad = new DataView(dtClasificacion);
                    dvModalidad.RowFilter = "Activo = 1 AND (Descripcion = 'Modalidad' OR DescripcionCorta IN ('Presencial', 'A distancia', 'Híbrido', 'Virtual'))";
                    foreach (DataRowView row in dvModalidad)
                    {
                        string valor = row["DescripcionCorta"]?.ToString();
                        if (!string.IsNullOrEmpty(valor) && !cmbModalidad.Items.Contains(valor))
                        {
                            cmbModalidad.Items.Add(valor);
                        }
                    }
                }

                // 4. Régimen por Defecto (Anual, Cuatrimestral, etc.)
                if (cmbRegimenDefecto != null)
                {
                    cmbRegimenDefecto.Items.Clear();
                    DataView dvRegimen = new DataView(dtClasificacion);
                    dvRegimen.RowFilter = "Activo = 1 AND (Descripcion = 'Regimen' OR DescripcionCorta IN ('Anual', 'Cuatrimestral'))";
                    foreach (DataRowView row in dvRegimen)
                    {
                        string valor = row["DescripcionCorta"]?.ToString();
                        if (!string.IsNullOrEmpty(valor) && !cmbRegimenDefecto.Items.Contains(valor))
                        {
                            cmbRegimenDefecto.Items.Add(valor);
                        }
                    }
                    if (cmbRegimenDefecto.Items.Count > 0)
                        cmbRegimenDefecto.SelectedIndex = 0;
                }

                // 5. Variante
                if (cmbVariante != null)
                {
                    cmbVariante.Items.Clear();
                    DataView dvVariante = new DataView(dtClasificacion);
                    dvVariante.RowFilter = "Activo = 1 AND Descripcion = 'Variante'";
                    foreach (DataRowView row in dvVariante)
                    {
                        string valor = row["DescripcionCorta"]?.ToString();
                        if (!string.IsNullOrEmpty(valor) && !cmbVariante.Items.Contains(valor))
                        {
                            cmbVariante.Items.Add(valor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas desplegables dinámicas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCarrera();
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
            ofdCarreras.Filter = "Archivos PNG|.png|Archivos JPG|.jpg";

            if (ofdCarreras.ShowDialog() == DialogResult.OK)
            {
                txtImagenDescriptiva.Text = ofdCarreras.FileName;
            }
        }
    }
}