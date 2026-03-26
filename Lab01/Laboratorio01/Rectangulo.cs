using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio01
{
    internal class Rectangulo 
    {
        public Punto P1 { get; set; }
        public Punto P2 { get; set; }
        public Punto P3 { get; set; }
        public Punto P4 { get; set; }

        public Rectangulo(Punto p1, Punto p2, Punto p3, Punto p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public double Distancia(Punto a, Punto b)
        {
            return Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2)
            );
        }

        public bool EsRectangulo()
        {
            List<double> d = new List<double>
        {
            Distancia(P1, P2),
            Distancia(P1, P3),
            Distancia(P1, P4),
            Distancia(P2, P3),
            Distancia(P2, P4),
            Distancia(P3, P4)
        };

            d.Sort();

            double eps = 0.0001;

            if (d[0] < eps) return false;

            bool ladosValidos =
                Math.Abs(d[0] - d[1]) < eps &&
                Math.Abs(d[2] - d[3]) < eps &&
                Math.Abs(d[4] - d[5]) < eps;

            if (!ladosValidos) return false;

            return true;
        }

        public (double, double) ObtenerLados()
        {
            List<double> d = new List<double>
        {
            Distancia(P1, P2),
            Distancia(P1, P3),
            Distancia(P1, P4),
            Distancia(P2, P3),
            Distancia(P2, P4),
            Distancia(P3, P4)
        };

            d.Sort();

            return (d[0], d[2]);
        }

        public double CalcularArea()
        {
            if (!EsRectangulo())
                throw new Exception("Los puntos no forman un rectángulo");

            var lados = ObtenerLados();
            return lados.Item1 * lados.Item2;
        }

        public double CalcularPerimetro()
        {
            if (!EsRectangulo())
                throw new Exception("Los puntos no forman un rectángulo");

            var lados = ObtenerLados();
            return 2 * (lados.Item1 + lados.Item2);
        }
    }
}
