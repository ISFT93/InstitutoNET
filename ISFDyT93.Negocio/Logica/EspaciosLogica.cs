using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Interfaces;
using System.Collections.Generic;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Logica
{
    public class EspaciosLogica : IEspaciosLogica
    {
        EspaciosDao espaciosDao = new EspaciosDao();

        public IList<EspaciosModelo> ObtenerEspacios()
        {
            return espaciosDao.ObtenerEspacios();
        }

        public int ActualizarEspacios(IList<EspaciosModelo> ltsEspacios)
        {
            return espaciosDao.ActualizarEspacios(ltsEspacios);
        }

        public bool EspaciosActivos()
        {
            return espaciosDao.EspaciosActivos();
        }

        public bool EspaciosInactivos()
        {
            return espaciosDao.EspaciosInactivos();
        }

        public void HabilitarEspacio(int EspacioId)
        {
            espaciosDao.HabilitarEspacio(EspacioId);
        }

        public void DeshabilitarEspacio(int EspacioId)
        {
            espaciosDao.DeshabilitarEspacio(EspacioId);
        }

        public void AgregarEspacio(string Descripcion)
        {
            espaciosDao.AgregarEspacio(Descripcion);
        }
        public DataTable EspaciosHabilitados()
        {
            return espaciosDao.EspaciosHabilitados();
        }

        public DataTable EspaciosDeshabilitados()
        {
            return espaciosDao.EspaciosDeshabilitados();
        }
    }
}