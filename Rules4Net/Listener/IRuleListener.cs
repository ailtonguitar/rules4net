using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Listener
{
    public interface IRuleListener
    {
        void Handle(object data);
    }
}
