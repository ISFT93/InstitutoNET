using ISFDyT93.Datos.Core;
using ISFDyT93.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFDyT93.Datos.Interfaces
{
    public interface IDaoBase
    {
        Conexion Conexion { get; set; }
        string CreateInsertQuery<T>(T model);
        string CreateUpdateQuery<T>(T model);
        string CreateDeleteQuery<T>(T model);
        T MapToModel<T>(DataRow data) where T : new();
        IList<T> MapToModel<T>(DataTable table) where T : ModeloBase, new();
    }
}
