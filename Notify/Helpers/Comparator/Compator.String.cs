namespace Notify
{
    public static partial class Compator
    {

        public static class String
        {
            public static bool HasLengthGreaterThan(string valueToBeCompared, int referenceValue) => (valueToBeCompared.Length > referenceValue);
            public static bool HasLengthGreaterTo(string valueToBeCompared, string referenceValue) => (valueToBeCompared.Length > referenceValue.Length);
            public static bool HasLengthGreaterOrEqualThan(string valueToBeCompared, int referenceValue) => (valueToBeCompared.Length >= referenceValue);
            public static bool HasLengthGreaterOrEqualTo(string valueToBeCompared, string referenceValue) => (valueToBeCompared.Length >= referenceValue.Length);
            public static bool HasLengthEqualTo(string valueToBeCompared, int referenceValue) => (valueToBeCompared.Length == referenceValue);
            public static bool HasLengthEqualTo(string valueToBeCompared, string referenceValue) => (valueToBeCompared.Length == referenceValue.Length);
            public static bool HasContentEqualTo(string valueToBeCompared, string referenceValue) => (HasLengthEqualTo(valueToBeCompared, referenceValue) && string.Compare(valueToBeCompared, referenceValue, StringComparison.Ordinal) == 0);
            public static bool HasContentEqualToIgnoringCase(string valueToBeCompared, string referenceValue) => (HasLengthEqualTo(valueToBeCompared, referenceValue) && string.Compare(valueToBeCompared, referenceValue, StringComparison.OrdinalIgnoreCase) == 0);
            public static bool IsNull(string valueToBeCompared) => (valueToBeCompared is null);
            public static bool HasLengthNotGreaterThan(string valueToBeCompared, int referenceValue) => !(valueToBeCompared.Length > referenceValue);
            public static bool HasLengthNotGreaterTo(string valueToBeCompared, string referenceValue) => !(valueToBeCompared.Length > referenceValue.Length);
            public static bool HasLengthNotGreaterOrEqualThan(string valueToBeCompared, int referenceValue) => !(valueToBeCompared.Length >= referenceValue);
            public static bool HasLengthNotGreaterOrEqualTo(string valueToBeCompared, string referenceValue) => !(valueToBeCompared.Length >= referenceValue.Length);
            public static bool HasLengthNotEqualTo(string valueToBeCompared, int referenceValue) => !(valueToBeCompared.Length == referenceValue);
            public static bool HasLengthNotEqualTo(string valueToBeCompared, string referenceValue) => !(valueToBeCompared.Length == referenceValue.Length);
            public static bool HasContentNotEqualTo(string valueToBeCompared, string referenceValue) => !(HasLengthEqualTo(valueToBeCompared, referenceValue) && string.Compare(valueToBeCompared, referenceValue, StringComparison.Ordinal) == 0);
            public static bool HasContentNotEqualToIgnoringCase(string valueToBeCompared, string referenceValue) => !(HasLengthEqualTo(valueToBeCompared, referenceValue) && string.Compare(valueToBeCompared, referenceValue, StringComparison.OrdinalIgnoreCase) == 0);
            public static bool IsNotNull(string valueToBeCompared) => (valueToBeCompared is not null);
        }
    }
}
