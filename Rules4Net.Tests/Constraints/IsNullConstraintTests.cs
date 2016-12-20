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
    public class IsNullConstraintTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithIsNullConstraint()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new IsNullConstraint("Name"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = (string)null
            });

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithIsNullConstraintWithNotPresentProperty()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new IsNullConstraint("Name"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new { });

            Assert.AreEqual(1, rules.Count());
        }

    }
}
