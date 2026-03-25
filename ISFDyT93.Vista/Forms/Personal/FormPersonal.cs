using System;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Vista.Core;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormPersonal : FormBase
    {
        #region Propiedades Privadas
        private PersonalLogica personalLogica { get; set; }
        private int PersonalId { get; set; }
        private string Estado  { get; set; }
        #endregion

        public FormPersonal()
        {
            this.personalLogica = new PersonalLogica();
            InitializeComponent();
        }

        private void FormProfesores_Load(object sender, EventArgs e)
        {
            cmbFiltro.SelectedIndex = 0;
            RecargarGrilla();

            this.Contenedor.SetTitulo("Personal");

            dgvPersonal.Columns["PersonalEstadoId"].Visible = false;
            PropiedadesTabla();
        }

        public void PersonalEstados()
        {
            if (dgvPersonal.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPersonal.Rows.Count; i++)
                {
                    if (dgvPersonal.Rows[i].Cells["PersonalEstadoId"].Value.ToString() == "1")
                        dgvPersonal.Rows[i].Cells["PersonalEstadoId"].Style.ForeColor = Color.Green;
                    else if (dgvPersonal.Rows[i].Cells["PersonalEstadoId"].Value.ToString() == "2")
                        dgvPersonal.Rows[i].Cells["PersonalEstadoId"].Style.ForeColor = Color.Yellow;
                    else
                        dgvPersonal.Rows[i].Cells["PersonalEstadoId"].Style.ForeColor = Color.Red;
                }
            } 
        }

        public void CambiarColorEstado()
        {
            if (dgvPersonal.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPersonal.Rows.Count; i++)
                {
                    switch (dgvPersonal.Rows[i].Cells["Estado"].Value.ToString())
                    {
                        case "Borrador":
                            dgvPersonal.Rows[i].Cells["Estado"].Style.ForeColor = Color.Red;
                            dgvPersonal.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Red;
                            break;
                        case "Desactivada":
                            dgvPersonal.Rows[i].Cells["Estado"].Style.ForeColor = Color.Yellow;
                            dgvPersonal.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Yellow;
                            break;
                        case "Activa":
                            dgvPersonal.Rows[i].Cells["Estado"].Style.ForeColor = Color.Green;
                            dgvPersonal.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Green;
                            break;
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.RecargarGrilla(txtFiltro.Text);
        }

        private void RecargarGrilla(string filtro = "")
        {
            var estado = rbActivos.Checked ? 1 : rbInactivos.Checked ? 2 : 0;
            var tipo = (TipoFiltroProfesor)cmbFiltro.SelectedIndex;

            dgvPersonal.DataSource = personalLogica.ObtenerListaPersonal(tipo, filtro, estado);

            dgvPersonal.Columns["PersonalId"].Visible = false;
            PersonalEstados();
            CambiarColorEstado();
        }

        private void dgvPersonal_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvPersonal.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    dgvPersonal.Rows[info.RowIndex].Selected = true;

                    PersonalId = Convert.ToInt32(dgvPersonal["PersonalId", info.RowIndex].Value);
                    Estado = (dgvPersonal["Estado", info.RowIndex].Value).ToString();
                    var estadoId = Convert.ToInt32(dgvPersonal["PersonalEstadoId", info.RowIndex].Value);

                    tsmAgregarPersonal.Visible = true;
                    tsmLicencias.Visible = true;
                    tsmModificarPersonal.Visible = true;
                    tsmVerLegajo.Visible = true;
                    tsmVerServicios.Visible = true;
                    tsmSeparador.Visible = true;
                    tsmDocumentacion.Visible = true;
                    tsmHorarios.Visible = true;
                    tsmDarBaja.Visible = true;
                    tsmDarAlta.Visible = false;
                    tsmEliminar.Visible = false;

                    if (Estado == "Borrador")
                    {
                        tsmHorarios.Visible = false;
                        tsmLicencias.Visible = false;
                        tsmDocumentacion.Visible = false;
                        tsmDarBaja.Visible = false;
                        tsmEliminar.Visible = true;
                    }

                    if (estadoId == (int)PersonalEstado.Inactiva)
                    {
                        tsmAgregarPersonal.Visible = false;
                        tsmLicencias.Visible = true;
                        tsmModificarPersonal.Visible = true;
                        tsmVerLegajo.Visible = true;
                        tsmVerServicios.Visible = true;
                        tsmSeparador.Visible = false;
                        tsmDocumentacion.Visible = true;
                        tsmHorarios.Visible = false;
                        tsmDarBaja.Visible = false;
                        tsmDarAlta.Visible = false;
                    }

                    cmsPersonal.Show(dgvPersonal, e.X - cmsPersonal.Width / 2, e.Y);
                }
                else if(rbActivos.Checked)
                {
                    tsmAgregarPersonal.Visible = true;
                    tsmLicencias.Visible = false;
                    tsmModificarPersonal.Visible = false;
                    tsmVerLegajo.Visible = false;
                    tsmVerServicios.Visible = false;
                    tsmSeparador.Visible = false;
                    tsmDocumentacion.Visible = false;
                    tsmHorarios.Visible = false;
                    tsmDarBaja.Visible = false;
                    tsmDarAlta.Visible = false;

                    cmsPersonal.Show(dgvPersonal, e.X - cmsPersonal.Width / 2, e.Y);
                }
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            var check = (RadioButton)sender;

            if(check.Checked)
            {
                RecargarGrilla();
            }
        }

        private void PropiedadesTabla()
        {
            dgvPersonal.Columns["PersonalId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPersonal.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPersonal.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvPersonal.Columns["Apellido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void tsmVerLegajo_Click(object sender, EventArgs e)
        {
            personalLogica.VerLegajo(PersonalId);
        }

        private void tsmModificarPersonal_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarPersonal>(form => {
                form.Accion = TipoAccion.Modificar;
                form.PersonalId = this.PersonalId;
            });
        }

        private void tsmVerServicios_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormServicios>(form => {
                form.PersonalId = PersonalId;
            });
        }

        private void tsmAgregarPersonal_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarPersonal>(form => {
                form.Accion = TipoAccion.Agregar;
            });
        }

        private void tsmDarAlta_Click(object sender, EventArgs e)
        {
            personalLogica.DarAltaProfesores(PersonalId);
            RecargarGrilla();
        }

        private void tsmLicencias_Click(object sender, EventArgs e)
        {
            this.Contenedor.AbrirFormulario<FormServiciosLicencias>((form) =>
            {
                form.PersonalId = this.PersonalId;
            });
        }

        private void tsmDarBaja_Click(object sender, EventArgs e)
        {
            personalLogica.EliminarPersonal(PersonalId);
            RecargarGrilla();
        }

        private void tsmDocumentacion_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarDocumentacion>(form => {
                form.ProfesorId = this.PersonalId;
            });
        }

        private void tsmHorarios_Click(object sender, EventArgs e)
        {
            //Contenedor.AbrirFormulario<FormAsignarHorario>(form =>
            //{

            //});
        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            personalLogica.EliminarPersonal(PersonalId);
            RecargarGrilla();
        }

        private void tmerCambioColor_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
