using System;

namespace GenericParameterisedWithNullableTBenchmark.Common
{
    public class BenchmarkAction
    {
        public string Name { get; }
        public Action Method { get; }

        public BenchmarkAction(string name, Action method)
        {
            Name = name;
            Method = method;
        }
    }
}
