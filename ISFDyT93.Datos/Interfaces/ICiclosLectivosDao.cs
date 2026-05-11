using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICiclosLectivosDao
    {
        DataTable ObtenerCicloLectivo(bool actualizar = false);
        DataTable CargarInscripcionAlumnoSP(int CicloLectivo);
        int IngresoCursadaPrimeroSP(int CicloLectivo);
        int AgregarCicloLectivo(CicloLectivoModelo Modelo);
        int CargarCursadasSP(int anioLectivo);
        int AgregarFechaFinalesMarzo(CicloLectivoModelo modelo);
        int AgregarFechaFinalesJulio(CicloLectivoModelo modelo);
        int AgregarFechaFinalesDiciembre(CicloLectivoModelo modelo);
        int ObtenerAlumnoDePrimero(int CicloLectivo);
    }
}
