using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarEsquema : Form
    {
        EsquemaEvaluacionLogica esquemasLogica =
            new EsquemaEvaluacionLogica();

        public FormAgregarEsquema()
        {
            InitializeComponent();
            txtEsquema.ReadOnly = true;
            Load += FormAgregarEsquema_Load;
            txtIndice.MaxLength = 2;
            txtDescripcion.MaxLength = 12;
            txtPlanilla.MaxLength = 15;
            txtTipoDato.MaxLength = 5;
            txtIndice.KeyPress += (s, e) => FiltrarTecla(e, validaciones.SoloNumeros);
            txtDescripcion.KeyPress += (s, e) =>FiltrarTecla(e, validaciones.SoloLetrasYNumeros);
            txtPlanilla.KeyPress += (s, e) =>FiltrarTecla(e, validaciones.SoloLetrasYNumeros);
            txtTipoDato.KeyPress += (s, e) =>FiltrarTecla(e, validaciones.SoloLetras);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo(txtIndice, "Índice"))
                return;

            string textoIndice = txtIndice.Text.Trim();
            int indice;

            if (!validaciones.SoloNumeros(textoIndice) ||
                !int.TryParse(textoIndice, out indice))
            {
                MostrarErrorCampo(txtIndice, "Ingresá un índice entero válido usando solo dígitos.");
                return;
            }

            if (!ValidarCampo(txtEsquema, "Esquema") ||
                !ValidarCampo(txtDescripcion, "Descripción", validaciones.SoloLetrasYNumeros) ||
                !ValidarCampo(txtPlanilla, "Descripción de planilla", validaciones.SoloLetrasYNumeros) ||
                !ValidarCampo(txtTipoDato, "Tipo de dato", validaciones.SoloLetras))
            {
                return;
            }

            EsquemaEvaluacionModelo modelo = new EsquemaEvaluacionModelo()
                {
                    indice = indice,
                    esquema = txtEsquema.Text.Trim(),
                    ex_descripc = txtDescripcion.Text.Trim(),
                    ex_descripcion_planilla =
                        txtPlanilla.Text.Trim(),
                    ex_tipo_dat = txtTipoDato.Text,
                    ex_requeric = chkRequerido.Checked,
                    Activo = true
                };

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea guardar el esquema?\n\n" +
                "Esquema: " + modelo.esquema + "\n" +
                "Índice: " + modelo.indice + "\n" +
                "Descripción: " + modelo.ex_descripc + "\n" +
                "Descripción Planilla: " +
                    modelo.ex_descripcion_planilla + "\n" +
                "Tipo de dato: " + modelo.ex_tipo_dat + "\n" +
                "Requerido: " +
                    (modelo.ex_requeric ? "Sí" : "No"),
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                esquemasLogica.AgregarEsquema(modelo);

                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    "Esquema creado correctamente"
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al agregar el esquema: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private readonly Validaciones validaciones = new Validaciones();

        private bool ValidarCampo(
    Control campo, string nombre, Func<string, bool> formato = null)
        {
            string texto = campo.Text.Trim();

            if (!validaciones.Obligatorio(texto))
            {
                MostrarErrorCampo(campo, "Completá el campo «" + nombre + "».");
                return false;
            }

            if (formato != null && !formato(texto))
            {
                MostrarErrorCampo(campo, "Revisá los caracteres del campo «" + nombre + "».");
                return false;
            }

            return true;
        }

        private static void FiltrarTecla(KeyPressEventArgs e, Func<string, bool> formato)
        {
            if (!char.IsControl(e.KeyChar) && !formato(e.KeyChar.ToString()))
                e.Handled = true;
        }

        private void MostrarErrorCampo(Control campo, string mensaje)
        {
            MessageBox.Show(
                this, mensaje, "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning
            );

            campo.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarEsquema_Load(object sender, EventArgs e)
        {
            txtEsquema.Clear();

            try
            {
                const string prefijo = "Esqu";
                long mayor = 0;

                foreach (var esquema in esquemasLogica.ObtenerEsquemas())
                {
                    string nombre = (esquema.esquema ?? string.Empty).Trim();

                    if (!nombre.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
                        continue;

                    long numero;
                    if (long.TryParse(
                        nombre.Substring(prefijo.Length),
                        NumberStyles.None,
                        CultureInfo.InvariantCulture,
                        out numero))
                    {
                        mayor = Math.Max(mayor, numero);
                    }
                }

                long siguiente = checked(mayor + 1);
                txtEsquema.Text = prefijo + siguiente.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MostrarErrorCampo(
                    txtEsquema, "No se pudo generar el nombre del esquema. " + ex.Message
                );
            }
        }
    }
}
