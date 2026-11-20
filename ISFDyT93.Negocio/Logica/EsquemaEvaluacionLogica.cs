using ISFDyT93.Datos.Daos;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace ISFDyT93.Negocio.Logica
{
    public class EsquemaEvaluacionLogica : IEsquemaEvaluacionLogica
    {
        private readonly IEsquemaEvaluacionDao dao = new EsquemaEvaluacionDao();

        public DataTable ObtenerTipos() { return dao.ObtenerTipos(); }
        public DataTable ObtenerEsquemas() { return dao.ObtenerEsquemas(); }

        public int GuardarTipos(IList<TipoExamenModelo> tipos)
        {
            if (tipos == null) throw new ArgumentNullException("tipos");
            foreach (var tipo in tipos)
            {
                if (tipo == null || string.IsNullOrWhiteSpace(tipo.Descripcion) ||
                    tipo.Descripcion.Trim().Length > 250 ||
                    string.IsNullOrWhiteSpace(tipo.DescripcionPlanilla) ||
                    tipo.DescripcionPlanilla.Trim().Length > 50 ||
                    (tipo.TipoDato != "Num" && tipo.TipoDato != "texto"))
                    throw new ArgumentException("Completá descripción, planilla y tipo de dato (Num o texto) de cada tipo de examen.");
            }
            return dao.GuardarTipos(tipos);
        }

        public int GuardarEsquemas(IList<EsquemaEvaluacionModelo> esquemas)
        {
            if (esquemas == null) throw new ArgumentNullException("esquemas");
            foreach (var fila in esquemas)
            {
                if (fila == null || fila.Indice < 1 || fila.TipoExamenId < 1 ||
                    string.IsNullOrWhiteSpace(fila.Esquema) || fila.Esquema.Trim().Length > 10)
                    throw new ArgumentException("Cada componente necesita esquema (máximo 10 caracteres), índice positivo y tipo de examen.");
            }
            return dao.GuardarEsquemas(esquemas);
        }

        public void CambiarEstadoEsquema(string nombre, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Seleccioná un esquema.");
            dao.CambiarEstadoEsquema(nombre.Trim(), activo);
        }
    }
}
