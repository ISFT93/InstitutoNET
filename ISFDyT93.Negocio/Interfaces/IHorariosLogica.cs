using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IHorariosLogica
    {
        DataTable ObtnerModulos();
        DataTable ObtenerModulosPorTurno(string turno);
        DataTable ObtenerTurnosDisponibles();
        DataTable ObtenerTurnosConDetalleOrdenados();
        DataTable ObtenerTurnosUnicos();
        bool ActualizarEstadoModulo(int moduloId, bool activo);
        bool InsertarModulo(string turno, string descripcion);
        bool InsertarTurno(string turno);
        IList<HorariosModelo> ObtenerHorarios(int cursoId);
        int ActualizarHorarios(IList<HorariosModelo> ltsHorarios);

        bool ActualizarEstadoPorTurno(string turno, bool activo);
    }
}