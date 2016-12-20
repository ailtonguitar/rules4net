using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class IsNullConstraint : IConstraint
    {
        private string _property;

        public IsNullConstraint(string property)
        {
            this._property = property;
        }

        public virtual bool Evaluate(IDictionary<string, object> data)
        {
            if (!data.ContainsKey(this._property) || data[_property] == null)
                return true;

            return false;
        }
    }
}
