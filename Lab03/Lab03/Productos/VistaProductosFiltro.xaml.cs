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
    /// Lógica de interacción para VistaProductosFiltro.xaml
    /// </summary>
    public partial class VistaProductosFiltro : Window
    {
        ProductoDAO dao = new ProductoDAO();

        public VistaProductosFiltro()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            lstResultado.Items.Clear();

            decimal min = decimal.Parse(txtMin.Text);
            decimal max = decimal.Parse(txtMax.Text);

            foreach (var item in dao.FiltrarPorPrecio(min, max))
            {
                lstResultado.Items.Add(item);
            }
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
