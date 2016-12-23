using Rules4Net.Extensions;
using System;
using System.Collections;
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

            if (this._value == null)
                return false;

            var baseData = data[_property];
            if (baseData is string) {
                return baseData.ToString().ToLowerInvariant().Contains(this._value.ToString().ToLowerInvariant());
            } else if (baseData is IEnumerable) {
                var enumerable = baseData as IEnumerable;
                return enumerable.Contains(this._value);                
            } else {
                return false;
            }
        }
    } //class
}
