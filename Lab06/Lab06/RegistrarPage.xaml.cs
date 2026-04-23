using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Lab06
{
    public partial class RegistrarPage : Page
    {
        public RegistrarPage()
        {
            InitializeComponent();
            ListarMini();
        }

        // =========================
        // 🔹 REGISTRAR CLIENTE
        // =========================
        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtCompania.Text) ||
                string.IsNullOrWhiteSpace(txtContacto.Text) ||
                string.IsNullOrWhiteSpace(txtCargo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtRegion.Text) ||
                string.IsNullOrWhiteSpace(txtPostal.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtFax.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos para ingresar un cliente");
                return;
            }

            using (SqlConnection con = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", txtId.Text);
                cmd.Parameters.AddWithValue("@NombreCompañia", txtCompania.Text);
                cmd.Parameters.AddWithValue("@NombreContacto", txtContacto.Text);
                cmd.Parameters.AddWithValue("@CargoContacto", txtCargo.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                cmd.Parameters.AddWithValue("@CodPostal", txtPostal.Text);
                cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cliente registrado");

            LimpiarCampos();
            ListarMini();
        }

        // =========================
        // 🔹 LISTAR CLIENTES
        // =========================
        private void ListarMini()
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
                    Cliente c = new Cliente
                    {
                        IdCliente = dr["idCliente"].ToString(),
                        NombreCompañia = dr["NombreCompañia"].ToString(),
                        NombreContacto = dr["NombreContacto"].ToString(),
                        CargoContacto = dr["CargoContacto"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Ciudad = dr["Ciudad"].ToString(),
                        Region = dr["Region"].ToString(),
                        CodPostal = dr["CodPostal"].ToString(),
                        Pais = dr["Pais"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Fax = dr["Fax"].ToString()
                    };

                    lista.Add(c);
                }
            }

            dgMini.ItemsSource = lista;
        }

        // =========================
        // 🔹 LIMPIAR CAMPOS
        // =========================
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtCompania.Clear();
            txtContacto.Clear();
            txtCargo.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtRegion.Clear();
            txtPostal.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtFax.Clear();
        }

        // =========================
        // 🔹 OCULTAR COLUMNAS
        // =========================
        private void dgMini_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Activo")
            {
                e.Cancel = true;
            }
        }

        // =========================
        // 🔹 MOSTRAR BOTÓN ELIMINAR
        // =========================
        private void dgMini_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.Visibility =
                dgMini.SelectedItem != null
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        // =========================
        // 🔹 ELIMINAR CLIENTE (SOFT DELETE)
        // =========================
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgMini.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            Cliente cliente = (Cliente)dgMini.SelectedItem;

            using (SqlConnection con = Conexion.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cliente eliminado (desactivado)");

            btnEliminar.Visibility = Visibility.Collapsed;
            ListarMini();
        }
    }
}