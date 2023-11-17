namespace Notify
{
    public static partial class Comparator
    {

        public static class Decimal
        {
            public static bool GreaterThan(decimal valueToBeCompared, decimal referenceValue) => 
                (valueToBeCompared > referenceValue);
            public static bool GreaterOrEqualThan(decimal valueToBeCompared, decimal referenceValue) => 
                (valueToBeCompared >= referenceValue);
            public static bool EqualTo(decimal valueToBeCompared, decimal referenceValue) => 
                (valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(decimal valueToBeCompared, decimal referenceValue) => 
                !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(decimal valueToBeCompared, decimal referenceValue) => 
                !(valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(decimal valueToBeCompared, decimal referenceValue) => 
                !(valueToBeCompared == referenceValue);
        }
    }
}
