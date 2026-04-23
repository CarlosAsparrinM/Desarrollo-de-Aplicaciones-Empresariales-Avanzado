using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Lab06
{
    public class Conexion
    {
        private static string cadena =
            "Data Source=CARLOS-ASPARRIN\\MSSQLSERVER2017;" +
            "Initial Catalog=Neptuno06DB;" +
            "User ID=userHugo;" +
            "Password=123456;" +
            "TrustServerCertificate=True;";


        public static SqlConnection GetConexion()
        {
            return new SqlConnection(cadena);
        }

        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection con = GetConexion())
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
