using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaCebisev3 : MetodaNumerica
    {

        public Method GetMethod() { return Method.Cebisev3; }
        public void Run()
        {
            Console.WriteLine($"Metoda {GetMethod()}:");
            Console.WriteLine("");
            Console.WriteLine($"f: [{a},{b}] -> R, f(x) = {functia}");
            Console.WriteLine($"a = {a} | b = {b}");
            Console.WriteLine($"precision(eps) = {eps}");
            Console.WriteLine("");
            double xn = x0;
            Console.WriteLine($"n = 0");
            Console.WriteLine($"  x[0] = {xn}");
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double fxn = f(xn);
                double dfxn = df(xn);
                double ddfxn = df(xn);
                double calc = fxn / dfxn;
                double numerator = square(fxn) * ddf(xn);
                double denominator = 2 * cube(dfxn);
                double complex = numerator / denominator;
                double xn1 = xn - calc - complex;
                Console.WriteLine("");
                Console.WriteLine($"  x[{n}] = {xn} - {fxn} / {dfxn} - ({fxn}^2 * {ddfxn}) / (2 * {dfxn}^3)");
                Console.WriteLine($"  x[{n}] = {xn} - {calc} - {numerator} / {denominator}");
                Console.WriteLine($"  x[{n}] = {xn} - {calc} - {complex} = {xn1}");
                delta = Math.Abs(xn1 - xn);
                Console.WriteLine($"  |x[{n}] - x[{n - 1}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn = xn1;
                n++;
            }
            Console.WriteLine("");
            Console.WriteLine("Rezultat:");
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"  x* = {xn}");
        }
    }
}
