using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class AniosCarreraLogica : LogicaBase
    {
        AniosCarreraDao aniosDao;
       
        public AniosCarreraLogica()
        {
            this.aniosDao = new AniosCarreraDao();
        }
        public DataTable ObtenerAniosCarrera(int id)
        {
            return this.aniosDao.ObtenerAniosCarrera(id);
        }
        public DataTable ObtenerAnios(int AlumnoId)
        {
            return this.aniosDao.ObtenerAnios(AlumnoId);
        }
        public int ActualizarCargaHoraria(int AnioCarreraId)
        {
            return this.aniosDao.ActualizarCargaHoria(AnioCarreraId);
        }
        public int ObtenerCargaHoraria(int CarreraId)
        {
            return this.aniosDao.ObtenerCargaHoraria(CarreraId);
        }

        public AniosCarrerasModelo ObtenerAnioCarrera(int anioCarreraId)
        {
            return this.aniosDao.ObtenerAnioCarrera(anioCarreraId);
        }

        public CarrerasModelo ObtenerCarrera(int AnioCarreraId)
        {
            var row = this.aniosDao.ObtenerCarrera(AnioCarreraId);

            return new CarrerasModelo()
            {
                CarreraId = (int)row["CarreraId"],
            };

            //  return this.aniosDatos.ObtenerCarrera(AnioCarreraId);
        }

        public int ObtenerAnio(int anioCarreraId)
        {
            return this.aniosDao.ObtenerAnio(anioCarreraId);
        }
        //Agregar, eliminar estan en CarrerasLogica

        public int EliminarAnios(int AnioCarreraId)
        {
            return this.aniosDao.EliminarAnios(AnioCarreraId);
        }
    }
}
