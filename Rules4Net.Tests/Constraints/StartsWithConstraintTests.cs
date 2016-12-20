using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class StartsWithConstraintTests : TestBase
    {
        [Fact]
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

            Assert.Equal(1, rules.Count());
        }

        [Fact]
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

            Assert.Equal(0, rules.Count());
        }
    }
}
