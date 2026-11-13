using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Negocio.Interfaces
{
    public interface IEsquemaEvaluacionLogica
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