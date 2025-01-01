using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaGreenBilocalaIV : MetodaNumerica
    {
        static int decimale = 14;
        static double eps = 1 / pow(10, decimale);
        static double a = 0, b = 1, c = 1, d = 0.5, w = -1, r = -0.25;
        static int n = 10;
        static Func<double, double, double> f = (t, x) => 23.0 / pow(t + 1, 5) + pow(x, 5);// y'(x)
        static Func<double, double, double> H = (t, s) =>
        1.0 / 6.0 * pow((s - a) / (b - a), 2) * pow(1 - (t - a) / (b - a), 2) *
        ((t - a) / (b - a) - (s - a) / (b - a) + 2 * (1 - (s - a) / (b - a)) * ((t - a) / (b - a)));
        static Func<double, double, double> K = (s, t) =>
        1.0 / 6.0 * pow((s - a) / (b - a), 2) * pow(1 - (t - a) / (b - a), 2) *
        ((t - a) / (b - a) - (s - a) / (b - a) + 2 * (1 - (s - a) / (b - a)) * ((t - a) / (b - a)));

        static Func<double, double> y = (t) => 1 / (t + 1);// f(y) - solutia exacta

        public Method GetMethod() { return Method.GreenBilocalaIV; }

        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"n = {n}");
            println($"a = {a} | b = {b} | c = {c} | d = {d} | w = {w} | r = {r}");
            println($"precizie(eps) = {eps}");
            println();
            double[] t = new double[n + 1];
            double[] g = new double[n + 1];
            int maxM = 999;
            double[,] x = new double[maxM + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                double ti = t[i] = a + i * ((b - a) / n);
                x[0,i] = g[i] = pow(b - ti, 2) * (2 * (ti - a) + (b - a)) / pow(b - a, 3) * c +
                    pow(ti - a, 2) * (2 * (b - ti) + (b - a)) / pow(b - a, 3) * d +
                    pow(b - ti, 2) * (ti - a) / pow(b - a, 2) * w -
                    pow(ti - a, 2) * (b - ti) / pow(b - a, 2) * r;
            }
            int m = 1;
            while (m < maxM)
            {
                println($"m = {m}");
                x[m, 0] = c;
                x[m, n] = d;
                for (int i = 1; i <= n - 1; i++)
                {
                    double s1 = 0;
                    for (int j = 1; j <= i; j++)
                        s1 += H(t[i], t[j - 1]) * f(t[j - 1], x[m - 1, j - 1]) +
                            H(t[i], t[j]) * f(t[j], x[m - 1,j]);
                    double s2 = 0;
                    for (int j = i + 1; j <= n; j++)
                        s2 += K(t[i], t[j - 1]) * f(t[j - 1], x[m - 1, j - 1]) +
                            K(t[i], t[j]) * f(t[j], x[m - 1, j]);
                    double h = (b - a) / (2.0 * n);
                    x[m, i] = g[i] + h * s1 + h * s2;
                    println($"  x[{m},{i}] = {g[i]} + {h} * {s1} + {h} * {s2} = {x[m, i]:F20}");
                }
                bool finished = true;
                for (int i = 1; i <= n - 1; i++)
                {
                    if (abs(x[m, i] - x[m - 1, i]) >= eps)
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
                println($"x[{m},{i}] = {x[m, i]}");
            }
            println();
            println("Comparam cu solutiile exacte:");
            for (int i = 0; i <= n; i++)
            {
                double xi = y(t[i]);
                println($"x[{i}] = {xi:F20} | Delta = {abs(xi - x[m, i]):F20}");
            }
            DrawChart($"Metoda {GetMethod()}", t, GetRow(x, m));
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
