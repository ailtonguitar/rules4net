using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rules4Net.Extensions
{
    public static class ConcurrentBagExtensions
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
            {
                @this.Add(element);
            }
        }

        public static void Clear<T>(this ConcurrentBag<T> @this)
        {
            T result = default(T);

            while (!@this.IsEmpty)
                @this.TryTake(out result);
        }
    }
}
