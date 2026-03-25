using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormServicios : FormBase
    {
        #region Propiedades Públicas
        public int PersonalId { get; set; }
        #endregion

        #region Propiedades Privadas
        private int ServicioId { get; set; }
        
        private ServiciosLogica ServiciosLogica { get; set; }
        private PersonalLogica PersonalLogica { get; set; }
        private PersonalModelo Personal { get; set; }
        private List<int> ServiciosId { get; set; }
        #endregion

        public FormServicios()
        {
            this.ServiciosLogica = new ServiciosLogica();
            this.PersonalLogica = new PersonalLogica();
            this.ServiciosId = new List<int>();

            InitializeComponent();
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {
            this.Personal = this.PersonalLogica.ObtenerPersonal(this.PersonalId);

            this.Contenedor.SetTitulo($"Servicios de { Personal.Nombre } { Personal.Apellido }");

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormPersonal>();
            });

            Refrescar();
            AnchoColumnas();
        }

        public void AnchoColumnas()
        { 
            //cargo
            dgvServicios.Columns["Cargo"].Width =110;
            //Situacion
            dgvServicios.Columns["Situacion"].Width = 80;
            //Folio
            dgvServicios.Columns["Libro"].Width = 40;
            //Libro
            dgvServicios.Columns["Folio"].Width = 40;
            //Activo
            dgvServicios.Columns["Activo"].Width = 55;
        }
        
        public void Refrescar()
        {
            dgvServicios.DataSource = ServiciosLogica.ObtenerServiciosPersonal(this.PersonalId, rdbActivos.Checked ? 1 : 0);
            
            // ServicioId
            dgvServicios.Columns["ServicioId"].Visible = false;
            dgvServicios.Columns["Activo"].Visible = false;
        }

        private void tsmAsignar_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarServicios>(form =>
            {
                form.PersonalId = this.PersonalId;
            });
        }

        private void rdbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbInactivos.Checked)
            {
                Refrescar();
            }
        }

        private void rdbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbActivos.Checked)
            {
                Refrescar();
            }
        }

        private void tsmDesactivarServicio_Click(object sender, EventArgs e)
        {
            var cantidadServicios = dgvServicios.Rows.Count;

            ServiciosLogica.DesactivarServicio(this.ServicioId, cantidadServicios);
           
            Refrescar();
        }

        private void tsmLicencias_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmEvaluaciones_Click(object sender, EventArgs e)
        {  
            this.Contenedor.AbrirFormulario<FormCargaEvaluaciones>((form) => {
                form.ServicioId = ServicioId; 
            });
        }

        private void dgvServicios_MouseUp(object sender, MouseEventArgs e)
        {
            tsmEvaluaciones.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvServicios.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    dgvServicios.Rows[info.RowIndex].Selected = true;

                    if (dgvServicios.Rows[info.RowIndex].Cells[1].Value.ToString() == "Profesor/a" && rdbActivos.Checked==true) 
                        tsmEvaluaciones.Visible = true;
                    else
                        tsmEvaluaciones.Visible = false;

                     ServicioId = Convert.ToInt32(dgvServicios["ServicioId", info.RowIndex].Value.ToString()); 

                    tsmAsignarServicio.Visible = true;
                    tsmDesactivarServicio.Visible = true;

                    if (rdbInactivos.Checked == true)
                    {
                        tsmAsignarServicio.Visible = false; 
                        tsmDesactivarServicio.Visible = false;
                    }
                   
                    cmsServicios.Show(dgvServicios, e.X - cmsServicios.Width / 2, e.Y);
                }
                else
                {
                    if (rdbInactivos.Checked == true)
                    {
                        tsmAsignarServicio.Visible = false;
                        tsmDesactivarServicio.Visible = false;
                    }
                    else
                    {
                        tsmAsignarServicio.Visible = true;
                        tsmDesactivarServicio.Visible = false;
                    }
                    cmsServicios.Show(dgvServicios, e.X - cmsServicios.Width / 2, e.Y);
                }
            }
        }
    }
}


