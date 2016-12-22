using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class EndsWithConstraint : ExpressionConstraint
    {
        public EndsWithConstraint(string property, string value)
            : base(property, (o) =>
            {
                return o != null && o.ToString().EndsWith(value);
            })
        { }
    }
}
