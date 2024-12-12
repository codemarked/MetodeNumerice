using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproxSuccNeliniare : MetodaNumerica
    {
        static Func<double, double, double> f = (x, y) => sqrt((x * (y + 5) - 1) / 2);
        static Func<double, double, double> dfx = (x, y) => (y + 5) / (4 * sqrt((x * y + 5 * x - 1) / 2));
        static Func<double, double, double> dfy = (x, y) => x / (4 * sqrt((x * y + 5 * x - 1) / 2));

        static Func<double, double, double> g = (x, y) => sqrt(x + 3 * lg(x));
        static Func<double, double, double> dgx = (x, y) => 1 / (2 * sqrt(x + y));
        static Func<double, double, double> dgy = (x, y) => 1 / (2 * sqrt(x + y));

        static double decimals = 4;
        static double eps = 1 / pow(10, decimals);
        static double x0 = 3.5;
        static double y0 = 2.2;

        static double xc = 3.4, yc = 2.3;

        public Method GetMethod() { return Method.AproximatiilorSuccesiveNeliniare; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"precizie(eps) = {eps}");
            println();
            println($"x[0] = {x0}");
            println($"y[0] = {y0}");
            println();
            double xn = x0;
            double yn = y0;
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double xn1 = f(xn, yn);
                double yn1 = g(xn, yn);
                println($"x[{n}] = {xn1}");
                println($"y[{n}] = {yn1}");
                delta = max(abs(xn1 - xn), abs(yn1 - yn));
                println($"delta = Max(|x[{n}] - x[{n - 1}]|, |y[{n}] - y[{n - 1}]|) = {delta}");
                if (delta < eps)
                    println($"delta = {delta.ToString($"F{20}")} < {eps} => STOP");
                println();
                xn = xn1;
                yn = yn1;
                n++;
            }
            println();
            println($"n = {n}");
            println($"x[{n}] = {xn}");
            println($"y[{n}] = {yn}");
            println();
            println($"Compare with {xc},{yc} = {abs(xn - xc).ToString($"F{20}")},{abs(yn - yc).ToString($"F{20}")}");
        }

        static double J(double x, double y)// Determinantul Jacobian
        {
            return dfx(x, y) * dgy(x, y) - dfy(x, y) * dgx(x, y);
        }
    }
}
