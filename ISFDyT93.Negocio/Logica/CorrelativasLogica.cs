using System.Collections.Generic;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;
using ISFDyT93.Datos.Daos;

namespace ISFDyT93.Negocio.Logica
{
    public class CorrelativasLogica : LogicaBase
    {
        CorrelativasDao correlativasDao;
        public CorrelativasLogica()
        {
            this.correlativasDao = new CorrelativasDao();
        }
        public DataTable ObtenerCorreltividades(int IdMateria, int IdCarrera)
        {
            return correlativasDao.ObtenerCorrelatividades(IdMateria, IdCarrera);
        }
        public int CorrelativaExisteCarrera(int CarreraId)
        {
            return correlativasDao.CorrelativaExisteCarrera(CarreraId);
        }
        public DataTable ObtenerMateriasCorrelativas(int MateriaId)
        {
            return this.correlativasDao.ObtenerMateriasCorrelativas(MateriaId);
        }

        public int AgregarCorrelativa( int IdMateria, int IdCorrelativa )
        {
            return this.correlativasDao.AgregarCorrelativa(IdMateria, IdCorrelativa);
        }

        public int GuardarCorrelatividades(IList<CorrelatividadModel> modelos)
        {
            return correlativasDao.GuardarCorrelatividades(modelos);
        }

        public int EliminarCorrelativa(int CorrelativaId)
        {
            return this.correlativasDao.EliminarCorrelativa(CorrelativaId);
        }
        public int EliminarCorrelativas(int MateriaId)
        {
            return this.correlativasDao.EliminarCorrelativas(MateriaId);
        }

        public DataTable Correlativaid(int CarreraId)
        {
            return this.correlativasDao.Correlativaid(CarreraId);
        }

        public DataTable ObtenerCorrelativasAnio(int AnioCarreraId)
        {
            return this.correlativasDao.ObtenerCorrelativasAnio(AnioCarreraId);
        }

        public DataTable ObtenerCorrelativasCarrera(int CarreraId)
        {
            return this.correlativasDao.ObtenerCorrelativasCarrera(CarreraId);
        }
    }
}
