using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaEulerMidpoint : MetodaNumerica
    {
        static double x0 = 0, y0 = 1;//[x0,x0 + T]
        static double T = 1;// Lungimea intervalului
        static int n = 10;
        static Func<double, double, double> f = (x, y) => x + y;// y'(x)
        static Func<double, double> g = (x) => 2 * pow(Math.E, x) - x - 1;// y(x) - solutia exacta

        public Method GetMethod() { return Method.EulerMidpoint; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            double h = T / n;
            double[] x = new double[n + 1];
            double[] y = new double[n + 1];
            x[0] = x0;
            y[0] = y0;
            for (int i = 1; i <= n; i++)
                x[i] = x0 + i * h;
            for (int i = 1; i <= n; i++)
            {
                double K = f(x[i - 1], y[i - 1]);
                double U = f(x[i - 1] + h / 2.0, y[i - 1] + h / 2.0 * K);
                y[i] = y[i - 1] + h * U;
            }
            println();
            println("Comparam cu solutiile exacte:");
            for (int i = 1; i <= n; i++)
            {
                double yi = g(x[i]);
                println($"y[{i}] = {yi:F20} | Delta = {abs(yi - y[i]):F20}");
            }
        }
    }
}
