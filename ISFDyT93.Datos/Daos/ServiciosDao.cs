using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace ISFDyT93.Datos.Daos
{
    public class ServiciosDao : DaoBase
    {
        public DataTable ObtenerCargos(int personalId)
        {
         
            var parPersonalId = new SqlParameter("PersonalId", SqlDbType.Int);
            parPersonalId.Value = personalId;

            var parametros = new SqlParameter[1] { parPersonalId };

            return this.Conexion.EjecutarStore("SP_CargosLibres", parametros);
        }

        public LibroActasModelo ObtenerUltimoLibro(int tipoLibroId)
        {
            string query = $"SELECT Top 1 * FROM LibroActas WHERE TipoLibroId = {tipoLibroId} ORDER BY LibroActaId DESC";
            return this.MapToModel<LibroActasModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public DataTable ObtenerServicioPersonal(int personalId, int activo)
        {
            string query = "SELECT se.ServicioId, ca.Descripcion as Cargo, sr.Descripcion as Situacion, " +
                "IIF(se.CursoMateriaId IS NULL, IIF(se.CarreraId IS NOT NULL, car.DescripcionCorta, ''), CONCAT(ma.Nombre, ' - ', car.DescripcionCorta, ' ', ac.AnioCarrera, cu.NombreCurso)) AS 'Servicio', " +
                "se.FechaAlta, " +
                "se.FechaBaja, " +
                "la.LibroNumero as Libro, " +
                "la.FolioNumero as Folio, " +
                "se.Activo " +
                "FROM Servicios se " +
                "LEFT JOIN Carreras car on car.CarreraId = se.CarreraId " +
                "LEFT JOIN CursoMaterias cm on se.CursoMateriaId = cm.CursoMateriaId " +
                "LEFT JOIN Materias ma on ma.MateriaId = cm.MateriaId " +
                "INNER JOIN  Cargos ca on ca.CargoId = se.CargoId " +
                "LEFT JOIN SituacionRevistas sr on sr.SituacionRevistaId = se.SituacionRevistaId " +
                "LEFT JOIN personal pe on pe.PersonalId = se.PersonalId " +
                "LEFT JOIN AniosCarreras ac on ma.AnioCarreraId = ac.AnioCarreraId " +
                "LEFT JOIN LibroActas la on la.LibroActaId = se.LibroActaId " +
                "LEFT JOIN  Cursos cu on cu.CursoId = cm.CursoId " +
                $"WHERE se.personalId = { personalId } AND se.Activo = { activo }";
            return this.Conexion.ObtenerRegistros(query);
        }

        public ServiciosModelo ObtenerServicio(int servicioId)
        {
            string query = "SELECT * FROM Servicios";
            return this.MapToModel<ServiciosModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public DataTable ObtenerCargosAsignados(int cargoId, int personalId)
        {
            string query = "SELECT CONCAT(Car.Descripcion, ' (', Ma.Nombre, ') ') AS Cargos FROM dbo.Cargos AS Car " +
                "INNER JOIN dbo.Servicios AS Ser ON Car.CargoId = Ser.CargoId " +
                "INNER JOIN dbo.CursoMaterias AS CM ON Ser.CursoMateriaId = CM.CursoMateriaId " +
                "INNER JOIN dbo.Materias AS Ma ON Ma.MateriaId = CM.MateriaId " +
                $"WHERE Ser.Activo= 'True' AND Ser.PersonalId = {personalId} AND Ser.CargoId = {cargoId}";


            return this.Conexion.ObtenerRegistros(query);
        }

        

        public DataTable ObtenerMateriasLibres(int tipoAsignacionId, int cursoId, int situacionRevistaId)
        {
            var parTipoAsignacionId = new SqlParameter("TipoAsignacionId", SqlDbType.Int);
            parTipoAsignacionId.Value = tipoAsignacionId;

            var parCursoId = new SqlParameter("CursoId", SqlDbType.Int);
            parCursoId.Value = cursoId;

            var parSituacionRevistaId = new SqlParameter("SituacionRevistaId", SqlDbType.Int);
            parSituacionRevistaId.Value = situacionRevistaId;

            var parametros = new SqlParameter[3] { parTipoAsignacionId, parCursoId, parSituacionRevistaId };

            return this.Conexion.EjecutarStore("SP_CursoMateriasLibres", parametros);
        }

        public void ActualizarPersonalEstado(int personalEstadoId, int personalId)
        {
            string query = "UPDATE Personal SET PersonalEstadoId = " + personalEstadoId + " WHERE PersonalId = " + personalId;
            this.Conexion.EjecutarAccion(query);
        }

        public int AgregarServicio(ServiciosModelo modelo)
        {
            var query = this.CreateInsertQuery<ServiciosModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public int ActualizarServicio(ServiciosModelo modelo)
        {
            var query = this.CreateUpdateQuery<ServiciosModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerSituacionRevista()
        {
            string query = "SELECT SituacionRevistaId, Descripcion from SituacionRevistas";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerCarreras(int tipoAsignacionId, int situacionRevistaId)
        {
            var parTipoAsignacionId = new SqlParameter("TipoAsignacionId", SqlDbType.Int);
            parTipoAsignacionId.Value = tipoAsignacionId;

            var parSituacionRevistaId = new SqlParameter("SituacionRevistaId", SqlDbType.Int);
            parSituacionRevistaId.Value = situacionRevistaId;

            var parametros = new SqlParameter[2] { parTipoAsignacionId, parSituacionRevistaId };

            return this.Conexion.EjecutarStore("SP_CarrerasDisponibles", parametros);
        }

        public DataTable ObtenerCarrerasSinJefeCatedra(int PersonalId)
        {
            string query = "SELECT * FROM Carreras WHERE JefeCatedra IS NULL AND Activo= 'True'";

            return this.Conexion.ObtenerRegistros(query) ;
        }

        public DataTable ObtenerAnioCarreras(int carreraId)
        {
            string query = "SELECT AnioCarreraId, AnioCarrera FROM AniosCarreras WHERE CarreraId="+carreraId;
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerCursos(int anioCarreraId)
        {
            string query = "SELECT CursoId, NombreCurso FROM Cursos WHERE Activo=1 and AnioCarreraId="+ anioCarreraId;
            return this.Conexion.ObtenerRegistros(query);
        }

        public LibroActasModelo AgregarLibroActa(LibroActasModelo libro)
        {
            string query = this.CreateInsertQuery<LibroActasModelo>(libro);

            if (this.Conexion.EjecutarAccion(query) > 0)
                return this.ObtenerUltimoLibro(libro.TipoLibroId);

            return null;
        }

        public void ActualizarLibroActa(LibroActasModelo libro)
        {
            string query = this.CreateUpdateQuery<LibroActasModelo>(libro);

            this.Conexion.EjecutarAccion(query);
        }

        public void ActualizarJefeCatedra(int carreraId, string nombreProfesor)
        {
            nombreProfesor = nombreProfesor == null ? "NULL" : $"'{nombreProfesor}'";

            string query = $"UPDATE Carreras SET JefeCatedra = {nombreProfesor} WHERE CarreraId = {carreraId}";
            this.Conexion.EjecutarAccion(query);
        }

        public DataRow ObtenerModuloMateria(int CursoMateriaId)
        {
            string query = $"SELECT Modulos FROM Materias WHERE MateriaId = (SELECT MateriaId FROM CursoMaterias WHERE CursoMateriaId = {CursoMateriaId})";
            return this.Conexion.ObtenerRegistro(query);
        }
    }
}
