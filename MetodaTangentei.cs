using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaTangentei : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 5) - 5 * x + 1;// f(x) - functia matematica
        public static readonly Func<double, double> df = (x) => 5 * pow(x, 4) - 5;// f'(x) - derivata
        public static readonly Func<double, double> ddf = (x) => 20 * pow(x, 3);// f''(x) - derivata a doua

        public static readonly double decimals = 12;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = -1, b = 1;// Intervalul [a,b]
        public static readonly bool HasInitialValues = true;// Se dau valori initiale?
        public static readonly double x0 = 0;// Valori initiale - x[0]
        // Date de intrare - End

        public Method GetMethod() { return Method.Tangentei; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precizie(eps) = {eps}");
            println();
            double condValue = f(a) * ddf(a);
            bool cond = condValue > 0;
            double xn;
            if (HasInitialValues)
            {
                xn = x0;
                println("  Folosind valorile initiale:");
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
                double fPrevX = f(xn);
                double dfPrevX = df(xn);
                double calc = fPrevX / dfPrevX;
                double xn1 = xn - calc;
                println();
                println($"  x[{n + 1}] = {xn} - {fPrevX} / {dfPrevX}");
                println($"  x[{n + 1}] = {xn} - {calc} = {xn1}");
                delta = abs(xn1 - xn);
                println($"  |x[{n + 1}] - x[{n}]| = {delta} {(delta < eps ? $" < {eps} => STOP" : "")}");
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
