using System;
using System.Collections.Generic;
using CSP;

/*
 *  dwie heurestyki na zadanie
 *  czym jest zmienna, dziedziny
 *
 *  binary - n, m
 *  parametry -n -m -> flagi
 *  wydruk struktury grafu / siatki
 *
 *  losowanie + sprawdzanie ograniczeń (M pól zapełnione)
 *  lub pełna plansza + usuwamy aż do zostania M elementów
 *  dwa podejścia -> brak rozwiązania
 *  ile trwa przegląd zupełny
 *  porównanie backtracking i forward checkingu - szukamy pierwszego rozwiązania
 *  jedna plansza -> dwa podejścia
 *
 *  parametry dla binary -> plansza 20 x 20
 *
 *  wykres czas/wielkość planszy
 */
namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Dictionary<string, string>();

            foreach (string argument in args)
            {
                string[] splitted = argument.Split('=');

                if (splitted.Length == 2)
                {
                    arguments[splitted[0].Trim('-')] = splitted[1];
                }

                if (!argument.Contains("="))
                {
                    arguments[argument.Trim('-')] = "true";
                }
            }

            if (arguments.ContainsKey("binary"))
            {
                Console.Clear();
                Console.WriteLine("Witaj w programie rozwiazujacym problem binary.");

                int n = Int32.Parse(arguments["n"]);
                int m = Int32.Parse(arguments["m"]);
                // -bt lub -fc
                // -h // heurestic

                Console.WriteLine($"--------------- Poczatek testu {n}x{n} ---------------");
                var solverBinary = new BinaryProblemSolver();
                solverBinary.GenerateBoard(n, m, true);
                Console.WriteLine(solverBinary.PrintedBoard());
                solverBinary.Run(arguments.ContainsKey("bt"), arguments.ContainsKey("h"));
                Console.WriteLine("------------------- Koniec testu -------------------");
            }
            else if (arguments.ContainsKey("graph"))
            {
                Console.Clear();
                Console.WriteLine("Witaj w programie rozwiazujacym problem kolorowania grafu harmonicznego.");

                // -bt lub -fc
                // -h // heurestic

                int n = Int32.Parse(arguments["n"]);

                var solverGraph = new GraphColoringProblemSolver(n);
                solverGraph.Run(arguments.ContainsKey("bt"), arguments.ContainsKey("h"));
            }
        }
    }
}