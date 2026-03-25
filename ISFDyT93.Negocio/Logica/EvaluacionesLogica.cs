using System;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class EvaluacionesLogica : LogicaBase
    {
        EvaluacionesDao evaluacionesDao;
        public EvaluacionesLogica()
        {
            evaluacionesDao = new EvaluacionesDao();
        }

        public DataTable ObtenerAlumnos(int ServicioId)
        {
            return this.evaluacionesDao.ObtenerAlumnos(ServicioId);
        }

        public int AsignarFechaExamen(int CursadaId, DateTime fecha, int Evaluados)
        {
            return this.evaluacionesDao.AsignarFechaExamen(CursadaId,fecha,Evaluados); 
        }

        public DataRow ObtenerUltimoExamenId()
        { 
            return this.evaluacionesDao.ObtenerUltimoExamenId();
        }
    }
}
