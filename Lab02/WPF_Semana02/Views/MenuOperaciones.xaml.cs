using System.Windows;

namespace WPF_Semana02.Views
{
    public partial class MenuOperaciones : Window
    {
        public MenuOperaciones()
        {
            InitializeComponent();
        }
        private void BtnIngresos_Click(object sender, RoutedEventArgs e)
        {
            new Ingresos().Show();
            this.Close();
        }
        private void BtnSalidas_Click(object sender, RoutedEventArgs e)
        {
            // Aquí puedes crear la ventana de Salidas si la implementas
            MessageBox.Show("Funcionalidad de Salidas no implementada");
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuPrincipal().Show();
            this.Close();
        }
    }
}