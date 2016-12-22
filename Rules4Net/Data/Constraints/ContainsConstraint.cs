using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class ContainsConstraint : IConstraint
    {
        private string _property;
        private object _value;

        public ContainsConstraint(string property, object value)
        {
            this._property = property;
            this._value = value;
        }

        public virtual bool Evaluate(IDictionary<string, object> data)
        {
            if (!data.ContainsKey(_property) || data[_property] == null || string.IsNullOrEmpty(data[_property].ToString()))
                return false;

            return data[_property].ToString().ToLower().Contains(this._value.ToString().ToLower());
        }
    }
}
