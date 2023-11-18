using System.Diagnostics.CodeAnalysis;

namespace Notify.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DictionaryExtensions
    {
        public static void AddRangeOverride<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToBeIncremented, IDictionary<TKey, TValue> dictionaryToBeAdded)
        {
            dictionaryToBeAdded.ForEach(x => dictionaryToBeIncremented[x.Key] = x.Value);
        }

        public static void AddRangeNewOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToBeIncremented, IDictionary<TKey, TValue> dictionaryToBeAdded)
        {
            dictionaryToBeAdded.ForEach(x => 
            {
                if (!dictionaryToBeIncremented.ContainsKey(x.Key)) dictionaryToBeIncremented.Add(x.Key, x.Value); 
            });
        }

        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToBeIncremented, IDictionary<TKey, TValue> dictionaryToBeAdded)
        {
            dictionaryToBeAdded.ForEach(x => dictionaryToBeIncremented.Add(x.Key, x.Value));
        }

        public static bool ContainsKeys<TKey, TValue>(this IDictionary<TKey, TValue> diconary, IEnumerable<TKey> keys)
        {
            bool result = false;
            keys.ForEachOrBreak((x) => 
            { 
                result = diconary.ContainsKey(x); return result; 
            });
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static void ForEachOrBreak<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                bool result = func(item);
                if (result) break;
            }
        }
    }
}
