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


    }
}
