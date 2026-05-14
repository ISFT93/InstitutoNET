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
    public partial class FormDocumentacionAlumnos : FormBase
    {
        #region Propiedades Privadas

        private AlumnosLogica AlumnosLogica { get; set; }
        private InscripcionAlumnoLogica AlumnosInscLogica { get; set; }
        private CarrerasLogica carrerasLogica { get; set; }
        private CargaMasivaLogica CargaMasivaLogica { get; set; }
        private CicloLectivosLogica CicloLectivosLogica { get; set; }

        private int AlumnoId { get; set; }
        private string ApellidoNombre { get; set; }
        private int AlumnoCarreraId { get; set; }

        FormCargaMasivaCsv FormCarMasivaCsv = new FormCargaMasivaCsv();

        #endregion
        public FormDocumentacionAlumnos()
        {
            this.AlumnosLogica = new AlumnosLogica();
            this.AlumnosInscLogica = new InscripcionAlumnoLogica();
            this.CargaMasivaLogica = new CargaMasivaLogica();
            this.CicloLectivosLogica = new CicloLectivosLogica();
            carrerasLogica = new CarrerasLogica();  
            InitializeComponent();
        }

        private void FormDocumentacionAlumnos_Load(object sender, EventArgs e)
        {
            uscPaginacion1.dataGridView = dgvAlumnos; //pasa el datagridview a la paginacion
            cmbCarreraId.DataSource = carrerasLogica.ObtenerCarreras();
            cmbCarreraId.ValueMember = "CarreraId";
            cmbCarreraId.DisplayMember = "Descripción";
            cmbCarreraId.SelectedIndex = 0; //por defecto busca todos
            uscPaginacion1.BringToFront();

            

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

            var carreras =carrerasLogica.ObtenerCarreras();
            int tipo = 0;
            foreach (DataRow fila in carreras.Rows)
            {
                string c = fila["Descripción"].ToString();
                if (cmbCarreraId.Text == c)
                    tipo = Convert.ToInt32(fila["CarreraId"]);
            }

            if (rbTodos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(-1,tipo,filtro);
            else if (rbIncompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(1, tipo,filtro);
            else if (rbCompletos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerAlumnosPorEstadoDocumentacion(2, tipo, filtro);

            EstilosColumnasDGV();
        }
        private void EstilosColumnasDGV()
        {
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
                    }

                    e.FormattingApplied = true;
                }
            }
        }
        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // En CellDoubleClick ya dispones de las coordenadas de celda (fila/columna)

            object valor = null;
            if (dgvAlumnos.Columns.Contains("AlumnoId"))
            {
                string ini = Convert.ToString(dgvAlumnos["Inicializado", e.RowIndex].Value);
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
            string mailtexto = @"Por medio de la presente, se le solicita tenga a bien acercarse al instituto a fin de presentar la documentación correspondiente.
                                Desde ya, muchas gracias.";
            int enviados = 0;
            bool existe = dgvAlumnos.Rows
            .Cast<DataGridViewRow>()
            .Any(f => !f.IsNewRow &&
                      Convert.ToInt32(f.Cells["Inicializado"].Value) == 0);

            if (!existe)
            {
                this.Notificar(TipoNotificacion.Error, $"No hay alumnos para enviar el correo electronico.");
                return;
            }
            foreach (DataGridViewRow fila in dgvAlumnos.SelectedRows)
            {
                mailtexto = "Estimado/a " + fila.Cells["Apellido"].Value.ToString() + " " + fila.Cells["Nombre"].Value.ToString() + ",\n\n" + mailtexto;
                int id = Convert.ToInt32(fila.Cells["AlumnoId"].Value);
                string mail = fila.Cells["Correo"].Value.ToString();
                if (Convert.ToInt32(fila.Cells["Inicializado"].Value) == 0)
                {
                    bool enviado = AlumnosLogica.EnviarMailDocumentos(mail, mailasunto, mailtexto);
                    if (enviado)
                    {
                        AlumnosLogica.ActualizarEstadoInicializado(id, 1);
                        enviados++;
                    }
                    else
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
                    }
                }
            }
            this.Notificar(TipoNotificacion.Success, $"Se han {enviados} Mails enviados.");
            RecargarGrilla();
        }

        private void txtFiltroAlumno_TextChanged(object sender, EventArgs e)
        {
            RecargarGrilla(txtFiltroAlumno.Text);
        }
    }
}
