using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormAgregarModificarEquivalencias : FormBase
    {
        #region Propiedades públicas
        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; }
        #endregion

        #region Propiedades privadas
        private CarrerasLogica carrerasLogica;
        private EquivalenciasLogica equivalenciasLogica;
        private DataTable dtMaterias, dtMateriasEquivalentes;
        private int EquivalenciaId;
        #endregion

        public FormAgregarModificarEquivalencias()
        {
            InitializeComponent();
            equivalenciasLogica = new EquivalenciasLogica();
        }

        private void FormAgregarModificarEquivalencias_Load(object sender, EventArgs e)
        {
            Contenedor.SetTitulo("Equivalencias de " + NombreCarrera).SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormCarreras>();
            }); 
            cmbCarreras.DataSource = equivalenciasLogica.ObtenerCarreras(CarreraId);
            cmbCarreras.DisplayMember = "DescripcionCorta";
            cmbCarreras.ValueMember = "CarreraId";
            cargarListaMaterias();
            cargarListaEquivalentes();
            cargarGrillaEquivalencias(CarreraId, Convert.ToInt32(cmbCarreras.SelectedValue));
        }

        private void cmbCarreras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarListaMaterias();
            cargarListaEquivalentes();
            cargarGrillaEquivalencias(CarreraId, Convert.ToInt32(cmbCarreras.SelectedValue));
        }

        private void cargarListaMaterias()
        {
            dtMaterias = equivalenciasLogica.ObtenerMaterias(CarreraId);
            lstMaterias.DataSource = dtMaterias;
            lstMaterias.DisplayMember = "Nombre";
            lstMaterias.ValueMember = "MateriaId";
        }
        private void cargarListaEquivalentes()
        {
            dtMateriasEquivalentes = equivalenciasLogica.ObtenerMaterias(Convert.ToInt32(cmbCarreras.SelectedValue));
            lstEquivalentes.DataSource = dtMateriasEquivalentes;
            lstEquivalentes.DisplayMember = "Nombre";
            lstEquivalentes.ValueMember = "MateriaId";
        }

        private void cargarGrillaEquivalencias(int CarreraId, int CarreraEquivalenciaId)
        {
            dgvEquivalencias.DataSource = equivalenciasLogica.ObtenerEquivalencias(CarreraId, CarreraEquivalenciaId);
            dgvEquivalencias.Columns["EquivalenciaId"].Visible = false;
            dgvEquivalencias.Columns["MateriaId"].Visible = false;
            dgvEquivalencias.Columns["MateriaEquivalenciaId"].Visible = false;
            removerMaterias();

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            equivalenciasLogica.AsignarEquivalencia(CarreraId, Convert.ToInt32(lstMaterias.SelectedValue), Convert.ToInt32(cmbCarreras.SelectedValue), Convert.ToInt32(lstEquivalentes.SelectedValue));
            cargarListaMaterias();
            cargarListaEquivalentes();
            cargarGrillaEquivalencias(CarreraId, Convert.ToInt32(cmbCarreras.SelectedValue));
            removerMaterias();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (EquivalenciaId == 0)
            {
                EquivalenciaId = Convert.ToInt32(dgvEquivalencias["EquivalenciaId", 0].Value);
                equivalenciasLogica.EliminarEquivalencia(EquivalenciaId);
                EquivalenciaId = 0;
            }
            else
                equivalenciasLogica.EliminarEquivalencia(EquivalenciaId);
            cargarListaMaterias();
            cargarListaEquivalentes();
            cargarGrillaEquivalencias(CarreraId, Convert.ToInt32(cmbCarreras.SelectedValue));
            removerMaterias();
        }

        private void dgvEquivalencias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EquivalenciaId = Convert.ToInt32(dgvEquivalencias["EquivalenciaId", e.RowIndex].Value);
        }

        private void removerMaterias()
        {
            for (int j = 0; j < dgvEquivalencias.Rows.Count; j++)
            {
                for (int m = 0; m < dtMaterias.Rows.Count; m++)
                {
                    if (dtMaterias.Rows[m]["MateriaId"].ToString() == dgvEquivalencias.Rows[j].Cells["MateriaId"].Value.ToString())
                    {
                        dtMaterias.Rows.RemoveAt(m);
                    }
                    else if (dtMaterias.Rows[m]["MateriaId"].ToString() == dgvEquivalencias.Rows[j].Cells["MateriaEquivalenciaId"].Value.ToString())
                    {
                        dtMaterias.Rows.RemoveAt(m);
                    }
                }

                dtMaterias.AcceptChanges();

                for (int x = 0; x < lstEquivalentes.Items.Count; x++)
                {
                    if (dtMateriasEquivalentes.Rows[x]["MateriaId"].ToString() == dgvEquivalencias.Rows[j].Cells["MateriaEquivalenciaId"].Value.ToString())
                    {
                        dtMateriasEquivalentes.Rows.RemoveAt(x);
                    }
                    else if (dtMateriasEquivalentes.Rows[x]["MateriaId"].ToString() == dgvEquivalencias.Rows[j].Cells["MateriaId"].Value.ToString())
                    {
                        dtMateriasEquivalentes.Rows.RemoveAt(x);
                    }
                }

                dtMateriasEquivalentes.AcceptChanges();
            }

        }
    }
}
