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

namespace Lab03.Productos
{
    /// <summary>
    /// Lógica de interacción para VistaProductosDataTable.xaml
    /// </summary>
    public partial class VistaProductosDataTable : Window
    {
        ProductoDAO dao = new ProductoDAO();

        public VistaProductosDataTable()
        {
            InitializeComponent();
            dgProductos.ItemsSource = dao.ObtenerTodos().DefaultView;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
