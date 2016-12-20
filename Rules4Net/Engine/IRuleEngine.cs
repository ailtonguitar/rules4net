using Rules4Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Engine
{
    public interface IRuleEngine
    {
        IEnumerable<IRule> Evaluate(IDictionary<string, object> data);
        IEnumerable<IRule> Evaluate(object data);
    }
}
