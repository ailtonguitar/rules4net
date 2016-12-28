using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class GreaterOrEqualConstraint : IConstraint
    {
        private string _property;
        private object _value;

        public GreaterOrEqualConstraint(string property, object value)
        {
            this._property = property;
            this._value = value;
        }

        public virtual bool Evaluate(IDictionary<string, object> data)
        {
            var value = data.ContainsKey(_property) ? data[_property] : null;

            if (value == null)
                return false;

            if (value.GetType() != this._value.GetType())
                return false;

            var comparable = value as IComparable;

            return comparable.CompareTo(this._value) >= 0;
        }
    }
}
