using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Repository
{
    public class MemoryPool : IRulesPool
    {
        private MemoryPool() { }

        private IList<IRule> _rules = new List<IRule>();

        public static IRulesPool Default = new MemoryPool();

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
