using ISFDyT93.Datos.Core.Attributes;
using System;
using System.Linq;
using System.Data;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using System.Collections.Generic;

namespace ISFDyT93.Datos.Core
{
    public class DaoBase
    {
        protected Conexion Conexion { get; set; }

        public DaoBase()
        {
            this.Conexion = new Conexion();
        }

        public string CreateInsertQuery<T>(T model)
        {
            Type type = typeof(T);

            string name = type.Name.Substring(0, type.Name.IndexOf("Modelo"));

            string query_1 = "";
            string query_2 = "";

            var propiedades = type.GetProperties();

            foreach (var propiedad in propiedades)
            {
                var atributos = propiedad.GetCustomAttributes(true)
                    .Where(a => a.GetType() == typeof(Clave) || a.GetType() == typeof(Ignorar))
                    .ToList();

                var clave = (Clave) atributos.Where(a => a.GetType() == typeof(Clave)).SingleOrDefault();

                if (atributos.Count == 0 || (clave != null && clave.AutoIncremental == false))
                {
                    query_1 += propiedad.Name + ", ";
                    query_2 += this.GetValue(propiedad.GetValue(model));
                }
            }

            query_1 = query_1.Length > 0 ? query_1.Substring(0, query_1.Length - 2) : "";
            query_2 = query_2.Length > 0 ? query_2.Substring(0, query_2.Length - 2) : "";

            string query = $"INSERT INTO {name} ( {query_1} ) VALUES ({query_2})";

            return query;
        }

        public string CreateUpdateQuery<T>(T model)
        {
            Type type = typeof(T);

            string name = type.Name.Substring(0, type.Name.IndexOf("Modelo"));

            string query_1 = "";
            string query_2 = "";

            var propiedades = type.GetProperties();

            foreach (var propiedad in propiedades)
            {
                var atributos = propiedad.GetCustomAttributes(true);
                var propiedadAnterior = "";

                if (atributos.Length > 0)
                {
                    foreach (var atributo in atributos)
                    {
                        if (propiedadAnterior == propiedad.Name)
                        {
                            break;
                        }

                        Ignorar ignorar = atributo as Ignorar;
                        Clave clave = atributo as Clave;

                        if (clave != null)
                        {
                            if (query_2.Length > 0)
                            {
                                query_2 += " AND ";
                            }

                            query_2 += propiedad.Name + " = " + this.GetValue(propiedad.GetValue(model));
                        }
                        else if (ignorar == null)
                        {
                            query_1 += propiedad.Name + " = " + this.GetValue(propiedad.GetValue(model));
                        }

                        propiedadAnterior = propiedad.Name;
                    }
                }
                else
                {
                    if (propiedad.GetValue(model) == null)
                    {
                        query_1 += propiedad.Name + " = NULL, ";
                    }
                    else
                    {
                        query_1 += propiedad.Name + " = " + this.GetValue(propiedad.GetValue(model));
                    }
                }
            }

            query_1 = query_1.Length > 0 ? query_1.Substring(0, query_1.Length - 2) : "";
            query_2 = query_2.Length > 0 ? query_2.Substring(0, query_2.Length - 2) : "";

            string query = $"UPDATE {name} SET {query_1} WHERE {query_2}";

            return query;
        }

        public string CreateDeleteQuery<T>(T model)
        {
            Type type = typeof(T);

            string name = type.Name.Substring(0, type.Name.IndexOf("Modelo"));

            string query_1 = "";

            var propiedades = type.GetProperties();

            foreach (var propiedad in propiedades)
            {
                var atributos = propiedad.GetCustomAttributes(true);

                foreach (var atributo in atributos)
                {
                    Clave clave = atributo as Clave;

                    if (clave != null)
                    {
                        if (query_1.Length > 0)
                        {
                            query_1 += " AND ";
                        }

                        query_1 += propiedad.Name + " = " + propiedad.GetValue(model);
                    }
                }
            }

            query_1 = query_1.Length > 0 ? query_1 : "";

            string query = $"DELETE {name} WHERE {query_1}";

            return query;
        }

        public T MapToModel<T>(DataRow data) where T : new()
        {
            if (data == null) return default(T);

            var type = typeof(T);
            var properties = type.GetProperties();
            var columns = data.Table.Columns;
            var result = new T();

            foreach (var property in properties)
            {
                if (columns.Contains(property.Name))
                {
                    var value = data[property.Name];

                    if (value != DBNull.Value)
                    {
                        if (property.PropertyType == typeof(Int64))
                        {
                            long int64Value = 0;
                            Int64.TryParse(value.ToString(), out int64Value);
                            value = int64Value;
                        }
                        else if (property.PropertyType == typeof(Int32))
                        {
                            int int32Value = 0;
                            Int32.TryParse(value.ToString(), out int32Value);
                            value = int32Value;
                        }
                        else if (property.PropertyType == typeof(Int16))
                        {
                            short int16Value = 0;
                            Int16.TryParse(value.ToString(), out int16Value);
                            value = int16Value;
                        }
                        else if (property.PropertyType == typeof(Decimal))
                        {
                            decimal decimalValue = 0;
                            Decimal.TryParse(value.ToString(), out decimalValue);
                            value = decimalValue;
                        }
                        else if (property.PropertyType == typeof(Double))
                        {
                            double doubleValue = 0;
                            Double.TryParse(value.ToString(), out doubleValue);
                            value = doubleValue;
                        }
                        else if (property.PropertyType == typeof(Single))
                        {
                            float floatValue = 0;
                            Single.TryParse(value.ToString(), out floatValue);
                            value = floatValue;
                        }
                        else if (property.PropertyType == typeof(Char))
                        {
                            string stringValue = value.ToString();

                            if (!string.IsNullOrEmpty(stringValue))
                            {
                                value = stringValue[0];
                            }
                            else
                            {
                                value = (char)1;
                            }
                        }
                        else if (property.PropertyType == typeof(String))
                        {
                            if (string.IsNullOrEmpty(value as string))
                            {
                                value = null;
                            }
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {

                            if (value.GetType() != typeof(DateTime))
                            {
                                var dateValue = DateTime.MinValue;
                                DateTime.TryParse(value as string, out dateValue);
                                value = dateValue;
                            }
                        }
                        else if (property.PropertyType == typeof(Boolean))
                        {
                            if (value.GetType() != typeof(Boolean))
                            {
                                value = value.ToString() == "1";
                            }
                        }

                        property.SetValue(result, value);
                    }
                }
            }

            return result;
        }
   
        public IList<T> MapToModel<T>(DataTable table) where T : ModeloBase, new()
        {
            if (table == null) return null;

            var result = new List<T>();

            for(int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                var model = this.MapToModel<T>(row);

                result.Add(model);
            }

            return result;
        }

        private string GetValue(object value)
        {
            string result = "";

            if(value == null)
            {
                result = "NULL, ";
            }
            else if(value.GetType() == typeof(string))
            {
                result = "'" + value.ToString() + "', ";
            }
            else if (value.GetType() == typeof(char))
            {
                result = "'" + value.ToString() + "', ";
            }
            else if(value.GetType() == typeof(DateTime))
            {
                DateTime? date = value as DateTime?;

                result = "'" + date.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
            } 
            else if (value.GetType() == typeof(bool))
            {
                bool? boolean = value as bool?;
                result = (boolean.Value ? "1" : "0") + ", ";
            }
            else
            {
                result = value.ToString() + ", ";
            }

            return result;
        }
    }
}
