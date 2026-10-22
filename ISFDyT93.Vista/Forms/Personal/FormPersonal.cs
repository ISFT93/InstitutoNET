using ISFDyT93.Entidades.Enums;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Forms.Common;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
                    Estado = (dgvPersonal["ColEstado", info.RowIndex].Value).ToString();
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

        private void dgvPersonal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPersonal.Columns[e.ColumnIndex].Name == "ColEstado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                Color foreColor = Color.Black; // Color por defecto
                Color backColor = Color.White; // Fondo por defecto

                switch (estado)
                {
                    case "Activo":
                        foreColor = Color.Green;
                        break;

                    case "Inactivo":
                        foreColor = Color.FromArgb(230, 250, 0);
                        break;

                    case "Borrador":
                        foreColor = Color.Red;
                        break;
                }

                e.CellStyle.BackColor = backColor;
                e.CellStyle.ForeColor = foreColor;

                // Esto mantiene los colores aunque la celda esté seleccionada
                e.CellStyle.SelectionBackColor = Color.LightGray;
                e.CellStyle.SelectionForeColor = foreColor;
            }
        }
        /*private DialogResult SelectorDeArchivo()
        {
            using (Form tempForm = new Form())
            {
                Label label = new Label();

                Button buttonExcel = new Button();
                Button buttonCSV = new Button();
                Button buttonCancel = new Button();

                // Estilos
                Color buttonColor = Color.FromArgb(27, 1, 124);

                foreach (Button button in new[] { buttonExcel, buttonCSV, buttonCancel })
                {
                    button.BackColor = buttonColor;
                    button.Font = new Font(
                        "Tahoma",
                        10.8F,
                        FontStyle.Regular,
                        GraphicsUnit.Point,
                        ((byte)(0))
                    );
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                }

                // Posiciones
                label.SetBounds(9, 20, 372, 13);
                buttonExcel.SetBounds(105, 72, 80, 25);
                buttonCSV.SetBounds(190, 72, 80, 25);
                buttonCancel.SetBounds(309, 72, 80, 25);

                // Propiedades
                label.AutoSize = true;

                buttonExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCSV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                tempForm.Text = "Escoger el tipo de archivo para la carga masiva.";
                label.Text = "Escoger el tipo de archivo:";

                buttonExcel.Text = "Excel";
                buttonCSV.Text = ".Csv";
                buttonCancel.Text = "Cancelar";

                buttonExcel.DialogResult = DialogResult.Yes;
                buttonCSV.DialogResult = DialogResult.No;
                buttonCancel.DialogResult = DialogResult.Cancel;

                // Formulario
                tempForm.ClientSize = new Size(396, 107);
                tempForm.Controls.AddRange(new Control[] {label, buttonExcel, buttonCSV, buttonCancel});

                tempForm.ClientSize = new Size(Math.Max(300, label.Right + 10), tempForm.ClientSize.Height);

                tempForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                tempForm.StartPosition = FormStartPosition.CenterScreen;
                tempForm.BackColor = Color.White;
                tempForm.MinimizeBox = false;
                tempForm.MaximizeBox = false;
                tempForm.AcceptButton = buttonExcel;
                tempForm.CancelButton = buttonCancel;

                return tempForm.ShowDialog();
            }
        }*/
        private void tsmCargaMasiva_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormPersonalCargaMasivaExcel>();
            this.Close();
        }
        private void dgvPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método agregado para manejar el evento de la celda de la grilla
        }

    }

}
