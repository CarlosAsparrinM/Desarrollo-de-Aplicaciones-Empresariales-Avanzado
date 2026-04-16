using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab04
{
    public partial class ListarProveedores : Window
    {
        string conexion = "Data Source=CARLOS-ASPARRIN\\MSSQLSERVER2017;Initial Catalog=Neptuno;User Id=userNeptuno;Password=123456;TrustServerCertificate=True;";

        public ListarProveedores()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarProveedores", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Proveedor p = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                        NombreContacto = dr["NombreContacto"].ToString(),
                        Ciudad = dr["Ciudad"].ToString()
                    };

                    lista.Add(p);
                }

                dr.Close();
            }

            dgProveedores.ItemsSource = lista;
        }
        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}
