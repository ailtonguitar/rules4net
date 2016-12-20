using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Helpers
{
    public class ObjectHelper
    {
        public static IDictionary<string, object> ToDictionary(object data)
        {
            var properties = data.GetType().GetProperties();
            return properties.ToDictionary(p => p.Name, p => p.GetValue(data, null));
        }
    }
}
