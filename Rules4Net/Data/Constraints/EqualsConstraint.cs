using System.Collections.Generic;

namespace Rules4Net.Data.Constraints
{
    public class EqualsConstraint : IConstraint
    {
        private string _property;
        private object _value;

        public EqualsConstraint(string property, object value)
        {
            this._property = property;
            this._value = value;
        }

        public virtual bool Evaluate(IDictionary<string, object> data)
        {
            if (!data.ContainsKey(_property))
                return false;

            var value = data[_property];
            return value != null && value.Equals(this._value);
        }
    }
}
