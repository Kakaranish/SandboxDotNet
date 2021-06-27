using BenchmarkDotNet.Attributes;
using System;

namespace Yield
{
    [MemoryDiagnoser]
    public class YieldBenchmark
    {
        [Benchmark]
        public void GetPeopleWithoutYield()
        {
            var yieldWorkspace = new YieldWorkspace();
            foreach (var person in yieldWorkspace.GetPeople(1_000_000))
            {
                if (person.Id >= 1000) break;
                Console.WriteLine(person);
            }
        }

        [Benchmark]
        public void GetPeopleWithYield()
        {
            var yieldWorkspace = new YieldWorkspace();
            foreach (var person in yieldWorkspace.GetPeopleWithYield(1_000_000))
            {
                if (person.Id >= 1000) break;
                Console.WriteLine(person);
            }
        }
    }
}
