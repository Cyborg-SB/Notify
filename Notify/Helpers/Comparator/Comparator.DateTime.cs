namespace Notify
{
    public static partial class Compator
    {

        public static class DateTime
        {
            public static bool IsWeekend(System.DateTime valueToBeCompared) =>
                ((valueToBeCompared.DayOfWeek == DayOfWeek.Saturday) || 
                (valueToBeCompared.DayOfWeek ==  DayOfWeek.Sunday));
            public static bool IsNotWeekend(System.DateTime valueToBeCompared) =>
                !IsWeekend(valueToBeCompared);
            public static bool IsSameDayOfWeek(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
                (valueToBeCompared.DayOfWeek == referenceValue.DayOfWeek);
            public static bool IsNotSameDayOfWeek(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
               !IsSameDayOfWeek(valueToBeCompared, referenceValue);
            public static bool IsSameDate(System.DateTime valueToBeCompared, System.DateTime referenceValue) => 
                (valueToBeCompared.Date == referenceValue.Date);
            public static bool IsNotSameDate(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
               !IsSameDate(valueToBeCompared, referenceValue);
            public static bool EqualTo(System.DateTime valueToBeCompared, System.DateTime referenceValue) => 
                (valueToBeCompared == referenceValue);
            public static bool GreaterThan(System.DateTime valueToBeCompared, System.DateTime referenceValue) => 
                (valueToBeCompared > referenceValue);
            public static bool GreaterOrEqualThan(System.DateTime valueToBeCompared, System.DateTime referenceValue) => 
                (valueToBeCompared >= referenceValue);
            public static bool NotEqualTo(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
                !(valueToBeCompared == referenceValue);
            public static bool NotGreaterThan(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
                !(valueToBeCompared > referenceValue);
            public static bool NotGreaterOrEqualThan(System.DateTime valueToBeCompared, System.DateTime referenceValue) =>
                !(valueToBeCompared >= referenceValue);
        }
    }
}
