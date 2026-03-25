using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.UserControls;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Vista.Core.Enums;
using System.Data;
using System.Collections;

namespace ISFDyT93.Vista
{
    public partial class FormParametros : FormBase
    {
        public FormParametros()
        {
            InitializeComponent();
        }

        private List<TipoParametro> tipoParametro = new List<TipoParametro>();
        ParametrosLogica parametros = new ParametrosLogica();
        private IList<ParametrosModelo> LtsParametros { get; set; }
        private List<uscCargos> ltsUscCargos = new List<uscCargos>();

        #region Eventos
        private void FormParametros_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetTitulo("Parametros");

            LtsParametros = parametros.ObtenerParametros();

            CargarTiposParametros();

            CargarControles();
        }
        private void Check_Changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                switch (checkBox.Name)
                {
                    case "chkTabla":
                        Deschekear();
                        break;
                    case "chkFecha":
                        chkTabla.Checked = false;
                        break;
                    case "chkTexto":
                        chkTabla.Checked = false;
                        break;
                    case "chkNumero":
                        chkTabla.Checked = false;
                        break;
                    case "chkHora":
                        chkTabla.Checked = false;
                        break;
                }
                btnBuscar_Click(btnBuscar, null);
            }

            void Deschekear()
            {
                chkFecha.Checked = false;
                chkTexto.Checked = false;
                chkNumero.Checked = false;
                chkHora.Checked = false;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!chkFecha.Checked && !chkTexto.Checked && !chkNumero.Checked && !chkHora.Checked && !chkTabla.Checked)
            {
                chkTabla.Checked = true;
            }
            CargarTiposParametros();
            CargarControles();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(chkTabla.Checked)
            {
                foreach(var control in flpContenedor.Controls)
                {
                    if (control.GetType() == typeof(uscCargos))
                        ((uscCargos)control).Guardar();
                }
            }
            else if (LtsParametros.Count > 0)
            {
                int Nro = parametros.ActualizarParametros(LtsParametros);
                if (Nro > 0) Notificar(TipoNotificacion.Success, "Parametros Actualizados");
                else Notificar(TipoNotificacion.Error, "Error al Actualizar");
            }

        }
        #endregion

        private void CargarTiposParametros()
        {
            tipoParametro.Clear();
            if (chkTabla.Checked)
            {
                tipoParametro.Add(TipoParametro.Table);
            }
            else
            {
                if (chkFecha.Checked) tipoParametro.Add(TipoParametro.Date);
                if (chkTexto.Checked) tipoParametro.Add(TipoParametro.Text);
                if (chkNumero.Checked) tipoParametro.Add(TipoParametro.Num);
                if (chkHora.Checked) tipoParametro.Add(TipoParametro.Time);
            }
        }
        private void CargarControles()
        {
            flpContenedor.Controls.Clear();
            if (tipoParametro.IndexOf(TipoParametro.Table) != -1)
            {
                uscCargos cargos = new uscCargos();
                flpContenedor.Controls.Add(cargos);
            }
            else
            {
                if (LtsParametros.Count > 0)
                {

                    foreach (ParametrosModelo parametro in LtsParametros)
                    {
                        string nombre = parametro.Nombre.ToLower();
                        if (tipoParametro.IndexOf((TipoParametro)parametro.TipoId) != -1 && nombre.Contains(txtBuscar.Text.Trim().ToLower()))
                            flpContenedor.Controls.Add(new uscParametro(parametro));
                    }

                }
            }
        }
    }
}
