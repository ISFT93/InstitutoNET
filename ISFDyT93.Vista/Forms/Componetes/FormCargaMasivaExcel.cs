using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ISFDyT93.Vista.Forms.Alumnos;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Componentes
{
    public partial class FormCargaMasivaExcel : Form
    {
        AlumnosLogica alumnosLogica = new AlumnosLogica();
        CarrerasLogica carrerasLogica = new CarrerasLogica();
        
        public FormPrincipal Contenedor { get; set; }
        public string Accion { get; set; }
        public int AlumnoId { get; set; }
        public int AlumnoCarreraId { get; set; }

        DataTable dtExcel;

        public FormCargaMasivaExcel()
        {
            InitializeComponent();
        }

        private void btnBuscarArchivoExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivoExcel = new OpenFileDialog();
            archivoExcel.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos .csv (*.csv)|*.csv";
            archivoExcel.InitialDirectory = "C://";


            if (archivoExcel.ShowDialog() == DialogResult.OK)
            {
                dtExcel = new DataTable();
                string rutaCvs = archivoExcel.FileName;
                using (Stream inputStream = File.OpenRead(rutaCvs))
                {
                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {
                        IApplication application = excelEngine.Excel;
                        IWorkbook workbook = application.Workbooks.Open(inputStream);
                        IWorksheet worksheet = workbook.Worksheets[0];
                        dtExcel = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                    }
                }
                dgvCargaMasiva.DataSource = dtExcel;
                
            }
        }

        private void btnAceptarCargaMasiva_Click(object sender, EventArgs e)
        {
            if (dtExcel != null)
            {
                DataTable dtCarreras = new DataTable();
                dtCarreras = carrerasLogica.ObtenerCarreras();

                foreach (DataRow dr2 in dtCarreras.Rows)
                {
                    var carreraNombre = dr2["Nombre"].ToString();
                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        var carreraExcel = dr["Carrera"].ToString();
                        if (carreraExcel == carreraNombre)
                        {
                            //chequea si DNI alumno existe
                            if (alumnosLogica.AlumnoExiste(dr["DNI:"].ToString()) != true)
                            {
                                if (dr.Field<string>("Sexo:") == "Femenino") dr.SetField("Sexo:", "F");
                                else { dr.SetField("Sexo:", "M"); }

                                int cortarIndice = dr["Fecha de Nacimiento:"].ToString().IndexOf(" ");
                                string fechaNacimineto = dr["Fecha de Nacimiento:"].ToString().Substring(0, cortarIndice).Trim();

                                const int MaxLength = 15;
                                var localidadNacimiento = dr[8].ToString();
                                if (localidadNacimiento.Length > MaxLength) localidadNacimiento = localidadNacimiento.Substring(0, MaxLength); // name = "Chris" 
                                string FechaActual = DateTime.Now.ToString("yyyy-MM-dd");
                                //FormAgregarModificarAlumnos frmAgregarModificarAlumno = new FormAgregarModificarAlumnos();

                                var modelo = new AlumnosModelo()
                                {
                                    AlumnoId = this.AlumnoId,
                                    Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[4].ToString()),
                                    Apellido = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[3].ToString()),
                                    TipoDocumento = "Dni",
                                    NumeroDocumento = dr[5].ToString(),
                                    EstadoCivil = dr[9].ToString(),
                                    Sexo = Convert.ToChar(dr[6]),
                                    //FechaNacimiento = fechaNacimineto,
                                    LocalidadNacimiento = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(localidadNacimiento),
                                    Calle = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[11].ToString()),
                                    Provincia = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[15].ToString()),
                                    Distrito = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[13].ToString()),
                                    Localidad = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[12].ToString()),
                                    CodigoPostal = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[14].ToString()),
                                    Celular = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[10].ToString()),
                                    Email = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dr[1].ToString()),
                                    FotoUrl = dr[16].ToString()
                                };

                                var modelo1 = new AlumnosCarrerasModelo()
                                {
                                    AlumnoId = this.AlumnoId,
                                    AlumnoCarreraId = AlumnoCarreraId
                                };

                                if (this.Accion == "Agregar")
                                {
                                    AlumnosLogica alumnosLogica = new AlumnosLogica();
                                    modelo1.AlumnoId = alumnosLogica.AgregarAlumnoCargaMasiva(modelo);
                                    if (modelo1.AlumnoId > 0)
                                    {
                                        modelo1.Activo = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            Contenedor.AbrirFormulario<FormAlumnos>();
            FormNotificacion.Mensaje(TipoNotificacion.Success, "Los alumnos fueron agregados con exito");
        }             
    }
}
