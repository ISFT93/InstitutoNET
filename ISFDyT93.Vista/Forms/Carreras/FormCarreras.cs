using System;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using System.Data;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormCarreras : FormBase
    {
        #region Propiedades Publicas
        public FormPrincipal Contenedor { get; set; }
        public int CarreraId { get; set; }
        #endregion

        #region Propiedades Privadas
        private string NombreCarrera { get; set; }
        private string AccionARealizar { get; set; }

        private CarrerasLogica carrerasLogica { get; set; }
        private AniosCarreraLogica aniosCarreraLogica { get; set; }
        private CorrelativasLogica correlativasLogica { get; set; }
        private MesasFinalesLogica mesasFinalesLogica {  get; set; }
        #endregion
        private int Ticks;
        public FormCarreras()
        {
            this.carrerasLogica = new CarrerasLogica();
            this.aniosCarreraLogica = new AniosCarreraLogica();
            this.correlativasLogica = new CorrelativasLogica();
            this.mesasFinalesLogica = new MesasFinalesLogica();

            InitializeComponent();
            tmrRetrasoForm.Start();
        }

        //Metodos para actualizar grilla
        private void CargarGrillaActivoInactivo()
        {

            if (rbActivos.Checked == true)
            {
                dgvCarreras.DataSource = this.carrerasLogica.CarrerasActivas();

                CarreraEstados();
                if (dgvCarreras.Rows.Count > 0)
                {
                    //Ocultar columna de la grilla CarreraId CarreraEstadoId
                    dgvCarreras.Columns["CarreraId"].Visible = false;
                    dgvCarreras.Columns["CarreraEstadoId"].Visible = false;
                }
            }
            else
            if (rbInactivos.Checked == true)
            {
                dgvCarreras.DataSource = this.carrerasLogica.CarrerasInactivas();
                CarreraEstados();
                if (dgvCarreras.Rows.Count > 0)
                {
                    //Ocultar columna de la grilla CarreraId CarreraEstadoId
                    dgvCarreras.Columns["CarreraId"].Visible = false;
                    dgvCarreras.Columns["CarreraEstadoId"].Visible = false;
                }
            }
            else
            if (rbBorrador.Checked == true)
            {
                dgvCarreras.DataSource = this.carrerasLogica.CarrerasBorrador();
                CarreraEstados();
                if (dgvCarreras.Rows.Count > 0)
                {
                    //Ocultar columna de la grilla CarreraId CarreraEstadoId
                    dgvCarreras.Columns["CarreraId"].Visible = false;
                    dgvCarreras.Columns["CarreraEstadoId"].Visible = false;
                    dgvCarreras.Columns["Carga Horaria Completa"].Visible = false;
                }
            }

        }

        private void CambiarColor()
        {
            if (dgvCarreras.Rows.Count > 0)
            {
                for (int i = 0; i < dgvCarreras.Rows.Count; i++)
                {
                    switch (dgvCarreras.Rows[i].Cells["Estado"].Value.ToString())
                    {
                        case "Bloqueado":
                            dgvCarreras.Rows[i].Cells["Estado"].Style.ForeColor = Color.Red;
                            dgvCarreras.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Red;
                            break;
                    }
                }
            }

        }

        public void Refrescar()
        {
            rbActivos.Visible = true;
            rbInactivos.Visible = true;
            dgvCarreras.ContextMenuStrip = cmsCarreras;
            this.dgvCarreras.DataSource = this.carrerasLogica.ObtenerCarreras();

            //Ocultar columna de la grilla CarreraId CarreraEstadoId
            dgvCarreras.Columns["CarreraId"].Visible = false;
            dgvCarreras.Columns["CarreraEstadoId"].Visible = false;
            dgvCarreras.Columns["Año De Fin"].Visible = false;
            dgvCarreras.Columns["Carga Horaria Completa"].Visible = false;
            dgvCarreras.Columns["Año De Inicio"].Visible = false;

            CarreraEstados();
        }

        public void CarreraEstados()
        {
            if (dgvCarreras.Rows.Count > 0)
            {

                for (int i = 0; i < dgvCarreras.Rows.Count; i++)
                {
                    var estado = dgvCarreras.Rows[i].Cells["Estado"].Value.ToString();

                    if (estado == "Activa")
                    {
                        dgvCarreras.Rows[i].Cells["Estado"].Style.ForeColor = Color.Green;
                        dgvCarreras.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Green;
                    }
                    else if (estado == "Inactiva")
                    {
                        dgvCarreras.Rows[i].Cells["Estado"].Style.ForeColor = Color.Yellow;
                        dgvCarreras.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Yellow;
                    }
                    else
                    {
                        dgvCarreras.Rows[i].Cells["Estado"].Style.ForeColor = Color.Red;
                        dgvCarreras.Rows[i].Cells["Estado"].Style.SelectionForeColor = Color.Red;
                    }
                }
            }
        }

        private void ExistenMesasFinales()
        {
            DataTable dt = mesasFinalesLogica.ObtenerMesas(this.CarreraId);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Primero debe generar mesas finales.", "No existen mesas finales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Contenedor.AbrirFormulario<FormMesasFinales>(form =>
                {
                    form.CarreraId = this.CarreraId;
                    form.NombreCarrera = this.NombreCarrera;
                });
            }
        }

        private void FormCarreras_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetTitulo("Carreras");
            CargarGrillaActivoInactivo();

        }

        private void tsmActivar_Click(object sender, EventArgs e)
        {
            int ExisteCorrelativa = correlativasLogica.CorrelativaExisteCarrera(CarreraId);

            if (ExisteCorrelativa == 0)
            {
                DialogResult result = MessageBox.Show("En la carrera '" + this.NombreCarrera + "' no hay correlativas asignadas, Desea agregarlas?", "Asignar correlativas", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Contenedor.AbrirFormulario<FormAniosCarreras>(form =>
                    {
                        form.CarreraId = this.CarreraId;
                    });
                }
                else if (result == DialogResult.No)
                {
                    carrerasLogica.AltaCarreraActivo(CarreraId);
                    Notificar(TipoNotificacion.Success, "Carrera dada de alta con exito");
                    Refrescar();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Desea activar la carrera '" + this.NombreCarrera + "'?", "Activar carrera", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    carrerasLogica.AltaCarreraActivo(CarreraId);
                    Notificar(TipoNotificacion.Success, "Carrera dada de alta con exito");

                }

                Refrescar();
            }
        }

        private void dgvCarreras_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvCarreras.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    this.NombreCarrera = dgvCarreras["Descripción", info.RowIndex].Value.ToString();
                    this.CarreraId = Convert.ToInt32(dgvCarreras["CarreraId", info.RowIndex].Value.ToString());
                    var estado = Convert.ToInt32(dgvCarreras.Rows[info.RowIndex].Cells["CarreraEstadoId"].Value);
                    var cargaHoraria = aniosCarreraLogica.ObtenerCargaHoraria(this.CarreraId).ToString();

                    dgvCarreras.Rows[info.RowIndex].Selected = true;

                    // Control si esta Activo solo se puede ver los datos, caso contrario, si es borrador, se pueden modificar
                    if (estado == (int)CarreraEstado.Activa)
                    {
                        tsmModificarCarrera.Text = "Ver datos";
                        tsmEliminarCarrera.Text = "Bloqueado";
                        AccionARealizar = "Bloquear";
                        tsmEliminarCarrera.Image = global::ISFDyT93.Vista.Properties.Resources.eye_slash_solid;
                        tsmModificarCarrera.Visible = true;
                        tsmEliminarCarrera.Visible = true;
                        tsmVerAnios.Visible = true;
                        tsmVerCorrelativas.Visible = true;
                        tsmVerEquivalencias.Visible = true;
                        tsmDarAlta.Visible = false;
                        tsmActivar.Visible = false;
                    }
                    else if (estado == (int)CarreraEstado.Borrador)
                    {
                        tsmEliminarCarrera.Text = "Eliminar";
                        tsmEliminarCarrera.Image = global::ISFDyT93.Vista.Properties.Resources.trash_alt_solid;
                        tsmModificarCarrera.Text = "Modificar";
                        tsmAgregarCarrera.Visible = true;
                        tsmModificarCarrera.Visible = true;
                        tsmEliminarCarrera.Visible = true;
                        tsmVerAnios.Visible = true;
                        tsmVerCorrelativas.Visible = true;
                        tsmVerEquivalencias.Visible = true;
                        tsmDarAlta.Visible = false;
                        tsmActivar.Visible = true;
                    }
                    else
                    {
                        tsmModificarCarrera.Text = "Ver datos";
                        tsmAgregarCarrera.Visible = true;
                        tsmModificarCarrera.Visible = true;
                        AccionARealizar = "Eliminar";
                        tsmEliminarCarrera.Visible = false;
                        tsmVerAnios.Visible = true;
                        tsmVerCorrelativas.Visible = true;
                        tsmVerEquivalencias.Visible = true;
                        tsmDarAlta.Visible = false;
                        tsmActivar.Visible = false;
                    }

                    //Si hay una carrera en borrador no se podra agregar otra
                    if (dgvCarreras.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvCarreras.Rows.Count; i++)
                        {
                            if (estado == (int)CarreraEstado.Borrador)
                            {
                                tsmAgregarCarrera.Visible = false;
                            }
                        }
                    }

                    //Controla si coinciden las cantidades de horas cargadas y las calculadas para poder activar la carrera
                    bool Activar = true;
                    if (estado == (int)CarreraEstado.Borrador && cargaHoraria == dgvCarreras["Carga Horaria Completa", info.RowIndex].Value.ToString())
                    {
                        //Controla que no haya años vacios 
                        var anios = aniosCarreraLogica.ObtenerAniosCarrera(CarreraId);
                        for (int i = 0; i < anios.Rows.Count; i++)
                        {
                            if (anios.Rows[i]["Carga Horaria Completa"].ToString() == "0" || anios.Rows[i]["Carga Horaria Completa"].ToString() == "" || anios.Rows[i]["Carga Horaria Completa"].ToString() == null)
                            {
                                Activar = false;
                            }
                        }
                    }
                    else
                    {
                        Activar = false;
                    }

                    if (Activar == true)
                        tsmActivar.Visible = true;
                    else
                        tsmActivar.Visible = false;

                    cmsCarreras.Show(dgvCarreras, e.X - cmsCarreras.Width / 2, e.Y);
                }
                else
                {
                    tsmDarAlta.Visible = false;
                    tsmModificarCarrera.Visible = false;
                    tsmEliminarCarrera.Visible = false;
                    tsmVerCorrelativas.Visible = false;
                    tsmVerEquivalencias.Visible = false;
                    tsmActivar.Visible = false;

                    //Si hay una carrera en borrador no se podra agregar otra
                    bool agregar = true;
                    if (dgvCarreras.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvCarreras.Rows.Count; i++)
                        {
                            //var estado = dgvCarreras.Rows[i].Cells["Estado"].Value.ToString();
                            var estado = "";
                            if (estado == "Borrador")
                            {
                                agregar = false;
                            }
                        }
                    }
                    if (agregar == true)
                    {
                        tsmAgregarCarrera.Visible = true;
                    }

                    cmsCarreras.Show(dgvCarreras, e.X - cmsCarreras.Width / 2, e.Y);
                }
            }
        }

        private void tsmAgregarCarreras_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarCarrera>(form =>
            {
                form.CarreraId = this.CarreraId;
                form.Accion = TipoAccion.Agregar;
            });
        }

        private void tsmModificarCarrera_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarCarrera>(form =>
            {
                form.CarreraId = this.CarreraId;
                form.Accion = tsmModificarCarrera.Text == "Modificar" ? TipoAccion.Modificar : TipoAccion.Ver;
            });
        }
        private void tsmVerAnios_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAniosCarreras>(form =>
            {
                form.CarreraId = this.CarreraId;
            });
        }

        private void tsmEliminarCarrera_Click(object sender, EventArgs e)
        {
            if (tsmEliminarCarrera.Text == "Desactivar")
            {
                Contenedor.AbrirFormulario<FormAgregarModificarCarrera>(form =>
                {
                    form.CarreraId = this.CarreraId;
                    form.Accion = TipoAccion.Desactivar;
                });
            }
            else
            {
                //CellContentClick cuando se selecciona en el menu Eliminar
                DialogResult resultado = MessageBox.Show($"¿Desea {AccionARealizar} la Carrera '" + this.NombreCarrera + "'?",
                  "Eliminar Carrera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    carrerasLogica.EliminarCarrera(CarreraId);
                    Refrescar();
                }
            }
        }
        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaActivoInactivo();
        }
        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaActivoInactivo();
        }
        private void tsmDarAlta_Click(object sender, EventArgs e)
        {
            carrerasLogica.AltaCarreraActivo(CarreraId);
            Notificar(TipoNotificacion.Success, "Carrera dada de alta con exito");
            Refrescar();
            rbActivos.Checked = true;
        }

        private void tsmVerCorrelativas_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormVerCorrelativas>(form =>
            {
                form.CarreraId = this.CarreraId;
            });
        }

        private void tsmVerEquivalencias_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarEquivalencias>(form =>
            {
                form.CarreraId = this.CarreraId;
                form.NombreCarrera = this.NombreCarrera;
            });
        }

        private void rbBorrador_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaActivoInactivo();
        }

        private void tmrRetrasoForm_Tick(object sender, EventArgs e)
        {
            Ticks++;
            if (Ticks == 2)
                tmrRetrasoForm.Stop();
            CarreraEstados();
        }

        private void tsmVerFinales_Click(object sender, EventArgs e)
        {
            ExistenMesasFinales();
        }
    }
}

