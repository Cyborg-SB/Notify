namespace Notify
{
    public static partial class Compator
    {

        public static class Long
        {
            public static bool GreaterThan(long valueToBeCompared, long referenceValue) => (valueToBeCompared > referenceValue);           
            public static bool GreaterOrEqualThan(long valueToBeCompared, long referenceValue) => (valueToBeCompared >= referenceValue);
            public static bool EqualTo(long valueToBeCompared, long referenceValue) => (valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(long valueToBeCompared, long referenceValue) => !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(long valueToBeCompared, long referenceValue) => !(valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(long valueToBeCompared, long referenceValue) => !(valueToBeCompared == referenceValue);    

        }
    }
}
