using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaSteffensen : MetodaNumerica
    {
        public Method GetMethod() { return Method.Steffensen; }
        public void Run()
        {
            Console.WriteLine($"Metoda {GetMethod()}:");
            Console.WriteLine("");
            Console.WriteLine($"f: [{a},{b}] -> R, f(x) = {functia}");
            Console.WriteLine($"a = {a} | b = {b}");
            Console.WriteLine($"precision(eps) = {eps}");
            Console.WriteLine("");
            double condValue = f(a) * ddf(a);
            bool cond = condValue > 0;
            double xn = cond ? a : b;
            if (cond)
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {a}");
            else
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {b}");
            Console.WriteLine(" ");
            Console.WriteLine($"  x[0] = {xn}");
            int n = 1;
            double delta;
            do
            {
                double fxn = f(xn);
                double fxnn = f(xn + fxn);
                double denominator = fxnn - fxn;
                double calc = square(fxn) / denominator;
                double xn1 = xn - calc;
                delta = Math.Abs(xn1 - xn);
                Console.WriteLine(" ");
                Console.WriteLine($"  x[{n}] = {xn} - ({fxn})^2 / ({fxnn} - {fxn})");
                Console.WriteLine($"  x[{n}] = {xn} - ({fxn})^2 / {denominator}");
                Console.WriteLine($"  x[{n}] = {xn} - {calc} = {xn1}");
                Console.WriteLine($"  |x[{n}] - x[{n - 1}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn = xn1;
                n++;
            } while (delta >= eps);
            Console.WriteLine("");
            Console.WriteLine("Rezultat:");
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"  x* = {xn}");
        }
    }
}
