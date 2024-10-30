using static MetodeNumerice.Program;

namespace MetodeNumerice
{
    public class MetodaTangenteiCombinate : MetodaNumerica
    {

        public Method GetMethod() { return Method.TangenteiCombinate; }
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
                double calc = fPrevX / dfPrevX;
                double simple = xn - calc;
                double fsimple = f(simple);
                double complex = fsimple / dfPrevX;
                double xn1 = simple - complex;
                Console.WriteLine("");
                Console.WriteLine($"  x[{n}] = {xn} - {fPrevX} / {dfPrevX} - {fsimple} / {dfPrevX}");
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
