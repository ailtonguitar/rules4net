using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Extensions {
    public static class IEnumerableExtensions {
        public static bool Contains(this IEnumerable @this, object value) {            
            foreach (var item in @this) {
                if(item.Equals(value))
                    return true;
            }
            return false;
        }
    } //class
}
