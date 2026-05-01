using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ILicenciaServicioDao
    {
        DataTable ObtenerLicencias(int id);
        DataRow ObtenerServicios(int servicioId);
        DataRow ObtenerFechaBajaObligatorio(LicenciaServicioModelo modelos);
        DataTable ObtenerLicenciasDeActivos(LicenciaServicioModelo modelo);
        DataTable ObtenerLicenciasDeInactivos(LicenciaServicioModelo modelo);
        DataTable ObtenerLicenciasTipo();
        int BajaLicencia(LicenciaServicioModelo modelo);
        int AltaLicencia(LicenciaServicioModelo modelo);
    }
}
