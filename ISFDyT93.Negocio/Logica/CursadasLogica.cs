using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Logica
{
    public class CursadasLogica : LogicaBase
    {
        CursadasDao cursadasDao;

        public CursadasLogica()
        {
            this.cursadasDao = new CursadasDao();
        }
        
        public CursadasModelo ObtenerCursada(int CursadaId)
        {
            return this.cursadasDao.ObtenerCursada(CursadaId);
        }

        public DataRow ObtenerCursadaByCursadaAlumnoCarreraId(int CursadaAlumnoCarreraId)
        {
            return this.cursadasDao.ObtenerDatosCursadaByCursadaAlumnoCarreraId(CursadaAlumnoCarreraId);
        }
    }
}
