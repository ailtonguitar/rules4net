using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class IsNotNullConstraint : IsNullConstraint
    {
        public IsNotNullConstraint(string property) : base(property) { }

        public override bool Evaluate(IDictionary<string, object> data)
        {
            return !base.Evaluate(data);
        }
    }
}
