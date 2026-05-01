using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IHorariosDao
    {
        DataTable ObtnerModulos();
        IList<HorariosModelo> ObtenerHorarios(int cursoId);
        int ActualizarHorarios(IList<HorariosModelo> ltsHorarios);
    }
}
