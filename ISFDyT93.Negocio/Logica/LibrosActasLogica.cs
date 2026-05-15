using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Negocio.Logica
{
    public class LibrosActasLogica
    {
        private LibroActasDao dao = new LibroActasDao();
        public IList<LibroActasModelo> ObtenerTodosLosLibros()
        {
            var libros = dao.ObtenerLibroActas();

            foreach (var libro in libros)
            {
                // Si llegó al máximo y todavía figura como activo en la BD
                if (libro.FolioNumero >= libro.FolioMaximo && libro.Activo)
                {
                    // desactivamos el check de la grilla
                    libro.Activo = false;
                    libro.FechaBaja = DateTime.Today;

                    //desactivamos el libro en la bd
                    dao.DesactivarLibro(libro.LibroActaId);
                }
            }

            return libros;
        }

        public IList<LibroActasModelo> ObtenerTiposLibroDisponibles(int? carreraId = null)
        {

            return dao.ObtenerTiposLibroDisponibles(carreraId ?? 0);
        }

        public IList<LibroActasModelo> ObtenerCarrerasDisponibles()
        {
            return dao.ObtenerCarrerasDisponibles();
        }

        public IList<LibroActasModelo> ObtenerTiposLibroDisponibles(int carreraId)
        {
            return dao.ObtenerTiposLibroDisponibles(carreraId);
        }

        public void CrearLibroActa(
            int tipoLibroId,
            int carreraId,
            int folioMaximo)
        {
            dao.CrearLibroActa(
                tipoLibroId,
                carreraId,
                folioMaximo);
        }
    }
}
