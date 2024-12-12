using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproximatiilorSuccesive : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 3) - x - 1;// f(x) - functia matematica

        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / Math.Pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 1, b = 2;// Intervalul [a,b]
        public static readonly double x0 = 2;// Valori initiale - x[0]
        // Date de intrare - End
        public Method GetMethod() { return Method.AproximatiilorSuccesive; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precizie(eps) = {eps}");
            println();
            double xn = x0;
            println($"  x[0] = {xn}");
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double gPrevX = f(xn);
                println("");
                println($"n = {n + 1}");
                println($"  x[{n + 1}] = {gPrevX}");
                delta = abs(gPrevX - xn);
                println($"  |x[{n + 1}] - x[{n}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn = gPrevX;
                n++;
            }
            println("");
            println("Rezultat:");
            println($"n = {n}");
            println($"  x* = {xn}");
        }
    }
}
