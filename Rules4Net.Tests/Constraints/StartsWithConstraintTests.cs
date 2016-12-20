using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests.Constraints
{
    [TestClass]
    public class StartsWithConstraintTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithStartsWithConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new StartsWithConstraint("Name", "John"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "John Doe"
            });

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithStartsWithConstraintAndOtherStartSubstring()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new StartsWithConstraint("Name", "John"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "ohn"
            });

            Assert.AreEqual(0, rules.Count());
        }
    }
}
