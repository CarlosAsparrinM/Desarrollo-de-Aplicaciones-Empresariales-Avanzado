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
    /// Lógica de interacción para VistaProductosDataReader.xaml
    /// </summary>
    public partial class VistaProductosDataReader : Window
    {
        ProductoDAO dao = new ProductoDAO();

        public VistaProductosDataReader()
        {
            InitializeComponent();

            foreach (var item in dao.Listar())
            {
                lstProductos.Items.Add(item);
            }
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
