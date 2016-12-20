using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Filters
{
    public class AndFilter : Filter
    {
        public AndFilter()
            : base() { }

        public AndFilter(IRule rule)
            : base(rule)
        { }

        public AndFilter(IEnumerable<IConstraint> constraints) : base(constraints) {
        }

        public AndFilter(IRule rule, IEnumerable<IConstraint> constraints) : base(rule, constraints) {
        }

        public override bool Evaluate(IDictionary<string, object> data)
        {
            return this.Constraints.All(c => c.Evaluate(data));
        }
    }
}
