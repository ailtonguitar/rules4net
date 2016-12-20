using Rules4Net.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Repository
{
    public class MemoryRuleStore : IRuleStore
    {
        private MemoryRuleStore() { }

        private ConcurrentBag<IRule> _rules = new ConcurrentBag<IRule>();

        public static IRuleStore Default = new MemoryRuleStore();

        public void AddRule(Data.IRule rule)
        {
            this._rules.Add(rule);
        }

        public IEnumerable<Data.IRule> Get()
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
