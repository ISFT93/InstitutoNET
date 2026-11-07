using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using System;
using System.Data;
using System.Drawing;
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

                    // Selecciona los valores correspondientes en los ComboBox
                    SeleccionarValoresCombobox();
                    break;
                case TipoAccion.Ver:
                    ComprobarCarreraId();
                    this.Contenedor.SetTitulo($"Carrera  {Modelo.DescripcionCorta}");
                    this.DeshabilitarControles();
                    DeshabilitarComboBoxes();
                    btnGuardar.Visible = false;
                    break;
                case TipoAccion.Desactivar:
                    ComprobarCarreraId();
                    this.DeshabilitarControles();
                    DeshabilitarComboBoxes();
                    this.nudAnioFin.Value = DateTime.Now.Year;
                    break;
            }
        }

        private void DeshabilitarComboBoxes()
        {
            cmbSectorActividad.Enabled = false;
            cmbFamiliaProfesional.Enabled = false;
            cmbVariante.Enabled = false;
            cmbModalidad.Enabled = false;
            cmbRegimenDefecto.Enabled = false;
        }

        private void SeleccionarValoresCombobox()
        {
            if (this.Modelo == null) return;

            if (!string.IsNullOrWhiteSpace(this.Modelo.SectorActividad))
            {
                int idx = cmbSectorActividad.FindStringExact(this.Modelo.SectorActividad.Trim());
                if (idx >= 0) cmbSectorActividad.SelectedIndex = idx;
            }
            if (!string.IsNullOrWhiteSpace(this.Modelo.FamiliaProfesional))
            {
                int idx = cmbFamiliaProfesional.FindStringExact(this.Modelo.FamiliaProfesional.Trim());
                if (idx >= 0) cmbFamiliaProfesional.SelectedIndex = idx;
            }
            if (!string.IsNullOrWhiteSpace(this.Modelo.Variante))
            {
                int idx = cmbVariante.FindStringExact(this.Modelo.Variante.Trim());
                if (idx >= 0) cmbVariante.SelectedIndex = idx;
            }
            if (!string.IsNullOrWhiteSpace(this.Modelo.Modalidad))
            {
                int idx = cmbModalidad.FindStringExact(this.Modelo.Modalidad.Trim());
                if (idx >= 0) cmbModalidad.SelectedIndex = idx;
            }
            if (!string.IsNullOrWhiteSpace(this.Modelo.RegimenDefecto))
            {
                int idx = cmbRegimenDefecto.FindStringExact(this.Modelo.RegimenDefecto.Trim());
                if (idx >= 0) cmbRegimenDefecto.SelectedIndex = idx;
            }
        }

        private void ComprobarCarreraId()
        {
            if (this.CarreraId > 0)
            {
                this.Modelo = CarrerasLogica.ObtenerCarrera(this.CarreraId);

                this.MapToForm<CarrerasModelo>(Modelo);

                SeleccionarValoresCombobox();

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
                var regimenes = CarrerasLogica.ObtenerRegimenes();
                var filaRegimen = regimenes.AsEnumerable().FirstOrDefault(r =>
                    string.Equals(r["Nombre"].ToString(), carrera.RegimenDefecto, StringComparison.OrdinalIgnoreCase));
                carrera.RegimenId = filaRegimen != null ? Convert.ToInt32(filaRegimen["RegimenId"]) : 1;
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
            MostrarCarreraExistentes();
        }

        private void CargarListasDesplegables()
        {
            try
            {
                ClasificacionCarrerasLogica clasificacionLogica = new ClasificacionCarrerasLogica();
                DataTable dtClasificacion = clasificacionLogica.ObtenerClasificacion();

                if (dtClasificacion == null) return;

                DataView dvActivos = new DataView(dtClasificacion);
                dvActivos.RowFilter = "Activo = 1";

                // 1. Sector de Actividad
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

                // 3. Modalidad
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

                // 4. Régimen por Defecto
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

        // Dibuja los ComboBox adaptándose si están deshabilitados o activos
        private void ComboBoxClasificacion_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (e.Index < 0) return;

            bool esAreaEdicion = (e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit;
            bool resaltarItemLista = !esAreaEdicion && (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color colorFondo = resaltarItemLista ? SystemColors.Highlight : Color.White;
            Color colorTexto = resaltarItemLista ? SystemColors.HighlightText : Color.Black;

            // Si el ComboBox está deshabilitado, aplicar colores de control protegido/deshabilitado
            if (!cmb.Enabled)
            {
                colorFondo = SystemColors.Control;
                colorTexto = SystemColors.GrayText;
            }

            using (SolidBrush pincel = new SolidBrush(colorFondo))
            {
                e.Graphics.FillRectangle(pincel, e.Bounds);
            }

            TextRenderer.DrawText(e.Graphics, cmb.GetItemText(cmb.Items[e.Index]), e.Font, e.Bounds,
                colorTexto, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
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
