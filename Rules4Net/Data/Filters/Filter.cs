using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data
{
    public abstract class Filter
    {
        protected Filter(IRule rule)
        {
            this.Rule = rule;
            this.Constraints = new List<IConstraint>();
        }

        public IRule Rule { get; internal set; }
        public IList<IConstraint> Constraints { get; set; }

        public Filter Add(IConstraint constraint)
        {
            this.Constraints.Add(constraint);
            return this;
        }

        public abstract bool Evaluate(IDictionary<string, object> data);
    }
}
