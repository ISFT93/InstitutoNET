using System;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Enums;
using System.Data.SqlClient;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class AlumnosDao : DaoBase
    {
        public int AgregarAlumnoTablaExcel(AlumnosModelo modelo)
        {
            string query = "INSERT INTO Alumnos  ([Apellido], [Nombre],[TipoDocumento], [NumeroDocumento],[EstadoCivil]," +
                    "[Sexo],  [LocNacimiento], [Calle],[Numero],[Provincia],[Distrito],[Localidad],[CodigoPostal],[Celular]," +
                    "[Email], [FotoUrl], [Activo]) VALUES ('" + modelo.Apellido + "','" +
                     modelo.Nombre + "', '" + modelo.TipoDocumento + "','" + modelo.NumeroDocumento + "','" +
                     modelo.EstadoCivil + "', '" + modelo.Sexo + "', '" +
                     modelo.LocalidadNacimiento + "', '" + modelo.Calle + "','" +
                     modelo.Numero + "', '" + modelo.Provincia + "','" +
                     modelo.Distrito + "', '" + modelo.Localidad + "', '" + modelo.CodigoPostal + "', '" +
                     modelo.Celular + "', '" + modelo.Email + "', '" + modelo.FotoUrl + "', '" + modelo.Activo + "' )";

            return this.Conexion.EjecutarAccion(query);
        }
        public int ModificarAlumnoTablaExcel(AlumnosModelo modelo)
        {
            string query = "UPDATE Alumnos SET Apellido='" + modelo.Apellido + "',Nombre=" +
            " '" + modelo.Nombre + "',TipoDocumento='" + modelo.TipoDocumento + "',EstadoCivil=" +
            " '" + modelo.EstadoCivil + "',Sexo='" + modelo.Sexo + "',LocNacimiento=" +
            " '" + modelo.LocalidadNacimiento + "',Calle='" + modelo.Calle + "',Numero=" +
            " '" + modelo.Numero +"',Provincia='" + modelo.Provincia + "',Distrito=" +
            " '" + modelo.Distrito + "',Localidad='" + modelo.Localidad + "',CodigoPostal='" + modelo.CodigoPostal  + "',Celular=" +
            " '" + modelo.Celular + "',Email='" + modelo.Email + "',FotoUrl='" + modelo.FotoUrl+ "',Activo='" +modelo.Activo +"' WHERE NumeroDocumento ='" + modelo.NumeroDocumento+"'";

            return this.Conexion.EjecutarAccion(query);
        }


        public int AgregarAlumno(AlumnosModelo modelo)
        {
            string q = this.CreateInsertQuery<AlumnosModelo>(modelo);

            return this.Conexion.EjecutarAccion(q);
        }

        public int AgregarAlumnoCargaMasiva(AlumnosModelo modelo)
        {
            string query = "INSERT INTO Alumnos ([Apellido], [Nombre], [TipoDocumento],[NumeroDocumento]," +
                    "[EstadoCivil], [Sexo], [FechaNacimiento], [LocNacimiento],[Calle],[Provincia],[Distrito],[Localidad],[CodigoPostal],[Celular]," +
                    "[Email], [FotoUrl])  VALUES ('" + modelo.Apellido + "','" + modelo.Nombre + "', '" + modelo.TipoDocumento + "', '" + modelo.NumeroDocumento + "','" +
          modelo.EstadoCivil + "', '" + modelo.Sexo + "', '" + modelo.FechaNacimiento + "','" + modelo.LocalidadNacimiento + "','" + modelo.Calle + "','" + modelo.Provincia + "','" +
          modelo.Distrito + "', '" + modelo.Localidad + "', '" + modelo.CodigoPostal + "', '" + modelo.Celular + "', '" + modelo.Email + "', '" + modelo.FotoUrl + "')";

            return this.Conexion.EjecutarAccion(query);
        }
        public int ModificarAlumno(AlumnosModelo modelo)
        {
            string query = this.CreateUpdateQuery<AlumnosModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }
        
        public int AgregarAlumnoCarrera(AlumnosCarrerasModelo modelo)
        {
            string query = this.CreateInsertQuery<AlumnosCarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }
        public int AgregarAlumnoCarreraExcel(AlumnosCarrerasModelo modelo)
        {
            int activ = 0;
            if (modelo.Activo == false)
                activ = 1;
            else
                activ = 0;

            string query = "INSERT INTO AlumnosCarreras ([CarreraId], [AlumnoId], [FechaAlta], [Activo]) VALUES (" +
            modelo.CarreraId + "," + modelo.AlumnoId + ",'" + modelo.FechaAlta + "'," + activ + ")";
            return this.Conexion.EjecutarAccion(query);
        }
        public int ModificarAlumnoCarrera(AlumnosCarrerasModelo modelo)
        {
            string query = this.CreateUpdateQuery<AlumnosCarrerasModelo>(modelo);

            return this.Conexion.EjecutarAccion(query);
        }       

        
        public DataTable ObtenerAlumnosPrueba()//Carga la grilla new
        {
            string query = "SELECT Alumnos.Apellido, Alumnos.Nombre, Alumnos.NumeroDocumento AS [Documento] FROM Alumnos ";

            return this.Conexion.ObtenerRegistros(query);
        }

        public AlumnosModelo ObtenerAlumno(int AlumnoId)
        {
            string query = "SELECT * FROM Alumnos WHERE AlumnoId = " + AlumnoId;
            return MapToModel<AlumnosModelo>(this.Conexion.ObtenerRegistro(query));
        }
        public AlumnosModelo ObtenerAlumnoCarrera(int AlumnoId)
        {
            string query = "SELECT A.*, C.[DescripcionCorta] AS Carrera FROM Alumnos A " +
                "INNER JOIN AlumnoCarrera ca ON ca.AlumnoId = A.AlumnoId " +
                "INNER JOIN Carreras C ON c.CarreraId = ca.CarreraId " +
                "WHERE AlumnoId = " + AlumnoId;

            return MapToModel<AlumnosModelo>(this.Conexion.ObtenerRegistro(query));
        }

        public AlumnosCarrerasModelo TraerAlumnoCarrera(int AlumnoId)
        {
            string query = "SELECT * FROM AlumnosCarreras WHERE AlumnoId =" + AlumnoId + " AND Activo = 1";
            return MapToModel<AlumnosCarrerasModelo>(this.Conexion.ObtenerRegistro(query));
   
        }
        public void EliminarAlumno(int AlumnoId)
        {
            string query = "UPDATE Alumnos SET Activo = " + 0 + "WHERE AlumnoId = " + AlumnoId + "";
            this.Conexion.EjecutarAccion(query);
        }
        public void BajaAlumnoCarrera(int AlumnoId)
        {
            string query = "UPDATE AlumnosCarreras SET Activo = " + 0 + " WHERE AlumnoId = " + AlumnoId + "";
            this.Conexion.EjecutarAccion(query);
        }

        public int TraerCarreraIdActiva(int AlumnoId)
        {
            string query = "SELECT A.CarreraId FROM AlumnosCarreras as A INNER JOIN Carreras as C on A.CarreraId = C.CarreraId WHERE C.Activo = 1 and A.AlumnoId= " + AlumnoId + "";
            var CarreraId = this.Conexion.ObtenerRegistro(query);

            if (CarreraId != null)
            {
                return Convert.ToInt32(CarreraId["CarreraId"]);
            }

            return 0;
        }
        public int UltimoId()
        {
            string query = "SELECT TOP 1 AlumnoId FROM Alumnos ORDER BY AlumnoId DESC";
            var alumno = this.Conexion.ObtenerRegistro(query);

            if (alumno != null)
            {
                return Convert.ToInt32(alumno["AlumnoId"]);
            }

            return 0;
        }

        public DataRow AlumnoExiste(string DNI)
        {
            string query = "SELECT TOP 1 AlumnoId FROM Alumnos WHERE NumeroDocumento = '" + DNI + "'";
            return this.Conexion.ObtenerRegistro(query);
        }

        public int ConsultarAlumnoCiclo(int AlumnoId)
        {
            string query = "SELECT TOP 1 [CursadaAlumnoCarreraId] FROM [dbo].[CursadaAlumnoCarreras] CAC " +
                "INNER JOIN [AlumnosCarreras] CA ON CAC.AlumnoCarreraId = CA.AlumnoCarreraId " +
                "WHERE CA.AlumnoId = " + AlumnoId;

            var existe = this.Conexion.ObtenerRegistro(query);

            if (existe != null)
            {
                return Convert.ToInt32(existe["CursadaAlumnoCarreraId"]);
            }
            return 0;
        }
        public void DarAltaAlumnos(int alumnoId)
        {
            string query = "UPDATE Alumnos SET Activo = " + 1 + " WHERE AlumnoId = " + alumnoId;
            this.Conexion.EjecutarAccion(query);
        }
        
        public DataTable ObtenerTodosAlumnos(TipoFiltroAlumno tipo, string filtro, string activo)
        {
            string query;
            if (tipo != TipoFiltroAlumno.Anio && tipo != TipoFiltroAlumno.Curso)
            {
                query = "SELECT Alumnos.AlumnoId, AlumnosCarreras.AlumnoCarreraId, Alumnos.Apellido, Alumnos.Nombre, " +
                    "Alumnos.NumeroDocumento AS Documento, Alumnos.FechaNacimiento AS Nacimiento, Carreras.DescripcionCorta AS Carrera, " +
                    "Alumnos.Activo, AlumnosCarreras.Inicializado " +
                    "FROM Alumnos " +
                    "LEFT JOIN AlumnosCarreras ON Alumnos.AlumnoId = AlumnosCarreras.AlumnoId " +
                    "LEFT JOIN Carreras ON AlumnosCarreras.CarreraId = Carreras.CarreraId " +
                    "WHERE ";
            }
            else
            {
                query = "SELECT Apellido, Nombre, Materia, Anio AS Año, Curso, Carrera, Activo, AlumnoId, AlumnoCarreraId, Inicializado FROM AlumnoMateriaCursoAnioCarrera WHERE ";
            }

            switch (tipo)
            {
                case TipoFiltroAlumno.Todos:
                    query += "(Alumnos.Apellido LIKE '%" + filtro + "%'" + " OR " +
                        "Alumnos.Nombre LIKE '%" + filtro + "%'" + " OR " +
                        "Alumnos.NumeroDocumento LIKE '%" + filtro + "%')";
                    break;
                case TipoFiltroAlumno.NumeroDocumento:
                    query += "Alumnos.NumeroDocumento LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroAlumno.Nombre:
                    query += "Alumnos.Nombre LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroAlumno.Apellido:
                    query += "Alumnos.Apellido LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroAlumno.Carrera:
                    query += "Carreras.DescripcionCorta LIKE '%" + filtro + "%'";
                    break;
                case TipoFiltroAlumno.Anio:
                    query += $"Anio LIKE '%{filtro}%'";
                    break;
                case TipoFiltroAlumno.Curso:
                    query += $"Curso LIKE '%{filtro}%'";
                    break;
            }

            if (activo != null)
            {
                if (tipo != TipoFiltroAlumno.Anio && tipo != TipoFiltroAlumno.Curso)
                    query += " AND Alumnos.Activo= " + activo;
                else
                    query += " AND Activo= " + activo;
            }
            query += " ORDER BY Apellido ASC";

            return this.Conexion.ObtenerRegistros(query);
        }

        public int CargarCursadasAlumnoSP(AlumnosCarrerasModelo Modelo)
        {
            int result = 0;

            var parAlumnoId = new SqlParameter("alumnoId", SqlDbType.Int);
            parAlumnoId.Value = Modelo.AlumnoId;

            var parCarreraId = new SqlParameter("carreraId", SqlDbType.Int);
            parCarreraId.Value = Modelo.CarreraId;

            var parametros = new SqlParameter[2] { parAlumnoId, parCarreraId };
            result = Conexion.EjecutarStoreNumber("SP_CursadaAlumnoCarrera", parametros);

            return result;
        }

        public DataTable ObtenerPaisNacimientoAlumnos()
        {
            string query = "SELECT DISTINCT PaisNacimiento FROM Alumnos";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerLocalidadAlumnos()
        {
            return this.Conexion.EjecutarStore("SP_ListaLocalidades");
        }
        public DataTable ObtenerDistritoAlumnos()
        {
            string query = "SELECT DISTINCT Distrito FROM Alumnos";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerProvinciaAlumnos()
        {
            string query = "SELECT DISTINCT Provincia FROM Alumnos";
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
