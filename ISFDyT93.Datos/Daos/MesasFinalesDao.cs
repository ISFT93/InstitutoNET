using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Core;
using System.Reflection;
using System.Data.SqlClient;
using System.Security;

namespace ISFDyT93.Datos.Daos
{
    public class MesasFinalesDao : DaoBase
    {

        public DataTable ObtenerProfesorTitular(int MateriaId)
        {
            var query = $"select Pe.PersonalId, concat (Pe.Nombre, ' ', Pe.Apellido) as Nombre from Personal Pe " +
                $"inner join Servicios Se on Pe.PersonalId = Se.PersonalId " +
                $"inner join CursoMaterias Cu on Se.CursoMateriaId = Cu.CursoMateriaId " +
                $"inner join Materias Ma on Cu.MateriaId = Ma.MateriaId " +
                $"where Ma.MateriaId = {MateriaId} and Se.Activo = 1";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerVocales(int CarreraId, int PersonalId)
        {
            var query = $"select Pe.PersonalId, concat (Pe.Nombre, ' ', Pe.Apellido) as Nombre from Personal Pe " +
                $"inner join Servicios Se on Pe.PersonalId = Se.PersonalId " +
                $"where Se.CarreraId = {CarreraId} and Se.Activo = 1 " +
                $"and Se.PersonalId not in (select PersonalId from Servicios where PersonalId = {PersonalId})";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int AgregarMesa(int CarreraId, DateTime fecha, int Turno, int Llamado, int MateriaId, int PresidenteId, int VocalId, int AnioLectivo)
        {
            var query = $"insert into MesasFinales values ({CarreraId} ,'{fecha:yyyy-MM-dd}', {Turno}, {Llamado}, {MateriaId}, {PresidenteId}, {VocalId}, {AnioLectivo}, 1)";
            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerMesas(int CarreraId)
        {
            var query = "select Fi.MesaFinalId, Fi.Fecha, Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Ma.Nombre as 'Materia', concat (Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat (Voc.Nombre, ' ', Voc.Apellido) as Vocal, FinEst.Descripcion as 'Estado' " +
                "from MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId " +
                "inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId " +
                "inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId " +
                "inner join FinalEstados FinEst on Fi.FinalEstadoId = FinEst.FinalEstadoId " +
                "left join Personal Pe on Fi.PresidenteId = Pe.PersonalId " +
                $"left join Personal Voc on Fi.VocalId = Voc.PersonalId where Fi.CarreraId = {CarreraId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int ModificarMesas(DateTime fecha, int turno, int presidenteId, int vocalId, int mesaFinalId)
        {
            var query = $"update MesasFinales set Fecha = '{fecha:yyyy-MM-dd}', TurnoId = '{turno}', PresidenteId = {presidenteId}, VocalId = {vocalId}, FinalEstadoId = 1 where MesaFinalId = {mesaFinalId}";
            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarMesas(int mesaFinalId)
        {
            var query = $"delete from MesasFinales where MesaFinalId = {mesaFinalId}";
            return this.Conexion.EjecutarAccion(query);
        }

        public DataTable ObtenerMateriaFinal(int mesaFinalId)
        {
            var query = "select Ma.MateriaId, Ma.Nombre from Materias Ma " +
                "inner join MesasFinales Fi on Ma.MateriaId = Fi.MateriaId " +
                $"where Fi.MesaFinalId = {mesaFinalId}";  
            return this.Conexion.ObtenerRegistros(query);
        }

        public int CargarMesasFinales(int cicloLectivoId, int turnoId)
        {
            var parcicloLectivoId = new SqlParameter ("anioLectivo", SqlDbType.Int);
            parcicloLectivoId.Value = cicloLectivoId;
            var parturnoId = new SqlParameter("turnoId", SqlDbType.Int);
            parturnoId.Value = turnoId;
            var parameters = new SqlParameter[2] { parcicloLectivoId, parturnoId };
            var res = this.Conexion.EjecutarStoreNumber("SP_CrearMesasFinales", parameters);
            return res;
        }

        public DataTable ObtenerTurnoMesa(int mesaFinalId)
        {
            var query = $"select Tu.TurnoId, Tu.Descripcion from Turnos Tu inner join MesasFinales MF " +
                $"on Tu.TurnoId = MF.TurnoId where MF.MesaFinalId = {mesaFinalId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerTurnos()
        {
            var query = "select * from Turnos";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerAniosLectivos()
        {
            var query = "select distinct CicloLectivoId from MesasFinales";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMesasFiltro(int carreraId, int anioLectivoId, int turnoId, int llamadoId)
        {
            var query = "select Fi.MesaFinalId, Ma.Nombre as 'Materia', Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Fi.Fecha, concat (Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat (Voc.Nombre, ' ', Voc.Apellido) as Vocal, FinEst.Descripcion as 'Estado' " +
                "from MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId " +
                "inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId " +
                "inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId " +
                "inner join FinalEstados FinEst on Fi.FinalEstadoId = FinEst.FinalEstadoId " +
                "left join Personal Pe on Fi.PresidenteId = Pe.PersonalId " +
                $"left join Personal Voc on Fi.VocalId = Voc.PersonalId where Fi.CarreraId = {carreraId} and Fi.CicloLectivoId = {anioLectivoId} and Fi.TurnoId = {turnoId} and Fi.LlamadoId = {llamadoId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerMesasReporte(int carreraId, int anioLectivoId, int turnoId, int llamadoId)
        {
            var query = "select Fi.MesaFinalId, Ma.Nombre as 'Materia', Ll.Descripcion as 'Llamado', Tu.Descripcion as 'Turno', Fi.Fecha, concat (Pe.Nombre, ' ', Pe.Apellido) as 'Titular', concat (Voc.Nombre, ' ', Voc.Apellido) as Vocal, FinEst.Descripcion as 'Estado' " +
                "from MesasFinales Fi inner join Materias Ma on Fi.MateriaId = Ma.MateriaId " +
                "inner join Turnos Tu on Fi.TurnoId = Tu.TurnoId " +
                "inner join Llamados Ll on Fi.LlamadoId = Ll.LlamadoId " +
                "inner join FinalEstados FinEst on Fi.FinalEstadoId = FinEst.FinalEstadoId " +
                "left join Personal Pe on Fi.PresidenteId = Pe.PersonalId " +
                $"left join Personal Voc on Fi.VocalId = Voc.PersonalId where Fi.CarreraId = {carreraId} and Fi.CicloLectivoId = {anioLectivoId} and Fi.TurnoId = {turnoId} and Fi.LlamadoId = {llamadoId} and Fi.FinalEstadoId = 1";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ExistenFechasFinales(int anioLectivo)
        {
            var paranioLectivo = new SqlParameter("anioLectivo", SqlDbType.Int);
            paranioLectivo.Value = anioLectivo;
            var parametros = new SqlParameter[1] { paranioLectivo };
            return this.Conexion.EjecutarStore("SP_ExistenFechasFinales", parametros);
        }

        public DataTable ObtenerLlamados()
        {
            var query = "select * from Llamados";
            return this.Conexion.ObtenerRegistros(query);
        }
    }
}
