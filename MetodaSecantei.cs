using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaSecantei : MetodaNumerica
    {
        public Method GetMethod() { return Method.Secantei; }
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
            double xn_1;// x[n-1]
            double xn;// x[n]
            Console.WriteLine($"n = 0");
            if (HasInitialValues)
            {
                xn_1 = x0;
                xn = x1;
                Console.WriteLine("  Using initial values:");
            }
            else if (cond)
            {
                xn_1 = a;
                xn = b;
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {xn_1} si x[1] = b = {xn}");
            }
            else
            {
                xn_1 = b;
                xn = a;
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {xn_1} si x[1] = a = {xn}");
            }
            Console.WriteLine($"  x[0] = {x0}");
            Console.WriteLine($"  x[1] = {x1}");
            int n = 2;
            // Recurenta:
            double xn1;
            double delta = eps;
            while (delta >= eps)
            {
                double fxn = f(xn);
                double fxn_1 = f(xn_1);
                double calc = fxn * (xn - xn_1) / (fxn - fxn_1);
                xn1 = xn - calc;
                Console.WriteLine("");
                Console.WriteLine($"  x[{n}] = {xn} - {fxn} * ({xn} - {xn_1}) / ({fxn} - {fxn_1})");
                Console.WriteLine($"  x[{n}] = {xn} - {calc} = {xn1}");
                delta = Math.Abs(xn1 - xn);
                Console.WriteLine($"  |x[{n}] - x[{n - 1}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn_1 = xn;
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
