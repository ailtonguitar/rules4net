using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class IsTodayConstraint : IConstraint
    {
        private string _property;

        public IsTodayConstraint(string property)
        {
            this._property = property;
        }

        public virtual bool Evaluate(IDictionary<string, object> data)
        {
            if (!data.ContainsKey(_property) || !(data[_property] is DateTime))
                return false;

            var value = (DateTime)data[_property];

            if (value.Kind != DateTimeKind.Utc)
                value = value.ToUniversalTime();

            return value.Date.Equals(DateTime.UtcNow.Date);
        }
    }
}
