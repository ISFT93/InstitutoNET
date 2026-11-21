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
           WHERE esquema = (
               SELECT esquema
               FROM Evaluacion.esquema_examen
               WHERE [cod-esq] = {CodEsq}
           )";

            this.Conexion.EjecutarAccion(query);
        }


        public void HabilitarEsquema(int CodEsq)
        {
            string query =
                $@"UPDATE Evaluacion.esquema_examen
           SET Activo = 1
           WHERE esquema = (
               SELECT esquema
               FROM Evaluacion.esquema_examen
               WHERE [cod-esq] = {CodEsq}
           )";

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

            string query = $@"
        SET XACT_ABORT ON;

        BEGIN TRY
            BEGIN TRANSACTION;

            DECLARE @NombreEsquema nvarchar(max) = N'{esquema}';

            IF EXISTS (
                SELECT 1
                FROM Evaluacion.esquema_examen WITH (TABLOCKX, HOLDLOCK)
                WHERE LOWER(LTRIM(RTRIM(esquema))) = LOWER(@NombreEsquema)
            )
            BEGIN
                THROW 50001, N'Ya existe un esquema con ese nombre.', 1;
            END;

            UPDATE Evaluacion.esquema_examen
            SET Activo = 0
            WHERE Activo = 1;

            INSERT INTO Evaluacion.esquema_examen (
                indice,
                esquema,
                ex_descripc,
                ex_descripcion_planilla,
                ex_tipo_dat,
                ex_requeric,
                Activo
            )
            VALUES (
                {modelo.indice},
                @NombreEsquema,
                N'{descripcion}',
                N'{descripcionPlanilla}',
                N'{tipoDato}',
                {(modelo.ex_requeric ? 1 : 0)},
                1
            );

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            IF XACT_STATE() <> 0
                ROLLBACK TRANSACTION;

            THROW;
        END CATCH;";

            this.Conexion.EjecutarAccion(query);
        }
        public void AgregarDescripcion(
    int codEsq, string descripcion, string planilla, string tipoDato)
        {
            descripcion = descripcion.Replace("'", "''");
            planilla = planilla.Replace("'", "''");
            tipoDato = tipoDato.Replace("'", "''");

            string query = $@"
        SET XACT_ABORT ON;
        BEGIN TRANSACTION;

        DECLARE @Esquema varchar(50), @Indice int, @Requerido bit;

        SELECT @Esquema = esquema,
               @Indice = indice,
               @Requerido = ex_requeric
        FROM Evaluacion.esquema_examen WITH (TABLOCKX, HOLDLOCK)
        WHERE [cod-esq] = {codEsq} AND Activo = 1;

        IF @Esquema IS NULL
        BEGIN
            THROW 50002, N'El esquema seleccionado ya no está activo.', 1;
        END;

        UPDATE Evaluacion.esquema_examen
        SET ex_descripc = N'{descripcion}',
            ex_descripcion_planilla = N'{planilla}',
            ex_tipo_dat = N'{tipoDato}'
        WHERE [cod-esq] = {codEsq}
          AND ex_descripc = ''
          AND ex_descripcion_planilla = ''
          AND ex_tipo_dat = '';

        IF @@ROWCOUNT = 0
        BEGIN
            INSERT INTO Evaluacion.esquema_examen
                (indice, esquema, ex_descripc, ex_descripcion_planilla,
                 ex_tipo_dat, ex_requeric, Activo)
            VALUES
                (@Indice, @Esquema, N'{descripcion}', N'{planilla}',
                 N'{tipoDato}', @Requerido, 1);
        END;

        COMMIT TRANSACTION;";

            this.Conexion.EjecutarAccion(query);
        }
    }
}