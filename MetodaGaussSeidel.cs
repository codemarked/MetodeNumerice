using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaGaussSeidel : MetodaNumerica
    {
        static Func<double, double, double, double> f1 = (x, y, z) => sqrt(0.5 * (y * z + 5 * x - 1));
        static Func<double, double, double, double> f2 = (x, y, z) => sqrt(2 * x + ln(z));
        static Func<double, double, double, double> f3 = (x, y, z) => sqrt(x * y + 2 * z + 8);

        static double decimals = 4;
        static double eps = 1 / pow(10, decimals);
        static double x0 = 10;
        static double y0 = 10;
        static double z0 = 10;

        public Method GetMethod() { return Method.GaussSeidel; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"precizie(eps) = {eps}");
            println();
            println($"x[0] = {x0}");
            println($"y[0] = {y0}");
            println($"z[0] = {z0}");
            println();
            double xn = f1(x0, y0, z0);
            double yn = f2(x0, y0, z0);
            double zn = f3(x0, y0, z0);
            println($"x[1] = {xn}");
            println($"y[1] = {yn}");
            println($"z[1] = {zn}");
            println();
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double xn1 = f1(xn, yn, zn);
                double yn1 = f2(xn1, yn, zn);
                double zn1 = f3(xn1, yn1, zn);
                println($"x[{n + 1}] = {xn1}");
                println($"y[{n + 1}] = {yn1}");
                println($"z[{n + 1}] = {zn1}");
                delta = max(abs(xn1 - xn), max(abs(yn1 - yn), abs(zn1 - zn)));
                println($"delta = Max(|x[{n + 1}] - x[{n}]|, |y[{n + 1}] - y[{n}]|, |z[{n + 1}] - z[{n}]|) = {delta}");
                if (delta < eps)
                    println($"delta = {delta.ToString($"F{20}")} < {eps} => STOP");
                println();
                xn = xn1;
                yn = yn1;
                zn = zn1;
                n++;
            }
            println();
            println($"n = {n}");
            println($"x[{n}] = {xn}");
            println($"y[{n}] = {yn}");
            println($"z[{n}] = {zn}");
            println();
        }
    }
}
