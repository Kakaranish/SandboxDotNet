using BenchmarkDotNet.Running;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<YieldBenchmark>();
        }
    }
}
