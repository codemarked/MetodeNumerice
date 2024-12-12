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
        static double decimals = 4;
        static double eps = 1 / pow(10, decimals);
        static double x0 = 2.9;
        static double y0 = 1.1;

        static double xc = 3, yc = 1;

        public Method GetMethod() { return Method.TangenteiCombinate; }

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
                double j = J(xn, yn);
                //double j = J(x0, y0);
                double f1 = f(xn, yn);
                double fx = dfx(xn, yn);
                double fy = dfy(xn, yn);
                //double fx = dfx(x0, y0);
                //double fy = dfy(x0, y0);
                double g1 = g(xn, yn);
                //double gx = dgx(x0, y0);
                //double gy = dgy(x0, y0);
                double gx = dgx(xn, yn);
                double gy = dgy(xn, yn);
                double t1 = f1 * gy - g1 * fy;
                double t2 = fx * g1 - gx * f1;
                double xn1 = xn - 1 / j * t1;
                double yn1 = yn - 1 / j * t2;
                println($"x[{n}] = {xn} - 1 / {j} * ({f1} * {gy} - {g1} * {fy})");
                println($"x[{n}] = {xn} - 1 / {j} * {t1} = {xn1}");
                println($"y[{n}] = {yn} - 1 / {j} * ({fx} * {g1} - {gx} * {f1})");
                println($"y[{n}] = {yn} - 1 / {j} * {t2} = {yn1}");
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
