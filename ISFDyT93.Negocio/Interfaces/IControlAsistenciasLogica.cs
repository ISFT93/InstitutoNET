using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IControlAsistenciasLogica
    {
        DataTable CargarAsistenciasAlumnosReporte(AsistenciasModelo modelo);
        DataTable CargarAsistenciasAlumnos();
        DataTable CargarAsistenciasAnteriores(AsistenciasModelo modelo);
        DataRow CargarProfesor();
        void ActualizoUltimaFechaAsistencia(AsistenciasModelo Modelo);
        int AgregarAsistencia(AsistenciasModelo Modelo);
        int ActualizarCursada(AsistenciasModelo Modelo);
        DataRow CalculaTotalAlumnos();
        DataRow CalculaModulosAlumnos(AsistenciasModelo Modelo);
        int ActualizarGrilla(AsistenciasModelo Modelo);
        DataRow CalcularPorcentajeAsistenciaAlumnos(AsistenciasModelo Modelo);
        DataTable HistorialAsistenciasAlumnos(AsistenciasModelo Modelo);
    }
}
