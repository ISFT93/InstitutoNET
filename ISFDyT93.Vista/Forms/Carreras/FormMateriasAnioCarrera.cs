using ISFDyT93.Entidades.Enums;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Negocio.Interfaces;
using ISFDyT93.Negocio.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

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

            dgvMatAnioCarrera.CellFormatting -= dgvMatAnioCarrera_CellFormatting;
            dgvMatAnioCarrera.CellFormatting += dgvMatAnioCarrera_CellFormatting;

            dgvMatAnioCarrera.DataSource = this.materiasLogica.ObtenerMaterias(this.AnioCarreraId);

            if (dgvMatAnioCarrera.Columns.Contains("MateriaId")) dgvMatAnioCarrera.Columns["MateriaId"].Visible = false;
            if (dgvMatAnioCarrera.Columns.Contains("AnioCarreraId")) dgvMatAnioCarrera.Columns["AnioCarreraId"].Visible = false;
            if (dgvMatAnioCarrera.Columns.Contains("EspacioId")) dgvMatAnioCarrera.Columns["EspacioId"].Visible = false;

            if (dgvMatAnioCarrera.Columns.Contains("Descripción"))
                dgvMatAnioCarrera.Columns["Descripción"].HeaderText = "Espacios";
            else if (dgvMatAnioCarrera.Columns.Contains("Descripcion"))
                dgvMatAnioCarrera.Columns["Descripcion"].HeaderText = "Espacios";

            // Configuración de la columna "CantidadModulos"
            if (dgvMatAnioCarrera.Columns.Contains("CantidadModulos"))
            {
                var colModulo = dgvMatAnioCarrera.Columns["CantidadModulos"];
                colModulo.HeaderText = "Módulos";
                colModulo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colModulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvMatAnioCarrera.Columns.Contains("Carga Horaria"))
                {
                    colModulo.DisplayIndex = dgvMatAnioCarrera.Columns["Carga Horaria"].DisplayIndex + 1;
                }
            }

            dgvMatAnioCarrera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvMatAnioCarrera.Columns.Contains("Código"))
                dgvMatAnioCarrera.Columns["Código"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvMatAnioCarrera.Columns.Contains("Carga Horaria"))
                dgvMatAnioCarrera.Columns["Carga Horaria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvMatAnioCarrera.Columns.Contains("Correlativas"))
                dgvMatAnioCarrera.Columns["Correlativas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvMatAnioCarrera.Columns.Contains("Final / Promoción"))
                dgvMatAnioCarrera.Columns["Final / Promoción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvMatAnioCarrera.Columns.Contains("Descripción"))
                dgvMatAnioCarrera.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            else if (dgvMatAnioCarrera.Columns.Contains("Descripcion"))
                dgvMatAnioCarrera.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvMatAnioCarrera.Columns.Contains("Nombre"))
                dgvMatAnioCarrera.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dgvMatAnioCarrera.Columns.Contains("Carga Horaria"))
                dgvMatAnioCarrera.Columns["Carga Horaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvMatAnioCarrera.Columns.Contains("Correlativas"))
                dgvMatAnioCarrera.Columns["Correlativas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (this.anioCarrera.AnioCarrera == 1)
            {
                tsmVerCorrelatividades.Visible = false;

                if (dgvMatAnioCarrera.Columns.Contains("Correlativas"))
                    dgvMatAnioCarrera.Columns["Correlativas"].Visible = false;
            }

            tsmVerCorrelatividades.Text = "Gestionar correlativas";

            this.Contenedor.SetTitulo($" {this.anioCarrera.AnioCarrera} año de {anioCarrera.NombreCarrera}")
                .SetVolver(() =>
                {
                    this.Contenedor.AbrirFormulario<FormAniosCarreras>((form) =>
                    {
                        form.CarreraId = this.anioCarrera.CarreraId;
                    });
                }
            );

            CalcularHoras();
        }

        private void tsmAgregarMateria_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form =>
            {
                form.AnioCarreraId = this.AnioCarreraId;
                form.MateriaId = this.MateriaId;
                form.Accion = TipoAccion.Agregar;
            });
        }

        private void tsmModificarMateria_Click(object sender, EventArgs e)
        {
            if (tsmModificarMateria.Text == "Modificar")
            {
                Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form =>
                {
                    form.AnioCarreraId = this.AnioCarreraId;
                    form.MateriaId = this.MateriaId;
                    form.Accion = TipoAccion.Modificar;
                });
            }
            else
            {
                Contenedor.AbrirFormulario<FormAgregarModificarMateria>(form =>
                {
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
                Contenedor.AbrirFormulario<FormAgregarModificarCorrelativa>(form =>
                {
                    form.MateriaId = this.MateriaId;
                    form.DescripcionCarrera = anioCarrera.NombreCarrera;
                });
            }
        }


        private void tsmEliminarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                //CellContentClick cuando se selecciona en el menu Eliminar
                DialogResult resultado = MessageBox.Show("¿Desea eliminar la Materia seleccionada?",
                "Eliminar Materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    materiasLogica.EliminarMateria(this.MateriaId, this.AnioCarreraId);

                    //Renumera los codigos de bloque luego de que se elimina una materia
                    materiasLogica.RenumerarCodigoBloque(this.AnioCarreraId);

                    dgvMatAnioCarrera.DataSource = this.materiasLogica.ObtenerMaterias(this.AnioCarreraId);
                    //Ocultar columna de la grilla
                    dgvMatAnioCarrera.Columns["MateriaId"].Visible = false;
                }

                CalcularHoras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede proceder con la eliminación, la materia está asociada como correlativa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CalcularHoras()
        {
            Dictionary<string, int> acumuladoresPorEspacio = new Dictionary<string, int>();
            int cargaHorariaTotal = 0;

            foreach (DataGridViewRow row in dgvMatAnioCarrera.Rows)
            {
                if (row.IsNewRow) continue;

                var celdaEspacio = row.Cells["Descripción"].Value ?? row.Cells["Descripcion"]?.Value;
                var celdaHoras = row.Cells["Carga Horaria"].Value;

                if (celdaEspacio == null || celdaHoras == null) continue;

                string espacioMateria = celdaEspacio.ToString().Trim();
                int horas = 0;
                int.TryParse(celdaHoras.ToString(), out horas);

                if (!acumuladoresPorEspacio.ContainsKey(espacioMateria))
                {
                    acumuladoresPorEspacio[espacioMateria] = 0;
                }
                //cargaHorariaTotal = formacionEspecifica + formacionBasica + formacionInstitucional;

                acumuladoresPorEspacio[espacioMateria] += horas;
                cargaHorariaTotal += horas;
            }
            //lblDescripcion.Text = "Formacion basica: " + formacionBasica  + "\nFormacion especifica: " + formacionEspecifica + "\nFormacion institucional: " + formacionInstitucional + "\nCarga horaria total: " + cargaHorariaTotal;


            StringBuilder sb = new StringBuilder();

            foreach (var item in acumuladoresPorEspacio)
            {
                double porcentaje = cargaHorariaTotal > 0
                    ? Math.Round((double)item.Value / cargaHorariaTotal * 100, 1)
                    : 0;

                sb.AppendLine($"{item.Key}: {item.Value} hs ({porcentaje}%)");
                // Esta linea llama al método ActualizarTotalesEspacio de la clase MateriasLogica
                // para actualizar los totales por espacio en la base de datos o en la lógica de negocio
                this.materiasLogica.ActualizarTotalesEspacio(item.Key, item.Value, porcentaje);
            }

            sb.AppendLine($"\nCarga Horaria Total: {cargaHorariaTotal} hs");

            lblDescripcion.Text = sb.ToString();

            // CÓDIGO VIEJO PARA CALCULAR HORAS POR ESPACIO (COMENTADO)
            //int formacionBasica = 0, formacionEspecifica = 0, formacionInstitucional = 0, cargaHorariaTotal = 0;

            //if (dgvMatAnioCarrera.RowCount > 0)
            //{
            //    for (int i = 0; i < dgvMatAnioCarrera.RowCount; i++)
            //    {
            //        int espacio = Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["EspacioId"].Value);
            //        if (espacio == 1)
            //        {
            //            formacionBasica += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
            //        }
            //        if (espacio == 2)
            //        {
            //            formacionEspecifica += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
            //        }
            //        else if (espacio == 3)
            //        {
            //            formacionInstitucional += Convert.ToInt32(dgvMatAnioCarrera.Rows[i].Cells["Carga Horaria"].Value);
            //        }
            //    }
            //    cargaHorariaTotal = formacionEspecifica + formacionBasica + formacionInstitucional;
            //    lblDescripcion.Text = "Formacion basica: " + formacionBasica + "\nFormacion especifica: " + formacionEspecifica + "\nFormacion institucional: " + formacionInstitucional + "\nCarga horaria total: " + cargaHorariaTotal;
            //}
            //else
            //{
            //    lblDescripcion.Text = "Formacion basica: " + formacionBasica + "\nFormacion especifica: " + formacionEspecifica + "\nFormacion institucional: " + formacionInstitucional + "\nCarga horaria total: " + cargaHorariaTotal;
            //}
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

                    if (this.anioCarrera.CarreraEstadoId == (int)CarreraEstado.Activa || this.anioCarrera.CarreraEstadoId == (int)CarreraEstado.Inactiva)
                    {
                        tsmAgregarMateria.Visible = false;
                        tsmEliminarMateria.Visible = false;
                        tsmModificarMateria.Visible = false;
                    }
                    else if (anioCarrera.CarreraEstadoId == (int)CarreraEstado.Borrador)
                    {
                        tsmAgregarMateria.Visible = true;
                        tsmEliminarMateria.Visible = true;
                        tsmModificarMateria.Visible = true;
                        tsmModificarMateria.Text = "Modificar";
                        tsmVerCorrelatividades.Visible = this.anioCarrera.AnioCarrera != 1;
                        tsmVerCorrelatividades.Text = "Gestionar correlativas";
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

        private void dgvMatAnioCarrera_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMatAnioCarrera.Columns[e.ColumnIndex].Name == "Final / Promoción" && e.Value != null)
            {
                string valor = e.Value.ToString().Trim().ToUpper();

                if (valor == "F")
                {
                    e.Value = "Final";
                    e.FormattingApplied = true;
                }
                else if (valor == "P")
                {
                    e.Value = "Promocional";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}