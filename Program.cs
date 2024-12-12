namespace MetodeNumerice
{
    public class Program
    {

        static readonly Dictionary<Method, Func<MetodaNumerica>> methods = new()
        {
            { Method.AproxRadPatrat, () => new MetodaAproximatiilorRadPat() },
            { Method.AproximatiilorSuccesive, () => new MetodaAproximatiilorSuccesive() },
            { Method.AproximatiilorSuccesiveBilocalaII, () => new MetodaAproxSuccBilocalaII() },
            { Method.AproximatiilorSuccesiveCauchyI, () => new MetodaAproxSuccCauchyI() },
            { Method.AproximatiilorSuccesiveNeliniare, () => new MetodaAproxSuccNeliniare() },
            { Method.Cebisev3, () => new MetodaCebisev3() },
            { Method.Euler, () => new MetodaEuler() },
            { Method.EulerHeun, () => new MetodaEulerHeun() },
            { Method.EulerMidpoint, () => new MetodaEulerMidpoint() },
            { Method.GaussSeidel, () => new MetodaGaussSeidel() },
            { Method.Halley, () => new MetodaHalley() },
            { Method.Newton, () => new MetodaNewton() },
            { Method.RungeKutta, () => new MetodaRungeKutta() },
            { Method.Secantei, () => new MetodaSecantei() },
            { Method.Steffensen, () => new MetodaSteffensen() },
            { Method.Tangentei, () => new MetodaTangentei() },
            { Method.TangenteiCombinate, () => new MetodaTangenteiCombinate() }
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
