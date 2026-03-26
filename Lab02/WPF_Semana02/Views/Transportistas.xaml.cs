using System.Windows;
using System.Collections.Generic;

namespace WPF_Semana02.Views
{
    public partial class Transportistas : Window
    {
        public static List<Transportista> lista = new List<Transportista>();
        public Transportistas()
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
            lista.Add(new Transportista
            {
                Nombre = txtNombre.Text,
                RUC = txtRUC.Text,
                Empresa = txtEmpresa.Text
            });
            MessageBox.Show("Transportista registrado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    public class Transportista
    {
        public string Nombre { get; set; }
        public string RUC { get; set; }
        public string Empresa { get; set; }
    }
}