using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaCebisev3 : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly Func<double, double> f = (x) => pow(x, 3) - x - 1;// f(x) - functia matematica
        public static readonly Func<double, double> df = (x) => 3 * pow(x, 2) - 1;// f'(x) - derivata
        public static readonly Func<double, double> ddf = (x) => 6 * x;// f''(x) - derivata a doua

        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 1, b = 2;// Intervalul [a,b]
        public static readonly double x0 = 2;// Valori initiale - x[0]
        // Date de intrare - End

        public Method GetMethod() { return Method.Cebisev3; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"a = {a} | b = {b}");
            println($"precision(eps) = {eps}");
            println();
            double xn = x0;
            println($"  x[0] = {xn}");
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double fxn = f(xn);
                double dfxn = df(xn);
                double ddfxn = df(xn);
                double calc = fxn / dfxn;
                double numerator = pow(fxn, 2) * ddf(xn);
                double denominator = 2 * pow(dfxn, 3);
                double complex = numerator / denominator;
                double xn1 = xn - calc - complex;
                println();
                println($"  x[{n + 1}] = {xn} - {fxn} / {dfxn} - ({fxn}^2 * {ddfxn}) / (2 * {dfxn}^3)");
                println($"  x[{n + 1}] = {xn} - {calc} - {numerator} / {denominator}");
                println($"  x[{n + 1}] = {xn} - {calc} - {complex} = {xn1}");
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
