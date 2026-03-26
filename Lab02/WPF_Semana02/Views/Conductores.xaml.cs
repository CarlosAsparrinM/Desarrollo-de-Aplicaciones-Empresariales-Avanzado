using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Semana02.Models;

namespace WPF_Semana02.Views
{
    /// <summary>
    /// Lógica de interacción para Conductores.xaml
    /// </summary>
    public partial class Conductores : Window
    {
        public static List<Conductor> lista = new List<Conductor>();

        public Conductores()
        {
            InitializeComponent();
            dgConductores.ItemsSource = null;
            dgConductores.ItemsSource = lista;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            lista.Add(new Conductor
            {
                Nombre = txtNombre.Text,
                Licencia = txtLicencia.Text,
                Transporte = txtTransporte.Text
            });

            dgConductores.ItemsSource = null;
            dgConductores.ItemsSource = lista;

            MessageBox.Show("Registrado");
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuMantenimientos().Show();
            this.Close();
        }
    }
}
