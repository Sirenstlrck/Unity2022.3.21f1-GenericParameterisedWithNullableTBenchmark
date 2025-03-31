using System;
using GenericParameterisedWithNullableTBenchmark.Common;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace GenericParameterisedWithNullableTBenchmark.Unity
{
    public class BenchmarkActionsRunner
    {
        [Test, Performance]
        public void Run()
        {
            ReadOnlySpan<BenchmarkAction> benchmarks = BenchmarkActions.Get;
            
            // The measure isn't isolated so we can catch GC calls unrelated to the test
            // So we need more than 1 measurement to make it easier to detect relevant GC calls...
            const int MeasurementCount = 20;

            foreach (BenchmarkAction a in benchmarks)
            {
                Measure.Method(a.Method)
                   .MeasurementCount(MeasurementCount)
                   .SampleGroup(a.Name)
                   .GC()
                   .Run();
            }
        }
    }
}
