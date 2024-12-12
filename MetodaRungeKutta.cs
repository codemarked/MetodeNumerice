using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaRungeKutta : MetodaNumerica
    {
        static int ordin = 5;// 5 = ordinul 4 "3/8"
        static double x0 = 0, y0 = 1;//[x0,x0 + T]
        static int n = 10;
        static double T = 1;// Lungimea intervalului
        static Func<double, double, double> f = (x, y) => y + x;// y'(x)
        static Func<double, double> g = (x) => 2 * pow(Math.E, x) - x - 1;// f(y) - solutia exacta

        public Method GetMethod() { return Method.RungeKutta; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"Ordin: {(ordin < 1 ? "3/8" : ordin)}");
            println();
            double h = T / n;
            double[] y = new double[n + 1];
            double[] x = new double[n + 1];
            for (int i = 0; i <= n; i++)
                x[i] = x0 + i * h;
            y[0] = y0;
            for (int i = 1; i <= n; i++)
                println($"y[{i}] = {(y[i] = CalcY(ordin, x, y, h, i)):F20}");
            println();
            println("Comparam cu solutiile exacte:");
            for (int i = 1; i <= n; i++)
            {
                double yi = g(x[i]);
                println($"y[{i}] = {yi:F20} | Delta = {abs(yi - y[i]):F20}");
            }
        }

        static double CalcY(int ordin, double[] x, double[] y, double h, int i)
        {
            switch (ordin)
            {
                case 1:
                    {
                        double K1 = f(x[i - 1], y[i - 1]);
                        double K2 = f(x[i - 1] + 2 * h / 3, y[i - 1] + 2 * h / 3 * K1);
                        return y[i - 1] + h / 4 * (K1 + 3 * K2);
                    }
                case 2:
                    {
                        double K1 = f(x[i - 1], y[i - 1]);
                        double K2 = f(x[i - 1] + 3 * h / 4, y[i - 1] + 3 * h / 4 * K1);
                        return y[i - 1] + h / 3 * (K1 + 2 * K2);
                    }
                case 3:
                    {
                        double K1 = f(x[i - 1], y[i - 1]);
                        double K2 = f(x[i - 1] + h / 2, y[i - 1] + h * K1 / 2);
                        double K3 = f(x[i - 1] + h, y[i - 1] + h * (2 * K2 - K1));
                        return y[i - 1] + h / 6.0 * (K1 + 4 * K2 + K3);
                    }
                case 4:
                    {
                        double K1 = h * f(x[i - 1], y[i - 1]);
                        double K2 = h * f(x[i - 1] + h / 2, y[i - 1] + K1 / 2);
                        double K3 = h * f(x[i - 1] + h / 2, y[i - 1] + K2 / 2);
                        double K4 = h * f(x[i - 1] + h, y[i - 1] + K3);
                        return y[i - 1] + (1.0 / 6.0) * (K1 + 2 * K2 + 2 * K3 + K4);
                    }
                default:// 3/8
                    {
                        double K1 = f(x[i - 1], y[i - 1]);
                        double K2 = f(x[i - 1] + (1.0 / 3.0) * h, y[i - 1] + h / 3 * K1);
                        double K3 = f(x[i - 1] + (2.0 / 3.0) * h, y[i - 1] + h * (-(1.0 / 3.0) * K1 + K2));
                        double K4 = f(x[i - 1] + h, y[i - 1] + h * (K1 - K2 + K3));
                        return y[i - 1] + h / 8 * (K1 + 3 * K2 + 3 * K3 + K4);
                    }
            }
        }
    }
}
