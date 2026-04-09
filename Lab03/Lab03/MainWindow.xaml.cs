using Lab03.Productos;
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

namespace Lab03
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

        private void BtnDataTable_Click(object sender, RoutedEventArgs e)
        {
            VistaDataTable ventana = new VistaDataTable();
            ventana.Show();
        }

        private void BtnDataReader_Click(object sender, RoutedEventArgs e)
        {
            VistaDataReader ventana = new VistaDataReader();
            ventana.Show();
        }

        private void BtnFiltro_Click(object sender, RoutedEventArgs e)
        {
            VistaFiltro ventana = new VistaFiltro();
            ventana.Show();
        }

        private void BtnP1_Click(object sender, RoutedEventArgs e)
        {
            new VistaProductosDataTable().Show();
            this.Close();
        }

        private void BtnP2_Click(object sender, RoutedEventArgs e)
        {
            new VistaProductosDataReader().Show();
            this.Close();
        }

        private void BtnP3_Click(object sender, RoutedEventArgs e)
        {
            new VistaProductosFiltro().Show();
            this.Close();
        }
    }
}