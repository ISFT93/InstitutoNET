using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IMesasFinalesLogica
    {
        DataTable ObtenerProfesorTitular(int materiaId);
        DataTable ObtenerVocales(int carreraId, int personalId);
        int AgregarMesa(int carreraId, DateTime fecha, int turno, int llamado, int materiaId, int presidenteId, int vocalId, int anioLectivo);
        int ModificarMesa(DateTime fecha, int turno, int presidenteId, int vocalId, int mesaFinalId);
        int EliminarMesa(int mesaFinalId);
        DataTable ObtenerMateriaFinal(int mesaFinalId);
        DataTable ObtenerMesas(int carreraId);
        DataTable ObtenerMesasFiltro(int carreraId, int anioLectivoId, int turnoId, int llamadoId);
        DataTable ObtenerMesasReporte(int carreraId, int anioLectivoId, int turnoId, int llamadoId);
        int CargarMesasFinales(int cicloLectivoId, int turnoId);
        DataTable ObtenerTurnoMesa(int mesaFinalId);
        DataTable ObtenerTurnos(bool todos);
        DataTable ObtenerAniosLectivos();
        DataTable ExistenMesasFinales(int anioLectivo);
        DataTable ObtenerLlamados(bool fechaUnica);
    }
}
