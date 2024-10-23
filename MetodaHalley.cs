using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaHalley : MetodaNumerica
    {

        public Method GetMethod() { return Method.Halley; }
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
            double xn;
            Console.WriteLine($"n = 0");
            if (HasInitialValues)
            {
                xn = x0;
                Console.WriteLine("  Using initial values:");
            }
            else if (cond)
            {
                xn = a;
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} > 0 deci x[0] = a = {xn}");
            }
            else
            {
                xn = b;
                Console.WriteLine($"  f(a) * f''(a) = f({a}) * f''({a}) = {condValue} <= 0 deci x[0] = b = {xn}");
            }
            Console.WriteLine($"  x[0] = {xn}");
            int n = 1;
            double delta = eps;
            while (delta >= eps)
            {
                double fPrevX = f(xn);
                double dfPrevX = df(xn);
                double ddfPrevX = ddf(xn);
                double numerator = 2 * fPrevX * dfPrevX;
                double denominator = 2 * square(dfPrevX) - fPrevX * ddfPrevX;
                double calc = numerator / denominator;
                double xn1 = xn - calc;
                Console.WriteLine("");
                Console.WriteLine($"  x[{n}] = {xn} - (2 * {fPrevX} * {dfPrevX}) / (2 * {dfPrevX}^2 - {fPrevX} * {ddfPrevX})");
                Console.WriteLine($"  x[{n}] = {xn} - {numerator} / {denominator}");
                Console.WriteLine($"  x[{n}] = {xn} - {calc} = {xn1}");
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
