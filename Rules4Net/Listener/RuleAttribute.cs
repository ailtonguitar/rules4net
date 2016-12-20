using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Listener
{
    public class RuleAttribute : Attribute
    {
        public string Name { get; set; }

        public RuleAttribute(string name)
        {
            this.Name = name;
        }
    }
}
