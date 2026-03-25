using System;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormCargaEvaluaciones : FormBase
    {
        public int ServicioId { get; set; }
        public int CursadaId { get; set; }
        public int CursadaExamenId { get; set; }
        EvaluacionesLogica evaluacionesLogica;
        public FormCargaEvaluaciones()
        {
            evaluacionesLogica = new EvaluacionesLogica();
            InitializeComponent();
        }
        private void FormCargaEvaluaciones_Load(object sender, EventArgs e)
        {
            var Alumnos = evaluacionesLogica.ObtenerAlumnos(ServicioId);
            CursadaId =Convert.ToInt32(Alumnos.Rows[0][3]);
            for (int i = 0; i < Alumnos.Rows.Count; i++)
            {
                dgvEvaluaciones.Rows.Add();
                //CursadaAlumnoCarreraId
                dgvEvaluaciones.Rows[i].Cells[0].Value = Alumnos.Rows[i][0].ToString();
                //Nombre y apellido
                dgvEvaluaciones.Rows[i].Cells[1].Value = Alumnos.Rows[i][1].ToString();
                //Condicion
                dgvEvaluaciones.Rows[i].Cells[2].Value = Alumnos.Rows[i][2].ToString();

            }

            for (int i = 0; i < dgvEvaluaciones.Rows.Count; i++)
            {
                if (dgvEvaluaciones.Rows[i].Cells[2].Value.ToString().Trim() == "L")
                {
                    dgvEvaluaciones.Rows[i].Cells[3].ReadOnly = true;
                }
            }
            var UltimoExamenId = this.evaluacionesLogica.ObtenerUltimoExamenId();
            CursadaExamenId = Convert.ToInt32(UltimoExamenId["CursadaExamenId"]);

           // btnGuardar.Enabled = false;
        }

        private void dgvEvaluaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvEvaluaciones.Columns[e.ColumnIndex].Name == "Parcial1")
            {

                if (Convert.ToInt32(dgvEvaluaciones.Rows[e.RowIndex].Cells[3].Value) >= 4)
                {
                    dgvEvaluaciones.Rows[e.RowIndex].Cells[5].Value = dgvEvaluaciones.Rows[e.RowIndex].Cells[3].Value;
                }
                else
                {
                    dgvEvaluaciones.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                }
            }

            if (dgvEvaluaciones.Columns[e.ColumnIndex].Name == "Recuperatorio1")
            {

                dgvEvaluaciones.Rows[e.RowIndex].Cells[5].Value = dgvEvaluaciones.Rows[e.RowIndex].Cells[4].Value;

            }
           // PrimerInforme();
        }
        public int CantidadEvaluados;
        public int CantidadLibres;

        public void PrimerInforme()
        {
             CantidadEvaluados=0;
             CantidadLibres=0;
            for (int i = 0; i < dgvEvaluaciones.Rows.Count; i++)
            {
                if(dgvEvaluaciones.Rows[i].Cells[2].Value.ToString().Trim() == "L")
                {
                    CantidadLibres++;
                }

                if(dgvEvaluaciones.Rows[i].Cells[5].Value.ToString() != "" )
                {
                    CantidadEvaluados++;
                }
                 
            }

            if(CantidadEvaluados == (dgvEvaluaciones.Rows.Count - CantidadLibres))
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int result = evaluacionesLogica.AsignarFechaExamen(CursadaId, dtpFechaExamen.Value, 0);
            if (result > 0)
            {
                Notificar(TipoNotificacion.Success, "Fecha de examen generada correctamente.");
            }
        }
    }
}
