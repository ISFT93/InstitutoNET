using ISFDyT93.Negocio.Logica;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FolioExamenControl : UserControl
    {
        public int Idcarrera;

        private bool debeCerrar = false;

        LibroActasLogica libroActasLogica =
            new LibroActasLogica();


        public FolioExamenControl()
        {
            InitializeComponent();

            MinimumSize = Size.Empty;
            MaximumSize = Size.Empty;
        }



        public void CargarDatos(int carreraId)
        {
            Idcarrera = carreraId;

            // Si presionó anteriormente
            // "No mostrar nuevamente"
            if (ObtenerNoMostrarFolioExamen())
            {
                debeCerrar = true;
                return;
            }

            int folioActual =
                obtenerFolio(Idcarrera);

            // Mostrar solamente después del folio 180
            //if (folioActual >= 180)
            //{
                //debeCerrar = true;
              //  return;
            //}

            lblFolioActual.Text =
                folioActual.ToString();

            obtenerNombre(Idcarrera);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (debeCerrar)
            {
                BeginInvoke(new Action(() =>
                {
                    FindForm()?.Close();
                }));
            }
        }

        public int obtenerFolio(int idcarrera)
        {
            foreach (
                DataRow row in
                libroActasLogica.ObtenerLibros().Rows)
            {
                if (
                    row["CarreraID"] != DBNull.Value &&
                    Convert.ToInt32(
                        row["CarreraID"]) == idcarrera
                )
                {
                    return Convert.ToInt32(
                        row["FolioNumero"]);
                }
            }

            return 0;
        }


        public void obtenerNombre(int idcarrera)
        {
            foreach (
                DataRow row in
                libroActasLogica.ObtenerLibros().Rows)
            {
                if (
                    row["CarreraID"] != DBNull.Value &&
                    Convert.ToInt32(
                        row["CarreraID"]) == idcarrera
                )
                {
                    lblSistema.Text =
                        Convert.ToString(
                            row["DescripcionCorta"]);

                    lblNumeroLibro.Text =
                        Convert.ToString(
                            row["LibroNumero"]);

                    return;
                }
            }
        }


        // =============================================
        // EVENTOS
        // =============================================

        public event EventHandler OnAceptarClick;

        public event EventHandler
            OnNoMostrarNuevamenteClick;


        // =============================================
        // ACEPTAR
        // =============================================

        private void btnAceptar_Click_1(
            object sender,
            EventArgs e)
        {
            OnAceptarClick?.Invoke(
                this,
                EventArgs.Empty);

            FindForm()?.Close();
        }


        // =============================================
        // NO MOSTRAR NUEVAMENTE
        // =============================================

        private void btnNoMostrar_Click_1(
            object sender,
            EventArgs e)
        {
            GuardarNoMostrarFolioExamen(true);

            OnNoMostrarNuevamenteClick?.Invoke(
                this,
                EventArgs.Empty
            );

            FindForm()?.Close();
        }


        // =============================================
        // LEER APP.CONFIG
        // =============================================

        public static bool
            ObtenerNoMostrarFolioExamen()
        {
            try
            {
                string rutaConfig =
                    Application.ExecutablePath +
                    ".config";

                if (!File.Exists(rutaConfig))
                    return false;

                XmlDocument documento =
                    new XmlDocument();

                documento.Load(rutaConfig);

                XmlNode nodo =
                    documento.SelectSingleNode(
                        "/configuration/" +
                        "appSettings/" +
                        "add[@key=" +
                        "'NoMostrarFolioExamen']"
                    );

                if (nodo == null)
                    return false;

                string valor =
                    nodo.Attributes["value"]?.Value;

                if (
                    bool.TryParse(
                        valor,
                        out bool resultado)
                )
                {
                    return resultado;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }


        // =============================================
        // GUARDAR APP.CONFIG
        // =============================================

        public static void
            GuardarNoMostrarFolioExamen(
                bool valor)
        {
            try
            {
                string rutaConfig =
                    Application.ExecutablePath +
                    ".config";

                XmlDocument documento =
                    new XmlDocument();

                documento.Load(rutaConfig);

                XmlNode appSettings =
                    documento.SelectSingleNode(
                        "/configuration/appSettings"
                    );

                if (appSettings == null)
                {
                    appSettings =
                        documento.CreateElement(
                            "appSettings");

                    documento
                        .DocumentElement
                        .AppendChild(appSettings);
                }

                XmlNode nodo =
                    documento.SelectSingleNode(
                        "/configuration/" +
                        "appSettings/" +
                        "add[@key=" +
                        "'NoMostrarFolioExamen']"
                    );

                if (nodo == null)
                {
                    XmlElement nuevoNodo =
                        documento.CreateElement(
                            "add");

                    nuevoNodo.SetAttribute(
                        "key",
                        "NoMostrarFolioExamen"
                    );

                    nuevoNodo.SetAttribute(
                        "value",
                        valor
                            .ToString()
                            .ToLower()
                    );

                    appSettings.AppendChild(
                        nuevoNodo);
                }
                else
                {
                    nodo.Attributes["value"].Value =
                        valor
                            .ToString()
                            .ToLower();
                }

                documento.Save(rutaConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar la " +
                    "configuración.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}