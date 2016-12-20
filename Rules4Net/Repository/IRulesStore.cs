using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Repository
{
    public interface IRuleStore
    {
        void AddRule(IRule rule);
        IEnumerable<IRule> Get();
        void Clear();
    }
}
