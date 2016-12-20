using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Listener.Repository;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests
{
    [TestClass]
    public class RuleEngineTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRule()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithDynamicData()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "John Doe"
            });

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithAndClause()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            filter.Add(new EqualsConstraint("Email", "fake@fake.com"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";
            data["Email"] = "fake@fake.com";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithOrClause()
        {
            var rule = new Rule();
            var filter = rule.AddOrFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            filter.Add(new EqualsConstraint("Email", "fake@fake2.com"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";
            data["Email"] = "fake@fake.com";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());
        }


        [TestMethod]
        public void ShouldBePossibleEvaluateRuleAndFireListener()
        {
            ListenerRepository.Register(typeof(RuleEngineTests));

            var rule = new Rule();
            rule.Name = "fake.rule";
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            this.Engine.EvaluateAndFire(data);

            Assert.AreEqual(true, data["Changed"]);
        }
    }
}
