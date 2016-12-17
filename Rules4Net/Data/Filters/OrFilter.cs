using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Filters
{
    public class OrFilter : Filter
    {
        public OrFilter(IRule rule)
            : base(rule)
        { }

        public override bool Evaluate(IDictionary<string, object> data)
        {
            return this.Constraints.Any(c => c.Evaluate(data));
        }
    }
}
