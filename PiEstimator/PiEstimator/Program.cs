using System;
using System.Drawing;

namespace PiEstimator
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            
            Console.WriteLine("Pi Estimator");
            Console.WriteLine("================================================");

            n = GetNumber("Enter number of iterations (n): ");

            double pi = EstimatePi(n);
            double diff = Math.Abs(pi - Math.PI);

            Console.WriteLine();
            Console.WriteLine($"Pi (estimate): {pi}, Pi (system): {Math.PI}, Difference: {diff}");
        }

        static double EstimatePi(long n)
        {
            Random rand = new Random(System.Environment.TickCount);
            double pi = 0.0;

            // TODO: Calculate Pi

            PointD point;
            double radius;
            double ratio = 0;
            double hits = 0;

            for (int i = 0; i < n; i++)
            {
                point = new PointD(rand.NextDouble(), rand.NextDouble());
                radius = point.GetRadius();

                if (radius < 1)
                {
                    hits++;
                }
            }
            
            ratio = hits / n;
            pi = ratio * 4;
            
            return pi;
        }

        static long GetNumber(string prompt)
        {
            long output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Int64.TryParse(input, out output))
                {
                    return output;
                }
            }
        }
    }

    struct PointD
    {
        public double x;
        public double y;

        public PointD(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetRadius()
        {
            double xPow = x * x;
            double yPow = y * y;

            return Math.Sqrt(xPow + yPow);
        }
    }
}