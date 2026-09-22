using System;
using System.Windows.Forms;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Parametros
{
    public partial class FormAgregarEspacio : Form
    {
        private readonly EspacioFormacionLogica espacioLogica = new EspacioFormacionLogica();
        private int? espacioId = null;

        public FormAgregarEspacio()
        {
            InitializeComponent();
        }

        // Método que invoca opcionModificar_Click para precargar los datos
        public void CargarDatos(EspacioModelo modelo)
        {
            this.espacioId = modelo.EspacioId;
            this.txtDescripcion.Text = modelo.Descripcion;
            this.txtAcumulador.Text = modelo.Acumulador;
            this.chkSumaHoras.Checked = modelo.SumaHoras;
            this.chkCalculaPorcentaje.Checked = modelo.CalculaPorcentaje;

            this.lblTitulo.Text = "Modificar Espacio de Formación";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                FormNotificacion.Mensaje(TipoNotificacion.Warning, "Debe ingresar una descripción válida.");
                txtDescripcion.Focus();
                return;
            }

            var modelo = new EspacioModelo
            {
                Descripcion = txtDescripcion.Text.Trim(),
                Acumulador = string.IsNullOrWhiteSpace(txtAcumulador.Text) ? null : txtAcumulador.Text.Trim(),
                SumaHoras = chkSumaHoras.Checked,
                CalculaPorcentaje = chkCalculaPorcentaje.Checked
            };

            int resultado;

            if (espacioId.HasValue)
            {
                modelo.EspacioId = espacioId.Value;
                resultado = espacioLogica.ModificarEspacio(modelo);

                if (resultado > 0)
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Success, "Espacio modificado correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo modificar el espacio.");
                }
            }
            else
            {
                resultado = espacioLogica.AgregarEspacio(modelo);

                if (resultado > 0)
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Success, "Espacio agregado correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Error, "No se pudo agregar el espacio.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}