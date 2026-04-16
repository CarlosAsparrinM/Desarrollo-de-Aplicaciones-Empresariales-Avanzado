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

namespace Lab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarProveedores ventana = new ListarProveedores();
            ventana.Show();
            this.Hide(); // ocultar menú
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarProveedores ventana = new BuscarProveedores();
            ventana.Show();
            this.Hide(); // ocultar menú
        }
    }
}