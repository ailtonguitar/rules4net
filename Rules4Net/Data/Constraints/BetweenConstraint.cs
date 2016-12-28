using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class BetweenConstraint : IConstraint
    {
        private GreaterOrEqualConstraint lowerBound;
        private LessOrEqualConstraint upperBound;

        public BetweenConstraint(string property, object lower, object upper)
        {
            this.lowerBound = new GreaterOrEqualConstraint(property, lower);
            this.upperBound = new LessOrEqualConstraint(property, upper);
        }

        public bool Evaluate(IDictionary<string, object> data)
        {
            return this.lowerBound.Evaluate(data) && this.upperBound.Evaluate(data);
        }
    }
}
