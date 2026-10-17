using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Forms.Carreras;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using iTextSharp.text;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text.pdf.codec.wmf;
using static ISFDyT93.Vista.UserControls.uscPersonalGrid;
using System.Drawing.Imaging;
using ISFDyT93.Datos;
using Point = System.Drawing.Point;
using ISFDyT93.Entidades.Enums;
using System.IO;
using System.Drawing;
using System.Data;

namespace ISFDyT93.Vista.Forms.Common
{
    public partial class FormAsignarHorario : FormBase
    {
        #region Propiedades Públicas
        public int AnioCarreraId { get; set; }
        public bool Personal { get; set; } = false;
        #endregion

        #region Propiedades Privadas
        private IList<HorariosModelo> LtsHorariosModelo { get; set; }
        private AniosCarrerasModelo AnioCarrera { get; set; }
        private (int row, int column) Posicion { get; set; }
        private DataTable Modulos { get; set; }
        private DataTable Materias { get; set; }
        private DataTable Cursos { get; set; }
        private IList<CargosModeloDTO> Cargos { get; set; }
        private int MateriaId
        {
            get
            {
                if (cmbMaterias.SelectedValue != null && int.TryParse(cmbMaterias.SelectedValue.ToString(), out int id))
                {
                    return id;
                }
                return 0; 
            }
        }

        private List<(int id, Color color)> ColorCelda = new List<(int id, Color color)>();

        HorariosLogica horariosLogica = new HorariosLogica();
        CursosLogica cursosLogica = new CursosLogica();
        PersonalLogica personalLogica = new PersonalLogica();
        AniosCarreraLogica aniosLogica = new AniosCarreraLogica();
        MateriasLogica materiasLogica = new MateriasLogica();
        HorarioPorCurso HxCurso = new HorarioPorCurso();
        private Bitmap bmpCaptura;
        #endregion
        
        public FormAsignarHorario()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormAsignarHorario_Load(object sender, EventArgs e)
        {
            dgvAsignarHorario.ShowCellToolTips = true;
            this.AnioCarrera = aniosLogica.ObtenerAnioCarrera(AnioCarreraId);
            dgvAsignarHorario.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if (this.AnioCarrera != null)
                this.Contenedor.SetTitulo($"Horarios - {AnioCarrera.AnioCarrera} Año - {AnioCarrera.NombreCarrera}");

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAniosCarreras>((form) =>
                {
                    if (!Personal)
                        form.CarreraId = this.AnioCarrera.CarreraId;
                });
            });

            Cursos = cursosLogica.ConsultarCursos(AnioCarreraId);
            Materias = materiasLogica.ObtenerMaterias(AnioCarreraId);


            CargarHorarios();
            CargarModulos();
            AsignarColoresMaterias();

            var listaCursoMateriasIds = HxCurso.ObtenerCursoMateriasIds();
            Cargos = personalLogica.ObtenerPersonalConCargos(listaCursoMateriasIds);

            CargarCombos();
        }
        private void tsmEliminarHorario_Click(object sender, EventArgs e)
        {
            int moduloId = Convert.ToInt32(dgvAsignarHorario.Rows[Posicion.row].Cells["ModuloId"].Value);
            int diaId = Posicion.column - 1;

            var horariosAEliminar = LtsHorariosModelo
                .Where(x => x.DiaId == diaId && x.ModuloId == moduloId)
                .ToList();

            if (horariosAEliminar.Any())
            {
                int idMateriaEliminada = horariosAEliminar.First().MateriaId;

                foreach (var horario in horariosAEliminar)
                {
                    if (horario.HorarioId > 0)
                    {
                        horario.DiaId = null;
                        horario.ModuloId = null;
                    }
                    else
                    {
                        LtsHorariosModelo.Remove(horario);
                    }
                }

                if (idMateriaEliminada != MateriaId)
                {
                    cmbMaterias.SelectedValue = idMateriaEliminada;
                }

                MostrarHorarios();
                contarModulos(); 
                btnGuardar.FlatAppearance.BorderColor = Color.Red;
                ActualizarComboMaterias();
            }
        }
        private void dgvAsignarHorario_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo info = dgvAsignarHorario.HitTest(e.X, e.Y);

                dgvAsignarHorario.Rows[info.RowIndex].Cells[info.ColumnIndex].Selected = true;

                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1 && info.ColumnIndex > 1)
                {
                    Posicion = (info.RowIndex, info.ColumnIndex);
                    var celda = dgvAsignarHorario.Rows[Posicion.row].Cells[Posicion.column];
                    bool estado = string.IsNullOrEmpty(celda.Value.ToString());

                    if (e.Button == MouseButtons.Right)
                    {
                        if (Admin)
                        {
                            tsmAgregarMateria.Visible = estado;
                            tsmQuitarMateria.Visible = !estado;
                            cmsHorarios.Show(dgvAsignarHorario, e.X - cmsHorarios.Width / 2, e.Y);
                        }
                    }
                    if (e.Button == MouseButtons.Left)
                    {
                        if (!estado)
                        {
                            int cursoMateriaId = LtsHorariosModelo.Where(x => x.DiaId == Posicion.column - 1
                                      && x.ModuloId == (int)dgvAsignarHorario.Rows[Posicion.row].Cells["ModuloId"].Value)
                                     .Select(x => x.CursoMateriaId).FirstOrDefault();
                            MostrarCargos(cursoMateriaId, celda.Value.ToString());
                        }
                    }
                }
            }
            catch { }
        }
        private void tsmAgregarMateria_Click(object sender, EventArgs e)
        {
            if (cmbMaterias.Items.Count > 0 && MateriaId > 0)
            {
                var materiaBase = LtsHorariosModelo.FirstOrDefault(x => x.MateriaId == MateriaId);

                if (materiaBase != null)
                {
                    int totalModulosPermitidos = materiaBase.Modulos;
                    int modulosYaAsignados = LtsHorariosModelo.Count(x => x.MateriaId == MateriaId && x.Asignado);

                    if (modulosYaAsignados < totalModulosPermitidos)
                    {
                        HorariosModelo horario = LtsHorariosModelo.FirstOrDefault(x => x.MateriaId == MateriaId && !x.Asignado);

                        if (horario == null)
                        {
                            horario = new HorariosModelo
                            {
                                MateriaId = materiaBase.MateriaId,
                                Nombre = materiaBase.Nombre,
                                CursoMateriaId = materiaBase.CursoMateriaId, 
                                Modulos = materiaBase.Modulos
                            };
                            LtsHorariosModelo.Add(horario);
                        }

                        horario.ModuloId = Convert.ToInt32(dgvAsignarHorario.Rows[Posicion.row].Cells["ModuloId"].Value);
                        horario.DiaId = Posicion.column - 1;

                        MostrarHorarios();
                        btnGuardar.FlatAppearance.BorderColor = Color.Red;
                        contarModulos();
                        ActualizarComboMaterias();
                    }
                    else
                    {
                        Notificar(TipoNotificacion.Message, $"Ya se asignaron todos los\nmodulos de la materia: {cmbMaterias.Text}");
                    }
                }
            }
        }
        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCursos.Items.Count > 0 && int.TryParse(cmbCursos.SelectedValue.ToString(), out _))
            {
                LtsHorariosModelo = HxCurso.ObtenerHorarioCurso(Convert.ToInt32(cmbCursos.SelectedValue));

                MostrarHorarios();


                ActualizarComboMaterias();
            }
            else if (Cursos.Rows.Count > 0)
            {
                LtsHorariosModelo = HxCurso.ObtenerHorarioCurso((int)Cursos.Rows[0]["CursoId"]);

                MostrarHorarios();


                ActualizarComboMaterias();
            }
        }
        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            contarModulos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            foreach (DataRow dr in Cursos.Rows)
            {
                int idCurso = Convert.ToInt32(dr["CursoId"]);
                var horariosCurso = HxCurso.ObtenerHorarioCurso(idCurso);
                if (horariosCurso != null && horariosCurso.Any())
                {
                    resultado += horariosLogica.ActualizarHorarios(horariosCurso);
                }
            }

            if (resultado > 0)
            {
                Notificar(TipoNotificacion.Success, "Horarios Actualizados correctamente.");
                btnGuardar.FlatAppearance.BorderColor = Color.White;

                CargarHorarios();

                if (cmbCursos.SelectedValue != null && int.TryParse(cmbCursos.SelectedValue.ToString(), out int idCursoSeleccionado))
                {
                    LtsHorariosModelo = HxCurso.ObtenerHorarioCurso(idCursoSeleccionado);
                }

                MostrarHorarios();
                contarModulos();
            }
            else
            {
                Notificar(TipoNotificacion.Error, "Ocurrió un error al actualizar los horarios o no hubo cambios.");
            }
        }
        private void tsmQuitarTodo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea quitar todos módulos asignados?",
            "Quitar horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
            if (LtsHorariosModelo != null)
            {
                foreach (HorariosModelo horario in LtsHorariosModelo)
                {
                    horario.DiaId = null;
                    horario.ModuloId = null;
                }

                MostrarHorarios();
                btnGuardar.FlatAppearance.BorderColor = Color.Red;
                ActualizarComboMaterias();
                }
            }
        }
        #endregion

        #region Metodos 
        private HorariosModelo BuscarHorario(int moduloId, int diaId) =>
             LtsHorariosModelo.Where(x => x.ModuloId == moduloId && x.DiaId == diaId).FirstOrDefault();
        private void CargarCombos()
        {
            cmbCursos.ValueMember = "CursoId";
            cmbCursos.DisplayMember = "CodigoBloque";
            cmbCursos.DataSource = Cursos;

            cmbMaterias.ValueMember = "MateriaId";
            cmbMaterias.DisplayMember = "Nombre";
            cmbMaterias.DataSource = Materias;

            ActualizarComboMaterias();
        }
        private void CargarModulos()
        {
            Modulos = horariosLogica.ObtnerModulos();
            dgvAsignarHorario.Rows.Clear(); 
            dgvAsignarHorario.RowTemplate.Height = 80;

            if (Modulos != null && Modulos.Rows.Count > 0)
            {
                dgvAsignarHorario.Rows.Add(Modulos.Rows.Count);

                foreach (DataGridViewRow fila in dgvAsignarHorario.Rows)
                {
                    fila.Cells[1].Style.BackColor = ThemeColor.GetTheme().Secondary;
                    fila.Cells[1].Style.ForeColor = Color.White;
                    fila.Cells[1].Style.SelectionBackColor = ThemeColor.GetTheme().Secondary;
                    fila.Cells[1].Style.SelectionForeColor = Color.White;

                    fila.Cells[0].Value = Modulos.Rows[fila.Index]["ModuloId"];
                    fila.Cells[1].Value = Modulos.Rows[fila.Index]["Descripcion"];
                }

                if (dgvAsignarHorario.CurrentRow != null)
                {
                    dgvAsignarHorario.CurrentRow.Cells[1].Selected = false;
                }
            }
        }
        private void AsignarColoresMaterias()
        {
            foreach (DataRow dr in Materias.Rows)
            {
                for (; ; )
                {
                    Color col = ThemeColor.GetColor();
                    if (ColorCelda.FindIndex(x => x.color == col) == -1)
                    {
                        ColorCelda.Add(((int)dr["MateriaId"], col));
                        break;
                    }
                }
            }
        }
        private void CargarHorarios()
        {
            HxCurso = new HorarioPorCurso(); 
            foreach (DataRow dr in Cursos.Rows)
            {
                int cursoId = Convert.ToInt32(dr["CursoId"]);
                var grupoHorarios = horariosLogica.ObtenerHorarios(cursoId);
                HxCurso.AgregarListaHorarios(cursoId, grupoHorarios);
            }
        }
        private void MostrarHorarios()
        {
            if (LtsHorariosModelo == null) return;

            foreach (DataGridViewRow dr in dgvAsignarHorario.Rows)
            {
                for (int i = 1; i < 6; i++)
                {
                    var celda = dr.Cells[i + 1];
                    celda.Style.BackColor = Color.White;
                    celda.Value = string.Empty;
                    celda.ToolTipText = string.Empty; 

                    int moduloId = Convert.ToInt32(dr.Cells["ModuloId"].Value);

                    var mod = LtsHorariosModelo
                        .Where(x => x.DiaId == i && x.ModuloId == moduloId)
                        .ToList();

                    if (mod.Any())
                    {
                        celda.Value = mod[0].Nombre;

                   
                        int colorIndex = ColorCelda.FindIndex(x => x.id == mod[0].MateriaId);
                        if (colorIndex >= 0)
                        {
                            celda.Style.BackColor = ColorCelda[colorIndex].color;
                        }
                        celda.ToolTipText = ObtenerDocentesMateria(mod[0].CursoMateriaId);
                    }
                }
            }

            contarModulos();
        }
        private void contarModulos()
        {
            if (MateriaId <= 0) return;

            var materia = LtsHorariosModelo.FirstOrDefault(x => x.MateriaId == MateriaId);

            if (materia == null)
            {
                lblModulos.Text = "Cantidad de modulos: 0";
                return;
            }

            int totalModulosMateria = materia.Modulos;

            int modulosAsignados = LtsHorariosModelo
                .Count(x => x.MateriaId == MateriaId && x.DiaId.HasValue && x.ModuloId.HasValue);

            int modulosRestantes = totalModulosMateria - modulosAsignados;
            if (modulosRestantes < 0) modulosRestantes = 0;

            lblModulos.Text = $"Cantidad de modulos: {modulosRestantes}";
        }
        private void MostrarCargos(int cursoMateriaId, string materia)
        {
            if (Cargos != null && Cargos.Count > 0)
            {
                string cargosTomados = null;

                var listaCargos = Cargos.Where(x => x.CursoMateriaId == cursoMateriaId).ToList();
                foreach (var cargo in listaCargos)
                    cargosTomados += $"{cargo.Cargo} - {cargo.NombreCompleto}\n";

                if (cargosTomados != null)
                    Notificar(TipoNotificacion.Message, $"La Materia {materia} tiene los siguientes cargos:\n{cargosTomados}");
            }
        }
        private void ImprimirHorarios()
        {
            if (AnioCarrera == null)
            {
                Notificar(TipoNotificacion.Warning, "No hay datos de la carrera seleccionada para imprimir.");
                return;
            }

            if (cmbCursos.SelectedValue == null || !int.TryParse(cmbCursos.SelectedValue.ToString(), out int cursoId))
            {
                Notificar(TipoNotificacion.Warning, "Debe seleccionar un curso/bloque para imprimir los horarios.");
                return;
            }


            var dataHorariosReporte = horariosLogica.ObtenerHorarios(cursoId);
            if (dataHorariosReporte == null || !dataHorariosReporte.Any())
            {
                Notificar(TipoNotificacion.Warning, "No existen horarios asignados para imprimir en este curso.");
                return;
            }


            Control controlACapturar = dgvAsignarHorario;

            Bitmap bmp = new Bitmap(controlACapturar.Width, controlACapturar.Height);
            controlACapturar.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, controlACapturar.Width, controlACapturar.Height));

            byte[] imagenBytes;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imagenBytes = ms.ToArray();
            }

            DataTable dtImagen = new DataTable();
            dtImagen.Columns.Add("ImagenCapturada", typeof(byte[]));
            dtImagen.Rows.Add(imagenBytes);


            string carreraNombre = AnioCarrera.NombreCarrera ?? string.Empty;
            string anioCarreraTexto = $"{AnioCarrera.AnioCarrera}° Año";
            string cursoBloque = cmbCursos.Text;


            this.Contenedor.SetTitulo("Imprimir Horarios").AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.Horarios.rdlc")
                    .AddDataSource(dtImagen, "DSImagen") 
                    .AddParameter("Carrera", carreraNombre)
                    .AddParameter("AnioCarrera", anioCarreraTexto)
                    .AddParameter("Curso", cursoBloque)
                    .AddParameter("FechaEmision", DateTime.Now.ToString("dd/MM/yyyy"));
            });
        }
        private DataTable ConvertirADataTable(IList<HorariosModelo> lista)
        {
            DataTable table = new DataTable();
            var propiedades = typeof(HorariosModelo).GetProperties();

            foreach (var prop in propiedades)
            {
                Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, colType);
            }

            foreach (var item in lista)
            {
                var row = table.NewRow();
                foreach (var prop in propiedades)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
        #endregion

        bool Admin = true;
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin = !Admin;
            btnAdmin.BackColor = (Admin ? Color.FromArgb(0, 192, 0) : Color.FromArgb(255, 128, 0));
            btnAdmin.Text = (Admin ? "Admin On" : "Admin Off");

            btnGuardar.Visible = Admin;
            cmbMaterias.Visible = Admin;
            lblMateria.Visible = Admin;
            lblModulos.Visible = Admin;
        }

        private void picImprimir_Click(object sender, EventArgs e)
        {



            ImprimirHorarios();
        }

        private string ObtenerDocentesMateria(int cursoMateriaId)
        {

            if (Cargos == null || !Cargos.Any())
                return "Sin docente asignado";

            var listaCargos = Cargos.Where(x => x.CursoMateriaId == cursoMateriaId).ToList();

            if (!listaCargos.Any())
                return "Sin docente asignado";

            return string.Join("\n", listaCargos.Select(c => $"{c.Cargo}: {c.NombreCompleto}"));
        }

        private void ActualizarComboMaterias()
        {
            if (Materias == null || Materias.Rows.Count == 0 || LtsHorariosModelo == null)
                return;

   //seleccionamos las materias con modulos disponibles
            var materiasDisponibles = Materias.AsEnumerable().Where(dr =>
            {
                int idMateria = Convert.ToInt32(dr["MateriaId"]);
                var materiaBase = LtsHorariosModelo.FirstOrDefault(x => x.MateriaId == idMateria);

                if (materiaBase == null) return false;

                int totalModulos = materiaBase.Modulos;
                int asignados = LtsHorariosModelo.Count(x => x.MateriaId == idMateria && x.DiaId.HasValue && x.ModuloId.HasValue);

                return (totalModulos - asignados) > 0;
            }).ToList();

            
            int materiaSeleccionadaActual = MateriaId;

            
            cmbMaterias.SelectedIndexChanged -= cmbMaterias_SelectedIndexChanged;

            if (materiasDisponibles.Any())
            {
                DataTable dtFiltrado = materiasDisponibles.CopyToDataTable();
                cmbMaterias.DataSource = dtFiltrado;
                cmbMaterias.ValueMember = "MateriaId";
                cmbMaterias.DisplayMember = "Nombre";

                if (dtFiltrado.AsEnumerable().Any(r => Convert.ToInt32(r["MateriaId"]) == materiaSeleccionadaActual))
                {
                    cmbMaterias.SelectedValue = materiaSeleccionadaActual;
                }
            }
            else
            {
                cmbMaterias.DataSource = null;
                cmbMaterias.Items.Clear();

               
                cmbMaterias.ValueMember = "";
                cmbMaterias.DisplayMember = "";
                cmbMaterias.Items.Add("-=Todas las materias fueron asignadas=-");


                cmbMaterias.SelectedIndex = 0;
            }

 
            cmbMaterias.SelectedIndexChanged += cmbMaterias_SelectedIndexChanged;

            contarModulos();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picImprimirCursos_Click(object sender, EventArgs e)
        {
            ImprimirTodosLosHorarios();
        }

        private void ImprimirTodosLosHorarios()
        {
            if (AnioCarrera == null)
            {
                Notificar(TipoNotificacion.Warning, "No hay datos de la carrera seleccionada para imprimir.");
                return;
            }

            if (Cursos == null || Cursos.Rows.Count == 0)
            {
                Notificar(TipoNotificacion.Warning, "No hay cursos disponibles para imprimir.");
                return;
            }

            var cursoOriginalId = cmbCursos.SelectedValue;

            DataTable dtImagenes = new DataTable();
            dtImagenes.Columns.Add("ImagenCapturada", typeof(byte[]));
            dtImagenes.Columns.Add("CursoNombre", typeof(string));

            try
            {
                dgvAsignarHorario.SuspendLayout();

                foreach (DataRow dr in Cursos.Rows)
                {
                    int idCurso = Convert.ToInt32(dr["CursoId"]);
                    string nombreCurso = dr["CodigoBloque"].ToString();

                    LtsHorariosModelo = HxCurso.ObtenerHorarioCurso(idCurso);

                    if (LtsHorariosModelo == null || !LtsHorariosModelo.Any()) continue;

                    MostrarHorarios();

 
                    dgvAsignarHorario.ClearSelection();
                    dgvAsignarHorario.Refresh();


                    using (Bitmap bmp = new Bitmap(dgvAsignarHorario.Width, dgvAsignarHorario.Height))
                    {
                        dgvAsignarHorario.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, dgvAsignarHorario.Width, dgvAsignarHorario.Height));

                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, ImageFormat.Png);
                            dtImagenes.Rows.Add(ms.ToArray(), nombreCurso);
                        }
                    }
                }
            }
            finally
            {

                if (cursoOriginalId != null)
                {
                    cmbCursos.SelectedValue = cursoOriginalId;
                    LtsHorariosModelo = HxCurso.ObtenerHorarioCurso(Convert.ToInt32(cursoOriginalId));
                    MostrarHorarios();
                }
                dgvAsignarHorario.ResumeLayout();
            }

            if (dtImagenes.Rows.Count == 0)
            {
                Notificar(TipoNotificacion.Warning, "No se encontraron horarios asignados para imprimir en este año.");
                return;
            }

            string carreraNombre = AnioCarrera.NombreCarrera ?? string.Empty;
            string anioCarreraTexto = $"{AnioCarrera.AnioCarrera}° Año";

            this.Contenedor.SetTitulo("Imprimir Todos los Horarios").AbrirFormulario<FormReporte>(form => {
                form.SetReporte("ISFDyT93.Vista.Reports.HorariosMasivo.rdlc") 
                    .AddDataSource(dtImagenes, "DSImagenMasivo")
                    .AddParameter("Carrera", carreraNombre)
                    .AddParameter("AnioCarrera", anioCarreraTexto)
                    .AddParameter("FechaEmision", DateTime.Now.ToString("dd/MM/yyyy"));
              
            });
        }
    }




    internal class HorarioPorCurso
    {
        private Dictionary<int, IList<HorariosModelo>> lts = new Dictionary<int, IList<HorariosModelo>>();

        internal void AgregarListaHorarios(int cursoId, IList<HorariosModelo> ltsHorarios)
        {
            if (lts.ContainsKey(cursoId))
                lts[cursoId] = ltsHorarios;
            else
                lts.Add(cursoId, ltsHorarios);
        }

        internal IList<HorariosModelo> ObtenerHorarioCurso(int cursoId)
        {
            if (lts.ContainsKey(cursoId))
                return lts[cursoId];

            return new List<HorariosModelo>();
        }

        internal List<int> ObtenerCursoMateriasIds()
        {
            var listaResult = new List<int>();
            foreach (var lt in lts.Values)
            {
                var ids = new HashSet<int>(lt.Select(x => x.CursoMateriaId));
                listaResult.AddRange(ids);
            }
            return listaResult;
        }

   
    }

}
