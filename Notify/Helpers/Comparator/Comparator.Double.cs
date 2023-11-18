namespace Notify
{
    public static partial class Comparator
    {

        public static class Double
        {
            public static bool GreaterThan(double valueToBeCompared, double referenceValue) => (valueToBeCompared > referenceValue);           
            public static bool GreaterOrEqualThan(double valueToBeCompared, double referenceValue) => (valueToBeCompared >= referenceValue);
            public static bool EqualTo(double valueToBeCompared, double referenceValue) => (valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(double valueToBeCompared, double referenceValue) => !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(double valueToBeCompared, double referenceValue) => !(valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(double valueToBeCompared, double referenceValue) => !(valueToBeCompared == referenceValue);

        }
    }
}
