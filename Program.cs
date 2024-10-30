namespace MetodeNumerice
{
    public class Program
    {
        public static readonly Method method = Method.AproxRadPatrat;
        // Date de intrare - Start
        public static readonly string functia = "x^3 - 2";// Folosit doar pentru afisarea expresiei functiei(nu pentru calcul)!!!
        public static readonly Func<double, double> fx = (x) => Math.Pow(x, 3) - 2;// f(x)
        public static readonly Func<double, double> dfx = (x) => 3 * square(x);// f'(x)
        public static readonly Func<double, double> ddfx = (x) => 6 * x;// f''(x)

        public static readonly double a = 5, b = 2;// Intervalul [a,b]
        public static readonly double decimals = 4;// Decimale sau cifre dupa virgula
        public static readonly double eps = 1 / Math.Pow(10, decimals);// Precizie = 1/10^(decimals)
        // Metoda Halley, Secantei - exista valori initiale?
        public static readonly bool HasInitialValues = false;// Valori initiale?
        public static readonly double x0 = 0;// Valori initiale - x[0]
        public static readonly double x1 = 1.4;// Valori initiale - x[1]
        // Date de intrare - End

        static void Main(string[] args)
        {
            Run(method);
            Console.ReadKey();
        }

        static List<MetodaNumerica> methods = [
            new MetodaSecantei(),new MetodaSteffensen(),new MetodaTangentei(),
        new MetodaCebisev3(),new MetodaHalley(), new MetodaTangenteiCombinate(),
        new MetodaAproximatiilorRadPat()];

        static void Run(Method method)
        {
            MetodaNumerica metodaNumerica = methods.First(m => m.GetMethod().Equals(method)) 
                ?? throw new Exception("Metoda nu exista");
            metodaNumerica.Run();
        }

        public static double f(double x)
        {
            return fx.Invoke(x);
        }

        public static double df(double x)
        {
            return dfx.Invoke(x);
        }

        public static double ddf(double x)
        {
            return ddfx.Invoke(x);
        }

        public static double square(double x)
        {
            return x * x;
        }

        public static double cube(double x)
        {
            return x * x * x;
        }


    }

}
