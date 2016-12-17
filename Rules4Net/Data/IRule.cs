using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data
{
    public interface IRule
    {
        string Name { get; set; }
        IList<Filter> Filters { get; set; }
        Filter Add(Filter filter);
        Filter AddAndFilter();
        Filter AddOrFilter();
    }
}
