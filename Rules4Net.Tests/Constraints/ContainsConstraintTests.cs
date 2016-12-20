﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests.Constraints
{
    [TestClass]
    public class ContainsConstraintTests : TestBase
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithContainsConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new ContainsConstraint("Name", "John"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithContainsConstraintAndNotContainsValue()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new ContainsConstraint("Name", "John"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Fake User";

            var rules = this.Engine.Evaluate(data);

            Assert.AreEqual(0, rules.Count());
        }
    }
}
