using Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure
{
    public class IProduct
    {
        public readonly ConnectionDB connectionDB = new ConnectionDB();

        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = connectionDB.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("ListProducts", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                    };

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
