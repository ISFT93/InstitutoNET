using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEvaluacionesLogica
    {
        DataTable ObtenerAlumnos(int ServicioId);
        int AsignarFechaExamen(int CursadaId, DateTime fecha, int Evaluados);
        DataRow ObtenerUltimoExamenId();
    }
}
