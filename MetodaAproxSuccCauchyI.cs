using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproxSuccCauchyI : MetodaNumerica
    {
        static int decimale = 14;
        static double eps = 1 / pow(10, decimale);
        static double a = 0, b = 4;
        static double y0 = 0;//[x0,x0 + T]
        static int n = 16;
        static Func<double, double, double> f = (x, y) => 1.0 / (1.0 + pow(x, 2)) - 2.0 * pow(y, 2);// y'(x)
        static Func<double, double> g = (x) => x / (1.0 + pow(x, 2));// f(y) - solutia exacta

        public Method GetMethod() { return Method.AproximatiilorSuccesiveCauchyI; }

        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"n = {n}");
            println($"a = {a} | b = {b} | y0 = {y0}");
            println($"precizie(eps) = {eps}");
            println();
            double[] x = new double[n + 1];
            double[,] y = new double[200, n + 1];
            double h = (b - a) / n;
            for (int i = 0; i <= n; i++)
            {
                x[i] = a + i * h;
                println($"x[{i}] = {x[i]}");
            }
            println();
            for (int i = 0; i <= n; i++)
                y[0, i] = y0;
            y[1, 0] = y0;
            println("m = 1");
            for (int i = 1; i <= n; i++)
            {
                double t = 0;
                for (int j = 1; j <= i; j++)
                    t += f(x[j - 1], y0) + f(x[j], y0);
                double h1 = (b - a) / (2.0 * n);
                y[1, i] = y0 + h1 * t;
                println($" y[1,{i}] = {y0} + {h1} * {t} = {y[1, i]:F20}");
            }
            int m = 1;
            int maxM = 199;
            while (m < maxM)
            {
                bool finished = true;
                for (int i = 1; i <= n; i++)
                {
                    if (abs(y[m, i] - y[m - 1, i]) >= eps)
                    {
                        finished = false;
                        break;
                    }
                }
                if (finished)
                    break;
                println($"m = {m + 1}");
                y[m + 1, 0] = y0;
                for (int i = 1; i <= n; i++)
                {
                    double t = 0;
                    for (int j = 1; j <= i; j++)
                        t += f(x[j - 1], y[m, j - 1]) + f(x[j], y[m, j]);
                    double h1 = (b - a) / (2.0 * n);
                    y[m + 1, i] = y0 + h1 * t;
                    println($" y[{m + 1},{i}] = {y0} + {h1} * {t} = {y[m + 1, i]:F20}");
                }
                m++;
            }
            println();
            println($"Ultima iteratie este {m}");
            for (int i = 0; i <= n; i++)
            {
                println($"y[{m},{i}] = {y[m, i]}");
            }
            println();
            println("Comparam cu solutiile exacte:");
            for (int i = 0; i <= n; i++)
            {
                double yi = g(x[i]);
                println($"y[{i}] = {yi:F20} | Delta = {abs(yi - y[m, i]):F20}");
            }
            DrawChart($"Metoda {GetMethod()}", x, GetRow(y, m));
        }

        static double[] GetRow(double[,] array, int rowIndex)// ChatGPT help :D
        {
            int columns = array.GetLength(1); // Get number of columns
            double[] row = new double[columns];

            for (int col = 0; col < columns; col++)
            {
                row[col] = array[rowIndex, col];
            }

            return row;
        }
    }
}
