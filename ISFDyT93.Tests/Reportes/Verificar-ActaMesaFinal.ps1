param([switch]$BaseLocal)
# Ejecutar con Windows PowerShell 5.1 (ReportViewer requiere .NET Framework).
$ErrorActionPreference = 'Stop'
$repo = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
$bin = Join-Path $repo 'ISFDyT93.Vista/bin/Debug'
$salida = Join-Path $env:TEMP 'ISFDyT93-ActaMesaFinal-tests'
New-Item -ItemType Directory -Force -Path $salida | Out-Null
$source = @'
using System;
using System.Data;
using System.IO;
using Microsoft.Reporting.WinForms;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Forms.Common;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;
using System.Threading;
using System.Diagnostics;

class VerificarActa
{
    static void Require(bool ok, string message) { if (!ok) throw new Exception(message); }
    static void ExpectInvalid(Action action, string message)
    {
        try { action(); } catch (InvalidOperationException) { return; }
        throw new Exception(message);
    }
    static void VerifyViewer(string repo, string output)
    {
        XNamespace ns = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition";
        XNamespace rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";
        foreach (string name in new[] { "AlumnosActivos", "MesasFinales", "ControlAsistencias", "HistorialAsistenciasAlumnos", "Personas" })
        {
            using (var form = new FormReporte())
            {
                var xml = XDocument.Load(Path.Combine(repo, "ISFDyT93.Vista", "Reports", name+".rdlc"));
                form.SetReporte((name == "ControlAsistencias" || name == "HistorialAsistenciasAlumnos" ? "Diseño.Reports." : "ISFDyT93.Vista.Reports.") + name + ".rdlc");
                foreach (var ds in xml.Descendants(ns+"DataSet"))
                {
                    var table = new DataTable();
                    foreach (var field in ds.Descendants(ns+"Field"))
                        table.Columns.Add((string)field.Attribute("Name"), Type.GetType((string)field.Element(rd+"TypeName") ?? "System.String"));
                    form.AddDataSource(table, (string)ds.Attribute("Name"));
                }
                foreach (var parameter in xml.Descendants(ns+"ReportParameter"))
                    form.AddParameter((string)parameter.Attribute("Name"), (string)parameter.Element(ns+"DataType") == "Boolean" ? "False" : ((string)parameter.Element(ns+"DataType") == "DateTime" ? "2026-10-09T00:00:00" : "1"));
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(-30000,-30000);
                form.ShowInTaskbar = false;
                var viewer = (ReportViewer)form.Controls.Find("rvwReportes", true)[0];
                bool complete = false;
                Exception failure = null;
                viewer.RenderingComplete += (sender, e) => { complete = true; failure = e.Exception; };
                form.Show();
                var clock = Stopwatch.StartNew();
                while (!complete && clock.ElapsedMilliseconds < 20000) { Application.DoEvents(); Thread.Sleep(20); }
                Require(complete && failure == null, name + ": fallo al cargar en FormReporte: " + failure);
                Require(form.Controls.Find("btnImprimir",true)[0].Enabled, "Impresion debe habilitarse tras renderizar.");
                ((Button)form.Controls.Find("btnAjustarPagina",true)[0]).PerformClick();
                Require(viewer.ZoomMode == ZoomMode.FullPage, "Ajustar pagina.");
                ((Button)form.Controls.Find("btnAjustarAncho",true)[0]).PerformClick();
                Require(viewer.ZoomMode == ZoomMode.PageWidth, "Ajustar ancho.");
                foreach (var size in new[] {new Size(420,350),new Size(800,600),new Size(1280,800)})
                {
                    form.ClientSize = size;
                    form.PerformLayout(); Application.DoEvents();
                    var bar = form.Controls.Find("barraAcciones",true)[0];
                    Require(viewer.Top >= bar.Bottom, "La barra se superpone con el visor.");
                    Require(viewer.Width > 0 && viewer.Height > 0, "Visor sin espacio.");
                    foreach (Control button in bar.Controls)
                        Require(bar.ClientRectangle.Contains(button.Bounds), "Boton fuera de la barra: " + button.Name);
                }
                var pdf = viewer.LocalReport.Render("PDF");
                Require(pdf.Length > 1000, name+": PDF vacio.");
                File.WriteAllBytes(Path.Combine(output, "compatibilidad-"+name+".pdf"), pdf);
                Console.WriteLine("PASS: " + name + " en FormReporte, zoom, 3 tamanos y PDF.");
                form.Close();
            }
        }
    }
    [STAThread]
    static int Main(string[] args)
    {
        try
        {
            if (args.Length > 2)
            {
                var dao = new MesasFinalesDao();
                var mesa = dao.ObtenerMesaReporte(1);
                Require(mesa.Rows.Count == 1, "La mesa de prueba debe existir.");
                Require(mesa.Columns.Contains("CicloLectivoId"), "Falta el ciclo lectivo real en el encabezado.");
                Require(Convert.ToInt32(mesa.Rows[0]["CicloLectivoId"]) == 2024, "El ciclo lectivo no puede ser MesaFinalId.");
                Require(Convert.ToString(mesa.Rows[0]["Estado"]) == "Activa", "Debe utilizar FinalEstados.");
                Require(dao.ObtenerMesaReporte(int.MaxValue).Rows.Count == 0, "Mesa inexistente.");
                var negocio = new MesasFinalesLogica();
                Require(negocio.ObtenerMesaReporte(1).Rows.Count == 1, "Mesa activa.");
                ExpectInvalid(() => negocio.ObtenerMesaReporte(11), "Debe rechazar Borrador.");
                ExpectInvalid(() => negocio.ObtenerMesaReporte(int.MaxValue), "Debe rechazar mesa inexistente.");
                var alumnos = negocio.ObtenerAlumnosMesaReporte(1);
                Require(alumnos.Rows.Count == 0 && !string.IsNullOrEmpty(Convert.ToString(alumnos.ExtendedProperties["AvisoInscripciones"])), "Falta de relacion no debe ocultarse como cero inscriptos.");
                Console.WriteLine("PASS: encabezado real, catalogo de estados y mesa inexistente (solo lectura).");
            }
            var reportPath = Path.Combine(args[0], "ISFDyT93.Vista", "Reports", "ActaMesaFinal.rdlc");
            Require(File.Exists(reportPath), "Falta el reporte ActaMesaFinal.rdlc.");
            foreach (int count in new[] {0, 1, 8, 100})
            {
                using (var report = new LocalReport())
                {
                    report.ReportPath = reportPath;
                    var mesa = new DataTable();
                    foreach (string field in new[] {"Carrera", "Materia", "AnioCarrera", "Curso", "CicloLectivoId", "Turno", "Llamado", "Titular", "Vocal", "LibroActa", "FolioActa"}) mesa.Columns.Add(field);
                    mesa.Columns.Add("Fecha", typeof(DateTime));
                    mesa.Rows.Add("TECNICATURA SUPERIOR EN ANALISIS, DESARROLLO Y PROGRAMACION DE APLICACIONES", "EDI - PRODUCCION DE SOFTWARE", "2", "", "2026", "Diciembre", "Primero", "Profesora de prueba", "Profesor vocal de prueba", "", "", new DateTime(2026, 12, 10));
                    var alumnos = new DataTable();
                    alumnos.Columns.Add("AlumnoId", typeof(int));
                    foreach (string field in new[] {"Libro", "Folio", "NumeroDocumento", "Apellido", "Nombre", "Email", "Celular", "Condicion"}) alumnos.Columns.Add(field);
                    for (int i=1; i<=count; i++) alumnos.Rows.Add(i, i == 1 ? null : "13", i == 1 ? null : "008", (40000000+i).ToString(), "APELLIDO" + i.ToString("D3"), "Nombre compuesto de prueba", "correo.extenso.de.prueba@institucion.example", "1123456789", "Regular");
                    report.DataSources.Add(new ReportDataSource("DSMesaFinal", mesa));
                    report.DataSources.Add(new ReportDataSource("DSAlumnosMesa", alumnos));
                    report.SetParameters(new ReportParameter("AvisoInscripciones", ""));
                    var pdf = report.Render("PDF");
                    Require(pdf.Length > 1000, "No se genero un PDF valido.");
                    File.WriteAllBytes(Path.Combine(args[1], "acta-"+count+".pdf"), pdf);
                    Console.WriteLine("PASS: render PDF con " + count + " alumnos sinteticos.");
                    if (count == 0)
                    {
                        report.SetParameters(new ReportParameter("AvisoInscripciones", "Inscripciones no disponibles: falta la relacion entre alumnos y mesas finales."));
                        File.WriteAllBytes(Path.Combine(args[1], "acta-no-disponible.pdf"), report.Render("PDF"));
                    }
                }
            }
            VerifyViewer(args[0], args[1]);
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex.ToString()); return 1; }
    }
}
'@
$cs = Join-Path $salida 'VerificarActa.cs'
Set-Content -LiteralPath $cs -Value $source -Encoding UTF8
$exe = Join-Path $bin 'VerificarActa.exe'
$refs = @('System.dll','System.Core.dll','System.Data.dll','System.Xml.dll','System.Xml.Linq.dll','System.Drawing.dll','System.Windows.Forms.dll', (Join-Path $bin 'ISFDyT93.Vista.exe'), (Join-Path $bin 'ISFDyT93.Negocio.dll'), (Join-Path $bin 'ISFDyT93.Datos.dll'), (Join-Path $bin 'ISFDyT93.Entidades.dll'), (Join-Path $bin 'Microsoft.ReportViewer.WinForms.dll'), (Join-Path $bin 'Microsoft.ReportViewer.Common.dll'))
$compiler = Join-Path $env:WINDIR 'Microsoft.NET/Framework64/v4.0.30319/csc.exe'
& $compiler /nologo /target:exe "/out:$exe" ($refs | ForEach-Object { "/reference:$_" }) $cs
if ($LASTEXITCODE -ne 0) { throw 'No se pudo compilar la prueba.' }
Copy-Item -LiteralPath (Join-Path $repo 'ISFDyT93.Vista/App.config') -Destination "$exe.config" -Force
if ($BaseLocal) { & $exe $repo $salida 'base' } else { & $exe $repo $salida }
if ($LASTEXITCODE -ne 0) { throw 'Fallo la verificacion del acta.' }
Write-Output "PDFs de prueba: $salida"

