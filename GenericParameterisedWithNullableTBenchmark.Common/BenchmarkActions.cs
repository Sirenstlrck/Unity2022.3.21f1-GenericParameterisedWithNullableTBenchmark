using System;
using System.Runtime.CompilerServices;

namespace GenericParameterisedWithNullableTBenchmark.Common
{
    public static class BenchmarkActions
    {
        private static readonly Generic<object> GenericWithObject = new Generic<object>(new object());
        
        private static readonly Generic<int> GenericWithInt = new Generic<int>(0);
        
        private static readonly Generic<int?> GenericWithNullableIntNotNull = new Generic<int?>(0);
        private static readonly Generic<int?> GenericWithNullableIntNull= new Generic<int?>(null);
        
        private static readonly NullableTConstrainedGeneric<int> ConstrainedWithIntNotNull
            = new NullableTConstrainedGeneric<int>(0);
        private static readonly NullableTConstrainedGeneric<int> ConstrainedWithIntNull
            = new NullableTConstrainedGeneric<int>(null);

        private static readonly BenchmarkAction[] Actions = {
            new BenchmarkAction(
                $"{nameof(GenericWithObject)} '{nameof(GenericWithObject.IsNull)}'",
                () => Consume(GenericWithObject.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(GenericWithObject)} '{nameof(GenericWithObject.IsNotNull)}'",
                () => Consume(GenericWithObject.IsNotNull)
            ),
            
            new BenchmarkAction(
                $"{nameof(GenericWithInt)} '{nameof(GenericWithInt.IsNull)}'",
                () => Consume(GenericWithInt.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(GenericWithInt)} '{nameof(GenericWithInt.IsNotNull)}'",
                () => Consume(GenericWithInt.IsNotNull)
            ),
            
            new BenchmarkAction(
                $"{nameof(GenericWithNullableIntNotNull)} '{nameof(GenericWithNullableIntNotNull.IsNull)}'",
                () => Consume(GenericWithNullableIntNotNull.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(GenericWithNullableIntNotNull)} '{nameof(GenericWithNullableIntNotNull.IsNotNull)}'",
                () => Consume(GenericWithNullableIntNotNull.IsNotNull)
            ),
            
            new BenchmarkAction(
                $"{nameof(GenericWithNullableIntNull)} '{nameof(GenericWithNullableIntNull.IsNull)}'",
                () => Consume(GenericWithNullableIntNull.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(GenericWithNullableIntNull)} '{nameof(GenericWithNullableIntNull.IsNotNull)}'",
                () => Consume(GenericWithNullableIntNull.IsNotNull)
            ),
            
            new BenchmarkAction(
                $"{nameof(ConstrainedWithIntNotNull)} '{nameof(ConstrainedWithIntNotNull.IsNull)}'",
                () => Consume(ConstrainedWithIntNotNull.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(ConstrainedWithIntNotNull)} '{nameof(ConstrainedWithIntNotNull.IsNotNull)}'",
                () => Consume(ConstrainedWithIntNotNull.IsNotNull)
            ),
            
            new BenchmarkAction(
                $"{nameof(ConstrainedWithIntNull)} '{nameof(ConstrainedWithIntNull.IsNull)}'",
                () => Consume(ConstrainedWithIntNull.IsNull)
            ),
            new BenchmarkAction(
                $"{nameof(ConstrainedWithIntNull)} '{nameof(ConstrainedWithIntNull.IsNotNull)}'",
                () => Consume(ConstrainedWithIntNull.IsNotNull)
            ),
        };
        
        public static ReadOnlySpan<BenchmarkAction> Get => Actions.AsSpan();
        
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private static void Consume<T>(T v) { }
    }
}
