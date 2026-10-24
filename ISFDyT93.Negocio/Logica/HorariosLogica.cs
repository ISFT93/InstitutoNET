
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ISFDyT93.Datos.Daos;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Core;
using ISFDyT93.Negocio.Interfaces;

namespace ISFDyT93.Negocio.Logica
{
    public class HorariosLogica : LogicaBase, IHorariosLogica
    {
        HorariosDao horariosDao = new HorariosDao();

        public DataTable ObtnerModulos()
        {
            return horariosDao.ObtnerModulos();
        }

        public IList<HorariosModelo> ObtenerHorarios(int cursoId)
        {
            return horariosDao.ObtenerHorarios(cursoId);
        }

        public int ActualizarHorarios(IList<HorariosModelo> ltsHorarios)
        {
            return horariosDao.ActualizarHorarios(ltsHorarios);
        }

        public DataTable ObtenerModulosPorTurno(string turno)
        {
            return horariosDao.ObtenerModulosPorTurno(turno);
        }

        public DataTable ObtenerTurnosDisponibles()
        {
            return horariosDao.ObtenerTurnosDisponibles();
        }

        public DataTable ObtenerTurnosConDetalleOrdenados()
        {
            DataTable dtOriginal = horariosDao.ObtenerTurnosDisponibles();

            if (dtOriginal == null || dtOriginal.Rows.Count == 0)
                return dtOriginal;

            DataTable dtOrdenado = new DataTable();
            dtOrdenado.Columns.Add("ModuloId", typeof(int));
            dtOrdenado.Columns.Add("Turno", typeof(string));
            dtOrdenado.Columns.Add("horario", typeof(string));
            dtOrdenado.Columns.Add("Activo", typeof(bool));

            var query = dtOriginal.AsEnumerable()
                .OrderByDescending(r => Convert.ToBoolean(r["Activo"])) 
                .ThenBy(r => r.Field<string>("Turno"))                 
                .ThenBy(r => r.Field<string>("Descripcion"));          

            foreach (var row in query)
            {
                dtOrdenado.Rows.Add(
                    row["ModuloId"],
                    row["Turno"],
                    row["Descripcion"],
                    row["Activo"]
                );
            }

            return dtOrdenado;
        }
        public bool ActualizarEstadoModulo(int moduloId, bool activo)
        {
            int resultado = horariosDao.ActualizarEstadoModulo(moduloId, activo);
            return resultado > 0;
        }

        public DataTable ObtenerTurnosUnicos()
        {
            DataTable dtOriginal = horariosDao.ObtenerTurnosDisponibles();

            if (dtOriginal == null || dtOriginal.Rows.Count == 0)
                return new DataTable();

            DataTable dtUnicos = dtOriginal.Clone();

            var turnosFiltrados = dtOriginal.AsEnumerable()
                .Where(r => r.Field<string>("Turno") != null)
                .GroupBy(r => r.Field<string>("Turno").Trim())
                .Select(g => g.First());

            foreach (var row in turnosFiltrados)
            {
                dtUnicos.ImportRow(row);
            }

            return dtUnicos;
        }
        public bool InsertarTurno(string turno)
        {
            if (string.IsNullOrWhiteSpace(turno))
                return false;

            int resultado = horariosDao.InsertarTurnoNuevo(turno.Trim());
            return resultado > 0;
        }

        public bool InsertarModulo(string turno, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(turno) || string.IsNullOrWhiteSpace(descripcion))
                return false;

            int resultado = horariosDao.InsertarModulo(turno.Trim(), descripcion.Trim());
            return resultado > 0;
        }
        public bool ActualizarEstadoPorTurno(string turno, bool activo)
        {
            int resultado = horariosDao.ActualizarEstadoPorTurno(turno, activo);
            return resultado > 0;
        }
    }
}