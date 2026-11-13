using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using System.Data;


namespace ISFDyT93.Datos.Interfaces
{
    public interface IEsquemaEvaluacionDao
    {
        IList<EsquemaEvaluacionModelo> ObtenerEsquemas();

        int ActualizarEsquemas(
            IList<EsquemaEvaluacionModelo> esquemas
        );

        bool EsquemasActivos();

        bool EsquemasInactivos();

        void DeshabilitarEsquema(int CodEsq);

        void HabilitarEsquema(int CodEsq);

        DataTable EsquemasHabilitados();

        DataTable EsquemasDeshabilitados();

        void AgregarEsquema(EsquemaEvaluacionModelo esquema);
    }
}