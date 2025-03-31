namespace GenericParameterisedWithNullableTBenchmark.Common
{
    public class Generic<T>
    {
        private readonly T _value;
        
        public Generic(T value) => _value = value;

        public bool IsNull => _value == null;
        public bool IsNotNull => _value != null;
    }
}
