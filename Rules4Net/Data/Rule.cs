using Rules4Net.Data.Filters;
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
        }

        public string Name { get; set; }
        public IList<Filter> Filters { get; set; }

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
    }
}
