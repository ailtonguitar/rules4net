using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rules4Net.Data;
using Rules4Net.Repository;
using System.Reflection;
using Rules4Net.Helpers;

namespace Rules4Net.Engine
{
    public class RuleEngine : IRuleEngine
    {
        private IRuleStore _pool;

        public RuleEngine(IRuleStore pool)
        {
            _pool = pool;
        }

        public IEnumerable<IRule> Evaluate(IDictionary<string, object> data)
        {
            return _pool.Get().Where(r => r.Filters.All(f => f.Evaluate(data)));
        }

        public IEnumerable<IRule> Evaluate(object data)
        {
            return this.Evaluate(ObjectHelper.ToDictionary(data));
        }
    }
}
