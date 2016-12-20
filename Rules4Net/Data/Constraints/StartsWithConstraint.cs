using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class StartsWithConstraint : ExpressionConstraint
    {
        public StartsWithConstraint(string property, string value)
            : base(property, (o) =>
            {
                return o.ToString().StartsWith(value);
            }) { }
    }
}
