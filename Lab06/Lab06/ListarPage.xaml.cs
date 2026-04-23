using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Lab06
{
    public partial class ListarPage : Page
    {
        public ListarPage()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection con = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente c = new Cliente();

                    c.IdCliente = dr["idCliente"].ToString();
                    c.NombreCompañia = dr["NombreCompañia"].ToString();
                    c.NombreContacto = dr["NombreContacto"].ToString();
                    c.CargoContacto = dr["CargoContacto"].ToString();
                    c.Direccion = dr["Direccion"].ToString();
                    c.Ciudad = dr["Ciudad"].ToString();
                    c.Region = dr["Region"].ToString();
                    c.CodPostal = dr["CodPostal"].ToString();
                    c.Pais = dr["Pais"].ToString();
                    c.Telefono = dr["Telefono"].ToString();
                    c.Fax = dr["Fax"].ToString();

                    lista.Add(c);
                }
            }

            dgClientes.ItemsSource = lista;
        }

        private void dgClientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Activo")
            {
                e.Cancel = true;
            }
        }
    }
}