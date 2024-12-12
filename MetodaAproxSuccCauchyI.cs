using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproxSuccCauchyI : MetodaNumerica
    {
        static int decimale = 14;
        static double eps = 1 / pow(10, decimale);
        static double a = 0, b = 1;
        static double y0 = 1;//[x0,x0 + T]
        static int n = 10;
        static Func<double, double, double> f = (x, y) => y + x;// y'(x)
        static Func<double, double> g = (x) => 2 * pow(Math.E, x) - x - 1;// f(y) - solutia exacta

        public Method GetMethod() { return Method.AproximatiilorSuccesiveCauchyI; }

        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precizie(eps) = {eps}");
            println();
            double[] x = new double[n + 2];
            double[,] y = new double[200, n + 2];
            double h = (b - a) / n;
            for (int i = 1; i <= n; i++)
                x[i] = a + i * h;
            for (int i = 0; i <= n; i++)
                y[0, i] = y0;
            y[1, 0] = y0;
            for (int i = 0; i <= n; i++)
            {
                double t1 = y0 + (b - a) / (2 * n);
                double t2 = 0;
                for (int j = 1; j <= i; j++)
                {
                    t2 += f(x[j - 1], y0) + f(x[j], y0);
                }
                y[1, i] = t1 + t2;
            }
            int m = 1;
            while (true)
            {
                double delta = 0;
                for (int i = 1; i < n; ++i)
                    delta = max(delta, abs(y[m, i] - y[m - 1, i]));
                if (delta < eps)
                    break;
                y[m + 1, 0] = y0;
                for (int i = 1; i <= n; i++)
                {
                    double t1 = (b - a) / (2 * n);
                    double t2 = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        t2 += f(x[j - 1], y[m, j - 1]) + f(x[j], y[m, j]);
                    }
                    y[m + 1, i] = y0 + t1 * t2;
                }
                m++;
            }
            println($"Ultima iteratie este {m}");
            for (int i = 0; i <= n; i++)
            {
                println($"y[{m},{i}] = {y[m, i]}");
            }
        }
    }
}
