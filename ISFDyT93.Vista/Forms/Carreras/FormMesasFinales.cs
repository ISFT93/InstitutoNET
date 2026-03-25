using System;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Forms.Common;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormMesasFinales : FormBase
    {
        #region Publics

        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        public int AnioLectivoId { get; set; }
        public int TurnoId { get; set; }
        public bool FechaUnica { get; set; }
        public int LlamadoId { get; set; }
        #endregion

        #region Privates
        MesasFinalesLogica mesasFinalesLogica;
        private int MesaFinalId, anioLectivoId, turnoId, llamadoId;
        private DateTime Fecha;

        #endregion
        public FormMesasFinales()
        {
            InitializeComponent();
            mesasFinalesLogica = new MesasFinalesLogica();
        }

        private void FormMesasFinales_Load(object sender, EventArgs e)
        {
            Contenedor.SetTitulo($"Mesas Finales de {NombreCarrera}").SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormCarreras>();
            });

            CargarTurnos();
            if (LlamadoId != 0 && !FechaUnica)
                CargarLlamados(false);
            else
                CargarLlamados(true);
            CargarAniosLectivos();
            ControlLlamados();
            DGVRefresh();
        }

        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Agregar;
                form.CarreraId = this.CarreraId;
                form.NombreCarrera = this.NombreCarrera;
                form.AnioLectivoId = Convert.ToInt32(cmbAnioLectivo.SelectedValue);
            });
        }

        //private void tsmEliminarFecha_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = MessageBox.Show("Desea eliminar la Mesa seleccionada?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (dr == DialogResult.Yes)
        //    {
        //        int res = mesasFinalesLogica.EliminarMesa(this.MesaFinalId);
        //        if (res > 0)
        //        {
        //            Notificar(TipoNotificacion.Success, "Mesa eliminada correctamente");
        //            CargarGrilla();
        //        }
        //        else
        //            Notificar(TipoNotificacion.Error, "Ocurrió un error");
        //    }
        //}

        private void CargarTurnos()
        {
            cmbTurno.DataSource = mesasFinalesLogica.ObtenerTurnos(true);
            cmbTurno.DisplayMember = "Descripcion";
            cmbTurno.ValueMember = "TurnoId";
            if (TurnoId != 0)
                cmbTurno.SelectedValue = this.TurnoId;
            turnoId = (int)cmbTurno.SelectedValue;
        }

        private void CargarLlamados(bool fechaUnica)
        {
            cmbLlamados.DataSource = mesasFinalesLogica.ObtenerLlamados(fechaUnica);
            cmbLlamados.DisplayMember = "Descripcion";
            cmbLlamados.ValueMember = "LlamadoId";

            if (LlamadoId != 0)
            {
                cmbLlamados.SelectedValue = this.LlamadoId;
                cmbLlamados.Text = "Text";
                this.LlamadoId = 0;
            }
                
            llamadoId = (int)cmbLlamados.SelectedValue;
            
        }

        private void CargarAniosLectivos()
        {
            cmbAnioLectivo.DataSource = mesasFinalesLogica.ObtenerAniosLectivos();
            cmbAnioLectivo.DisplayMember = "CicloLectivoId";
            cmbAnioLectivo.ValueMember = "CicloLectivoId";
            if (AnioLectivoId != 0)
                cmbLlamados.SelectedValue = this.AnioLectivoId;
            anioLectivoId = (int)cmbAnioLectivo.SelectedValue;
        }

        private void cmbAnioLectivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            anioLectivoId = (int)cmbAnioLectivo.SelectedValue;
            DGVRefresh();
        }

        private void cmbLlamados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            llamadoId = (int)cmbLlamados.SelectedValue;
            DGVRefresh();
        }

        private void cmbTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            turnoId = (int)cmbTurno.SelectedValue;
            ControlLlamados();
            DGVRefresh();
        }

        private void btnReporteMesas_Click(object sender, EventArgs e)
        {
            var data = this.mesasFinalesLogica.ObtenerMesasReporte(this.CarreraId, anioLectivoId, turnoId, llamadoId);

            this.Contenedor.SetTitulo("Imprimir Fechas Finales").AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.MesasFinales.rdlc")
                .AddDataSource(data, "DSMesasFinales")
                .AddParameter("Carrera", this.NombreCarrera)
                .AddParameter("Turno", cmbTurno.Text)
                .AddParameter("Llamado", cmbLlamados.Text)
                .AddParameter("AnioLectivo", cmbAnioLectivo.Text);
            });
        }

        private void dgvMesasFinales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarFechasFinales>(form =>
            {
                form.Accion = TipoAccion.Modificar;
                form.CarreraId = this.CarreraId;
                form.NombreCarrera = this.NombreCarrera;
                form.MesaFinalId = (int)dgvMesasFinales.Rows[e.RowIndex].Cells["MesaFinalId"].Value;
                form.Fecha = DateTime.Now;
                form.AnioLectivoId = (int)cmbAnioLectivo.SelectedValue;
                form.TurnoId = (int)cmbTurno.SelectedValue;
                form.LlamadoId = (int)cmbLlamados.SelectedValue;
            });
        }

        private void DGVRefresh()
        {
            dgvMesasFinales.DataSource = mesasFinalesLogica.ObtenerMesasFiltro(this.CarreraId, anioLectivoId, turnoId, llamadoId);
            dgvMesasFinales.Columns["MesaFinalId"].Visible = false;
            dgvMesasFinales.Columns["Turno"].Visible = false;
            dgvMesasFinales.Columns["Llamado"].Visible = false;
        }

        private void ControlLlamados()
        {
            if ((int)cmbTurno.SelectedValue != 3)
            {
                CargarLlamados(true);
                cmbLlamados.Enabled = false;
            }
            else
            {
                CargarLlamados(false);
                cmbLlamados.Enabled = true;
            }
        }
    }
}
