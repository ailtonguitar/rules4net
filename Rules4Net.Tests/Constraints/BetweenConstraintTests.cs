using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{
    public class BetweenConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithBetweenConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new BetweenConstraint("Age", 12, 18));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Age = 13
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithBetweenConstraintAndValueOutOfRange()
        {
            var data = ObjectHelper.ToDictionary(new
            {
                Age = 19
            });

            var constraint = new BetweenConstraint("Age", 12, 18);
            Assert.False(constraint.Evaluate(data));
        }
    }
}
