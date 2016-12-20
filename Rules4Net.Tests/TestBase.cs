using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Engine;
using Rules4Net.Listener;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests
{
    public class TestBase
    {
        private IRuleStore Pool { get; set; }
        protected IRuleEngine Engine { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.Pool = MemoryRuleStore.Default;
            this.Engine = new RuleEngine(this.Pool);
        }

        [TestCleanup]
        public void End()
        {
            this.Clear();
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

    [Rule("fake.rule")]
    public class FakeRuleListener : IRuleListener
    {
        public void Handle(object data)
        {
            var dic = (IDictionary<string, object>)data;
            dic["Changed"] = true;
        }
    }

}
