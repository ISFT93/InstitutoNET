using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Parametro;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscClasificacionCarreras : UserControl
    {
        private ClasificacionCarrerasLogica logica;
        private ContextMenuStrip cmsMenuPrincipal;

        public uscClasificacionCarreras()
        {
            DoubleBuffered = true;
            InitializeComponent();
            logica = new ClasificacionCarrerasLogica();

            dgvClasificacion.ReadOnly = false;
            dgvClasificacion.EditMode = DataGridViewEditMode.EditOnEnter;

            ConfigurarMenuContextual();

            // Suscribimos el evento para controlar el menú contextual según la columna
            dgvClasificacion.CellMouseDown += dgvClasificacion_CellMouseDown;

            // Inicializamos la estructura y datos una sola vez al arrancar
            InicializarEstructuraGrilla();
            AplicarEstiloGrilla();
        }

        private void uscClasificacionCarreras_Load(object sender, EventArgs e)
        {
            flpContenedor.Visible = false; // contenedor oculto al iniciar
            this.Height = 60;              // altura de entrada, igual que uscMostrarCargos
        }

        private void chkClasificacion_CheckedChanged(object sender, EventArgs e)
        {
            MostrarOcultar();
        }

        private void MostrarOcultar()
        {
            if (chkClasificacion.Checked)
            {
                this.Height = 350;
                flpContenedor.Visible = true;
                AjustarAnchoGrilla();
            }
            else
            {
                flpContenedor.Visible = false;
                this.Height = 60;
            }

            if (this.Parent != null)
            {
                this.Parent.PerformLayout();
            }
        }

        private void flpContenedor_SizeChanged(object sender, EventArgs e)
        {
            AjustarAnchoGrilla();
        }

        // La grilla ocupa todo el contenedor (FlowLayoutPanel no admite Dock en sus hijos)
        private void AjustarAnchoGrilla()
        {
            dgvClasificacion.Width = flpContenedor.ClientSize.Width;
            dgvClasificacion.Height = flpContenedor.ClientSize.Height;
        }

        private void InicializarEstructuraGrilla()
        {
            try
            {
                DataTable dt = logica.ObtenerClasificacion();

                // Si viene nulo o sin esquema de columnas, se lo creamos manualmente para que nunca falle al agregar filas
                if (dt == null || dt.Columns.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Descripcion", typeof(string));
                    dt.Columns.Add("DescripcionCorta", typeof(string));
                    dt.Columns.Add("Horas", typeof(int));
                    dt.Columns.Add("Activo", typeof(bool));
                }

                dgvClasificacion.DataSource = null;
                dgvClasificacion.Columns.Clear();

                // 1. Columna Descripción
                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripcion",
                    Width = 435,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                dgvClasificacion.Columns.Add(colDescripcion);

                // 2. Columna Descripción Corta
                DataGridViewTextBoxColumn colDescripcionCorta = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DescripcionCorta",
                    HeaderText = "DescripcionCorta",
                    Width = 435,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                dgvClasificacion.Columns.Add(colDescripcionCorta);

                // 3. Columna Horas
                DataGridViewTextBoxColumn colHoras = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Horas",
                    HeaderText = "Horas",
                    Width = 85,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                dgvClasificacion.Columns.Add(colHoras);

                // 4. Columna Activo
                DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Activo",
                    HeaderText = "Activo",
                    Width = 75,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                dgvClasificacion.Columns.Add(colActivo);

                dgvClasificacion.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la estructura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarEstiloGrilla()
        {
            dgvClasificacion.EnableHeadersVisualStyles = false;
            dgvClasificacion.RowHeadersVisible = false;
            dgvClasificacion.AllowUserToAddRows = false;
            dgvClasificacion.AllowUserToResizeRows = false;
            dgvClasificacion.BorderStyle = BorderStyle.FixedSingle;
            dgvClasificacion.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvClasificacion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvClasificacion.GridColor = Color.Silver;
            dgvClasificacion.BackgroundColor = Color.White;

            // BLOQUEO GENERAL: Nadie puede escribir directamente sobre las celdas de texto
            dgvClasificacion.ReadOnly = true;

            // Permitimos que SOLO la columna del checkbox ("Activo") se pueda marcar/desmarcar con un clic
            if (dgvClasificacion.Columns["Activo"] != null)
            {
                dgvClasificacion.Columns["Activo"].ReadOnly = false;
            }

            dgvClasificacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvClasificacion.ColumnHeadersHeight = 35;
            dgvClasificacion.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvClasificacion.RowTemplate.Height = 30;
            dgvClasificacion.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.FromArgb(0, 120, 215),
                SelectionForeColor = Color.White,
                Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            if (dgvClasificacion.Columns.Count > 2)
                dgvClasificacion.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigurarMenuContextual()
        {
            cmsMenuPrincipal = new ContextMenuStrip { ImageScalingSize = new System.Drawing.Size(24, 24) };

            // Suscribimos el evento Opening para poblar el menú justo antes de que se muestre
            cmsMenuPrincipal.Opening += CmsMenuPrincipal_Opening;

            dgvClasificacion.ContextMenuStrip = cmsMenuPrincipal;
        }

        private ToolStripMenuItem CrearItemMenu(string texto, Image icono, EventHandler eventoClick)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(texto)
            {
                BackColor = Color.FromArgb(51, 51, 76),
                ForeColor = Color.White,
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Image = icono
            };
            if (eventoClick != null) item.Click += eventoClick;
            return item;
        }

        private void dgvClasificacion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Solo nos aseguramos de seleccionar la celda/fila donde se hizo clic derecho si es válida
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvClasificacion.ClearSelection();
                dgvClasificacion.Rows[e.RowIndex].Selected = true;
                dgvClasificacion.CurrentCell = dgvClasificacion.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void CmsMenuPrincipal_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsMenuPrincipal.Items.Clear();
            Image iconoAgregar = global::ISFDyT93.Vista.Properties.Resources.user_plus_solid;
            DataTable dt = (DataTable)dgvClasificacion.DataSource;

            // CASO 1: Grilla vacía o clic fuera de las filas -> Permitir agregar la primera Familia
            if (dt == null || dt.Rows.Count == 0 || dgvClasificacion.CurrentRow == null || dgvClasificacion.CurrentRow.Index < 0)
            {
                cmsMenuPrincipal.Items.Add(CrearItemMenu("Agregar Familia", iconoAgregar, (s, ev) => AbrirModalCarga("Familia")));
                return;
            }

            int rowIndex = dgvClasificacion.CurrentRow.Index;
            int columnIndex = dgvClasificacion.CurrentCell.ColumnIndex;
            string nombreColumna = dgvClasificacion.Columns[columnIndex].DataPropertyName;

            bool estadoActual = true;
            if (rowIndex < dt.Rows.Count)
            {
                estadoActual = Convert.ToBoolean(dt.Rows[rowIndex]["Activo"]);
            }
            string textoHabilitarDeshabilitar = estadoActual ? "Deshabilitar" : "Habilitar";

            if (nombreColumna == "Descripcion")
            {
                cmsMenuPrincipal.Items.Add(CrearItemMenu("Agregar Familia", iconoAgregar, (s, ev) => AbrirModalCarga("Familia")));
            }
            else if (nombreColumna == "DescripcionCorta")
            {
                cmsMenuPrincipal.Items.Add(CrearItemMenu("Agregar Variable", iconoAgregar, (s, ev) => AbrirModalCarga("Variable")));
            }
            else
            {
                cmsMenuPrincipal.Items.Add(CrearItemMenu(textoHabilitarDeshabilitar, global::ISFDyT93.Vista.Properties.Resources.minus_circle_solid, AccionActivarInactivar));
                return;
            }

            cmsMenuPrincipal.Items.Add(new ToolStripSeparator());
            cmsMenuPrincipal.Items.Add(CrearItemMenu(textoHabilitarDeshabilitar, global::ISFDyT93.Vista.Properties.Resources.minus_circle_solid, AccionActivarInactivar));
        }
        private object CalcularHoras(string descCorta)
        {
            if (descCorta.Equals("Anual", StringComparison.OrdinalIgnoreCase)) return 32;
            if (descCorta.Equals("Cuatrimestral", StringComparison.OrdinalIgnoreCase)) return 16;
            if (descCorta.Equals("Presencial", StringComparison.OrdinalIgnoreCase) ||
                descCorta.Equals("Virtual", StringComparison.OrdinalIgnoreCase) ||
                descCorta.Equals("Híbrido", StringComparison.OrdinalIgnoreCase)) return 0;
            return DBNull.Value;
        }

        private void AbrirModalCarga(string grupo)
        {
            try
            {
                DataTable dt = (DataTable)dgvClasificacion.DataSource;
                if (dt == null) return;

                string familiaSeleccionada = "";

                if (grupo == "Variable")
                {
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Debe agregar una Familia primero antes de poder cargar una Variable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataRowView vista = dgvClasificacion.CurrentRow?.DataBoundItem as DataRowView;
                    if (vista == null)
                    {
                        MessageBox.Show("Por favor, seleccione primero la fila de la Familia donde desea agregar esta variable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    familiaSeleccionada = vista.Row["Descripcion"]?.ToString()?.Trim() ?? "";
                    if (string.IsNullOrEmpty(familiaSeleccionada))
                    {
                        MessageBox.Show("La fila seleccionada no tiene una Familia válida asignada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (FormCargarClasificacion frm = new FormCargarClasificacion(grupo))
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;

                    if (grupo == "Familia")
                    {
                        string descNueva = frm.DescripcionSeleccionada?.Trim() ?? "";

                        // La familia puede repetirse (una fila por variable), pero no puede haber
                        // dos filas de la misma familia sin variable asignada
                        foreach (DataRow row in dt.Rows)
                        {
                            string d = row["Descripcion"]?.ToString()?.Trim() ?? "";
                            string dc = row["DescripcionCorta"]?.ToString()?.Trim() ?? "";
                            if (d.Equals(descNueva, StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(dc))
                            {
                                MessageBox.Show("Esta familia ya se encuentra cargada sin variable. Agregale una variable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        DataRow nuevaFila = dt.NewRow();
                        nuevaFila["Descripcion"] = descNueva;
                        nuevaFila["DescripcionCorta"] = "";
                        nuevaFila["Activo"] = true;
                        dt.Rows.Add(nuevaFila);
                    }
                    else
                    {
                        string descCorta = frm.DescripcionCortaSeleccionada?.Trim() ?? "";

                        DataRow filaVacia = null;
                        foreach (DataRow row in dt.Rows)
                        {
                            string d = row["Descripcion"]?.ToString()?.Trim() ?? "";
                            string dc = row["DescripcionCorta"]?.ToString()?.Trim() ?? "";

                            if (!d.Equals(familiaSeleccionada, StringComparison.OrdinalIgnoreCase)) continue;

                            if (dc.Equals(descCorta, StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Ya existe esta misma variable asignada a esta familia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (string.IsNullOrEmpty(dc) && filaVacia == null)
                                filaVacia = row;
                        }

                        DataRow destino;
                        if (filaVacia != null)
                        {
                            // La familia aún no tiene variable: se completa su fila, sin duplicarla
                            destino = filaVacia;
                        }
                        else
                        {
                            // La familia ya tiene variables: se agrega una fila nueva para la nueva variable
                            destino = dt.NewRow();
                            destino["Descripcion"] = familiaSeleccionada;
                            destino["Activo"] = true;
                            dt.Rows.Add(destino);
                        }

                        destino["DescripcionCorta"] = descCorta;
                        destino["Horas"] = CalcularHoras(descCorta);

                        // Elimina cualquier otra fila en blanco de la misma familia
                        var sobrantes = new System.Collections.Generic.List<DataRow>();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row == destino) continue;
                            string d = row["Descripcion"]?.ToString()?.Trim() ?? "";
                            string dc = row["DescripcionCorta"]?.ToString()?.Trim() ?? "";
                            if (d.Equals(familiaSeleccionada, StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(dc))
                                sobrantes.Add(row);
                        }
                        foreach (DataRow row in sobrantes) dt.Rows.Remove(row);
                    }

                    // Guardado definitivo apenas se confirma en el formulario de carga
                    PersistirCambios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Guarda en la base lo que hay en la grilla y la recarga desde la base
        private void PersistirCambios()
        {
            DataTable dt = (DataTable)dgvClasificacion.DataSource;
            if (dt == null) return;

            dgvClasificacion.EndEdit();

            try
            {
                logica.GuardarClasificacionCompleta(dt);
            }
            finally
            {
                // Si falló, la grilla vuelve a lo que realmente está en la base
                InicializarEstructuraGrilla();
                AplicarEstiloGrilla();
            }
        }
        public void GuardarClasificacion()
        {
            try
            {
                DataTable dt = (DataTable)dgvClasificacion.DataSource;

                if (dt == null)
                {
                    MessageBox.Show("No hay registros para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                logica.GuardarClasificacionCompleta(dt);

                MessageBox.Show("Clasificación guardada con éxito en la base de datos.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccionActivarInactivar(object sender, EventArgs e)
        {
            try
            {
                if (dgvClasificacion.CurrentRow != null)
                {
                    int index = dgvClasificacion.CurrentRow.Index;
                    DataTable dt = (DataTable)dgvClasificacion.DataSource;
                    bool estadoActual = Convert.ToBoolean(dt.Rows[index]["Activo"]);
                    dt.Rows[index]["Activo"] = !estadoActual;
                    dgvClasificacion.Refresh();
                    PersistirCambios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccionEliminar(object sender, EventArgs e)
        {
            try
            {
                if (dgvClasificacion.CurrentRow != null)
                {
                    dgvClasificacion.Rows.RemoveAt(dgvClasificacion.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}