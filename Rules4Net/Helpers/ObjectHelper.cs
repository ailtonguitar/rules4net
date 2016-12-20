using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static IEnumerable<Type> GetListeners()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(t => t.GetCustomAttributes(typeof(RuleAttribute), true).Any());
        }
    }
}
