using System;

namespace CSP
{
    public class Statistic
    {
        public int N { get; set; }
        public double Duration { get; set; }
        public long AsignCount { get; set; }
        public bool Backtracking { get; set; }
        public bool Heurestic { get; set; }

        public Statistic(int n, bool b, bool h)
        {
            N = n;
            Backtracking = b;
            Heurestic = h;
        }

        public void Add(Statistic s)
        {
            Duration += s.Duration;
            AsignCount += s.AsignCount;
        }

        public void PrintResult(int numberOfCycles)
        {
            var method = Backtracking ? "bt" : "fc";
            var heurestic = Heurestic ? "++" : "--";
            Console.WriteLine($"{N}\t{method}\t{heurestic}\t{Duration/numberOfCycles}\t{AsignCount / numberOfCycles}");
        }
    }
}
