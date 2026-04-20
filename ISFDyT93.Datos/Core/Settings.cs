using System;

namespace ISFDyT93.Datos.Core
{
    internal static class Settings
    {
        public static string STRCONNECTION
        {
            get
            {
                string connStr = @"Data Source=DESKTOP-7NSE6PJ;Initial Catalog=instituto_db;Integrated Security=True;"; if (string.IsNullOrWhiteSpace(connStr))
                    throw new InvalidOperationException(
                        "La variable de entorno INSTITUTO_DB_CONNECTION_STRING no está definida.");
                return connStr;
            }
        }
    }
}
