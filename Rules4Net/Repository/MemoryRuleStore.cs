using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Repository
{
    public class MemoryRuleStore : IRuleStore
    {
        private MemoryRuleStore() { }

        private IList<IRule> _rules = new List<IRule>();

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
            this._rules.Clear();
        }
    }
}
