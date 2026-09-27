using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Interfaces;
using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string query = "SELECT CursoMaterias.MateriaId, Materias.Nombre, HorarioId, DiaId, Horarios.ModuloId, CursoMaterias.CursoMateriaId, Materias.Modulos " +
               "FROM Cursos " +
               "LEFT JOIN CursoMaterias ON CursoMaterias.CursoId = Cursos.CursoId " +
               "LEFT JOIN Horarios ON Horarios.CursoMateriaId = CursoMaterias.CursoMateriaId " +
               "LEFT JOIN Materias ON Materias.MateriaId = CursoMaterias.MateriaId " +
               $"WHERE Cursos.CursoId = {cursoId}";

            var ltsHorarios = MapToModel<HorariosModelo>(Conexion.ObtenerRegistros(query));

            var porMateria = ltsHorarios.GroupBy(x => x.CursoMateriaId);
            foreach (var grupo in porMateria)
            {
                int existentes = grupo.Count(x => x.HorarioId > 0);
                int faltantes = grupo.First().Modulos - existentes;

                for (int i = 0; i < faltantes; i++)
                {
                    ltsHorarios.Add(new HorariosModelo
                    {
                        HorarioId = 0,
                        CursoMateriaId = grupo.Key,
                        MateriaId = grupo.First().MateriaId,
                        Nombre = grupo.First().Nombre,
                        Modulos = grupo.First().Modulos,
                        DiaId = null,
                        ModuloId = null
                    });
                }

                if (existentes == 0)
                {
                    var placeholderOriginal = grupo.FirstOrDefault(x => x.HorarioId == 0);
                    if (placeholderOriginal != null) ltsHorarios.Remove(placeholderOriginal);
                }
            }

            return ltsHorarios;
        }

        public int ActualizarHorarios(IList<HorariosModelo> ltsHorarios)
        {
            int total = 0;
            foreach (HorariosModelo horario in ltsHorarios)
            {
                string dia = (horario.DiaId == null ? "NULL" : horario.DiaId.ToString());
                string modulo = (horario.ModuloId == null ? "NULL" : horario.ModuloId.ToString());

                if (horario.HorarioId > 0)
                {
                    string query = $"UPDATE Horarios SET DiaId= {dia}, ModuloId= {modulo} WHERE HorarioId= {horario.HorarioId}";
                    total += this.Conexion.EjecutarAccion(query);
                }
                else
                {
                    string query = $"INSERT INTO Horarios (CursoMateriaId, DiaId, ModuloId) VALUES ({horario.CursoMateriaId}, {dia}, {modulo}); " +
                                    "SELECT SCOPE_IDENTITY() AS HorarioId;";

                    var fila = this.Conexion.ObtenerRegistro(query);
                    if (fila != null && fila["HorarioId"] != DBNull.Value)
                    {
                        horario.HorarioId = Convert.ToInt32(fila["HorarioId"]);
                        total += 1;
                    }
                }
            }

            return total;
        }
    }
}
