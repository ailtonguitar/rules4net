using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rules4Net.Extensions {
    public static class ConcurrentBagHelper {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd) {
            foreach (var element in toAdd) {
                @this.Add(element);
            }
        }
    } //class
}
