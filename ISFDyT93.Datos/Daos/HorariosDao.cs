using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Datos.Core;

namespace ISFDyT93.Datos.Daos
{
    public class HorariosDao : DaoBase
    {
        public DataTable ObtnerModulos()
        {
            var query = "SELECT * FROM Modulos";
            return this.Conexion.ObtenerRegistros(query);
        }

        public IList<HorariosModelo> ObtenerHorarios(int cursoId)
        {
            string query = "SELECT CursoMaterias.MateriaId, Materias.Nombre, HorarioId, DiaId, Horarios.ModuloId, Horarios.CursoMateriaId " +
                "FROM Horarios " +
                "INNER JOIN CursoMaterias ON Horarios.CursoMateriaId = CursoMaterias.CursoMateriaId " +
                "INNER JOIN Cursos ON CursoMaterias.CursoId = Cursos.CursoId " +
                "INNER JOIN Materias ON Materias.MateriaId = CursoMaterias.MateriaId " +
                $"WHERE Cursos.CursoId = {cursoId}";              

            return MapToModel<HorariosModelo>(Conexion.ObtenerRegistros(query));            
        }

        public int ActualizarHorarios(IList<HorariosModelo> ltsHorarios)
        {
            int total = 0;
            foreach(HorariosModelo horario in ltsHorarios)
            {
                string dia = (horario.DiaId == null ? "NULL" : horario.DiaId.ToString());
                string modulo = (horario.ModuloId == null ? "NULL" : horario.ModuloId.ToString());

                string query = $"UPDATE Horarios SET DiaId= {dia}, ModuloId= {modulo} WHERE HorarioId= {horario.HorarioId}";
                total += this.Conexion.EjecutarAccion(query);
            }

            return total;
        }
    }
}
