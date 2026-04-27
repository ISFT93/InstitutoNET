using System;
using System.Windows.Forms;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class LicenciaServicioLogica : LogicaBase
    {
        private LicenciaServicioDao LicenciaDao { get; set; }

        public LicenciaServicioLogica()
        {
            this.LicenciaDao = new LicenciaServicioDao();
        }

        public DataTable ObtenerLicencias(int id)
        {
            return LicenciaDao.ObtenerLicencias(id);
        }
        public DataTable ObtenerServiciosActivos(int[] servicioId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Servicios");

            int servId = 0;
            for (int i = 0; i <= servicioId.Length - 1; i++)
            {
                if (servicioId[i] != 0)
                {
                    servId = servicioId[i];
                    dt.Rows.Add(this.LicenciaDao.ObtenerServicios(servId).ItemArray[0]);
                }
                else break;
            }
            return dt;
        }

        public int BajaLicencia(Datos.Modelos.LicenciaServicioModelo modelo)
        {
            return this.LicenciaDao.BajaLicencia(modelo);
        }
        public DataTable ObtenerServiciosDeActivo(Datos.Modelos.LicenciaServicioModelo modelo)
        {
            return this.LicenciaDao.ObtenerLicenciasDeActivos(modelo);
        }

        public DataTable ObtenerServiciosDeInactivo(Datos.Modelos.LicenciaServicioModelo modelo)
        {
            return this.LicenciaDao.ObtenerLicenciasDeInactivos(modelo);

        }

        public DataRow ObtenerFechaBajaObligatorio(Datos.Modelos.LicenciaServicioModelo modelo)
        {
            return this.LicenciaDao.ObtenerFechaBajaObligatorio(modelo);
        }

        public DataTable ObtenerLicenciasTipo()
        {
            return this.LicenciaDao.ObtenerLicenciasTipo();
        }

        public int AltaLicencia(Datos.Modelos.LicenciaServicioModelo modelo)
        {
            string time = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string rutaOriginal = modelo.certificado;

            if (modelo.fechaAltaSTR == "1753-01-01")
                return 0;
            if (modelo.fechaAlta > modelo.fechaBaja)
                return 0;

            if (!string.IsNullOrEmpty(modelo.certificado))
            {
                modelo.certificado = @"\PDF\Certificado_" + time + ".pdf";
            }


            if (this.LicenciaDao.AltaLicencia(modelo) > 0)
            {
                GuardarArchivo(rutaOriginal, modelo.certificado, @"\PDF");
                return 1;
            }
            else
                return 0;
        }

        private void GuardarArchivo(string rutaOrigina, string rutaNueva, string Carpeta)
        {
            var path = Application.StartupPath;

            if (!System.IO.Directory.Exists(Carpeta))
            {
                System.IO.Directory.CreateDirectory(Carpeta);
            }

            if (System.IO.File.Exists(path + rutaNueva))
            {
                System.IO.File.Delete(path + rutaNueva);
            }

            System.IO.File.Copy(rutaOrigina, path + rutaNueva);
        }
    }
}
