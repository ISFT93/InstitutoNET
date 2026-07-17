using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Daos;


namespace ISFDyT93.Negocio.Logica
{
    public class LibroActasLogica
    {
        LibroActasDao libroActasDao = new LibroActasDao();
        public DataTable ObtenerLibros() => libroActasDao.ObtenerLibros();
        public bool RelacionNuevaPosible() => libroActasDao.RelacionNuevaPosible();
        public bool ActualizacionPosible() => libroActasDao.ActualizacionPosible();
        public int? ObtenerTomaPosicion() => libroActasDao.ObtenerTomaPosicion();
        public void LibrosSinActualizar(ComboBox cmb) => libroActasDao.LibrosSinActualizar(cmb);
        public void CarrerasSinActualizar(ComboBox cmb, int tipoLibroId) => libroActasDao.CarrerasSinActualizar(cmb, tipoLibroId);
        public void LibrosSinRelacionar(ComboBox cmb, int? excepcion) => libroActasDao.LibrosSinRelacionar(cmb, excepcion);
        public void CarrerasSinRelacionar(ComboBox cmb, int tipoLibroId) => libroActasDao.CarrerasSinRelacionar(cmb, tipoLibroId);
        public void SumarNumeroLibro(int TipoLibroId, int? CarreraId, int FoliosMaximos, DateTime FechaAlta) => libroActasDao.SumarNumeroLibro(TipoLibroId, CarreraId, FoliosMaximos, FechaAlta);

    }
}
