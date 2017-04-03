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
                var test = new AlgoRunner(n, m);
            }
            else //if (arguments.ContainsKey("graph"))
            {
                Console.Clear();
                Console.WriteLine("Witaj w programie rozwiazujacym problem kolorowania grafu harmonicznego.");

                /*
                var solver1 = new GraphColoringProblemSolver(2);
                solver1.Run();
                
                var solver2 = new GraphColoringProblemSolver(3);
                solver2.Run();

                var solver3 = new GraphColoringProblemSolver(4);
                solver3.Run();

                var solver4 = new GraphColoringProblemSolver(5);
                solver4.Run();

                var solver5 = new GraphColoringProblemSolver(6);
                solver5.Run();

                var solver6 = new GraphColoringProblemSolver(7);
                solver6.Run();

                var solver7 = new GraphColoringProblemSolver(8);
                solver7.Run();

                var solver8 = new GraphColoringProblemSolver(9);
                solver8.Run();

                var solver9 = new GraphColoringProblemSolver(10);
                solver9.Run();
                */

                //                var p1 = new Point(1, 3);
                //                var p2 = new Point(3, 1);
                //                Console.WriteLine(p1.GetHashCode());
                //                Console.WriteLine(p2.GetHashCode());
                //                Console.WriteLine(p1.Equals(p2));
                //
                //                Console.ReadKey();

                var watch = System.Diagnostics.Stopwatch.StartNew();

                var solver8 = new GraphColoringProblemSolver(12);
                solver8.Run();
                
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
                Console.ReadKey();
            }
        }
    }
}