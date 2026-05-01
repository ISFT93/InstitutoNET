using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IMesasFinalesDao
    {
        DataTable ObtenerProfesorTitular(int MateriaId);
        DataTable ObtenerVocales(int CarreraId, int PersonalId);
        int AgregarMesa(int CarreraId, DateTime fecha, int Turno, int Llamado, int MateriaId, int PresidenteId, int VocalId, int AnioLectivo);
        DataTable ObtenerMesas(int CarreraId);
        int ModificarMesas(DateTime fecha, int turno, int presidenteId, int vocalId, int mesaFinalId);
        int EliminarMesas(int mesaFinalId);
        DataTable ObtenerMateriaFinal(int mesaFinalId);
        int CargarMesasFinales(int cicloLectivoId, int turnoId);
        DataTable ObtenerTurnoMesa(int mesaFinalId);
        DataTable ObtenerTurnos();
        DataTable ObtenerAniosLectivos();
        DataTable ObtenerMesasFiltro(int carreraId, int anioLectivoId, int turnoId, int llamadoId);
        DataTable ObtenerMesasReporte(int carreraId, int anioLectivoId, int turnoId, int llamadoId);
        DataTable ExistenFechasFinales(int anioLectivo);
        DataTable ObtenerLlamados();
    }
}
