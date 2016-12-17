using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Filters
{
    public class AndFilter : Filter
    {
        public AndFilter(IRule rule)
            : base(rule)
        { }

        public override bool Evaluate(IDictionary<string, object> data)
        {
            return this.Constraints.All(c => c.Evaluate(data));
        }
    }
}
