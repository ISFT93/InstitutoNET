using ISFDyT93.Negocio.Core;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ISFDyT93.Negocio.Logica
{
    public class EquivalenciasLogica : LogicaBase
    {
        EquivalenciasDao equivalenciasDao;

        public EquivalenciasLogica()
        {
            this.equivalenciasDao = new EquivalenciasDao();
        }

        public DataTable ObtenerCarreras(int carreraId)
        {
            return this.equivalenciasDao.ObtenerCarreras(carreraId);
        }

        public DataTable ObtenerMaterias(int CarreraId)
        {
            return this.equivalenciasDao.ObtenerMaterias(CarreraId);
        }

        public DataTable ObtenerEquivalencias(int CarreraId, int CarreraEquivalenciaId)
        {
            return this.equivalenciasDao.ObtenerEquivalencias(CarreraId, CarreraEquivalenciaId);
        }

        public int EliminarEquivalencia(int EquivalenciaId)
        {
            return this.equivalenciasDao.EliminarEquivalencia(EquivalenciaId);
        }

        public int AsignarEquivalencia(int CarreraId, int MateriaId, int CarreraEquivalenciaId, int MateriaEquivalenciaId)
        {
            return this.equivalenciasDao.AsignarEquivalencia(CarreraId, MateriaId, CarreraEquivalenciaId, MateriaEquivalenciaId);
        }
    }
}
