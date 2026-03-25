using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Datos.Enums;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormMateriasAnioCarrera : Form
    {
        #region Propiedades Publicas
        public FormPrincipal Contenedor { get; set; }

        public int AnioCarreraId { get; set; }
        #endregion

        #region Propiedades Privadas
        private AniosCarrerasModelo anioCarrera { get; set; }

        private int MateriaId { get; set; }

        private MateriasLogica materiasLogica { get; set; }
        private AniosCarreraLogica aniosLogica { get; set; }
        #endregion
        
        public FormMateriasAnioCarrera()
        {
            this.materiasLogica = new MateriasLogica();
            this.aniosLogica = new AniosCarreraLogica();

            InitializeComponent();   
        }

        private void FormMateriasAnioCarrera_Load(object sender, EventArgs e)
        {   
            this.anioCarrera = this.aniosLogica.ObtenerAnioCarrera(this.AnioCarreraId);

            dgvMatAnioCarrera.DataSource = this.materiasLogica.ObtenerMaterias(this.AnioCarreraId);
            dgvMatAnioCarrera.Columns["MateriaId"].Visible = false;
            dgvMatAnioCarrera.Columns["AnioCarreraId"].Visible = false;
            dgvMatAnioCarrera.Columns["EspacioId"].Visible = false;
            dgvMatAnioCarrera.Columns["Carga Horaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatAnioCarrera.Columns["Correlativas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (this.anioCarrera.AnioCarrera == 1)
            {
                tsmVerCorrelatividades.Visible = false;
            }

            this.Contenedor.SetTitulo($"Materias de { this.anioCarrera.AnioCarrera } año de { anioCarrera.NombreCarrera }")
                .SetVolver(() => {
                    this.Contenedor.AbrirFormulario<FormAniosCarreras>((form) => {
                       form.CarreraId = this.anioCarrera.CarreraId;
                   });
                }
            );

            CalcularHoras();
        }

        private void tsmAgregarMateria_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form => {
                form.AnioCarreraId = this.AnioCarreraId;
                form.MateriaId = this.MateriaId;
                form.Accion = TipoAccion.Agregar;
            }); 
        }

        private void tsmModificarMateria_Click(object sender, EventArgs e)
        {
            if (tsmModificarMateria.Text == "Modificar")
            {
                Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form => {
                    form.AnioCarreraId = this.AnioCarreraId;
                    form.MateriaId = this.MateriaId;
                    form.Accion = TipoAccion.Modificar;
                });
            }
            else
            {
                Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form => {
                    form.AnioCarreraId = this.AnioCarreraId;
                    form.MateriaId = this.MateriaId;
                    form.Accion = TipoAccion.Ver;
                });
            }
        }

        private void tsmVerCorrelatividades_Click(object sender, EventArgs e)
        {
            if (MateriaId > 0)
            {
                Contenedor.AbrirFormulario<FormAgregarModificarCorrelativa>(form => {
                    form.MateriaId = this.MateriaId;
                    form.DescripcionCarrera = anioCarrera.NombreCarrera;
                });
            }
        }

        private void tsmEliminarMateria_Click(object sender, EventArgs e)
        {
            //CellContentClick cuando se selecciona en el menu Eliminar
            DialogResult resultado = MessageBox.Show("¿Desea eliminar la Materia seleccionada?",
            "Eliminar Materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                materiasLogica.EliminarMateria(this.MateriaId, this.AnioCarreraId);
                
                dgvMatAnioCarrera.DataSource = this.materiasLogica.ObtenerMaterias(this.AnioCarreraId); 
                //Ocultar columna de la grilla
                dgvMatAnioCarrera.Columns["MateriaId"].Visible = false;
            }

            CalcularHoras();
        }

        private void CalcularHoras()
        {
            int formacionBasica = 0, formacionEspecifica = 0, formacionInstitucional = 0, cargaHorariaTotal = 0;

            if (dgvMatAnioCarrera.RowCount > 0)
            {
                for (int i = 0; i < dgvMatAnioCarrera.RowCount; i++)
                {
                    int espacio = Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["EspacioId"].Value);
                    if (espacio == 1)
                    {
                        formacionBasica += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
                    }
                    if (espacio == 2)
                    {
                        formacionEspecifica += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
                    }
                    else if (espacio == 3)
                    {
                        formacionInstitucional += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
                    }
                }
                cargaHorariaTotal = formacionEspecifica + formacionBasica + formacionInstitucional;
                lblDescripcion.Text = "Formacion basica: " + formacionBasica + "\nFormacion especifica: " + formacionEspecifica + "\nFormacion institucional: " + formacionInstitucional + "\nCarga horaria total: " + cargaHorariaTotal;
            }
            else
            {
                lblDescripcion.Text = "Formacion basica: " + formacionBasica + "\nFormacion especifica: " + formacionEspecifica + "\nFormacion institucional: " + formacionInstitucional + "\nCarga horaria total: " + cargaHorariaTotal;
            }
        }

        private void dgvMatAnioCarrera_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvMatAnioCarrera.HitTest(e.X, e.Y);
                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    dgvMatAnioCarrera.Rows[info.RowIndex].Selected = true;
                    //Obtengo MateriaID y AnioCarreraID de la grilla

                    MateriaId = Convert.ToInt32(dgvMatAnioCarrera["MateriaId", info.RowIndex].Value.ToString());

                    //ACTIVA o INACTIVA
                    if (this.anioCarrera.CarreraEstadoId == (int)CarreraEstado.Activa || this.anioCarrera.CarreraEstadoId == (int)CarreraEstado.Inactiva)
                    {
                        tsmAgregarMateria.Visible = false;
                        tsmEliminarMateria.Visible = false;
                        tsmModificarMateria.Text = "Ver materias";
                    }
                    else if (anioCarrera.CarreraEstadoId == (int)CarreraEstado.Borrador)
                    {
                        //BORRADOR
                        tsmAgregarMateria.Visible = true;
                        tsmEliminarMateria.Visible = true;
                        tsmModificarMateria.Visible = true;
                        tsmModificarMateria.Text = "Modificar";
                        tsmVerCorrelatividades.Visible = this.anioCarrera.AnioCarrera != 1;
                    }

                    cmsMaterias.Show(dgvMatAnioCarrera, e.X - cmsMaterias.Width / 2, e.Y);
                }
                else
                {
                    if (anioCarrera.CarreraEstadoId == 2 || anioCarrera.CarreraEstadoId == 1)
                    {
                        tsmAgregarMateria.Visible = false;
                    }

                    tsmEliminarMateria.Visible = false;
                    tsmModificarMateria.Visible = false;
                    tsmVerCorrelatividades.Visible = false;
                    cmsMaterias.Show(dgvMatAnioCarrera, e.X - cmsMaterias.Width / 2, e.Y);
                }
            }
        }
    }
}

