using System.Windows;

namespace WPF_Semana02.Views
{
    public partial class MenuMantenimientos : Window
    {
        public MenuMantenimientos()
        {
            InitializeComponent();
        }
        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            new Conductores().Show();
            this.Close();
        }
        private void BtnTransportistas_Click(object sender, RoutedEventArgs e)
        {
            new Transportistas().Show();
            this.Close();
        }
        private void BtnCamiones_Click(object sender, RoutedEventArgs e)
        {
            new Camiones().Show();
            this.Close();
        }
        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            new Productos().Show();
            this.Close();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuPrincipal().Show();
            this.Close();
        }
    }
}