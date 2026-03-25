using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using System.Globalization;
using ISFDyT93.Vista.Forms.Componentes;
using ISFDyT93.Vista.Forms.Common;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormAlumnos : FormBase
    {
        #region Propiedades Privadas

        private AlumnosLogica AlumnosLogica { get; set; }
        private InscripcionAlumnoLogica AlumnosInscLogica { get; set; }
        private CarrerasLogica CarreraLogica { get; set; }
        private CargaMasivaLogica CargaMasivaLogica { get; set; }
        private CicloLectivosLogica CicloLectivosLogica { get; set; }

        private int AlumnoId { get; set; }
        private string ApellidoNombre { get; set; }
        private int AlumnoCarreraId { get; set; }
       
        FormCargaMasivaCsv FormCarMasivaCsv = new FormCargaMasivaCsv();

        #endregion

        public FormAlumnos()
        {
            this.AlumnosLogica = new AlumnosLogica();
            this.AlumnosInscLogica = new InscripcionAlumnoLogica();
            this.CargaMasivaLogica = new CargaMasivaLogica();
            this.CicloLectivosLogica = new CicloLectivosLogica();
            
            InitializeComponent();
        }

        private void FormAlumnos_Load(object sender, EventArgs e)
        {
            uscPaginacion1.dataGridView = dgvAlumnos; //pasa el datagridview a la paginacion            
            this.Contenedor.SetTitulo("Alumnos");
            cmbFiltroAlum.SelectedIndex = 0; //por defecto busca todos
            RecargarGrilla();
            uscPaginacion1.BringToFront();
            if (dgvAlumnos.Rows.Count == 0)
            {
                dgvAlumnos.ContextMenuStrip = cmsAlumnos;
                tsmEliminarAlumno.Visible = false;
                tsmModificarAlumno.Visible = false;
            }
        }

        private void RecargarGrilla(string filtro = "")
        {
            var tipo = (TipoFiltroAlumno)cmbFiltroAlum.SelectedIndex;

            if (rbTodos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro);
            else if (rbActivos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro, "'True'");
            else if (rbInactivos.Checked == true)
                uscPaginacion1.EntradaDatos = AlumnosLogica.ObtenerTodosAlumnos(tipo, filtro, "'False'");

            EstilosColumnasDGV();
        }
        private void EstilosColumnasDGV()
        {
            if (dgvAlumnos.Columns.Contains("AlumnoId"))
                dgvAlumnos.Columns["AlumnoId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("AlumnoCarreraId"))
                dgvAlumnos.Columns["AlumnoCarreraId"].Visible = false;
            if (dgvAlumnos.Columns.Contains("Inicializado"))
                dgvAlumnos.Columns["Inicializado"].Visible = false;
            if (dgvAlumnos.Columns.Contains("Curso"))
            {
                dgvAlumnos.Columns["Curso"].FillWeight = 50;
                dgvAlumnos.Columns["Curso"].MinimumWidth = 50;
            }
            if (dgvAlumnos.Columns.Contains("Año"))
                dgvAlumnos.Columns["Año"].FillWeight = 50;
            if (dgvAlumnos.Columns.Contains("Carrera"))
                dgvAlumnos.Columns["Carrera"].FillWeight = 100;
            if (dgvAlumnos.Columns.Contains("Activo"))
                dgvAlumnos.Columns["Activo"].FillWeight = 50;
        }
        private void dgvAlumnos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvAlumnos.HitTest(e.X, e.Y);

                tsmAgregarAlumno.Visible = ((CicloLectivosLogica.ObtenerAniosCiclosLectivosActivos().Length > 0));

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    dgvAlumnos.Rows[info.RowIndex].Selected = true;
                    cmsAlumnos.Show(dgvAlumnos, e.X - cmsAlumnos.Width / 2, e.Y);
                    this.AlumnoId = Convert.ToInt32(dgvAlumnos["AlumnoId", info.RowIndex].Value);
                    this.AlumnoCarreraId = Convert.ToInt32(dgvAlumnos["AlumnoCarreraId", info.RowIndex].Value);
                    bool activo = Convert.ToBoolean(dgvAlumnos["Activo", info.RowIndex].Value);
                    ApellidoNombre = dgvAlumnos["Apellido", info.RowIndex].Value.ToString();
                    ApellidoNombre += " " + dgvAlumnos["Nombre", info.RowIndex].Value.ToString();

                    
                    tsmModificarAlumno.Visible = activo;
                    tsmEliminarAlumno.Visible = activo;
                    tsmVerAlumno.Visible = true;
                    tsmAsignarMaterias.Visible = ((Convert.ToBoolean(dgvAlumnos["Inicializado", info.RowIndex].Value)) && activo);
                    tsmDarAlta.Visible = !activo;

                }
                else
                {
                    cmsAlumnos.Show(dgvAlumnos, e.X - cmsAlumnos.Width / 2, e.Y);
                    tsmModificarAlumno.Visible = false;
                    tsmEliminarAlumno.Visible = false;
                    tsmVerAlumno.Visible = false;
                    tsmAsignarMaterias.Visible = false;
                }
            }
        }

        #region ControlMenuStrip
        private void tsmAgregarAlumno_Click(object sender, EventArgs e)
        {
            
            bool OK = AlumnosInscLogica.obtenerFechaIncripcion();
            if (OK)
            {
                Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form => {
                    form.Accion = TipoAccion.Agregar;
                    form.AlumnoId = AlumnoId;
                });
            }
            else
            {
                DialogResult dg = MessageBox.Show("Fecha a inscripciones cerrada", "Fecha inscripción cerrada", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dg == DialogResult.OK)
                {
                    Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form => {
                        form.Accion = TipoAccion.Agregar;
                        form.AlumnoId = AlumnoId;
                    });
                }
            }
        }
        private void tsmModificarAlumno_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form => {
                form.Accion = TipoAccion.Modificar;
                form.AlumnoId = AlumnoId;
            });
        }
        private void tsmEliminarAlumno_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar el Alumno seleccionado?",
            "Eliminar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                AlumnosLogica.EliminarAlumno(AlumnoId);
                RecargarGrilla();
            }
        }
        private void tsmDarAlta_Click(object sender, EventArgs e)
        {
            this.AlumnosLogica.DarAltaAlumnos(AlumnoId);
            RecargarGrilla();
        }
        public void tsmCargaMasiva_Click(object sender, EventArgs e)
        {
            //color 27, 1, 124
            //tahoma white
            Form tempForm = new Form();
            Label label = new Label();
            Button buttonYes = new Button();
            buttonYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            buttonYes.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonYes.ForeColor = System.Drawing.Color.White;
            buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            Button buttonNo = new Button();
            buttonNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            buttonNo.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonNo.ForeColor = System.Drawing.Color.White;
            buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            Button buttonCancel = new Button();
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(1)))), ((int)(((byte)(124)))));
            buttonCancel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            label.SetBounds(9, 20, 372, 13);
            buttonYes.SetBounds(105, 72, 80, 25);
            buttonNo.SetBounds(190, 72, 80, 25);
            buttonCancel.SetBounds(309, 72, 80, 25);

            label.AutoSize = true;
            buttonYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            tempForm.Text = "Escoger el tipo de archivo para la carga masiva.";
            label.Text = "Escoger el tipo de archivo:";
            buttonYes.Text = "Excel";
            buttonNo.Text = ".Csv";
            buttonCancel.Text = "Cancelar";
            buttonYes.DialogResult = DialogResult.Yes;
            buttonNo.DialogResult = DialogResult.No;
            buttonCancel.DialogResult = DialogResult.Cancel;

            tempForm.ClientSize = new Size(396, 107);
            tempForm.Controls.AddRange(new Control[] { label, buttonYes, buttonNo, buttonCancel });
            tempForm.ClientSize = new Size(Math.Max(300, label.Right + 10), tempForm.ClientSize.Height);
            tempForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            tempForm.StartPosition = FormStartPosition.CenterScreen;
            tempForm.BackColor = System.Drawing.Color.White;
            tempForm.MinimizeBox = false;
            tempForm.MaximizeBox = false;
            tempForm.AcceptButton = buttonYes;
            tempForm.CancelButton = buttonCancel;

            var dialogResult = tempForm.ShowDialog();
            var dtable = new DataTable();

            if (dialogResult == DialogResult.Yes)
            {
                Contenedor.AbrirFormulario<FormCargaMasivaExcel>(form => {
                    form.Accion = "Agregar";
                    form.AlumnoId = AlumnoId;
                    form.AlumnoCarreraId = AlumnoCarreraId;
                });
            }
            if (dialogResult == DialogResult.No)
            {
                var FormCargaMasiva = new FormCargaMasivaCsv();
                var result = FormCargaMasiva.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dtable = this.CargaMasivaLogica.ImportarExel(FormCargaMasiva.PathArchivo);
                    int ContxVuelta = 0;
                    char Sexo;

                    if (FormCargaMasiva.PasajeChek == false)
                    {
                        while ((dtable.Rows.Count != ContxVuelta))
                        {
                            if (dtable.Rows[ContxVuelta]["Sexo:"].ToString() == "Femenino")
                            {
                                Sexo = 'F';
                            }
                            else
                            {
                                Sexo = 'M';
                            }
                            var varcarrera = dtable.Rows[ContxVuelta]["Carrera:"].ToString();
                            var varcarreraexiste = CarreraLogica.CarrerasExiste(varcarrera);

                            var modelo = new AlumnosModelo()
                            {
                                Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Nombre:"].ToString()),
                                Apellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Apellido:"].ToString()),
                                TipoDocumento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["TipoDocumento:"].ToString()),
                                NumeroDocumento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["DNI:"].ToString()),
                                EstadoCivil = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Estado Civil:"].ToString()),
                                Sexo = Sexo,
                                //FechaNacimiento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Fecha de Nacimiento:"].ToString()),
                                LocalidadNacimiento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Lugar de Nacimiento:"].ToString()),
                                Calle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Dirección:"].ToString()),
                                Numero = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Número:"].ToString()),
                                Provincia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Provincia:"].ToString()),
                                Distrito = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Partido:"].ToString()),
                                Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Localidad:"].ToString()),
                                CodigoPostal = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Código Postal:"].ToString()),
                                Celular = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Número de teléfono celular:"].ToString()),
                                Email = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Dirección de correo electrónico:"].ToString()),
                                FotoUrl = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Formación: adjuntar foto del titulo secundario o constancia de titulo en tramite o constancia de alumno regular actualizada."].ToString()),
                                Activo = varcarreraexiste,
                            };
                            var varalumnoexiste = AlumnosLogica.AlumnoExiste(dtable.Rows[ContxVuelta]["DNI:"].ToString());

                            if (varalumnoexiste == false)
                                AlumnosLogica.AgregarAlumnoTablaExcel(modelo);
                            ContxVuelta += 1;
                        }
                        Notificar(TipoNotificacion.Success, "Los registros\nse Agregaron con exito.");
                    }
                    else
                    {
                        while ((dtable.Rows.Count != ContxVuelta))
                        {
                            if (dtable.Rows[ContxVuelta]["Sexo:"].ToString() == "Femenino")
                            {
                                Sexo = 'F';
                            }
                            else
                            {
                                Sexo = 'M';
                            }
                            var varcarrera = dtable.Rows[ContxVuelta]["Carrera:"].ToString();
                            var varcarreraexiste = CarreraLogica.CarrerasExiste(varcarrera);

                            var modelo = new AlumnosModelo()
                            {
                                Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Nombre:"].ToString()),
                                Apellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Apellido:"].ToString()),
                                TipoDocumento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["TipoDocumento:"].ToString()),
                                NumeroDocumento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["DNI:"].ToString()),
                                EstadoCivil = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Estado Civil:"].ToString()),
                                Sexo = Sexo,
                                //FechaNacimiento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Fecha de Nacimiento:"].ToString()),
                                LocalidadNacimiento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Lugar de Nacimiento:"].ToString()),
                                Calle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Dirección:"].ToString()),
                                Numero = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Número:"].ToString()),
                                Provincia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Provincia:"].ToString()),
                                Distrito = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Partido:"].ToString()),
                                Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Localidad:"].ToString()),
                                CodigoPostal = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Código Postal:"].ToString()),
                                Celular = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Número de teléfono celular:"].ToString()),
                                Email = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Dirección de correo electrónico:"].ToString()),
                                FotoUrl = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtable.Rows[ContxVuelta]["Formación: adjuntar foto del titulo secundario o constancia de titulo en tramite o constancia de alumno regular actualizada."].ToString()),
                                Activo = varcarreraexiste,
                            };

                            var varalumnoexiste = AlumnosLogica.AlumnoExiste(dtable.Rows[ContxVuelta]["DNI:"].ToString());
                            if (varalumnoexiste == false)
                                AlumnosLogica.AgregarAlumnoTablaExcel(modelo);
                            else
                                AlumnosLogica.ModificarAlumnoTablaExcel(modelo);
                            ContxVuelta += 1;
                        }
                        Notificar(TipoNotificacion.Success, "Los registros se\nModificaron con exito.");
                    }
                }
            }
        }
        private void tsmVerAlumno_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarAlumnos>(form => {
                form.Accion = TipoAccion.Ver;
                form.AlumnoId = AlumnoId;
            });
        }
        private void tsmAsignarMaterias_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormInscripcionMaterias>(form => {
                form.AlumnoId = AlumnoId;
                form.ApellidoNombre = ApellidoNombre;
            });
        }
        #endregion

        private void btnReporte_Click(object sender, EventArgs e)
        {
            var datos = this.AlumnosLogica.ObtenerAlumnosPrueba();

            this.Contenedor.AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.AlumnosActivos.rdlc")
                .AddDataSource(datos, "AlumnosDS")
                .AddParameter("Carrera", "Sistemas")
                .AddParameter("Anio", "1")
                .AddParameter("Curso", "A")
                .AddParameter("OcultarGrilla", "False");
            });
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RecargarGrilla(txtFiltroAlumno.Text);
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e) //Corregido para que no se ejecute mas de 1 vez
        {
            if (((RadioButton)sender).Checked)
                RecargarGrilla();
        }

        private void FormAlumnos_Resize(object sender, EventArgs e)
        {
            uscPaginacion1.Left = (dgvAlumnos.Width / 2) - (uscPaginacion1.Width / 2);
        }
    }
}
