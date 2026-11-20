using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ISFDyT93.Datos.Daos
{
    public class EsquemaEvaluacionDao : IEsquemaEvaluacionDao
    {
        public DataTable ObtenerTipos()
        {
            const string sql = @"SELECT TipoExamenId, Descripcion, DescripcionPlanilla,
                                        TipoDato, Requerido, Activo
                                 FROM dbo.TipoExamen ORDER BY TipoExamenId";
            return Consultar(sql);
        }

        public DataTable ObtenerEsquemas()
        {
            const string sql = @"SELECT e.[cod-esq] AS CodEsq, e.indice AS Indice,
                                        e.esquema AS Esquema, e.TipoExamenId, e.Activo,
                                        t.Descripcion, t.DescripcionPlanilla, t.TipoDato,
                                        t.Requerido
                                 FROM Evaluacion.esquema_examen e
                                 LEFT JOIN dbo.TipoExamen t ON t.TipoExamenId = e.TipoExamenId
                                 ORDER BY e.esquema, e.indice, e.[cod-esq]";
            return Consultar(sql);
        }

        private static DataTable Consultar(string sql)
        {
            using (var conexion = new Conexion().Conector)
            using (var adaptador = new SqlDataAdapter(sql, conexion))
            {
                var tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public int GuardarTipos(IList<TipoExamenModelo> tipos)
        {
            if (tipos.Count == 0) return 0;
            using (var conexion = new Conexion().Conector)
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var tipo in tipos)
                        {
                            if (!tipo.Activo && tipo.TipoExamenId > 0)
                            {
                                using (var verificar = new SqlCommand(
                                    @"SELECT COUNT(*) FROM Evaluacion.esquema_examen
                                      WHERE TipoExamenId = @Id AND Activo = 1", conexion, transaccion))
                                {
                                    verificar.Parameters.Add("@Id", SqlDbType.Int).Value = tipo.TipoExamenId;
                                    if ((int)verificar.ExecuteScalar() > 0)
                                        throw new InvalidOperationException(
                                            "No podés desactivar un tipo usado por un esquema activo. Desactivá primero sus componentes.");
                                }
                            }

                            string sql = tipo.TipoExamenId == 0
                                ? @"INSERT INTO dbo.TipoExamen
                                    (Descripcion, DescripcionPlanilla, TipoDato, Requerido, Activo)
                                    VALUES (@Descripcion, @Planilla, @Dato, @Requerido, @Activo)"
                                : @"UPDATE dbo.TipoExamen SET Descripcion = @Descripcion,
                                        DescripcionPlanilla = @Planilla, TipoDato = @Dato,
                                        Requerido = @Requerido, Activo = @Activo
                                    WHERE TipoExamenId = @Id";

                            using (var comando = new SqlCommand(sql, conexion, transaccion))
                            {
                                comando.Parameters.Add("@Id", SqlDbType.Int).Value = tipo.TipoExamenId;
                                comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = tipo.Descripcion.Trim();
                                comando.Parameters.Add("@Planilla", SqlDbType.VarChar, 50).Value = tipo.DescripcionPlanilla.Trim();
                                comando.Parameters.Add("@Dato", SqlDbType.VarChar, 20).Value = tipo.TipoDato;
                                comando.Parameters.Add("@Requerido", SqlDbType.Bit).Value = tipo.Requerido;
                                comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = tipo.Activo;
                                if (comando.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException("El tipo de examen ya no existe. Recargá la tabla.");
                            }

                            if (tipo.TipoExamenId > 0)
                            {
                                using (var sincronizar = new SqlCommand(
                                    @"UPDATE e SET ex_descripc = @Descripcion,
                                          ex_descripcion_planilla = @Planilla,
                                          ex_tipo_dat = @Dato, ex_requeric = @Requerido
                                      FROM Evaluacion.esquema_examen e
                                      WHERE e.TipoExamenId = @Id", conexion, transaccion))
                                {
                                    sincronizar.Parameters.Add("@Id", SqlDbType.Int).Value = tipo.TipoExamenId;
                                    sincronizar.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = tipo.Descripcion.Trim();
                                    sincronizar.Parameters.Add("@Planilla", SqlDbType.VarChar, 50).Value = tipo.DescripcionPlanilla.Trim();
                                    sincronizar.Parameters.Add("@Dato", SqlDbType.VarChar, 20).Value = tipo.TipoDato;
                                    sincronizar.Parameters.Add("@Requerido", SqlDbType.Bit).Value = tipo.Requerido;
                                    sincronizar.ExecuteNonQuery();
                                }
                            }
                        }
                        transaccion.Commit();
                        return tipos.Count;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public int GuardarEsquemas(IList<EsquemaEvaluacionModelo> esquemas)
        {
            if (esquemas.Count == 0) return 0;
            using (var conexion = new Conexion().Conector)
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (var bloqueo = new SqlCommand(
                            "EXEC @Resultado = sys.sp_getapplock @Resource = N'Evaluacion.Esquemas', " +
                            "@LockMode = N'Exclusive', @LockOwner = N'Transaction'",
                            conexion, transaccion))
                        {
                            var resultado = bloqueo.Parameters.Add("@Resultado", SqlDbType.Int);
                            resultado.Direction = ParameterDirection.Output;
                            bloqueo.ExecuteNonQuery();
                            if ((int)resultado.Value < 0)
                                throw new InvalidOperationException("No se pudo bloquear la configuración de esquemas.");
                        }

                        foreach (var fila in esquemas)
                        {
                            if (fila.CodEsq == 0)
                            {
                                using (var verificarAlta = new SqlCommand(
                                    @"SELECT CASE
                                          WHEN EXISTS (SELECT 1 FROM Evaluacion.esquema_examen
                                                       WHERE esquema = @Esquema) THEN 1
                                          WHEN EXISTS (SELECT 1 FROM Evaluacion.esquema_examen
                                                       WHERE Activo = 1) THEN 2
                                          ELSE 0 END",
                                    conexion, transaccion))
                                {
                                    verificarAlta.Parameters.Add("@Esquema", SqlDbType.VarChar, 10).Value = fila.Esquema.Trim();
                                    int estado = (int)verificarAlta.ExecuteScalar();
                                    if (fila.NuevoEsquema && estado == 1)
                                        throw new InvalidOperationException("Ya existe un esquema con ese nombre. Recargá la tabla.");
                                    if (estado == 2)
                                        throw new InvalidOperationException(
                                            "Antes de crear un nuevo esquema, deshabilitá y guardá el esquema activo.");
                                    if (!fila.NuevoEsquema && estado == 0)
                                        throw new InvalidOperationException("El esquema ya no existe. Recargá la tabla.");
                                }
                            }

                            using (var verificar = new SqlCommand(
                                @"SELECT Activo FROM dbo.TipoExamen WHERE TipoExamenId = @Id",
                                conexion, transaccion))
                            {
                                verificar.Parameters.Add("@Id", SqlDbType.Int).Value = fila.TipoExamenId;
                                object activo = verificar.ExecuteScalar();
                                if (activo == null || (fila.Activo && !(bool)activo))
                                    throw new InvalidOperationException("Seleccioná un tipo de examen activo para el esquema.");
                            }

                            string sql = fila.CodEsq == 0
                                ? @"INSERT INTO Evaluacion.esquema_examen
                                    (indice, esquema, TipoExamenId, ex_descripc,
                                     ex_descripcion_planilla, ex_tipo_dat, ex_requeric, Activo)
                                    SELECT @Indice, @Esquema, t.TipoExamenId, t.Descripcion,
                                           t.DescripcionPlanilla, t.TipoDato, t.Requerido, @Activo
                                    FROM dbo.TipoExamen t WHERE t.TipoExamenId = @TipoId"
                                : @"UPDATE e SET indice = @Indice, esquema = @Esquema,
                                          TipoExamenId = t.TipoExamenId,
                                          ex_descripc = t.Descripcion,
                                          ex_descripcion_planilla = t.DescripcionPlanilla,
                                          ex_tipo_dat = t.TipoDato, ex_requeric = t.Requerido,
                                          Activo = @Activo
                                    FROM Evaluacion.esquema_examen e
                                    JOIN dbo.TipoExamen t ON t.TipoExamenId = @TipoId
                                    WHERE e.[cod-esq] = @CodEsq";

                            using (var comando = new SqlCommand(sql, conexion, transaccion))
                            {
                                comando.Parameters.Add("@CodEsq", SqlDbType.Int).Value = fila.CodEsq;
                                comando.Parameters.Add("@Indice", SqlDbType.Int).Value = fila.Indice;
                                comando.Parameters.Add("@Esquema", SqlDbType.VarChar, 10).Value = fila.Esquema.Trim();
                                comando.Parameters.Add("@TipoId", SqlDbType.Int).Value = fila.TipoExamenId;
                                comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = fila.Activo;
                                if (comando.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException("El componente ya no existe. Recargá la tabla.");
                            }
                        }
                        using (var verificarGrupos = new SqlCommand(
                            @"SELECT COUNT(DISTINCT LOWER(LTRIM(RTRIM(esquema))))
                              FROM Evaluacion.esquema_examen WHERE Activo = 1",
                            conexion, transaccion))
                        {
                            if ((int)verificarGrupos.ExecuteScalar() > 1)
                                throw new InvalidOperationException(
                                    "Solo puede haber un esquema activo. Deshabilitá el anterior y guardá antes de activar otro.");
                        }
                        transaccion.Commit();
                        return esquemas.Count;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public void CambiarEstadoEsquema(string nombre, bool activo)
        {
            using (var conexion = new Conexion().Conector)
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (var bloqueo = new SqlCommand(
                            "EXEC @Resultado = sys.sp_getapplock @Resource = N'Evaluacion.Esquemas', " +
                            "@LockMode = N'Exclusive', @LockOwner = N'Transaction'",
                            conexion, transaccion))
                        {
                            var resultado = bloqueo.Parameters.Add("@Resultado", SqlDbType.Int);
                            resultado.Direction = ParameterDirection.Output;
                            bloqueo.ExecuteNonQuery();
                            if ((int)resultado.Value < 0)
                                throw new InvalidOperationException("No se pudo bloquear la configuración de esquemas.");
                        }

                        if (activo)
                        {
                            using (var validar = new SqlCommand(
                                @"SELECT CASE
                                    WHEN EXISTS (SELECT 1 FROM Evaluacion.esquema_examen
                                                 WHERE Activo = 1 AND esquema <> @Esquema) THEN 1
                                    WHEN EXISTS (SELECT 1 FROM Evaluacion.esquema_examen e
                                                 LEFT JOIN dbo.TipoExamen t ON t.TipoExamenId = e.TipoExamenId
                                                 WHERE e.esquema = @Esquema AND ISNULL(t.Activo, 0) = 0) THEN 2
                                    ELSE 0 END", conexion, transaccion))
                            {
                                validar.Parameters.Add("@Esquema", SqlDbType.VarChar, 10).Value = nombre;
                                int estado = (int)validar.ExecuteScalar();
                                if (estado == 1)
                                    throw new InvalidOperationException(
                                        "Primero deshabilitá el esquema actual; no puede haber dos activos.");
                                if (estado == 2)
                                    throw new InvalidOperationException(
                                        "El esquema contiene tipos de examen inactivos o sin parametrizar.");
                            }
                        }

                        using (var comando = new SqlCommand(
                            "UPDATE Evaluacion.esquema_examen SET Activo = @Activo WHERE esquema = @Esquema",
                            conexion, transaccion))
                        {
                            comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = activo;
                            comando.Parameters.Add("@Esquema", SqlDbType.VarChar, 10).Value = nombre;
                            if (comando.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException("El esquema ya no existe. Volvé a cargar la pantalla.");
                        }
                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
