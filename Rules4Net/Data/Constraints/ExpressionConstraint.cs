using System;
using System.Collections.Generic;

namespace Rules4Net.Data.Constraints {
    public class ExpressionConstraint : ExpressionConstraint<object> {
        public ExpressionConstraint(string propertyName, Func<object, bool> func) : base(propertyName, func) {
        }
    }

    public class ExpressionConstraint<T> : IConstraint {
        private readonly Func<T, bool> evaluationFunction;
        private readonly string propertyName;

        public ExpressionConstraint(string propertyName, Func<T, bool> func) {
            this.evaluationFunction = func;
            this.propertyName = propertyName;
        }

        public bool Evaluate(IDictionary<string, object> obj) {
            var val = obj.ContainsKey(propertyName) ? obj[propertyName] : null;
            if (val is T)
                return evaluationFunction((T)val);
            else
                return false;
        }
    } //class
}
