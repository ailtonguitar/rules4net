using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data.Constraints
{
    public class ExpressionConstraint : IConstraint
    {
        public virtual Func<object, bool> EvaluationFunction { get; protected set; }
        public string PropertyName { get; set; }

        protected ExpressionConstraint(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public ExpressionConstraint(string propertyName, Func<object, bool> func)
            : this(propertyName)
        {
            this.EvaluationFunction = func;
        }

        public bool Evaluate(IDictionary<string, object> obj)
        {
            var val = obj.ContainsKey(this.PropertyName) ? obj[this.PropertyName] : null;
            return this.EvaluationFunction(val);
        }
    }
}
