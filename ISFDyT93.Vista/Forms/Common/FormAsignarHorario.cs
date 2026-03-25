using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Datos.Modelos;
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
        private int MateriaId { get => Convert.ToInt32(cmbMaterias.SelectedValue); }

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
                    else
                    {

                    }
                });
            });

            Cursos = cursosLogica.ConsultarCursos(AnioCarreraId);
            Materias = materiasLogica.ObtenerMaterias(AnioCarreraId);

            CargarHorarios();

            CargarCombos();

            CargarModulos();

            AsignarColoresMaterias();

            cmbCursos_SelectedIndexChanged(cmbCursos, null);

            var listaCursoMateriasIds = HxCurso.ObtenerCursoMateriasIds();
            Cargos = personalLogica.ObtenerPersonalConCargos(listaCursoMateriasIds);
        }
        private void tsmEliminarHorario_Click(object sender, EventArgs e)
        {
            HorariosModelo horario = BuscarHorario((int)dgvAsignarHorario.Rows[Posicion.row].Cells["ModuloId"].Value, Posicion.column - 1);
            if (horario != null)
            {
                horario.DiaId = null;
                horario.ModuloId = null;

                MostrarHorarios();
                btnGuardar.FlatAppearance.BorderColor = Color.Red;
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
            if (cmbMaterias.Items.Count > 0 && cmbMaterias.Items.Count > 0)
            {
                HorariosModelo horario = LtsHorariosModelo.Where(x => x.MateriaId == MateriaId && x.Asignado == false).FirstOrDefault();
                if (horario != null)
                {
                    horario.ModuloId = Convert.ToInt32(dgvAsignarHorario.Rows[Posicion.row].Cells["ModuloId"].Value);
                    horario.DiaId = Posicion.column - 1;
                    MostrarHorarios();
                    btnGuardar.FlatAppearance.BorderColor = Color.Red;
                    contarModulos();
                }
                else Notificar(TipoNotificacion.Message, $"Ya se asignaron todos los\nmodulos de la materia: {cmbMaterias.Text}");
            }
        }
        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCursos.Items.Count > 0 && int.TryParse(cmbCursos.SelectedValue.ToString(), out _))
            {
                LtsHorariosModelo = HxCurso.ObtenerHorarioCurso(Convert.ToInt32(cmbCursos.SelectedValue));

                MostrarHorarios();
            }
            else if (Cursos.Rows.Count > 0)
            {
                LtsHorariosModelo = HxCurso.ObtenerHorarioCurso((int)Cursos.Rows[0]["CursoId"]);

                MostrarHorarios();
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
                resultado += horariosLogica.ActualizarHorarios(HxCurso.ObtenerHorarioCurso((int)dr["CursoId"]));

                if (resultado > 0)
                {
                    Notificar(TipoNotificacion.Success, "Horarios Actualizados");
                    btnGuardar.FlatAppearance.BorderColor = Color.White;
                }
                else
                    Notificar(TipoNotificacion.Error, "Ocurrio un error al actualizar");
            }
        }
        private void tsmQuitarTodo_Click(object sender, EventArgs e)
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
            }
        }
        #endregion

        #region Metodos 
        private HorariosModelo BuscarHorario(int moduloId, int diaId) =>
             LtsHorariosModelo.Where(x => x.ModuloId == moduloId && x.DiaId == diaId).FirstOrDefault();
        private void CargarCombos()
        {
            cmbCursos.ValueMember = "CursoId";
            cmbCursos.DisplayMember = "NombreCurso";
            cmbCursos.DataSource = Cursos;

            cmbMaterias.ValueMember = "MateriaId";
            cmbMaterias.DisplayMember = "Nombre";
            cmbMaterias.DataSource = Materias;
        }
        private void CargarModulos()
        {
            Modulos = horariosLogica.ObtnerModulos();
            dgvAsignarHorario.RowTemplate.Height = 80;
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
            dgvAsignarHorario.CurrentRow.Cells[1].Selected = false;
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
            foreach (DataRow dr in Cursos.Rows)
            {
                var grupoHorarios = horariosLogica.ObtenerHorarios((int)dr["CursoId"]);
                HxCurso.AgregarListaHorarios((int)dr["CursoId"], grupoHorarios);
            }
        }
        private void MostrarHorarios()
        {
            if (LtsHorariosModelo != null)
            {
                foreach (DataGridViewRow dr in dgvAsignarHorario.Rows)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        dr.Cells[i + 1].Style.BackColor = Color.White;
                        dr.Cells[i + 1].Value = "";

                        var mod = LtsHorariosModelo.Where(x => x.DiaId == i && x.ModuloId == (int)dr.Cells["ModuloId"].Value).ToList();
                        if (mod.Count > 0)
                        {
                            dr.Cells[i + 1].Value = mod[0].Nombre;

                            dr.Cells[i + 1].Style.BackColor = ColorCelda[ColorCelda.FindIndex(x => x.id == mod[0].MateriaId)].color;
                        }
                    }
                }
                contarModulos();
            }
        }
        private void contarModulos()
        {
            if (LtsHorariosModelo != null && cmbMaterias.SelectedValue != null)
            {
                var nroModulos = LtsHorariosModelo.Where(x => x.MateriaId == MateriaId && x.Asignado == false).Count();
                lblModulos.Text = $"Cantidad de modulos: {nroModulos}";
            }
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
        private void Guardar()
        {
            bmpCaptura = new Bitmap(this.Width, this.Height);
            Graphics captura = Graphics.FromImage(bmpCaptura);
            var posicion = this.PointToScreen(Point.Empty);
            captura.CopyFromScreen(posicion.X, posicion.Y, 0, 0, this.Size);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = $"Horarios{DateTime.Now.ToString("ssmmHH")}.png";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(bmpCaptura);
                image.Save(guardar.FileName, ImageFormat.Png);
            }
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
            Guardar();
        }
    }

    internal class HorarioPorCurso
    {
        private List<(int cursoId, IList<HorariosModelo> ltsHorarios)> lts = new List<(int cursoId, IList<HorariosModelo> ltsHorarios)>();
        internal void AgregarListaHorarios(int cursoId, IList<HorariosModelo> ltsHorarios)
        {
            lts.Add((cursoId, ltsHorarios));
        }

        internal IList<HorariosModelo> ObtenerHorarioCurso(int cursoId)
        {
            int index = lts.FindIndex(x => x.cursoId == cursoId);
            return lts[index].ltsHorarios;
        }
        internal List<int> ObtenerCursoMateriasIds()
        {
            var lista = lts.Select(x => x.ltsHorarios).ToList();
            var listaResult = new List<int>();
            foreach (var lt in lista)
            {
                var ids = new HashSet<int>(lt.Select(x => x.CursoMateriaId));
                listaResult.AddRange(ids.ToList());
            }
            return listaResult;
        }
    }
}
