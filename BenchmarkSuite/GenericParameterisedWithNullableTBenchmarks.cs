using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using GenericParameterisedWithNullableTBenchmark.Common;

namespace BenchmarkSuite
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class GenericParameterisedWithNullableTBenchmarks
    {
        public IEnumerable<int> ActionIndexSource => Enumerable.Range(0, BenchmarkActions.Get.Length);

        [ParamsSource(nameof(ActionIndexSource))]
        public int ActionIndex;
        
        [Benchmark]
        public void RunAction()
        {
            BenchmarkAction action = BenchmarkActions.Get[ActionIndex];
            
            action.Method();
        }
    }
}
