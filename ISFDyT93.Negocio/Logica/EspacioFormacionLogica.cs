using System;
using System.Windows.Forms;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Negocio.Core;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Logica
{
    public class EspacioFormacionLogica : LogicaBase, IEspacioFormacionLogica
    {
        private EspacioDao EspacioDao { get; set; }

        public EspacioFormacionLogica()
        {
            this.EspacioDao = new EspacioDao();
        }

        public DataTable ObtenerEspacios()
        {
            return this.EspacioDao.ObtenerEspacios();
        }

        public DataTable ObtenerEspaciosActivos()
        {
            return this.EspacioDao.ObtenerEspaciosActivos();
        }

        public int HabilitarEspacio(int espacioId)
        {
            return this.EspacioDao.HabilitarEspacio(espacioId);
        }

        public int DeshabilitarEspacio(int espacioId)
        {
            return this.EspacioDao.DeshabilitarEspacio(espacioId);
        }

        public int AgregarEspacio(Entidades.Modelos.EspacioModelo modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo.Descripcion))
                return 0;

            return this.EspacioDao.AgregarEspacio(modelo);
        }

        public int ModificarEspacio(Entidades.Modelos.EspacioModelo modelo)
        {
            if (modelo.EspacioId <= 0 || string.IsNullOrWhiteSpace(modelo.Descripcion))
                return 0;

            return this.EspacioDao.ModificarEspacio(modelo);
        }
    }
}
