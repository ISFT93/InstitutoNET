using System;
using System.Collections.Generic;
using System.Data;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core;

namespace ISFDyT93.Negocio.Logica
{
    public class TipoLicenciaLogica : LogicaBase
    {
        private TipoLicenciaDao licenciaDao;

        public TipoLicenciaLogica()
        {
            this.licenciaDao = new TipoLicenciaDao();
        }

        public IList<TipoLicenciaModelo> ObtenerLicencias()
        {
            return this.licenciaDao.ObtenerTipoLicencias();
        }

        public int GuardarLicencia(TipoLicenciaModelo modelo)
        {
            return this.licenciaDao.GuardarTipoLicencia(modelo);
        }

        public int ActualizarLicencias(IList<TipoLicenciaModelo> lista)
        {
            return this.licenciaDao.ActualizarTipoLicencias(lista);
        }

        public bool LicenciasActivas()
        {
            return this.licenciaDao.ExisteEstadoLicencia(true);
        }

        public bool LicenciasInactivas()
        {
            return this.licenciaDao.ExisteEstadoLicencia(false);
        }
    }
}