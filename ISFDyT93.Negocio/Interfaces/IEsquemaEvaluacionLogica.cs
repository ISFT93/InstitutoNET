using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using System.Data;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEsquemaEvaluacionLogica
    {
        DataTable ObtenerTipos();
        DataTable ObtenerEsquemas();
        int GuardarTipos(IList<TipoExamenModelo> tipos);
        int GuardarEsquemas(IList<EsquemaEvaluacionModelo> esquemas);
        void CambiarEstadoEsquema(string nombre, bool activo);
    }
}
