using Entidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCategory
    {
        string connectionString = "Data Source=HUGO\\SQLEXPRESS02;Initial Catalog=StoreDB;Integrated Security=True;TrustServerCertificate=True";

        public List<Category> Get()
        {
            List<Category> lista = new List<Category>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_SelCategories", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Category
                        {
                            IdCategory = Convert.ToInt32(dr["CategoryId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
        public void Insert()
        {
        }
        public void Update()
        {
        }
        public void Delete()
        {
        }
    }
}