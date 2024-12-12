using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaSteffensen : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 3) - x - 1;// f(x) - functia matematica
        public static readonly Func<double, double> ddf = (x) => 6 * x;// f''(x) - derivata a doua

        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 1, b = 2;// Intervalul [a,b]
        // Date de intrare - End
        public Method GetMethod() { return Method.Steffensen; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precision(eps) = {eps}");
            println();
            double condValue = f(a) * ddf(a);
            bool cond = condValue > 0;
            double xn = cond ? a : b;
            if (cond)
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {a}");
            else
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {b}");
            println();
            println($"  x[0] = {xn}");
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double fxn = f(xn);
                double fxnn = f(xn + fxn);
                double denominator = fxnn - fxn;
                double calc = pow(fxn, 2) / denominator;
                double xn1 = xn - calc;
                delta = abs(xn1 - xn);
                println();
                println($"  x[{n + 1}] = {xn} - ({fxn})^2 / ({fxnn} - {fxn})");
                println($"  x[{n + 1}] = {xn} - ({fxn})^2 / {denominator}");
                println($"  x[{n + 1}] = {xn} - {calc} = {xn1}");
                println($"  |x[{n + 1}] - x[{n}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn = xn1;
                n++;
            }
            println();
            println("Rezultat:");
            println($"n = {n}");
            println($"  x* = {xn}");
        }
    }
}
