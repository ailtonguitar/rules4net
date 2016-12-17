using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public interface IConstraint
    {
        bool Evaluate(IDictionary<string, object> data);
    }
}
