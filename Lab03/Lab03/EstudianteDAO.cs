using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lab03
{
    public class EstudianteDAO
    {
        // 🔹 DataTable
        public DataTable ObtenerTodos()
        {
            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Estudiantes", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 🔹 DataReader (listar todo)
        public List<string> Listar()
        {
            List<string> lista = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT id, nombres, apellidos, telefono FROM Estudiantes", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(
                        $"ID: {reader["id"]} | " +
                        $"Nombre: {reader["nombres"]} {reader["apellidos"]} | " +
                        $"Tel: {reader["telefono"]}"
                    );
                }
            }

            return lista;
        }

        // 🔹 DataReader (con filtro)
        public List<string> BuscarPorNombre(string nombre)
        {
            List<string> lista = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT id, nombres, apellidos, telefono FROM Estudiantes WHERE nombres LIKE @nombre", conn);

                cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(
                        $"ID: {reader["id"]} | " +
                        $"Nombre: {reader["nombres"]} {reader["apellidos"]} | " +
                        $"Tel: {reader["telefono"]}"
                    );
                }
            }

            return lista;
        }
    }
}