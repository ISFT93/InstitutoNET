using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public sealed partial class FormAgregarDescripcion : Form
    {
        private readonly EsquemaEvaluacionLogica logica;
        private readonly Validaciones validaciones = new Validaciones();
        private readonly int codEsq;

        public FormAgregarDescripcion()
        {
            InitializeComponent();
        }

        public FormAgregarDescripcion(
            EsquemaEvaluacionLogica logica, DataTable esquemasActivos)
            : this(logica, BuscarEsquemaActivo(logica, esquemasActivos))
        {
        }

        public FormAgregarDescripcion(
            EsquemaEvaluacionLogica logica, EsquemaEvaluacionModelo esquemaActivo)
            : this()
        {
            if (esquemaActivo == null || !esquemaActivo.Activo)
                throw new InvalidOperationException("Primero creá o habilitá un esquema.");

            this.logica = logica;
            codEsq = esquemaActivo.CodEsq;

            Text = "Agregar descripción";
            lblCargos.Text = Text;
            StartPosition = FormStartPosition.CenterParent;

            txtEsquema.Text = esquemaActivo.esquema;
            txtIndice.Text = esquemaActivo.indice.ToString();
            txtEsquema.ReadOnly = true;
            txtIndice.ReadOnly = true;
            txtEsquema.TabStop = false;
            txtIndice.TabStop = false;

            txtDesscripcion.MaxLength = 12;
            txtPlanillaDescrripcion.MaxLength = 15;
            txtTipoDeDAto.MaxLength = 5;

            txtDesscripcion.KeyPress += FiltrarTecla;
            txtPlanillaDescrripcion.KeyPress += FiltrarTecla;
            txtTipoDeDAto.KeyPress += FiltrarTecla;

            var requerido = new Label
            {
                Text = "Es requerido: " + (esquemaActivo.ex_requeric ? "Sí" : "No"),
                AutoSize = true,
                Location = new Point(12, 110)
            };

            var aceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(83, 197),
                Size = new Size(105, 30)
            };
            aceptar.Click += Aceptar_Click;

            var cancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(207, 197),
                Size = new Size(105, 30),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(requerido);
            Controls.Add(aceptar);
            Controls.Add(cancelar);
            AcceptButton = aceptar;
            CancelButton = cancelar;
        }

        private static EsquemaEvaluacionModelo BuscarEsquemaActivo(
            EsquemaEvaluacionLogica logica, DataTable esquemasActivos)
        {
            var codigos = new HashSet<int>(esquemasActivos.Rows.Cast<DataRow>()
                .Select(fila => Convert.ToInt32(fila["CodEsq"])));

            return logica.ObtenerEsquemas()
                .Where(esquema => esquema.Activo && codigos.Contains(esquema.CodEsq))
                .GroupBy(esquema => esquema.esquema, StringComparer.OrdinalIgnoreCase)
                .Select(grupo => grupo.OrderBy(esquema => esquema.CodEsq).First())
                .OrderByDescending(esquema => esquema.CodEsq)
                .FirstOrDefault();
        }

        private void FiltrarTecla(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !validaciones.SoloLetrasYNumeros(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampo(TextBox campo, string nombre)
        {
            if (validaciones.Obligatorio(campo.Text) &&
                validaciones.SoloLetrasYNumeros(campo.Text))
            {
                return true;
            }

            MessageBox.Show(this, "Ingresá letras o números en «" + nombre + "».");
            campo.Focus();
            return false;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo(txtDesscripcion, "Descripción") ||
                !ValidarCampo(txtPlanillaDescrripcion, "Planilla") ||
                !ValidarCampo(txtTipoDeDAto, "Tipo de dato"))
            {
                return;
            }

            try
            {
                logica.AgregarDescripcion(
                    codEsq,
                    txtDesscripcion.Text,
                    txtPlanillaDescrripcion.Text,
                    txtTipoDeDAto.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Agregar descripción",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}