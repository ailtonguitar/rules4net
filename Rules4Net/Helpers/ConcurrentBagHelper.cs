using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Helpers {
    public static class ConcurrentBagHelper {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd) {
            foreach (var element in toAdd) {
                @this.Add(element);
            }
        }
    } //class
}
