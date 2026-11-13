using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System.Collections.Generic;
using System.Data;

namespace ISFDyT93.Datos.Daos
{
    public class EsquemaEvaluacionDao : DaoBase, IEsquemaEvaluacionDao
    {
        public IList<EsquemaEvaluacionModelo> ObtenerEsquemas()
        {
            string query =
                @"SELECT
                    [cod-esq] AS CodEsq,
                    indice,
                    esquema,
                    ex_descripc,
                    ex_descripcion_planilla,
                    ex_tipo_dat,
                    ex_requeric,
                    Activo
                  FROM Evaluacion.esquema_examen";

            return this.MapToModel<EsquemaEvaluacionModelo>(
                this.Conexion.ObtenerRegistros(query)
            );
        }

        public int ActualizarEsquemas(
            IList<EsquemaEvaluacionModelo> esquemas)
        {
            int registros = 0;

            foreach (EsquemaEvaluacionModelo modelo in esquemas)
            {
                string descripcion = modelo.ex_descripc.Replace("'", "''");
                string descripcionPlanilla = modelo.ex_descripcion_planilla.Replace("'", "''");
                string esquema = modelo.esquema.Replace("'", "''");
                string tipoDato = modelo.ex_tipo_dat.Replace("'", "''");

                string query =
                    $@"UPDATE Evaluacion.esquema_examen
                       SET indice = {modelo.indice},
                           esquema = '{esquema}',
                           ex_descripc = '{descripcion}',
                           ex_descripcion_planilla = '{descripcionPlanilla}',
                           ex_tipo_dat = '{tipoDato}',
                           ex_requeric = {(modelo.ex_requeric ? 1 : 0)},
                           Activo = {(modelo.Activo ? 1 : 0)}
                       WHERE [cod-esq] = {modelo.CodEsq}";

                registros += this.Conexion.EjecutarAccion(query);
            }

            return registros;
        }

        public bool EsquemasActivos()
        {
            string query =
                @"SELECT * FROM Evaluacion.esquema_examen
                  WHERE Activo = 1";

            DataTable registros =
                this.Conexion.ObtenerRegistros(query);

            return registros.Rows.Count > 0;
        }

        public bool EsquemasInactivos()
        {
            string query =
                @"SELECT * FROM Evaluacion.esquema_examen
                  WHERE Activo = 0";

            DataTable registros =
                this.Conexion.ObtenerRegistros(query);

            return registros.Rows.Count > 0;
        }

        public void DeshabilitarEsquema(int CodEsq)
        {
            string query =
                $@"UPDATE Evaluacion.esquema_examen
                   SET Activo = 0
                   WHERE [cod-esq] = {CodEsq}";

            this.Conexion.EjecutarAccion(query);
        }

        public void HabilitarEsquema(int CodEsq)
        {
            string query =
                $@"UPDATE Evaluacion.esquema_examen
                   SET Activo = 1
                   WHERE [cod-esq] = {CodEsq}";

            this.Conexion.EjecutarAccion(query);
        }

        public DataTable EsquemasHabilitados()
        {
            string query =
                @"SELECT [cod-esq] AS CodEsq,
                         esquema,
                         ex_descripc,
                         ex_descripcion_planilla
                  FROM Evaluacion.esquema_examen
                  WHERE Activo = 1";

            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable EsquemasDeshabilitados()
        {
            string query =
                @"SELECT [cod-esq] AS CodEsq,
                         esquema,
                         ex_descripc,
                         ex_descripcion_planilla
                  FROM Evaluacion.esquema_examen
                  WHERE Activo = 0";

            return this.Conexion.ObtenerRegistros(query);
        }

        public void AgregarEsquema(EsquemaEvaluacionModelo modelo)
        {
            string esquema = modelo.esquema.Replace("'", "''");
            string descripcion = modelo.ex_descripc.Replace("'", "''");
            string descripcionPlanilla = modelo.ex_descripcion_planilla.Replace("'", "''");
            string tipoDato = modelo.ex_tipo_dat.Replace("'", "''");

            string query =
                $@"INSERT INTO Evaluacion.esquema_examen
                   (
                       indice,
                       esquema,
                       ex_descripc,
                       ex_descripcion_planilla,
                       ex_tipo_dat,
                       ex_requeric,
                       Activo
                   )
                   VALUES
                   (
                       {modelo.indice},
                       '{esquema}',
                       '{descripcion}',
                       '{descripcionPlanilla}',
                       '{tipoDato}',
                       {(modelo.ex_requeric ? 1 : 0)},
                       0
                   )";

            this.Conexion.EjecutarAccion(query);
        }
    }
}