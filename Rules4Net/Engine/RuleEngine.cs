using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rules4Net.Data;
using Rules4Net.Repository;

namespace Rules4Net.Engine
{
    public class RuleEngine : IRuleEngine
    {
        private IRulesPool _pool;

        public RuleEngine(IRulesPool pool)
        {
            _pool = pool;
        }

        public IEnumerable<IRule> Evaluate(IDictionary<string, object> data)
        {
            var rules = _pool.Get();
            return rules.Where(r => r.Filters.All(f => f.Evaluate(data)));
        }

        public IEnumerable<IRule> Evaluate(dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
