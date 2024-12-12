using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaSecantei : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 3) - x - 1;// f(x) - functia matematica
        public static readonly Func<double, double> df = (x) => 3 * pow(x, 2) - 1;// f'(x) - derivata
        public static readonly Func<double, double> ddf = (x) => 6 * x;// f''(x) - derivata a doua

        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 1, b = 2;// Intervalul [a,b]
        public static readonly bool HasInitialValues = false;// Se dau valori initiale?
        public static readonly double x0 = 2;// Valori initiale - x[0]
        public static readonly double x1 = 1.5;// Valori initiale - x[1]
        // Date de intrare - End
        public Method GetMethod() { return Method.Secantei; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precision(eps) = {eps}");
            println();
            double condValue = f(a) * ddf(a);
            bool cond = condValue > 0;
            double xn_1;// x[n-1]
            double xn;// x[n]
            if (HasInitialValues)
            {
                xn_1 = x0;
                xn = x1;
                println("  Using initial values:");
            }
            else if (cond)
            {
                xn_1 = a;
                xn = b;
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {xn_1} si x[1] = b = {xn}");
            }
            else
            {
                xn_1 = b;
                xn = a;
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {xn_1} si x[1] = a = {xn}");
            }
            println($"  x[0] = {xn_1}");
            println($"  x[1] = {xn}");
            int n = 1;
            double xn1;
            double delta = abs(xn - xn_1);
            while (delta >= eps)
            {
                double fxn = f(xn);
                double fxn_1 = f(xn_1);
                double calc = fxn * (xn - xn_1) / (fxn - fxn_1);
                xn1 = xn - calc;
                println();
                println($"  x[{n + 1}] = {xn} - {fxn} * ({xn} - {xn_1}) / ({fxn} - {fxn_1})");
                println($"  x[{n + 1}] = {xn} - {calc} = {xn1}");
                delta = abs(xn1 - xn);
                println($"  |x[{n + 1}] - x[{n}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn_1 = xn;
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
