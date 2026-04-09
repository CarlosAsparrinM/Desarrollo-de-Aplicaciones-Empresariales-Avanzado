using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Lab03
{
    public class ProductoDAO
    {
        // 🔹 DataTable
        public DataTable ObtenerTodos()
        {
            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 🔹 DataReader (listar)
        public List<string> Listar()
        {
            List<string> lista = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT id, nombre, cantidad, precio FROM Productos", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(
                        $"ID: {reader["id"]} | " +
                        $"Producto: {reader["nombre"]} | " +
                        $"Stock: {reader["cantidad"]} | " +
                        $"Precio: S/ {reader["precio"]}"
                    );
                }
            }

            return lista;
        }

        // 🔹 DataReader (filtro por rango de precios)
        public List<string> FiltrarPorPrecio(decimal min, decimal max)
        {
            List<string> lista = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT id, nombre, cantidad, precio FROM Productos WHERE precio BETWEEN @min AND @max", conn);

                cmd.Parameters.AddWithValue("@min", min);
                cmd.Parameters.AddWithValue("@max", max);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(
                        $"ID: {reader["id"]} | " +
                        $"Producto: {reader["nombre"]} | " +
                        $"Stock: {reader["cantidad"]} | " +
                        $"Precio: S/ {reader["precio"]}"
                    );
                }
            }

            return lista;
        }
    }
}