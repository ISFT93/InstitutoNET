using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IEvaluacionesDao
    {
        DataTable ObtenerAlumnos(int ServicioId);
        int AsignarFechaExamen(int CursadaId, DateTime fecha, int Evaluados);
        DataRow ObtenerUltimoExamenId();
        void AsignarNotas(int nota, int CursadaExamenId, int CursadaAlumnoCarreraId);
        void ModificarNota(int nota, int CursadaExamenId, int CursadaAlumnoCarreraId);
    }
}
