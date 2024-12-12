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
        public static readonly bool HasInitialValues = false;// Se dau valori initiale?
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
            println($"n = 0");
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
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double fPrevX = f(xn);
                double dfPrevX = df(xn);
                double calc = fPrevX / dfPrevX;
                double simple = xn - calc;
                double fsimple = f(simple);
                double complex = fsimple / dfPrevX;
                double xn1 = simple - complex;
                println("");
                println($"  x[{n}] = {xn} - {fPrevX} / {dfPrevX} - {fsimple} / {dfPrevX}");
                println($"  x[{n}] = {xn} - {calc} - {complex} = {xn1}");
                delta = abs(xn1 - xn);
                println($"  |x[{n}] - x[{n - 1}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
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
