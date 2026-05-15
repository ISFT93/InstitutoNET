using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface ICicloLectivosLogica
    {
        int AgregarCicloLectivo(CicloLectivoModelo Modelo);
        int CargarCursadas(int anioLectivoId);
        DataTable ConsultarUnCicloLectivo(int anio);
        int AgregarFechaFinalesMarzo(CicloLectivoModelo modelo);
        int AgregarFechaFinalesJulio(CicloLectivoModelo modelo);
        int AgregarFechaFinalesDiciembre(CicloLectivoModelo modelo);
        int IngresoCursadaPrimeroSP(int CicloLectivo);
        DataTable ObtenerCargaGrillaCicloLectivo();
        int ObtenerAlumnoDePrimero(int aniolectivo);
        int ObtenerMaximoAnioCicloLectivo();
        bool ExisteUnCicloCreado();
        DataTable CargarInscripcionAlumnoSP(int CicloLectivo);
        int[] ObtenerAniosCiclosLectivos();
        int[] ObtenerAniosCiclosLectivosActivos();
        int ObtenerCicloLectivoActual();
        bool CicloLectivoActivo();
    }
}
