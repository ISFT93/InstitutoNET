using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Daos
{
    public class EquivalenciasDao : DaoBase
    {
        public DataTable ObtenerCarreras(int CarreraId)
        {
            var query = $"select C.CarreraId, C.DescripcionCorta from Carreras C where C.CarreraId != {CarreraId}";
            return this.Conexion.ObtenerRegistros(query);
        }
        public DataTable ObtenerMaterias(int CarreraId)
        {
            var query = $"select M.MateriaId, M.Nombre from Materias M " +
                $"inner join AniosCarreras AC on M.AnioCarreraId = AC.AnioCarreraId " +
                $"inner join Carreras C on AC.CarreraId = C.CarreraId " +
                $"where C.CarreraId = {CarreraId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public DataTable ObtenerEquivalencias(int CarreraId, int CarreraEquivalenciaId)
        {
            var query = $"select E.EquivalenciaId, E.MateriaId, E.MateriaEquivalenciaId, " +
                $"concat(C.DescripcionCorta, ' - ', M.Nombre) as [Materia], concat(Ca.DescripcionCorta, ' - ', Mat.Nombre) as [Equivalencia] " +
                $"from Materias M inner join Equivalencias E on E.MateriaId = M.MateriaId " +
                $"inner join Materias Mat on E.MateriaEquivalenciaId = Mat.MateriaId " +
                $"inner join Carreras C on C.CarreraId = E.CarreraId " +
                $"inner join Carreras Ca on Ca.CarreraId = E.CarreraEquivalenciaId " +
                $"where E.CarreraId = {CarreraId} and E.CarreraEquivalenciaId = {CarreraEquivalenciaId} " +
                $"or E.CarreraId = {CarreraEquivalenciaId} and E.CarreraEquivalenciaId = {CarreraId}";
            return this.Conexion.ObtenerRegistros(query);
        }

        public int AsignarEquivalencia(int CarreraId, int MateriaId, int CarreraEquivalenciaId, int MateriaEquivalenciaId)
        {
            var query = $"insert into Equivalencias values ({CarreraId}, {MateriaId}, {CarreraEquivalenciaId}, {MateriaEquivalenciaId})";
            return this.Conexion.EjecutarAccion(query);
        }

        public int EliminarEquivalencia(int EquivalenciaId)
        {
            var query = $"delete from Equivalencias where EquivalenciaId = {EquivalenciaId}";
            return this.Conexion.EjecutarAccion(query);
        }
    }
}
