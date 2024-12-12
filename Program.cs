namespace MetodeNumerice
{
    public class Program
    {

        static readonly Dictionary<Method, Func<MetodaNumerica>> methods = new()
        {
            { Method.AproxRadPatrat, () => new MetodaAproximatiilorRadPat() }, // Lab 4
            { Method.AproximatiilorSuccesive, () => new MetodaAproximatiilorSuccesive() },
            { Method.AproximatiilorSuccesiveBilocalaII, () => new MetodaAproxSuccBilocalaII() }, // Lab 11
            { Method.AproximatiilorSuccesiveCauchyI, () => new MetodaAproxSuccCauchyI() }, // Lab 10
            { Method.AproximatiilorSuccesiveNeliniare, () => new MetodaAproxSuccNeliniare() }, // Lab 6
            { Method.Cebisev3, () => new MetodaCebisev3() }, // Lab 3
            { Method.Euler, () => new MetodaEuler() }, // Lab 7
            { Method.EulerHeun, () => new MetodaEulerHeun() }, // Lab 7
            { Method.EulerMidpoint, () => new MetodaEulerMidpoint() }, // Lab 7
            { Method.GaussSeidel, () => new MetodaGaussSeidel() }, // Lab 6
            { Method.Halley, () => new MetodaHalley() }, // Lab 3
            { Method.Newton, () => new MetodaNewton() }, // Lab 5
            { Method.RungeKutta, () => new MetodaRungeKutta() }, // Lab 8,9
            { Method.Secantei, () => new MetodaSecantei() }, // Lab 2
            { Method.Steffensen, () => new MetodaSteffensen() }, // Lab 2
            { Method.Tangentei, () => new MetodaTangentei() }, // Lab 1
            { Method.TangenteiCombinate, () => new MetodaTangenteiCombinate() } // Lab 4
        };

        static void Main(string[] args)
        {
            Run(Method.EulerHeun);
            Console.ReadKey();
        }

        static void Run(Method method)
        {
            if (methods.TryGetValue(method,out Func<MetodaNumerica>? supplier))
            {
                supplier().Run();
            } else
            {
                throw new Exception("Metoda nu exista");
            }
        }
    }
}
