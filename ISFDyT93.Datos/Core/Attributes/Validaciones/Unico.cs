using ISFDyT93.Datos.Modelos;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ISFDyT93.Datos.Core.Attributes.Validaciones
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class Unico : Validacion
    {
        private string PropertyName { get; set; }
        private string Condicion { get; set; }
        private Conexion Conexion;

        public Unico([CallerMemberName] string propertyName = null, string mensaje = "Ya existe este valor") : base(mensaje)
        {
            Metodo += InnerValidar;

            this.PropertyName = propertyName;
            this.Conexion = new Conexion();
        }

        public Unico(string condicion, [CallerMemberName] string propertyName = null, string mensaje = "Ya existe este valor") : base(mensaje)
        {
            Metodo += InnerValidar;

            this.PropertyName = propertyName;
            this.Condicion = condicion;
            this.Conexion = new Conexion();
        }

        public bool InnerValidar(object value, ModeloBase modelo)
        {
            Type type = modelo.GetType();

            if (!string.IsNullOrEmpty(this.Condicion))
            {
                var metodo = type.GetMethod(Condicion);

                bool result = (bool)metodo.Invoke(modelo, null);

                if (result == false)
                {
                    return true;
                }
            }

            string table = type.Name.Substring(0, type.Name.IndexOf("Modelo"));
            string query = null;

           // if (modelo.Modificando())
            {
                var clave = type.GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(Clave)))
                    .FirstOrDefault();

                if (clave != null)
                {
                    if (int.TryParse(clave.GetValue(modelo)?.ToString(), out int valorClave))
                    {
                        if (valorClave > 0)
                        {
                            query = $"SELECT TOP 1 { this.PropertyName } FROM { table } WHERE { this.PropertyName } = '{ value }' AND { clave.Name } != { valorClave }";
                        }
                    }
                }
            }
          //  else
            {
                query = $"SELECT TOP 1 { this.PropertyName } FROM { table } WHERE { this.PropertyName } = '{ value.ToString() }'";
            }


            var resultado = this.Conexion.ObtenerRegistro(query);

            return resultado == null;
        }
    }
}
