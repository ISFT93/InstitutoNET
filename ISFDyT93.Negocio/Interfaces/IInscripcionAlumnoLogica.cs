using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IInscripcionAlumnoLogica
    {
        DataTable ObtenerMateriasVigentes(int alumnoId, string anio);
        DataTable ObtenerAniosVigentes(int alumnoId);
        bool obtenerFechaIncripcion();
        int actualizarEstadoCursada(InscripcionMateriasModelo Modelo);
    }
}
