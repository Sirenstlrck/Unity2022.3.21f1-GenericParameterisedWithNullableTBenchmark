namespace GenericParameterisedWithNullableTBenchmark.Common
{
    public class NullableTConstrainedGeneric<T> where T : struct
    {
        private readonly T? _value;
        
        public NullableTConstrainedGeneric(T? value) => _value = value;

        public bool IsNull => _value == null;
        public bool IsNotNull => _value != null;
    }
}
