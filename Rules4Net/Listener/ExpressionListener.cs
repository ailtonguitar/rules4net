using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Listener
{
    internal class ExpressionListener : ExpressionListener<object>
    {
        public ExpressionListener(Action<object> action) : base(action)
        {
        }
    }

    internal class ExpressionListener<T> : IRuleListener
    {
        private Action<T> _action;

        public ExpressionListener(Action<T> action)
        {
            this._action = action;
        }

        public void Handle(object data)
        {
            if(data is T)
                this._action((T)data);
        }
    }
}
