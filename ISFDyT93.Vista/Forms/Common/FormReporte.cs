using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Forms.Carreras;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ISFDyT93.Vista.Forms.Common
{
    public partial class FormReporte : FormBase
    {
        public string Reporte { get; set; }
        public IList<ReportTable> Tables { get; set; }
        public IList<ReportParameter> Parameters { get; set; }
        public string TituloReporte { get; set; }
        private bool reporteListo;
        private bool exportando;

        public FormReporte SetTituloReporte(string titulo)
        {
            TituloReporte = titulo;
            return this;
        }

        public FormReporte SetReporte(string value)
        {
            this.Reporte = value;
            return this;
        }

        public FormReporte AddDataSource(DataTable data, string dataBinding)
        {
            if(Tables == null)
            {
                this.Tables = new List<ReportTable>();
            }

            this.Tables.Add(new ReportTable() { DataSource = data, DataBinding = dataBinding });

            return this;
        }

        public FormReporte AddParameter(string name, string value)
        {
            if (Parameters == null)
            {
                this.Parameters = new List<ReportParameter>();
            }

            var parameter = new ReportParameter() { Name = name };
            parameter.Values.Add(value);
            this.Parameters.Add(parameter);

            return this;
        }

        public FormReporte()
        {
            InitializeComponent();
            ConfigurarBoton(this.btnImprimir, "btnImprimir", "Imprimir", FontAwesome.Sharp.IconChar.Print, 0);
            ConfigurarBoton(this.btnExportarPdf, "btnExportarPdf", "Exportar PDF", FontAwesome.Sharp.IconChar.FilePdf, 1);
            ConfigurarBoton(this.btnAjustarPagina, "btnAjustarPagina", "Ajustar página", FontAwesome.Sharp.IconChar.Expand, 2);
            ConfigurarBoton(this.btnAjustarAncho, "btnAjustarAncho", "Ajustar ancho", FontAwesome.Sharp.IconChar.ArrowsLeftRight, 3);

            rvwReportes.RenderingBegin += (s, e) =>
            {
                reporteListo = false;
                lblEstado.Text = "Preparando reporte…";
                ActualizarAcciones();
            };
            rvwReportes.RenderingComplete += (s, e) =>
            {
                reporteListo = e.Exception == null;
                lblEstado.Text = reporteListo ? "Listo para imprimir" : "No se pudo generar el reporte";
                ActualizarAcciones();
            };
        }

        private void ConfigurarBoton(FontAwesome.Sharp.IconButton boton, string nombre, string texto,
            FontAwesome.Sharp.IconChar icono, int orden)
        {
            boton.Name = nombre;
            boton.Text = texto;
            boton.Size = new System.Drawing.Size(156, 38);
            boton.Margin = new System.Windows.Forms.Padding(3);
            boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            boton.ForeColor = System.Drawing.Color.White;
            boton.IconChar = icono;
            boton.IconColor = System.Drawing.Color.White;
            boton.IconSize = 20;
            boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            boton.TabIndex = orden;
            boton.Enabled = false;
            boton.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            try
            {
                rvwReportes.Reset();
                rvwReportes.ProcessingMode = ProcessingMode.Local;
                // Algunos consumidores conservan el namespace anterior del proyecto.
                if (Reporte != null && Reporte.StartsWith("Diseño.Reports.", StringComparison.Ordinal))
                    Reporte = "ISFDyT93.Vista.Reports." + Reporte.Substring("Diseño.Reports.".Length);
                rvwReportes.LocalReport.ReportEmbeddedResource = Reporte;
                lblTitulo.Text = TituloReporte ?? NombreReporte();
                Text = lblTitulo.Text;
                rvwReportes.LocalReport.DisplayName = NombreArchivo();
                if (Tables != null)
                {
                    foreach (var table in Tables)
                        rvwReportes.LocalReport.DataSources.Add(new ReportDataSource(table.DataBinding, table.DataSource));
                }
                if (Parameters != null && Parameters.Count > 0)
                    rvwReportes.LocalReport.SetParameters(Parameters);
                rvwReportes.ShowPrintButton = false;
                // El menú nativo conserva Word/Excel y otros formatos existentes.
                rvwReportes.ShowExportButton = true;
                rvwReportes.ShowZoomControl = false;
                rvwReportes.ZoomMode = ZoomMode.PageWidth;
                // Cambiar a diseño de impresión ya inicia el renderizado. Un
                // RefreshReport inmediato cancela ese trabajo (ThreadAbort).
                if (rvwReportes.DisplayMode != DisplayMode.PrintLayout)
                    rvwReportes.SetDisplayMode(DisplayMode.PrintLayout);
                else
                    rvwReportes.RefreshReport();
            }
            catch (Exception ex)
            {
                reporteListo = false;
                lblEstado.Text = "No se pudo cargar el reporte";
                MessageBox.Show(this, "No se pudo abrir el reporte. " + ex.Message,
                    "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarAcciones();
            Contenedor.SetTitulo("Vista de impresión").SetVolver(() =>
            {
                Contenedor.AbrirFormulario<FormMesasFinales>(form =>{});
            });
        }

        private string NombreReporte()
        {
            var partes = (Reporte ?? "Reporte.rdlc").Split('.');
            return partes.Length > 1 ? partes[partes.Length - 2] : "Reporte";
        }

        private string NombreArchivo()
        {
            var nombre = TituloReporte ?? NombreReporte();
            foreach (char invalido in Path.GetInvalidFileNameChars()) nombre = nombre.Replace(invalido, '_');
            return nombre;
        }

        private void ActualizarAcciones()
        {
            if (IsDisposed || Disposing) return;
            btnImprimir.Enabled = btnExportarPdf.Enabled = btnAjustarPagina.Enabled =
                btnAjustarAncho.Enabled = reporteListo && !exportando;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try { rvwReportes.PrintDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo iniciar la impresión. " + ex.Message,
                    "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjustarPagina_Click(object sender, EventArgs e)
        {
            rvwReportes.ZoomMode = ZoomMode.FullPage;
        }

        private void btnAjustarAncho_Click(object sender, EventArgs e)
        {
            rvwReportes.ZoomMode = ZoomMode.PageWidth;
        }

        private async void btnExportarPdf_Click(object sender, EventArgs e)
        {
            using (var dialogo = new SaveFileDialog
            {
                Title = "Exportar reporte a PDF", Filter = "Documento PDF (*.pdf)|*.pdf",
                DefaultExt = "pdf", AddExtension = true, OverwritePrompt = true,
                FileName = NombreArchivo() + ".pdf", RestoreDirectory = true
            })
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK) return;
                exportando = true;
                ActualizarAcciones();
                lblEstado.Text = "Exportando PDF…";
                try
                {
                    // Snapshot en el hilo de UI. El worker posee su propio LocalReport:
                    // nunca renderizar el informe del visor desde un hilo de fondo.
                    var recurso = Reporte;
                    var tablas = (Tables ?? new List<ReportTable>()).Select(t => new ReportTable
                        { DataBinding = t.DataBinding, DataSource = t.DataSource.Copy() }).ToList();
                    var parametros = rvwReportes.LocalReport.GetParameters().Select(p =>
                        new ReportParameter(p.Name, p.Values.ToArray())).ToArray();
                    var archivo = dialogo.FileName;
                    await Task.Run(() =>
                    {
                        using (var reporte = new LocalReport())
                        using (var definicion = typeof(FormReporte).Assembly.GetManifestResourceStream(recurso))
                        {
                            if (definicion == null) throw new InvalidOperationException("No se encontró el archivo RDLC.");
                            reporte.LoadReportDefinition(definicion);
                            foreach (var tabla in tablas)
                                reporte.DataSources.Add(new ReportDataSource(tabla.DataBinding, tabla.DataSource));
                            if (parametros.Length > 0) reporte.SetParameters(parametros);
                            // Sin DeviceInfo que cambie dimensiones: se respeta el papel del RDLC.


                            try
                            {
                                byte[] pdf = rvwReportes.LocalReport.Render("PDF");

                                File.WriteAllBytes(dialogo.FileName, pdf);

                                MessageBox.Show(
                                    "PDF exportado correctamente.",
                                    "Exportación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(
                                    ex.ToString(),
                                    "Error al exportar PDF",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }

                        }
                    });
                    if (!IsDisposed && !Disposing) lblEstado.Text = "PDF guardado";
                }
                catch (Exception ex)
                {
                    if (!IsDisposed && !Disposing)
                    {
                        lblEstado.Text = "No se pudo exportar";
                        MessageBox.Show(this, "No se pudo guardar el PDF. " + ex.Message,
                            "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally { exportando = false; ActualizarAcciones(); }
            }
        }
    }
}
