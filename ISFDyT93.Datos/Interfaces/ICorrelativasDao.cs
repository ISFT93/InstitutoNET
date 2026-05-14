using ISFDyT93.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface ICorrelativasDao
    {
        int CorrelativaExisteCarrera(int CarreraId);
        DataTable ObtenerCorrelatividades(int IdMateria, int IdCarrera);
        DataTable ObtenerMateriasCorrelativas(int MateriaId);
        int AgregarCorrelativa(int IdMateria, int IdCorrelativa);
        int GuardarCorrelatividades(IList<CorrelatividadModel> correlativas);
        int EliminarCorrelativa(int CorrelativaId);
        int EliminarCorrelativas(int IdMateria);
        DataTable Correlativaid(int CarreraId);
        DataTable ObtenerCorrelativasAnio(int AnioCarreraId);
        DataTable ObtenerCorrelativasCarrera(int CarreraId);
    }
}
