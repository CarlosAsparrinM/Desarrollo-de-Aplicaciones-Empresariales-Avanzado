using System.Windows;

namespace WPF_Semana02.Views
{
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void BtnOperaciones_Click(object sender, RoutedEventArgs e)
        {
            new MenuOperaciones().Show();
            this.Close();
        }
        private void BtnMantenimientos_Click(object sender, RoutedEventArgs e)
        {
            new MenuMantenimientos().Show();
            this.Close();
        }
        private void BtnReportes_Click(object sender, RoutedEventArgs e)
        {
            new Reportes().Show();
            this.Close();
        }
    }
}