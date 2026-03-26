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

namespace WPF_Semana02.Views
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnIngresos_Click(object sender, RoutedEventArgs e)
        {
            new Ingresos().Show();
        }

        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            new Conductores().Show();
        }

        private void BtnListaConductores_Click(object sender, RoutedEventArgs e)
        {
            new ListaConductores().Show();
        }

        private void BtnTransportistas_Click(object sender, RoutedEventArgs e)
        {
            new Transportistas().Show();
        }

        private void BtnCamiones_Click(object sender, RoutedEventArgs e)
        {
            new Camiones().Show();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            new Productos().Show();
        }

        private void BtnReportes_Click(object sender, RoutedEventArgs e)
        {
            new Reportes().Show();
        }
    }
}
