using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Forms.Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    internal abstract class FormDialogoEsquema : Form
    {
        protected readonly TableLayoutPanel Campos = new TableLayoutPanel();
        private readonly TableLayoutPanel barraAcciones = new TableLayoutPanel();
        private readonly ComponentResourceManager iconos = new ComponentResourceManager(typeof(FormAgregarCargos));
        private int cantidadCampos;

        protected FormDialogoEsquema(string titulo, int alto)
        {
            Text = titulo;
            Width = 700;
            Height = alto;
            MinimumSize = new Size(620, alto);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft Sans Serif", 8.25F);
            BackColor = Color.FromArgb(240, 240, 240);

            var cabecera = new Label
            {
                Dock = DockStyle.Top,
                Height = 46,
                Text = titulo,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(39, 39, 58)
            };

            Campos.Dock = DockStyle.Fill;
            Campos.ColumnCount = 2;
            Campos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Campos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Campos.Padding = new Padding(40, 22, 40, 5);
            Campos.AutoScroll = true;

            barraAcciones.Dock = DockStyle.Bottom;
            barraAcciones.Height = 95;
            barraAcciones.ColumnCount = 2;
            barraAcciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            barraAcciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            barraAcciones.Padding = new Padding(40, 8, 40, 16);
            barraAcciones.BackColor = BackColor;
            var cancelar = Boton("Cancelar", "btnCancelar.Image");
            cancelar.DialogResult = DialogResult.Cancel;
            cancelar.FlatAppearance.MouseOverBackColor = Color.Red;
            barraAcciones.Controls.Add(cancelar, 1, 0);
            CancelButton = cancelar;
            Controls.Add(Campos);
            Controls.Add(barraAcciones);
            Controls.Add(cabecera);
        }

        private Button Boton(string texto, string icono)
        {
            var boton = new Button
            {
                Text = texto,
                Dock = DockStyle.Fill,
                Margin = new Padding(4, 3, 24, 2),
                Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(39, 39, 58),
                FlatStyle = FlatStyle.Flat,
                Image = iconos.GetObject(icono) as Image,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            boton.FlatAppearance.BorderSize = 0;
            return boton;
        }

        protected void Campo(string etiqueta, Control control)
        {
            int fila = cantidadCampos / 2;
            int columna = cantidadCampos % 2;
            if (columna == 0)
            {
                Campos.RowCount++;
                Campos.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
            }
            cantidadCampos++;
            var campo = new Panel { Dock = DockStyle.Fill, Margin = new Padding(4, 0, 18, 6) };
            var titulo = new Label
            {
                Text = etiqueta,
                Dock = DockStyle.Top,
                Height = 26,
                Font = new Font("Microsoft Sans Serif", 9.75F),
                TextAlign = ContentAlignment.BottomLeft
            };
            control.Dock = DockStyle.Top;
            control.Margin = Padding.Empty;
            control.Font = new Font("Microsoft Sans Serif", 12F);
            if (control is CheckBox) control.Height = 32;
            campo.Controls.Add(control);
            campo.Controls.Add(titulo);
            Campos.Controls.Add(campo, columna, fila);
        }

        protected void GuardarAlAceptar(Action guardar)
        {
            var aceptar = Boton("Aceptar", "btnAñadir.Image");
            aceptar.Click += (s, e) =>
            {
                try
                {
                    guardar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException) return;
                    MessageBox.Show(this, ex.Message, "Esquemas de examen",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            barraAcciones.Controls.Add(aceptar, 0, 0);
            AcceptButton = aceptar;
        }
    }

    internal class FormTipoExamen : FormDialogoEsquema
    {
        private readonly TextBox descripcion = new TextBox();
        private readonly TextBox planilla = new TextBox();
        private readonly ComboBox tipoDato = new ComboBox();
        private readonly CheckBox requerido = new CheckBox();
        private readonly CheckBox activo = new CheckBox();

        public FormTipoExamen(EsquemaEvaluacionLogica logica, TipoExamenModelo original = null)
            : base(original == null ? "Añadir tipo de examen" : "Editar tipo de examen", 405)
        {
            descripcion.MaxLength = 250;
            planilla.MaxLength = 50;
            tipoDato.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoDato.Items.AddRange(new object[] { "Num", "texto" });
            descripcion.Text = original == null ? "" : original.Descripcion;
            planilla.Text = original == null ? "" : original.DescripcionPlanilla;
            tipoDato.SelectedItem = original == null ? "Num" : original.TipoDato;
            requerido.Checked = original != null && original.Requerido;
            activo.Checked = original == null || original.Activo;
            Campo("Descripción", descripcion);
            Campo("Planilla", planilla);
            Campo("Tipo de dato", tipoDato);
            Campo("Es requerido", requerido);
            Campo("Activo", activo);
            GuardarAlAceptar(() =>
            {
                if (string.IsNullOrWhiteSpace(descripcion.Text) ||
                    string.IsNullOrWhiteSpace(planilla.Text) || tipoDato.SelectedItem == null)
                    throw new InvalidOperationException("Completá descripción, planilla y tipo de dato.");

                logica.GuardarTipos(new List<TipoExamenModelo>
                {
                    new TipoExamenModelo
                    {
                        TipoExamenId = original == null ? 0 : original.TipoExamenId,
                        Descripcion = descripcion.Text.Trim(),
                        DescripcionPlanilla = planilla.Text.Trim(),
                        TipoDato = Convert.ToString(tipoDato.SelectedItem),
                        Requerido = requerido.Checked,
                        Activo = activo.Checked
                    }
                });
            });
        }
    }

    internal class FormComponenteEsquema : FormDialogoEsquema
    {
        private readonly NumericUpDown indice = new NumericUpDown();
        private readonly TextBox nombre = new TextBox();
        private readonly ComboBox tipo = new ComboBox();
        private readonly TextBox descripcion = new TextBox();
        private readonly TextBox planilla = new TextBox();
        private readonly TextBox dato = new TextBox();
        private readonly CheckBox requerido = new CheckBox();

        public FormComponenteEsquema(EsquemaEvaluacionLogica logica, DataTable tipos,
            string nombreEsquema, int indiceInicial, bool habilitado,
            bool nuevoEsquema, int codEsq = 0, int tipoInicial = 0)
            : base(nuevoEsquema ? "Añadir un nuevo esquema" :
                (codEsq == 0 ? "Añadir componente al esquema" : "Editar componente del esquema"), 500)
        {
            indice.Minimum = 1;
            indice.Maximum = 9999;
            indice.Value = Math.Max(1, Math.Min(9999, indiceInicial));
            nombre.Text = nombreEsquema;
            nombre.ReadOnly = true;
            descripcion.ReadOnly = true;
            planilla.ReadOnly = true;
            dato.ReadOnly = true;
            requerido.Enabled = false;

            tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            tipo.DisplayMember = "DescripcionPlanilla";
            tipo.ValueMember = "TipoExamenId";
            tipo.DataSource = tipos;
            if (tipoInicial > 0) tipo.SelectedValue = tipoInicial;
            tipo.SelectedIndexChanged += (s, e) => MostrarTipo();
            Shown += (s, e) => MostrarTipo();

            Campo("Índice", indice);
            Campo("Esquema", nombre);
            Campo("Tipo de examen", tipo);
            Campo("Descripción", descripcion);
            Campo("Planilla", planilla);
            Campo("Tipo de dato", dato);
            Campo("Es requerido", requerido);
            MostrarTipo();

            GuardarAlAceptar(() =>
            {
                if (tipo.SelectedValue == null || !(tipo.SelectedValue is int))
                    throw new InvalidOperationException("Seleccioná un tipo de examen. Si no hay tipos, agregá uno primero.");
                logica.GuardarEsquemas(new List<EsquemaEvaluacionModelo>
                {
                    new EsquemaEvaluacionModelo
                    {
                        CodEsq = codEsq,
                        Indice = (int)indice.Value,
                        Esquema = nombre.Text,
                        TipoExamenId = (int)tipo.SelectedValue,
                        Activo = habilitado,
                        NuevoEsquema = nuevoEsquema
                    }
                });
            });
        }

        private void MostrarTipo()
        {
            var seleccionado = tipo.SelectedItem as DataRowView;
            if (seleccionado == null) return;
            descripcion.Text = Convert.ToString(seleccionado["Descripcion"]);
            planilla.Text = Convert.ToString(seleccionado["DescripcionPlanilla"]);
            dato.Text = Convert.ToString(seleccionado["TipoDato"]);
            requerido.Checked = Convert.ToBoolean(seleccionado["Requerido"]);
        }
    }

    internal class FormEstadoEsquema : FormDialogoEsquema
    {
        private readonly ComboBox selector = new ComboBox();

        public FormEstadoEsquema(EsquemaEvaluacionLogica logica, DataTable esquemas, bool habilitar)
            : base(habilitar ? "Habilitar esquema" : "Deshabilitar esquema", 265)
        {
            var grupos = esquemas.Rows.Cast<DataRow>()
                .GroupBy(r => Convert.ToString(r["Esquema"]), StringComparer.OrdinalIgnoreCase)
                .Where(g => habilitar ? g.All(r => !Convert.ToBoolean(r["Activo"]))
                    : g.Any(r => Convert.ToBoolean(r["Activo"])))
                .Select(g => new { Nombre = g.Key, Titulo = g.Key + " — " + g.Count() + " componentes" })
                .ToList();
            selector.DropDownStyle = ComboBoxStyle.DropDownList;
            selector.DisplayMember = "Titulo";
            selector.ValueMember = "Nombre";
            selector.DataSource = grupos;
            Campo("Esquema", selector);
            GuardarAlAceptar(() =>
            {
                if (selector.SelectedValue == null)
                    throw new InvalidOperationException("No hay esquemas disponibles para esta acción.");
                if (MessageBox.Show(this,
                    (habilitar ? "¿Habilitar " : "¿Deshabilitar ") + selector.SelectedValue + "?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    throw new OperationCanceledException("Operación cancelada.");
                logica.CambiarEstadoEsquema(Convert.ToString(selector.SelectedValue), habilitar);
            });
        }
    }
}
