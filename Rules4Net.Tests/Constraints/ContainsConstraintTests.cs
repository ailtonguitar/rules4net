using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class ContainsConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithContainsConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new ContainsConstraint("Name", "John"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithContainsConstraintAndNotContainsValue()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new ContainsConstraint("Name", "John"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Fake User";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(0, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithContainsConstraintAndNotNullValue()
        {
            var data = new Dictionary<string, object>();
            data["Name"] = null;

            var contains = new ContainsConstraint("Name", "John");
            var result = contains.Evaluate(data);

            Assert.False(result);
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithContainsConstraintAndMissingProperty()
        {
            var data = new Dictionary<string, object>();
            var contains = new ContainsConstraint("Name", "John");
            var result = contains.Evaluate(data);

            Assert.False(result);
        }
    }
}
