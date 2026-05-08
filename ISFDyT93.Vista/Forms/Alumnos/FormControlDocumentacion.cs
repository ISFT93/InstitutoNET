using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class ControlDocumentacion : FormBase
    {
        private AlumnosLogica _logica = new AlumnosLogica();
        private CarrerasLogica _carreraLogica = new CarrerasLogica();

        public ControlDocumentacion()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += ControlDocumentacion_Load;
            this.btnEnvioMail.Click += btnEnvioMail_Click;
            this.dgvAlumnos.CellDoubleClick += dgvAlumnos_CellDoubleClick;

            // Filtros que actualizan la grilla al cambiar
            this.cmbFiltroAlum.SelectedIndexChanged += (s, e) => ActualizarGrilla();
            this.rbICompleto.CheckedChanged += (s, e) => { if (rbICompleto.Checked) ActualizarGrilla(); };
            this.rbTodos.CheckedChanged += (s, e) => { if (rbTodos.Checked) ActualizarGrilla(); };
        }

        private void ControlDocumentacion_Load(object sender, EventArgs e)
        {
            if (this.Contenedor != null)
            {
                this.Contenedor.SetTitulo("Control de Documentación");

                // --- CAMBIO SOLICITADO ---
                // Configuramos la flecha azul para que regrese a la pantalla de Alumnos
                this.Contenedor.SetVolver(() => this.Contenedor.AbrirFormulario<FormAlumnos>());
            }

            CargarCarreras();
            ActualizarGrilla();
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.Contenedor != null)
            {
                int id = Convert.ToInt32(dgvAlumnos.Rows[e.RowIndex].Cells["AlumnoId"].Value);

                // Al entrar a la ficha, la flecha ahora debe volver a ESTA pantalla (Control)
                this.Contenedor.AbrirFormulario<FormFichaDocumentacion>(f => f.SetAlumnoId(id));

                this.Contenedor.SetVolver(() => this.Contenedor.AbrirFormulario<ControlDocumentacion>());
            }
        }

        private void ActualizarGrilla()
        {
            try
            {
                int estadoFiltro = 0;
                if (rbICompleto.Checked) estadoFiltro = 2;
                if (rbTodos.Checked) estadoFiltro = -1;

                DataTable dt = _logica.ObtenerAlumnosPorEstadoDocumentacion(estadoFiltro);
                dgvAlumnos.DataSource = dt;

                if (dgvAlumnos.Columns.Contains("AlumnoId")) dgvAlumnos.Columns["AlumnoId"].Visible = false;
                CalcularYMostrarTotales(dt);
            }
            catch (Exception ex)
            {
                this.Notificar(TipoNotificacion.Success, "Error: " + ex.Message);
            }
        }

        private void CalcularYMostrarTotales(DataTable dt)
        {
            int total = dt.Rows.Count;
            int sin = dt.AsEnumerable().Count(r => Convert.ToInt32(r["Inicializado"]) == 0);
            int pen = dt.AsEnumerable().Count(r => Convert.ToInt32(r["Inicializado"]) == 1);

            // Buscamos los labels dinámicamente para evitar errores de referencia
            if (this.Controls.Find("lblTotalAlumnos", true).FirstOrDefault() is Label lblT) lblT.Text = total.ToString();
            if (this.Controls.Find("lblSinProcesar", true).FirstOrDefault() is Label lblS) lblS.Text = sin.ToString();
            if (this.Controls.Find("lblPendientes", true).FirstOrDefault() is Label lblP) lblP.Text = pen.ToString();
        }

        private void btnEnvioMail_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                int enviados = 0;
                foreach (DataGridViewRow fila in dgvAlumnos.SelectedRows)
                {
                    int id = Convert.ToInt32(fila.Cells["AlumnoId"].Value);
                    if (Convert.ToInt32(fila.Cells["Inicializado"].Value) == 0)
                    {
                        _logica.ActualizarEstadoInicializado(id, 1);
                        enviados++;
                    }
                }
                this.Notificar(TipoNotificacion.Success, $"{enviados} Mails enviados.");
                ActualizarGrilla();
            }
        }

        private void CargarCarreras()
        {
            var dt = _carreraLogica.ObtenerCarreras();
            cmbFiltroAlum.DataSource = dt;
            cmbFiltroAlum.DisplayMember = "Nombre";
            cmbFiltroAlum.ValueMember = "CarreraId";
        }
    }
}