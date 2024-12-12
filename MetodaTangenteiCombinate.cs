using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaTangenteiCombinate : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 3) - x - 1;// f(x) - functia matematica
        public static readonly Func<double, double> df = (x) => 3 * pow(x, 2) - 1;// f'(x) - derivata
        public static readonly Func<double, double> ddf = (x) => 6 * x;// f''(x) - derivata a doua

        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 1, b = 2;// Intervalul [a,b]
        public static readonly bool HasInitialValues = true;// Se dau valori initiale?
        public static readonly double x0 = 2;// Valori initiale - x[0]
        // Date de intrare - End

        public Method GetMethod() { return Method.TangenteiCombinate; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precision(eps) = {eps}");
            println();
            double condValue = f(a) * ddf(a);
            bool cond = condValue > 0;
            double xn;
            if (HasInitialValues)
            {
                xn = x0;
                println("  Using initial values:");
            }
            else if (cond)
            {
                xn = a;
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {xn}");
            }
            else
            {
                xn = b;
                println($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {xn}");
            }
            println($"  x[0] = {xn}");
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double f1 = f(xn);
                double df1 = df(xn);
                double t1 = f1 / df1;
                double t0 = xn - t1;
                double f2 = f(t0);
                double t2 = f2 / df1;
                double xn1 = t0 - t2;
                println();
                println($"  x[{n + 1}] = {xn} - {f1} / {df1} - {f2} / {df1}");
                println($"  x[{n + 1}] = {xn} - {t1} - {t2} = {xn1}");
                delta = abs(xn1 - xn);
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
