using System;

namespace CSP
{
    public class Statistic
    {
        public long Duration { get; set; }
        public long ReturnCount { get; set; }

        public void Add(Statistic s)
        {
            Duration += s.Duration;
            ReturnCount += s.ReturnCount;
        }

        public void PrintResult(int numberOfCycles)
        {
            Console.WriteLine($"{Duration/numberOfCycles}\t{ReturnCount/numberOfCycles}");
        }
    }
}
