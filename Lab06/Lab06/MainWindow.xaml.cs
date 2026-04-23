using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab06
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            frameContenido.Navigate(new ListarPage());
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            frameContenido.Navigate(new RegistrarPage());
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            frameContenido.Content = null; // limpia vista
        }
    }
}