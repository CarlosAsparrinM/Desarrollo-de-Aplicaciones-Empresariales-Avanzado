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

namespace Lab03
{
    public partial class VistaDataReader : Window
    {
        EstudianteDAO dao = new EstudianteDAO();

        public VistaDataReader()
        {
            InitializeComponent();

            foreach (var item in dao.Listar())
            {
                lstEstudiantes.Items.Add(item);
            }
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}