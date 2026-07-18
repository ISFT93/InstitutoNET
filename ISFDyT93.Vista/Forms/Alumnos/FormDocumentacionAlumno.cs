using CapaPresentacionAdmin.Controls;
using ISFDyT93.Entidades.Enums;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
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
    public partial class FormDocumentacionAlumno : FormBase
    {
        #region Propiedades Privadas

        private AlumnosLogica AlumnosLogica { get; set; }
        private InscripcionAlumnoLogica AlumnosInscLogica { get; set; }
        private CarrerasLogica carrerasLogica { get; set; }
        private CicloLectivosLogica CicloLectivosLogica { get; set; }
        private CursadasLogica CursadasLogica { get; set; }
        private int AlumnoId { get; set; }
        private string ApellidoNombre { get; set; }
        private int AlumnoCarreraId { get; set; }

        FormCargaMasivaCsv FormCarMasivaCsv = new FormCargaMasivaCsv();

        #endregion  
        public FormDocumentacionAlumno()
        {
            this.AlumnosLogica = new AlumnosLogica();
            this.CicloLectivosLogica = new CicloLectivosLogica();
            carrerasLogica = new CarrerasLogica();
            this.CursadasLogica = new CursadasLogica();
            InitializeComponent();
        }

        private void FormDocumentacionAlumno_Load(object sender, EventArgs e)
        {
            uscPaginacion1.dataGridView = dgvAlumnos; //pasa el datagridview a la paginacion
            cmbCarreraId.DataSource = carrerasLogica.ObtenerCarreras();
            cmbCarreraId.ValueMember = "CarreraId";
            cmbCarreraId.DisplayMember = "Descripción";
            cmbCarreraId.SelectedIndex = 0; //por defecto busca todos
            uscPaginacion1.BringToFront();

            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.ShowUpDown = false; // calendario desplegable
            dtpFecha.Width = 120;

            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true; // quita calendario y usa flechas
            dtpHora.Width = 70;

            RecargarGrilla();
            this.Contenedor.SetTitulo("Documentación de Alumnos");
            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });
        }
        private void RecargarGrilla(string filtro = "")
        {
            dgvAlumnos.DataSource = null;

            var carreras = carrerasLogica.ObtenerCarreras();
            int tipo = 0;
            foreach (DataRow fila in carreras.Rows)
            {
                string c = fila["Descripción"].ToString();
                if (cmbCarreraId.Text == c)
                    tipo = Convert.ToInt32(fila["CarreraId"]);
            }

            if (rbTodos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(-1, tipo, filtro);
            else if (rbIncompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(1, tipo, filtro);
            else if (rbCompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(2, tipo, filtro);

            EstilosColumnasDGV();
        }
        private void EstilosColumnasDGV()
        {
            if (!dgvAlumnos.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "Seleccionar";
                chk.HeaderText = "";
                chk.Width = 35;
                chk.FillWeight = 30;
                chk.MinimumWidth = 30;

                dgvAlumnos.Columns.Insert(0, chk);
            }

            if (dgvAlumnos.Columns.Contains("AlumnoId"))
                dgvAlumnos.Columns["AlumnoId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("AlumnoCarreraId"))
                dgvAlumnos.Columns["AlumnoCarreraId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("Inicializado"))
                dgvAlumnos.Columns["Inicializado"].Visible = true;
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
        private void dgvAlumnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvAlumnos.Columns[e.ColumnIndex].Name == "Inicializado")
                {
                    if (e.Value != null)
                    {
                        int valor = Convert.ToInt32(e.Value);

                        switch (valor)
                        {
                            case 0:
                                e.Value = "Correo no enviado";
                                break;

                            case 1:
                                e.Value = "Correo enviado";
                                break;

                            case 2:
                                e.Value = "Documentación completa";
                                break;
                            case 3:
                                e.Value = "Ya ingresado";
                                break;
                        }

                        e.FormattingApplied = true;
                    }
                }
            }
            catch { }

        }
        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvAlumnos.Columns.Contains("AlumnoId"))
                return;
            // Verifica que sea la columna CheckBox
            if ((e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Seleccionar"))
                return;

            // En CellDoubleClick ya dispones de las coordenadas de celda (fila/columna)
            object valor = null;
            if (dgvAlumnos.Columns.Contains("AlumnoId"))
            {
                string ini = Convert.ToString(dgvAlumnos["Inicializado", e.RowIndex].Value);
                if (ini == "0")
                {
                    this.Notificar(TipoNotificacion.Information, $"Todavía no se ha enviado el correo electrónico al alumno.");
                    return; // Si el estado es "Completos", no se abre el formulario
                }
                if (ini == "2")
                {
                    this.Notificar(TipoNotificacion.Information, $"El alumno ya tiene la documentacion completa.");
                    return; // Si el estado es "Completos", no se abre el formulario
                }
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvAlumnos.Columns.Contains("AlumnoId"))
                valor = dgvAlumnos["AlumnoId", e.RowIndex].Value;

            if (valor != null && valor != DBNull.Value)
            {
                this.AlumnoId = Convert.ToInt32(valor);
            }

            Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form =>
            {
                form.Accion = TipoAccion.Documentacion;
                form.AlumnoId = AlumnoId;
            });
        }

        private void cmbCarreraId_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void CheckedGrilla(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void btnEnviarMail_Click(object sender, EventArgs e)
        {


            string mailasunto = "Documentación Pendiente";
            int enviados = 0;
            string mailtexto =
                            @"Por medio de la presente, se le solicita tenga a bien acercarse al instituto a fin de presentar la documentación correspondiente.

                    Deberá presentarse el día "
                            + dtpFecha.Value.ToString("dd/MM/yyyy")
                            + " a las "
                            + dtpHora.Value.ToString("HH:mm")
                            + @" hs.

                    Desde ya, muchas gracias.";
            bool existe = dgvAlumnos.Rows
                        .Cast<DataGridViewRow>()
                        .Any(f => !f.IsNewRow && Convert.ToInt32(f.Cells["Inicializado"].Value) == 0);

            if (!existe)
            {
                this.Notificar(TipoNotificacion.Error, $"No hay alumnos para enviar el correo electronico.");
                return;
            }
            bool haySeleccionados = false;

            foreach (DataGridViewRow fila in dgvAlumnos.Rows)
            {
                bool seleccionado = Convert.ToBoolean(fila.Cells["Seleccionar"].Value == null ? false : fila.Cells["Seleccionar"].Value);
                if (seleccionado)
                {
                    haySeleccionados = true;
                    break;
                }
            }
            if (!haySeleccionados)
            {
                this.Notificar(TipoNotificacion.Error, "No hay alumnos seleccionados para enviar el correo electrónico.");
                return;
            }
            foreach (DataGridViewRow fila in dgvAlumnos.SelectedRows)
            {
                bool seleccionado = Convert.ToBoolean(fila.Cells["Seleccionar"].Value == null ? false : fila.Cells["Seleccionar"].Value);

                // Si no está seleccionado, continuar
                if (!seleccionado)
                {
                    this.Notificar(TipoNotificacion.Error, $"No hay alumnos seleccionados para enviar el correo electronico.");
                    continue;
                }

                mailtexto = "Estimado/a " + fila.Cells["Apellido"].Value.ToString() + " " + fila.Cells["Nombre"].Value.ToString() + ",\n\n" + mailtexto;
                int id = Convert.ToInt32(fila.Cells["AlumnoId"].Value);
                string mail = fila.Cells["Correo"].Value.ToString();
                if (Convert.ToInt32(fila.Cells["Inicializado"].Value) == 0)
                {
                    bool enviado = AlumnosLogica.EnviarMailDocumentos(mail, mailasunto, mailtexto);
                    if (!enviado)
                    {
                        Timer timerMensajes = new Timer();
                        this.Notificar(TipoNotificacion.Error, $"No se pudo enviar el mail a {fila.Cells["Apellido"].Value.ToString()} {fila.Cells["Nombre"].Value.ToString()}.");
                        timerMensajes.Interval = 4000;
                        timerMensajes.Tick += (s, c) =>
                        {
                            timerMensajes.Stop();
                            timerMensajes.Dispose();
                        };
                        timerMensajes.Start();
                        continue;
                    }
                    AlumnosLogica.ActualizarEstadoInicializado(id, 1);
                    enviados++;
                }
            }
            this.Notificar(TipoNotificacion.Success, $"Se han {enviados} Mails enviados.");
            RecargarGrilla();
        }

        private void txtFiltroAlumno_TextChanged(object sender, EventArgs e)
        {
            RecargarGrilla(txtFiltroAlumno.Text);
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que sea la columna CheckBox
            if (e.RowIndex >= 0 && dgvAlumnos.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                DataGridViewRow row = dgvAlumnos.Rows[e.RowIndex];

                string inicializado = row.Cells["Inicializado"].Value.ToString();

                if (inicializado != "0")
                {
                    row.Cells["Seleccionar"].Value = false;
                    this.Notificar(TipoNotificacion.Information, $"Este alumno ya tiene el correo enviado y no puede seleccionarse.\nRegistro bloqueado");
                    return;
                }

                DataGridViewCheckBoxCell chk =
                    (DataGridViewCheckBoxCell)dgvAlumnos.Rows[e.RowIndex].Cells["Seleccionar"];

                bool valorActual = Convert.ToBoolean(chk.Value == null ? false : chk.Value);

                // Contar seleccionados actuales
                int seleccionados = 0;

                foreach (DataGridViewRow fila in dgvAlumnos.Rows)
                {
                    bool marcado = Convert.ToBoolean(
                        fila.Cells["Seleccionar"].Value == null
                        ? false
                        : fila.Cells["Seleccionar"].Value);

                    if (marcado)
                        seleccionados++;
                }

                // Si intenta seleccionar más de 30
                if (!valorActual && seleccionados >= 30)
                {
                    this.Notificar(TipoNotificacion.Success, $"Solo puedes seleccionar un máximo de 30 registros.\nLímite alcanzado");
                    return;
                }

                // Cambiar estado del checkbox
                chk.Value = !valorActual;
            }
        }

        private void btnCerra_Click(object sender, EventArgs e)
        {
            var carreras = carrerasLogica.ObtenerCarreras();
            int carreraId = 0;
            foreach (DataRow fila in carreras.Rows)
            {
                string c = fila["Descripción"].ToString();
                if (cmbCarreraId.Text == c)
                    carreraId = Convert.ToInt32(fila["CarreraId"]);
            }

            var existenPrimeros = carrerasLogica.CarreraTienePrimerAnio(carreraId);
            if (existenPrimeros == 0)
            {
                this.Notificar(TipoNotificacion.Warning, "La carrera seleccionada no tiene configurado el primer año." + cmbCarreraId.Text);
                return;
            }
            bool existenPendientes = false;

            foreach (DataGridViewRow fila in dgvAlumnos.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string inicializado = Convert.ToString(fila.Cells["Inicializado"].Value);

                if (inicializado == "2")
                {
                    existenPendientes = true;
                    break;
                }
            }

            if (!existenPendientes)
            {
                this.Notificar(TipoNotificacion.Warning, "No se encontraron alumnos para cargar en los cursos.\nRevise los datos ingresados e inténtelo nuevamente.");
                return;
            }
            var tipo = (TipoFiltroAlumno)cmbCarreraId.SelectedIndex;
            var listAlumno = AlumnosLogica.ObtenerTodosAlumnos(tipo,"");
            foreach (DataRow fila in listAlumno.Rows)
            {
                //if (fila["Inicializado"] == DBNull.Value)
                //    {
                //    int id = Convert.ToInt32(fila["AlumnoId"]);
                //    AlumnosLogica.ActualizarEstadoInicializado(id, 0);
                //    AlumnosLogica.EliminarAlumno(id);
                //    AlumnosLogica.BajaAlumnoCarrera(id);
                //    continue;
                //    }
                if (Convert.ToInt32(fila["Inicializado"]) == 3)
                    continue;

                if (fila["Inicializado"] != DBNull.Value && Convert.ToInt32(fila["Inicializado"]) != 2)
                {
                    int id = Convert.ToInt32(fila["AlumnoId"]);
                    AlumnosLogica.EliminarAlumnoCompleto(id);
                }
            }

            CicloLectivosLogica.IngresoCursadaPrimeroSP(CicloLectivosLogica.ObtenerCicloLectivoActual(), carreraId);
            this.Notificar(TipoNotificacion.Information, "Se han cargados los alumnos correctamente a los primeros años de la carrera" );
            RecargarGrilla();
        }
    }
}
