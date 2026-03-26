using System.Windows;
using System.Collections.Generic;

namespace WPF_Semana02.Views
{
    public partial class Reportes : Window
    {
        public Reportes()
        {
            InitializeComponent();
            // Ejemplo de datos temporales
            dgCargas.ItemsSource = new List<dynamic> {
                new { Codigo = "C001", Producto = "Arena", Peso = 1000 },
                new { Codigo = "C002", Producto = "Cemento", Peso = 800 }
            };
            dgIngresos.ItemsSource = new List<dynamic> {
                new { Documento = "F001", Cliente = "Juan", Fecha = "2024-01-01" },
                new { Documento = "F002", Cliente = "Ana", Fecha = "2024-01-02" }
            };
            dgSalidas.ItemsSource = new List<dynamic> {
                new { Documento = "S001", Destino = "Obra1", Fecha = "2024-01-03" },
                new { Documento = "S002", Destino = "Obra2", Fecha = "2024-01-04" }
            };
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuPrincipal().Show();
            this.Close();
        }
    }
}