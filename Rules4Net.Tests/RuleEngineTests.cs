using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests
{
    [TestClass]
    public class RuleEngineTests
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRule()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());

            pool.Clear();
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithAndClause()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            filter.Add(new EqualsConstraint("Email", "fake@fake.com"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";
            data["Email"] = "fake@fake.com";

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());

            pool.Clear();
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithOrClause()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddOrFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            filter.Add(new EqualsConstraint("Email", "fake@fake2.com"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";
            data["Email"] = "fake@fake.com";

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());

            pool.Clear();
        }
    }
}
