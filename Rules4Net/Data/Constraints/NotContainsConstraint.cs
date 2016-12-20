using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class NotContainsConstraint : ContainsConstraint
    {
        public NotContainsConstraint(string property, object value) : base(property, value) { }

        public override bool Evaluate(IDictionary<string, object> data)
        {
            return !base.Evaluate(data);
        }
    }
}
