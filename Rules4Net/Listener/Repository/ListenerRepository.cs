using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rules4Net.Listener.Repository
{
    public class ListenerRepository
    {
        internal static IDictionary<string, Type> _types = new Dictionary<string, Type>();

        static ListenerRepository()
        {
            Load();
        }

        public static IRuleListener GetListener(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            var type = GetListenerType(name);

            if (type == null)
                return null;

            return (IRuleListener)Activator.CreateInstance(type);
        }

        private static IEnumerable<RuleAttribute> GetRuleAttributes(Type t)
        {
            return t.GetCustomAttributes(true).OfType<RuleAttribute>();
        }

        public static Type GetListenerType(string name)
        {
            if (!_types.ContainsKey(name))
                return null;

            return _types[name];
        }

        public static void Load(Assembly assembly)
        {
            var types = assembly.GetTypes().SelectMany(t => GetRuleAttributes(t).Select(r => new
            {
                Name = r.Name,
                Type = t
            }));

            foreach (var t in types)
                _types[t.Name] = t.Type;
        }

        public static void Register(Type type)
        {
            Load(type.Assembly);
        }

        private static void Load()
        {
            Load(Assembly.GetExecutingAssembly());
            Load(Assembly.GetCallingAssembly());
        }
    }
}
