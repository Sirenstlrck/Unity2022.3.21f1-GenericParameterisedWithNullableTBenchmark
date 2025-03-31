using System;
using BenchmarkDotNet.Running;
using GenericParameterisedWithNullableTBenchmark.Common;

namespace BenchmarkSuite
{
    public class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<GenericParameterisedWithNullableTBenchmarks>(args: args);
            PrintActionsLegend();
        }

        private static void PrintActionsLegend()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Actions legend:");
            
            ReadOnlySpan<BenchmarkAction> actions = BenchmarkActions.Get;

            for (int i = 0; i < actions.Length; ++i)
            {
                Console.WriteLine($"{i}\t{actions[i].Name}");
            }
        }
    }
}
