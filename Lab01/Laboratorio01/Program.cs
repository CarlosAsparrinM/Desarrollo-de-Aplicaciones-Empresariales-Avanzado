using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punto p1 = new Punto(0, 0);
            Punto p2 = new Punto(4, 0);
            Punto p3 = new Punto(4, 3);
            Punto p4 = new Punto(0, 3);

            Rectangulo rect = new Rectangulo(p1, p2, p3, p4);

            if (rect.EsRectangulo())
            {
                Console.WriteLine("Área: " + rect.CalcularArea());
                Console.WriteLine("Perímetro: " + rect.CalcularPerimetro());
            }
            else
            {
                Console.WriteLine("❌ No es un rectángulo");
            }
        }
    }
}
