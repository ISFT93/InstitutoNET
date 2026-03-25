using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.Core;
using System.Collections.Generic;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormInscripcionMaterias : FormBase
    {
        #region Propiedades Públicas
        public int AlumnoId { get; set; }
        public string ApellidoNombre { get; set; }
        #endregion

        #region Propiedades Privadas

        private int fila { get; set; }
        private string MateriaId { get; set; }
        private string CursoId { get; set; }

        private List<string> ltsMateriaIdCursoId = new List<string>();
        private InscripcionAlumnoLogica InscripcionAlumnoLogica = new InscripcionAlumnoLogica();
        #endregion

        public FormInscripcionMaterias()
        {
            InitializeComponent();
        }
        private void FormInscripcionMaterias_Load(object sender, EventArgs e)
        {
            DataTable dt = InscripcionAlumnoLogica.ObtenerAniosVigentes(AlumnoId);
            DataRow dr = dt.NewRow();
            dr["Anio"] = "Todos";
            dt.Rows.InsertAt(dr, 0);
            cmbAnio.DataSource = dt;
            cmbAnio.ValueMember = "Anio";
            cmbAnio.DisplayMember = "Anio";            

            cargarGrilla();

            this.Contenedor.SetTitulo("Incripción: " + ApellidoNombre);

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });
        }

        #region DataGridView
        public void cargarGrilla()
        {
            dgvInscripcionAlumnos.Columns.Clear();
            if (cmbAnio.SelectedIndex > -1)
            {
                string anio = "";
                if (cmbAnio.SelectedIndex > 0) anio = cmbAnio.SelectedValue.ToString();
                dgvInscripcionAlumnos.DataSource = InscripcionAlumnoLogica.ObtenerMateriasVigentes(this.AlumnoId, anio);
                EstilosColumnasDGV();
            }
        }
        private void EstilosColumnasDGV()
        {
            if (dgvInscripcionAlumnos.Columns.Contains("CursoId"))
                dgvInscripcionAlumnos.Columns["CursoId"].Visible = false;
            if (dgvInscripcionAlumnos.Columns.Contains("MateriaId"))
                dgvInscripcionAlumnos.Columns["MateriaId"].Visible = false;          
            if (dgvInscripcionAlumnos.Columns.Contains("Año"))
                dgvInscripcionAlumnos.Columns["Año"].FillWeight = 50;
            if (dgvInscripcionAlumnos.Columns.Contains("Carrera"))
                dgvInscripcionAlumnos.Columns["Carrera"].FillWeight = 50;
            if (dgvInscripcionAlumnos.Columns.Contains("Materia"))
                dgvInscripcionAlumnos.Columns["Materia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            if (dgvInscripcionAlumnos.Columns.Contains("Ciclo Lectivo"))
                dgvInscripcionAlumnos.Columns["Ciclo Lectivo"].FillWeight = 50;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Name = "Asignar";
            column.HeaderText = "Asignar";                
            dgvInscripcionAlumnos.Columns.Add(column);
            if (dgvInscripcionAlumnos.Columns.Contains("Asignar"))
                dgvInscripcionAlumnos.Columns["Asignar"].FillWeight = 50;
            
            foreach(DataGridViewRow row in dgvInscripcionAlumnos.Rows)
            {
                if (ltsMateriaIdCursoId.IndexOf(row.Cells["MateriaId"].Value.ToString() + row.Cells["CursoId"].Value.ToString()) != -1 )
                {
                    row.Cells["Asignar"].Value = "Asignado";
                    row.Cells["Asignar"].Style.ForeColor = Color.Green;
                }
            }
        }

        private void dgvInscripcionAlumnos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)            {
                
                if (e.X > -1 && e.Y > -1)
                {
                    DataGridView.HitTestInfo info = dgvInscripcionAlumnos.HitTest(e.X, e.Y);
                    cmsInscripciones.Show(dgvInscripcionAlumnos, e.X - cmsInscripciones.Width / 2, e.Y);
                    fila = info.RowIndex;
                    tsmAsignar.Visible = true;
                }
            }
        }

        private void tsmAsignar_Click(object sender, EventArgs e)
        {
            CursoId = dgvInscripcionAlumnos.Rows[fila].Cells["CursoId"].Value.ToString();
            MateriaId = dgvInscripcionAlumnos.Rows[fila].Cells["MateriaId"].Value.ToString();
            ltsMateriaIdCursoId.Add(MateriaId + CursoId);
            dgvInscripcionAlumnos.Rows[fila].Cells["Asignar"].Style.ForeColor = Color.Green;
            dgvInscripcionAlumnos.Rows[fila].Cells["Asignar"].Value = "Asignado";
            dgvInscripcionAlumnos.ClearSelection();
        }
        #endregion
        #region Botones
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int count = 0;
            int countOk = 0;
            for (int i = 0; i <= dgvInscripcionAlumnos.Rows.Count - 1; i++)
            {
                if (dgvInscripcionAlumnos.Rows[i].Cells["Estado"].Value != null || dgvInscripcionAlumnos.Rows[i].Cells["Cursada"].Value != null)
                {
                    var Modelo = new InscripcionMateriasModelo
                    {
                        cursadaAlumnoId = Convert.ToInt32(dgvInscripcionAlumnos.Rows[i].Cells["CursadaAlumnoCarreraId"].Value),
                        cursada = dgvInscripcionAlumnos.Rows[i].Cells["Cursada"].Value.ToString(),
                        estado = dgvInscripcionAlumnos.Rows[i].Cells["Estado"].Value.ToString()
                    };

                    count++;
                    int result = InscripcionAlumnoLogica.actualizarEstadoCursada(Modelo);
                    if (result == 1)
                        countOk++;
                }
            }

            if (count == countOk)
                Notificar(TipoNotificacion.Success, "Actualizado correctamente");
            cargarGrilla();
        }
        #endregion

        private void tmsLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
