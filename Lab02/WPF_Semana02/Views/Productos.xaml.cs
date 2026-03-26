using System.Windows;
using System.Collections.Generic;

namespace WPF_Semana02.Views
{
    public partial class Productos : Window
    {
        public static List<Producto> lista = new List<Producto>();
        public Productos()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            new MenuMantenimientos().Show();
            this.Close();
        }
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            lista.Add(new Producto
            {
                Nombre = txtNombre.Text,
                Codigo = txtCodigo.Text,
                Descripcion = txtDescripcion.Text
            });
            MessageBox.Show("Producto registrado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    public class Producto
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}