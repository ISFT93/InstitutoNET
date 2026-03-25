using System;
using System.Data;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class LicenciaServicioDao : DaoBase
    {
        public DataTable ObtenerLicencias(int id)
        {
            string query = $"SELECT * FROM viewLicencias WHERE PersonalId= {id}";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataRow ObtenerServicios(int servicioId)
        {
            string query = "SELECTIIF(se.CursoMateriaId IS NULL, IIF(se.CarreraId IS NOT NULL, car.DescripcionCorta, ''), CONCAT(ma.Nombre, ' - ', car.DescripcionCorta, ' ', ac.AnioCarrera, cu.NombreCurso)) AS 'Servicio' FROM Servicios S INNER JOIN CursoMaterias CM ON S.CursoMateriaId = CM.CursoMateriaId INNER JOIN Materias M ON M.MateriaId = CM.MateriaId WHERE S.ServicioId = " + servicioId;
            return this.Conexion.ObtenerRegistro(query);
        }

        public DataRow ObtenerFechaBajaObligatorio(Modelos.LicenciaServicioModelo modelos)
        {
            string query = "SELECT FechaBajaObligatiorio FROM TipoLicencias WHERE TipoLicenciaId = " + modelos.licenciaTipoId;
            return this.Conexion.ObtenerRegistro(query);
        }

        public DataTable ObtenerLicenciasDeActivos(Modelos.LicenciaServicioModelo modelo)
        {
            string query = " select L.LicenciaId, M.Nombre AS 'Servicio', L.FechaAlta AS 'Fecha de Inicio', L.FechaBaja AS 'Fecha de Fin', S.ServicioId, L.Comentarios, L.Certificado  FROM LicenciaServicios LS INNER JOIN Licencias L ON LS.LicenciaId = L.LicenciaId INNER JOIN Servicios S ON S.ServicioId = LS.ServicioId INNER JOIN Personal P ON P.PersonalId = S.PersonalId INNER JOIN CursoMaterias CM ON CM.CursoMateriaId = S.CursoMateriaId INNER JOIN Materias M ON M.MateriaId = CM.MateriaId WHERE P.PersonalId = " + modelo.personalId + " AND (L.FechaBaja IS NULL OR  L.FechaBaja >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "')";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerLicenciasDeInactivos(Modelos.LicenciaServicioModelo modelo)
        {
            string query = " select L.LicenciaId, M.Nombre AS 'Servicio', L.FechaAlta AS 'Fecha de Inicio', L.FechaBaja AS 'Fecha de Fin', S.ServicioId, L.Comentarios, L.Certificado FROM LicenciaServicios LS INNER JOIN Licencias L ON LS.LicenciaId = L.LicenciaId INNER JOIN Servicios S ON S.ServicioId = LS.ServicioId INNER JOIN Personal P ON P.PersonalId = S.PersonalId INNER JOIN CursoMaterias CM ON CM.CursoMateriaId = S.CursoMateriaId INNER JOIN Materias M ON M.MateriaId = CM.MateriaId WHERE P.PersonalId = " + modelo.personalId + " AND L.FechaBaja < '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerLicenciasTipo()
        {
            string query = "SELECT * FROM TipoLicencias";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int BajaLicencia(Modelos.LicenciaServicioModelo modelo)
        {
            string query = "UPDATE Licencias SET FechaBaja = '" + modelo.fechaBajaSTR + "' WHERE LicenciaId = " + modelo.licenciaId;
            return this.Conexion.EjecutarAccion(query);
        }
        public int AltaLicencia(Modelos.LicenciaServicioModelo modelo)
        {
            int res = 0;
            var parServicioId = new SqlParameter("servicioId", SqlDbType.Int);
            parServicioId.Value = modelo.servicioId;
            var parPersonalId = new SqlParameter("personalId", SqlDbType.Int);
            parPersonalId.Value = modelo.personalId;
            var parTipoLicenciaId = new SqlParameter("tipoLicenciaId", SqlDbType.Int);
            parTipoLicenciaId.Value = modelo.licenciaTipoId;
            var parCertf = new SqlParameter("certificado", SqlDbType.VarChar);
            parCertf.Value = modelo.certificado;
            var parfechaAlta = new SqlParameter("fechaAlta", SqlDbType.Date);
            parfechaAlta.Value = modelo.fechaAltaSTR;
            var parfechaBaja = new SqlParameter("fechaBaja", SqlDbType.Date);
            parfechaBaja.Value = modelo.fechaBajaSTR;
            var parComentarios = new SqlParameter("comentarios", SqlDbType.VarChar);
            parComentarios.Value = modelo.comentarios;
            var parametros = new SqlParameter[7] { parServicioId, parPersonalId, parTipoLicenciaId, parCertf, parfechaAlta, parfechaBaja,  parComentarios};
            res = this.Conexion.EjecutarStoreNumber("SP_LicenciasServicios", parametros);
            return res;
        }
    }
}
