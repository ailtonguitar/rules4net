using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests.TestObjects.Listeners
{
    public class FakeRuleListener : IRuleListener
    {
        public void Handle(object data)
        {
            var dic = (IDictionary<string, object>)data;
            dic["Changed"] = true;
        }
    }
}
