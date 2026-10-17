using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;

namespace ISFDyT93.Datos.Daos
{
    public class HorariosDao : DaoBase , IHorariosDao
    {
        public DataTable ObtnerModulos()
        {
            var query = "SELECT * FROM Modulos";
            return this.Conexion.ObtenerRegistros(query);
        }

        public IList<HorariosModelo> ObtenerHorarios(int cursoId)
        {
           
            string query = "SELECT CursoMaterias.MateriaId, Materias.Nombre, ISNULL(Materias.Modulos, 0) AS Modulos, " +
                           "HorarioId, DiaId, Horarios.ModuloId, CursoMaterias.CursoMateriaId " +
                           "FROM Cursos " +
                           "LEFT JOIN CursoMaterias ON CursoMaterias.CursoId = Cursos.CursoId " +
                           "LEFT JOIN Horarios ON Horarios.CursoMateriaId = CursoMaterias.CursoMateriaId " +
                           "LEFT JOIN Materias ON Materias.MateriaId = CursoMaterias.MateriaId " +
                           $"WHERE Cursos.CursoId = {cursoId}";

            return MapToModel<HorariosModelo>(Conexion.ObtenerRegistros(query));
        }

        public int ActualizarHorarios(IList<HorariosModelo> ltsHorarios)
        {
            int total = 0;

            foreach (HorariosModelo horario in ltsHorarios)
            {
                string dia = horario.DiaId == null ? "NULL" : horario.DiaId.ToString();
                string modulo = horario.ModuloId == null ? "NULL" : horario.ModuloId.ToString();

                if (horario.HorarioId > 0)
                {
                    string queryUpdate = $"UPDATE Horarios SET DiaId = {dia}, ModuloId = {modulo} WHERE HorarioId = {horario.HorarioId}";
                    total += this.Conexion.EjecutarAccion(queryUpdate);
                }
                else if (horario.Asignado)
                {
                    string queryInsert = $"INSERT INTO Horarios (CursoMateriaId, DiaId, ModuloId) " +
                                         $"VALUES ({horario.CursoMateriaId}, {dia}, {modulo})";
                    total += this.Conexion.EjecutarAccion(queryInsert);
                }
            }

            return total;
        }

        // Método para traer módulos filtrados
        public DataTable ObtenerModulosPorTurno(string turno)
        {
            string query = $"SELECT * FROM Modulos WHERE Turno = '{turno}' ORDER BY ModuloId ASC";
            return this.Conexion.ObtenerRegistros(query);
        }
        // Método para llenar el ComboBox de Turnos sin repetidos
        public DataTable ObtenerTurnosDisponibles()
        {
            string query = "SELECT ModuloId, Turno, Descripcion, Activo FROM Modulos WHERE Turno IS NOT NULL AND Turno <> ''";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int InsertarTurnoNuevo(string turno)
        {
            string query = $"INSERT INTO Modulos (Turno, Descripcion, Activo) VALUES ('{turno}', '-', 1)";
            return this.Conexion.EjecutarAccion(query);
        }


        public int InsertarModulo(string turno, string descripcion)
        {

            string queryLimpiarComodin = $"DELETE FROM Modulos WHERE Turno = '{turno}' AND (Descripcion = '-' OR Descripcion = 'Sin definir' OR Descripcion IS NULL)";
            this.Conexion.EjecutarAccion(queryLimpiarComodin);


            string queryInsertar = $"INSERT INTO Modulos (Turno, Descripcion, Activo) VALUES ('{turno}', '{descripcion}', 1)";
            return this.Conexion.EjecutarAccion(queryInsertar);
        }
        public int ActualizarEstadoModulo(int moduloId, bool activo)
        {
            int valorActivo = activo ? 1 : 0;
            string query = $"UPDATE Modulos SET Activo = {valorActivo} WHERE ModuloId = {moduloId}";
            return this.Conexion.EjecutarAccion(query);
        }
    }
}
