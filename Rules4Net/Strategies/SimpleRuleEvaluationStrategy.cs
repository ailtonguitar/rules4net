using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Strategies
{
    public class SimpleRuleEvaluationStrategy : IRuleEvaluationStrategy
    {
        public IEnumerable<IRule> Evaluate(IEnumerable<IRule> rules, 
            IDictionary<string, object> data)
        {
            return rules.Where(r => r.Filters.All(f => f.Evaluate(data)));
        }
    }
}
