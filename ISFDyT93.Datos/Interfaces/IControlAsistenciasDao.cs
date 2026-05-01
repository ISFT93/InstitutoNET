using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IControlAsistenciasDao
    {
        DataTable CargarAsistenciasAlumnos();
        DataTable CargarAsistenciasAlumnosReporte(AsistenciasModelo modelo);
        DataTable CargarAsistenciasAnteriores(AsistenciasModelo Modelo);
        DataRow CargarProfesor();
        void ActualizoUltimaFechaAsistencia(AsistenciasModelo Modelo);
        int AgregarAsistencia(AsistenciasModelo Modelo);
        int ActualizarCursada(AsistenciasModelo Modelo);
        DataRow CalculaTotalAlumnos();
        DataRow CalculaModulosAlumnos(AsistenciasModelo Modelo);
        DataRow CalcularPorcentajeAsistenciaAlumnos(AsistenciasModelo Modelo);
        DataTable GuardarAsistenciasAlumnos(AsistenciasModelo Modelo);
        int ActualizarGrilla(AsistenciasModelo Modelo);
        DataTable HistorialAsistenciasAlumnos(AsistenciasModelo Modelo);
    }
}
