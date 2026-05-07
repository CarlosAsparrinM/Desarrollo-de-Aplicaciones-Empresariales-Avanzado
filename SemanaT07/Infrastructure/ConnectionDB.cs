using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ConnectionDB
    {
        private static string connectionString =
            "Data Source=CARLOS-ASPARRIN\\MSSQLSERVER2017;" +
            "Initial Catalog=Semana07;" +
            "User ID=userHugo;" +
            "Password=123456;" +
            "TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
