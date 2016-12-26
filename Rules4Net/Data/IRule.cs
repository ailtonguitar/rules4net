using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Data
{
    public interface IRule
    {
        string Name { get; set; }
        IList<Filter> Filters { get; }
        IList<IRuleListener> Listeners { get; }
        void AddListener(IRuleListener listener);
        void AddListener<T>(Action<T> action);
        Filter Add(Filter filter);
        Filter AddAndFilter();
        Filter AddOrFilter();
    }
}
