using Rules4Net.Data.Filters;
using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data
{
    public class Rule : IRule
    {
        public Rule()
        {
            this.Filters = new List<Filter>();
            this._listeners = new List<IRuleListener>();
        }

        private IList<IRuleListener> _listeners;

        public string Name { get; set; }
        public IList<Filter> Filters { get; private set; }

        public Filter Add(Filter filter)
        {
            filter.Rule = this;
            this.Filters.Add(filter);
            return filter;
        }

        public Filter AddAndFilter()
        {
            return this.Add(new AndFilter(this));
        }

        public Filter AddOrFilter()
        {
            return this.Add(new OrFilter(this));
        }

        public IList<IRuleListener> Listeners
        {
            get { return this.Listeners; }
        }

        public void AddListener<T>(Action<T> action)
        {
            this._listeners.Add(new ExpressionListener<T>(action));
        }

        public void AddListener(IRuleListener listener)
        {
            this._listeners.Add(listener);
        }
    }
}
