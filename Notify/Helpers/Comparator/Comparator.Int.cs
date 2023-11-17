namespace Notify
{
    public static partial class Comparator
    {

        public static class Int
        {
            public static bool GreaterThan(int valueToBeCompared, int referenceValue) => (valueToBeCompared > referenceValue);           
            public static bool GreaterOrEqualThan(int valueToBeCompared, int referenceValue) => (valueToBeCompared >= referenceValue);
            public static bool EqualTo(int valueToBeCompared, int referenceValue) => (valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(int valueToBeCompared, int referenceValue) => !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(int valueToBeCompared, int referenceValue) => !(valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(int valueToBeCompared, int referenceValue) => !(valueToBeCompared == referenceValue);

        }
    }
}
