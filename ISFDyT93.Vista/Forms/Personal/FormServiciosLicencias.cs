using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormServiciosLicencias : FormBase
    {
        #region Propiedades Públicas
        public int PersonalId { get; set; }
        #endregion

        #region Propiedades Privadas

        private LicenciaServicioLogica LicenciaLogica = new LicenciaServicioLogica();
        private ServiciosLogica ServicioLogica = new ServiciosLogica();
        private PersonalLogica PersonalLogica { get; set; }
        private PersonalModelo personal { get; set; }

        private int fila;
        #endregion

        public FormServiciosLicencias()
        {
            InitializeComponent();
        }
        #region Eventos
        private void FormServiciosLicencias_Load(object sender, EventArgs e)
        {
            personal = new PersonalLogica().ObtenerPersonal(PersonalId);

            this.Contenedor.SetTitulo($"Licencia de: {personal.Nombre} {personal.Apellido}");

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormPersonal>();
            });

            CargarCombobox();
            CargarGrilla();
            IniciarDataTimePicker();
        }

        
        private void cmbLicencias_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        
        private void btnCertificado_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdCertificados = new OpenFileDialog();
            ofdCertificados.Filter = "Pdf Files |*.pdf";
            ofdCertificados.Title = "Cargar PDF";

            if (ofdCertificados.ShowDialog() == DialogResult.OK)
            {
                txtCertificado.Text = ofdCertificados.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        { 
        }

        private void txtCertificado_TextChanged(object sender, EventArgs e)
        {
            btnEliminar.Visible = (txtCertificado.Text.Trim() != "");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtCertificado.Clear();
        }

        private void chkFin_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaBaja.Enabled = chkFin.Checked;
        }

        private void dgvServicios_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (e.X > -1 && e.Y > -1)
                {
                    DataGridView.HitTestInfo info = dgvServicios.HitTest(e.X, e.Y);
                    if (info.RowIndex > -1)
                    {
                        cmsInscripciones.Show(dgvServicios, e.X - cmsInscripciones.Width / 2, e.Y);
                        fila = info.RowIndex;
                        tsmAsignar.Visible = true;
                    }
                }
            }
        }

        private void tsmAsignar_Click(object sender, EventArgs e)
        {

            dgvServicios.Rows[fila].Cells["Asignar"].Style.ForeColor = Color.Green;
            dgvServicios.Rows[fila].Cells["Asignar"].Value = "Asignado";
            dgvServicios.ClearSelection();
        }
        private void tmsLimpiar_Click(object sender, EventArgs e)
        {
            dgvServicios.Rows[fila].Cells["Asignar"].Value = "";
        }
        private void IniciarDataTimePicker()
        {
            dtpFechaAlta.Value = DateTime.Now;
            dtpFechaBaja.Value = DateTime.Now;
        }
        private void CargarCombobox()
        {

            cmbLicencias.ValueMember = "TipoLicenciaId";
            cmbLicencias.DisplayMember = "Descripcion";
            cmbLicencias.DataSource = this.LicenciaLogica.ObtenerLicenciasTipo();
        }
        private void CargarGrilla()
        {
            dgvServicios.DataSource = new LicenciaServicioLogica().ObtenerLicencias(PersonalId);
            EstilosGrilla();
        }
        #endregion

        #region Metodos
        private void EstilosGrilla()
        {
            if (dgvServicios.Columns.Contains("LicenciaId"))
                dgvServicios.Columns["LicenciaId"].Visible = false;
            if (dgvServicios.Columns.Contains("PersonalId"))
                dgvServicios.Columns["PersonalId"].Visible = false;
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
            {
                Visibles(false);
                btnAgregar.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleDown;
            }
            else
            {
                btnAgregar.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleUp;
                Visibles(true);
            }
        }
        private void Visibles(bool estado)
        {
            chkFin.Visible = estado;
            label1.Visible = estado;
            label2.Visible = estado;
            label3.Visible = estado;
            label4.Visible = estado;
            label6.Visible = estado;
            cmbCargo.Visible = estado;
            cmbLicencias.Visible = estado;
            txtComentarios.Visible = estado;
            panel1.Visible = estado;
            dtpFechaAlta.Visible = estado;
            dtpFechaBaja.Visible = estado;
            btnGuardar.Visible = estado;
            txtCertificado.Visible = estado;
            btnCertificado.Visible = estado;
            label5.Visible = estado;
        }
    }
}
