﻿using static MetodeNumerice.Utils;

namespace MetodeNumerice
{
    public class MetodaAproximatiilorRadPat : MetodaNumerica
    {
        // Date de intrare - Start
        public static readonly double decimals = 4;// Precizie
        public static readonly double eps = 1 / pow(10, decimals);// Precizie = 1/10^(decimals)

        public static readonly double a = 2;
        // Date de intrare - End

        public Method GetMethod() { return Method.AproxRadPatrat; }
        public void Run()
        {
            println($"Metoda {GetMethod()}:");
            println();
            println($"√{a}");
            println($"precision(eps) = {eps}");
            println();
            double xn = a;
            println($"  x[0] = a = {xn}");
            int n = 0;
            double delta = eps;
            while (delta >= eps)
            {
                double numerator = xn * (pow(xn, 2) + 3 * a);//cube
                double denominator = 3 * pow(xn, 2) + a;//cube
                double xn1 = numerator / denominator;
                println();
                println($"  x[{n + 1}] = {xn} * ({xn}^2 + 3 * {a}) / (3 * ({xn}^2 + {a}))");
                println($"  x[{n + 1}] = {numerator} / {denominator} = {xn1}");
                delta = abs(xn1 - xn);
                println($"  |x[{n + 1}] - x[{n}]| = {delta} {(delta < eps ? $" < {eps}" : "")}");
                xn = xn1;
                n++;
            }
            println();
            println("Rezultat:");
            println($"n = {n}");
            println($"  x* = {xn}");
        }
    }
}
