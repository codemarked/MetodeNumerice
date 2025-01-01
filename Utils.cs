using Plotly.NET;

namespace MetodeNumerice
{
    public class Utils
    {
        public static void println(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void println()
        {
            Console.WriteLine();
        }

        public static double pow(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public static double cbrt(double x)
        {
            return Math.Cbrt(x);
        }

        public static double abs(double x)
        {
            return Math.Abs(x);
        }

        public static double max(double a, double b)
        {
            return Math.Max(a, b);
        }

        public static double min(double a, double b)
        {
            return Math.Min(a, b);
        }

        public static double log2(double x)
        {
            return Math.Log2(x);
        }

        public static double ln(double x)
        {
            return Math.Log(x);
        }

        public static double lg(double x)
        {
            return Math.Log10(x);
        }

        public static double sin(double x)
        {
            return Math.Sin(x);
        }

        public static double cos(double x)
        {
            return Math.Cos(x);
        }

        public static void DrawChart(string title, double[] xValues, double[] yValues)
        {
            Chart2D.Chart.Line<double, double, string>(
                xValues,
                yValues
            ).WithTitle(title)
            .Show();
        }
    }
}
