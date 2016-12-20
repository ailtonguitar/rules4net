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
    public class IsNotNullConstraintTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithIsNotNullConstraint()
        {
            var rule = new Rule("MyRule");
            var filter = rule.AddAndFilter();
            filter.Add(new IsNotNullConstraint("Name"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "John Doe"
            });

            Assert.AreEqual(1, rules.Count());
        }
    }
}
