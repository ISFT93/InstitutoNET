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

            try
            {
                if (this.Parameters != null)
                {
                    rvwReportes.LocalReport.SetParameters(this.Parameters);
                }
            }
            catch (Exception ex)
            {
                string errorReal = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Detalle del error: " + errorReal, "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.rvwReportes.RefreshReport();
        }
    }
}
