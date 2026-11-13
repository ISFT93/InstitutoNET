using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
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

namespace ISFDyT93.Negocio
{
    public class EsquemaEvaluacionLogica : IEsquemaEvaluacionLogica
    {
        private readonly IEsquemaEvaluacionDao esquemaDao;

        public EsquemaEvaluacionLogica()
        {
            this.esquemaDao = new EsquemaEvaluacionDao();
        }

        public IList<EsquemaEvaluacionModelo> ObtenerEsquemas()
        {
            return this.esquemaDao.ObtenerEsquemas();
        }

        public int ActualizarEsquemas(
            IList<EsquemaEvaluacionModelo> esquemas)
        {
            if (esquemas == null)
                throw new ArgumentNullException("esquemas");

            return this.esquemaDao.ActualizarEsquemas(esquemas);
        }

        public bool EsquemasActivos()
        {
            return this.esquemaDao.EsquemasActivos();
        }

        public bool EsquemasInactivos()
        {
            return this.esquemaDao.EsquemasInactivos();
        }

        public void DeshabilitarEsquema(int CodEsq)
        {
            this.esquemaDao.DeshabilitarEsquema(CodEsq);
        }

        public void HabilitarEsquema(int CodEsq)
        {
            this.esquemaDao.HabilitarEsquema(CodEsq);
        }

        public DataTable EsquemasHabilitados()
        {
            return this.esquemaDao.EsquemasHabilitados();
        }

        public DataTable EsquemasDeshabilitados()
        {
            return this.esquemaDao.EsquemasDeshabilitados();
        }

        public void AgregarEsquema(EsquemaEvaluacionModelo esquema)
        {
            if (esquema == null)
                throw new ArgumentNullException("esquema");

            this.esquemaDao.AgregarEsquema(esquema);
        }
    }
}
