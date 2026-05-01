using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ILicenciaServicioLogica
    {
        DataTable ObtenerLicencias(int id);

        DataTable ObtenerServiciosActivos(int[] servicioId);

        int BajaLicencia(LicenciaServicioModelo modelo);

        DataTable ObtenerServiciosDeActivo(LicenciaServicioModelo modelo);

        DataTable ObtenerServiciosDeInactivo(LicenciaServicioModelo modelo);

        DataRow ObtenerFechaBajaObligatorio(LicenciaServicioModelo modelo);

        DataTable ObtenerLicenciasTipo();

        int AltaLicencia(LicenciaServicioModelo modelo);

    }
}
