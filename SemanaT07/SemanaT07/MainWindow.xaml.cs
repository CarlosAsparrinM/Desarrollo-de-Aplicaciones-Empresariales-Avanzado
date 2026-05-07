using Service;
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
using System.Xml.Linq;

namespace SemanaT07
{
    public partial class MainWindow : Window
    {
        
        SProduct service = new SProduct();

        public MainWindow()
        {
            InitializeComponent();

            dgProducts.ItemsSource = service.GetProducts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource =
                service.SearchProducts(txtName.Text);
        }
    }

}