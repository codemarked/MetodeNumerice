using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaNewton : MetodaNumerica
    {
        static Func<double, double, double> f = (x, y) => pow(x, 2) + pow(y, 2) - 10;
        static Func<double, double, double> dfx = (x, y) => 2 * x;
        static Func<double, double, double> dfy = (x, y) => 2 * y;
        static Func<double, double, double> g = (x, y) => sqrt(x + y) - 2;
        static Func<double, double, double> dgx = (x, y) => 1 / (2 * sqrt(x + y));
        static Func<double, double, double> dgy = (x, y) => 1 / (2 * sqrt(x + y));
        static readonly Func<double, double, double> J = (x, y) => dfx(x, y) * dgy(x, y) - dfy(x, y) * dgx(x, y);
        // Determinantul Jacobian
        static double decimals = 4;
        static double eps = 1 / pow(10, decimals);
        static double x0 = 0.9;
        static double y0 = 3.1;

        static double xc = 1, yc = 3;
        static bool modificata = true;// Metoda Newton modificata (tema)
        public Method GetMethod() { return Method.Newton; }

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
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double f1 = f(xn, yn);
                double g1 = g(xn, yn);
                double j, fx, fy, gx, gy;
                if (modificata)
                {
                    j = J(x0, y0);
                    fx = dfx(x0, y0);
                    fy = dfy(x0, y0);
                    gx = dgx(x0, y0);
                    gy = dgy(x0, y0);
                }
                else
                {
                    j = J(xn, yn);
                    fx = dfx(xn, yn);
                    fy = dfy(xn, yn);
                    gx = dgx(xn, yn);
                    gy = dgy(xn, yn);
                }
                double t1 = f1 * gy - g1 * fy;
                double t2 = fx * g1 - gx * f1;
                double xn1 = xn - 1 / j * t1;
                double yn1 = yn - 1 / j * t2;
                println($"x[{n + 1}] = {xn} - 1 / {j} * ({f1} * {gy} - {g1} * {fy})");
                println($"x[{n + 1}] = {xn} - 1 / {j} * {t1} = {xn1}");
                println($"y[{n + 1}] = {yn} - 1 / {j} * ({fx} * {g1} - {gx} * {f1})");
                println($"y[{n + 1}] = {yn} - 1 / {j} * {t2} = {yn1}");
                delta = max(abs(xn1 - xn), abs(yn1 - yn));
                println($"delta = Max(|x[{n + 1}] - x[{n}]|, |y[{n + 1}] - y[{n}]|) = {delta}");
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
            println($"Comparam cu solutia exacta ({xc},{yc}):");
            println($"deltaX = {abs(xn - xc).ToString($"F{20}")}");
            println($"deltaY = {abs(yn - yc).ToString($"F{20}")}");
        }
    }
}
