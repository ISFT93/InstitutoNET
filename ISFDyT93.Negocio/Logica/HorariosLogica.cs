
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class HorariosLogica : LogicaBase
    {
        HorariosDao horariosDao = new HorariosDao();

        public DataTable ObtnerModulos()
        {
            return horariosDao.ObtnerModulos();
        }
        public IList<HorariosModelo> ObtenerHorarios(int cursoId)
        {
            return horariosDao.ObtenerHorarios(cursoId);
        }
        public int ActualizarHorarios(IList<HorariosModelo> ltsHorarios)
        {
            return horariosDao.ActualizarHorarios(ltsHorarios);
        }
    }
}
