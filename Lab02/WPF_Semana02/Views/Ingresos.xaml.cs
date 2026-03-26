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
    /// Lógica de interacción para Ingresos.xaml
    /// </summary>
    public partial class Ingresos : Window
    {
        public Ingresos()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ingreso guardado");
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuOperaciones().Show();
            this.Close();
        }
    }
}
