using System;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class InscripcionAlumnoLogica : LogicaBase
    {
        InscripcionAlumnoDao inscripcionAlumnoDao = new InscripcionAlumnoDao();

        public DataTable ObtenerMateriasVigentes(int alumnoId, string anio)
        {            
            return inscripcionAlumnoDao.ObtenerMateriasVigentes(alumnoId, anio); ;
        }

        public DataTable ObtenerAniosVigentes(int alumnoId)
        {
            return inscripcionAlumnoDao.ObtenerAniosVigentes(alumnoId);
        }

        public bool obtenerFechaIncripcion()
        {
            bool OK;
            DataRow dr = inscripcionAlumnoDao.obtenerFechaIncripcion();
            OK = (DateTime.Today > Convert.ToDateTime(dr["FechaInscripcionInicio"]) && DateTime.Today <= Convert.ToDateTime(dr["FechaInscripcionFinal"]));            
            return OK;
        }
        public int actualizarEstadoCursada(InscripcionMateriasModelo Modelo)
        {
            return inscripcionAlumnoDao.actualizarEstadoCursada(Modelo);
        }

    }
}
