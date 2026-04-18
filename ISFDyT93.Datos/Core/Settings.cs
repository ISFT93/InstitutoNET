using System;

namespace ISFDyT93.Datos.Core
{
    internal static class Settings
    {
        public static string STRCONNECTION
        {
            get
            {
                string connStr = @"Data Source=DILANPC-1;Initial Catalog=instituto_db;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name='SQL Server Management Studio';";
                if (string.IsNullOrWhiteSpace(connStr))
                    throw new InvalidOperationException(
                        "La variable de entorno INSTITUTO_DB_CONNECTION_STRING no está definida.");
                return connStr;
            }
        }
    }
}
