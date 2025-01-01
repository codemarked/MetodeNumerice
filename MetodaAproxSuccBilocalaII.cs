using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproxSuccBilocalaII : MetodaNumerica
    {
        static int decimale = 14;
        static double eps = 1 / pow(10, decimale);
        static double a = 0, alfa = 1;
        static double b = /*1*/Math.PI / 4, beta = /*Math.E*/sqrt(2) / 2;
        static int n = 10;
        static Func<double, double, double> f = (t, x) => -1 / 2.0 * cos(t) - 1 / 2.0 * x /*2 / 3.0 * Math.Pow(Math.E, t) + 1 / 3.0 * x*/;
        static Func<double, double> g = (t) => cos(t)/*Math.Pow(Math.E, t)*/;

        public Method GetMethod() { return Method.AproximatiilorSuccesiveBilocalaII; }

        public void Run()
        {
            println();
            double[] t = new double[n + 1];
            for (int i = 1; i <= n; i++)
                t[i] = a + i * (b - a) / n;
            double[,] x = new double[200, n + 1];
            for (int i = 0; i <= n; i++)
                x[0, i] = (t[i] - a) / (b - a) * beta + (b - t[i]) / (b - a) * alfa;
            int m = 1;
            while (true)
            {
                double delta = 0;
                for (int i = 1; i < n; ++i)
                    delta = max(delta, abs(x[m, i] - x[m - 1, i]));
                if (delta < eps)
                    break;
                x[m + 1, 0] = alfa;
                x[m + 1, n] = beta;
                for (int i = 1; i < n; i++)
                {
                    double t1 = (t[i] - a) / (b - a) * beta + (b - t[i]) / (b - a) * alfa;
                    double t2 = 0;
                    for (int j = 1; j <= i; j++)
                        t2 += (t[j - 1] - a) * (b - t[i]) / (b - a) * f(t[j - 1], x[m, j - 1]) +
                            (t[j] - a) * (b - t[i]) / (b - a) * f(t[j], x[m, j]);
                    double t3 = 0;
                    for (int j = i + 1; j <= n; j++)
                        t3 += (t[i] - a) * (b - t[j - 1]) / (b - a) * f(t[j - 1], x[m, j - 1]) +
                            (t[i] - a) * (b - t[j]) / (b - a) * f(t[j], x[m, j]);
                    x[m + 1, i] = t1 - (b - a) / (2 * n) * t2 - (b - a) / (2 * n) * t3;
                }
                m++;
            }
            println($"Ultima iteratie este {m}");
            for (int i = 0; i <= n; i++)
            {
                println($"x[{m},{i}] = {x[m, i]}");
            }
            println();
            for (int i = 0; i <= n; i++)
            {
                println($"delta(x({m},t[{i}]),g(t[{i}])) = |{x[m, i]} - {g(t[i])}| = {abs(x[m, i] - g(t[i])):F20}");
            }
        }
    }
}
