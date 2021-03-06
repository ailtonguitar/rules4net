﻿using Rules4Net.Data;
using Rules4Net.Engine;
using Rules4Net.Listener;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests
{
    public class TestBase
    {
        protected IRuleStore Pool { get; set; }
        protected IRuleEngine Engine { get; set; }

        public TestBase() {
            this.Pool = new MemoryRuleStore();
            this.Engine = new RuleEngine(this.Pool);
        }

        protected IDisposable InCulture(CultureInfo cultureInfo) {
            return new LanguageContext(cultureInfo);
        }
        protected IDisposable InCulture(string culture) {
            return new LanguageContext(new CultureInfo(culture));
        }

        protected void AddRule(IRule rule)
        {
            this.Pool.AddRule(rule);
        }

        private void Clear()
        {
            this.Pool.Clear();
        }
    }
}
