using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Strategies
{
    public interface IRuleEvaluationStrategy
    {
        IEnumerable<IRule> Evaluate(IEnumerable<IRule> rules, 
            IDictionary<string, object> data);
    }
}
