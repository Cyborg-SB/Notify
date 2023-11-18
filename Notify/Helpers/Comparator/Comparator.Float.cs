namespace Notify
{
    public static partial class Comparator
    {

        public static class Float
        {
            public static bool GreaterThan(float valueToBeCompared, float referenceValue) => 
                (valueToBeCompared > referenceValue);
            public static bool GreaterOrEqualThan(float valueToBeCompared, float referenceValue) => 
                (valueToBeCompared >= referenceValue);
            public static bool EqualTo(float valueToBeCompared, float referenceValue) => 
                (valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(float valueToBeCompared, float referenceValue) => 
                !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(float valueToBeCompared, float referenceValue) => 
                !(valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(float valueToBeCompared, float referenceValue) => 
                !(valueToBeCompared == referenceValue);
        }
    }
}
