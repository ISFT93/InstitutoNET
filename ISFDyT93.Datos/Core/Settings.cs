using System;

namespace ISFDyT93.Datos.Core
{
    internal static class Settings
    {
        public static string STRCONNECTION
        {
            get
            {
                string connStr = Environment.GetEnvironmentVariable("INSTITUTO_DB_CONNECTION_STRING");
                if (string.IsNullOrWhiteSpace(connStr))
                    throw new InvalidOperationException(
                        "La variable de entorno INSTITUTO_DB_CONNECTION_STRING no está definida.");
                return connStr;
            }
        }
    }
}
