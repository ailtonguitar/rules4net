using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests.Constraints
{
    [TestClass]
    public class EqualsConstraintTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithEqualsConstraint()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNotEqualValue()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Fake User";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(0, rules.Count());
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNullValue()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = null;

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(0, rules.Count());
        }
    }
}
