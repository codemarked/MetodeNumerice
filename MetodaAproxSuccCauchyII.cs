using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproxSuccCauchyII : MetodaNumerica
    {
        static int decimale = 14;
        static double eps = 1 / pow(10, decimale);
        static double a = 0, b = 1;
        static double y0 = 1,dy0 = 1;
        static int n = 10;
        static Func<double, double, double> f = (x, y) => 2.0 / 3.0 * pow(Math.E, x) + 1.0 / 3.0 * y;// y'(x)
        static Func<double, double> g = (x) => pow(Math.E, x);// f(y) - solutia exacta

        public Method GetMethod() { return Method.AproximatiilorSuccesiveCauchyII; }

        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"n = {n}");
            println($"a = {a} | b = {b} | y0  = {y0} | dy0 = {dy0}");
            println($"precizie(eps) = {eps}");
            println();
            double[] x = new double[n + 1];
            int maxM = 999;
            double[,] y = new double[maxM + 1, n + 1];
            double h = (b - a) / n;
            for (int i = 0; i <= n; i++)
                x[i] = a + i * h;
            for (int i = 0; i <= n; i++)
                y[0, i] = y0 + (x[i] - x[0]) * dy0;
            int m = 1;
            while (m < maxM)
            {
                println($"m = {m}");
                y[m, 0] = y0;
                for (int i = 1; i <= n; i++)
                {
                    double t = 0;
                    for (int j = 1; j <= i; j++)
                        t += (x[i] - x[j - 1]) * f(x[j - 1], y[m - 1, j - 1]) +
                            (x[i] - x[j]) * f(x[j], y[m - 1, j]);
                    y[m, i] = y[0, i] + h / 2.0 * t;
                    println($"  y[{m},{i}] = {y[0, i]} + {h} / 2 * {t} = {y[m, i]:F20}");
                }
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
