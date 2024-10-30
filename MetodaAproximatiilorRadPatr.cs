using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaAproximatiilorRadPat : MetodaNumerica
    {

        public Method GetMethod() { return Method.AproxRadPatrat; }
        public void Run()
        {
            Console.WriteLine($"Metoda {GetMethod()}:");
            Console.WriteLine("");
            Console.WriteLine($"√{a}");
            Console.WriteLine($"precision(eps) = {eps}");
            Console.WriteLine("");
            double xn = a;
            Console.WriteLine($"n = 0");
            Console.WriteLine($"  x[0] = a = {xn}");
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double numerator = xn * (square(xn) + 3 * a);//cube
                double denominator = 3 * square(xn) + a;//cube
                double xn1 = numerator / denominator;
                Console.WriteLine("");
                Console.WriteLine($"  x[{n}] = {xn} * ({xn}^2 + 3 * {a}) / (3 * ({xn}^2 + {a}))");
                Console.WriteLine($"  x[{n}] = {numerator} / {denominator} = {xn1}");
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
