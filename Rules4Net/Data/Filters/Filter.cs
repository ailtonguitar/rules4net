using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data
{
    public abstract class Filter
    {
        protected Filter() {            
            this.Constraints = new List<IConstraint>();
        }

        protected Filter(IEnumerable<IConstraint> constraints) : this() {
            this.Constraints = constraints;
        }

        protected Filter(IRule rule, IEnumerable<IConstraint> constraints) : this(rule) {
            this.Constraints = constraints;
        }

        protected Filter(IRule rule) : this() {
            this.Rule = rule;
        }

        public IRule Rule { get; internal set; }
        public IEnumerable<IConstraint> Constraints { get; set; }

        /// <summary>
        /// Create a new IEnumerable of constraints every time to avoid concurrence problems. Initialize it via constructor should be the prefered way.
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public Filter Add(IConstraint constraint) {
            this.Constraints = this.Constraints.Concat(new[] { constraint });
            return this;
        }

        public abstract bool Evaluate(IDictionary<string, object> data);
    }
}
