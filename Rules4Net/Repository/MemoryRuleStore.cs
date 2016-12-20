using Rules4Net.Data;
using Rules4Net.Helpers;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rules4Net.Repository {
    public class MemoryRuleStore : IRuleStore
    {
        private ConcurrentBag<IRule> _rules = new ConcurrentBag<IRule>();        

        public MemoryRuleStore(IEnumerable<IRule> rules) {
            _rules.AddRange(rules);
        }

        public MemoryRuleStore() { }

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }

        public void AddRule(IEnumerable<IRule> rules) {
            _rules.AddRange(rules);
        }

        public IEnumerable<IRule> Get()
        {
            return this._rules;
        }

        public void Clear()
        {
            IRule result = null;

            while (!this._rules.IsEmpty)
                this._rules.TryTake(out result);
        }
    }
}
