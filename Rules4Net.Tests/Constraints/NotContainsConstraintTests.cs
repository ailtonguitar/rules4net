using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class NotContainsConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithNotContainsConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new NotContainsConstraint("Name", "John"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Jane Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithNotContainsConstraintAndContainsValue()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new NotContainsConstraint("Name", "John"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(0, rules.Count());
        }
    }
}
