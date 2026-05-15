using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICursadasDao
    {
        DataRow ObtenerDatosCursadaByCursadaAlumnoCarreraId(int CursadaAlumnoCarreraId);
        CursadasModelo ObtenerCursada(int CursadaId);
    }
}
