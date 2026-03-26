using System.Windows;
using System.Collections.Generic;

namespace WPF_Semana02.Views
{
    public partial class Camiones : Window
    {
        public static List<Camion> lista = new List<Camion>();
        public Camiones()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuMantenimientos().Show();
            this.Close();
        }
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            lista.Add(new Camion
            {
                Placa = txtPlaca.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text
            });
            MessageBox.Show("Camión registrado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    public class Camion
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}