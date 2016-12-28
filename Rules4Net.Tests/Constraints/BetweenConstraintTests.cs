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

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithBetweenConstraintAndPropertyMissing()
        {
            var data = ObjectHelper.ToDictionary(new { });
            var constraint = new BetweenConstraint("Age", 12, 18);
            Assert.False(constraint.Evaluate(data));
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithBetweenConstraintWhenPropertyIsNull()
        {
            var data = ObjectHelper.ToDictionary(new { Age = (int?)null });
            var constraint = new BetweenConstraint("Age", 12, 18);
            Assert.False(constraint.Evaluate(data));
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithBetweenConstraintWhenPropertyHasOtherType()
        {
            var data = ObjectHelper.ToDictionary(new { Age = "Older" });
            var constraint = new BetweenConstraint("Age", 12, 18);
            Assert.False(constraint.Evaluate(data));
        }

        [Fact]
        public void ShouldNotBePossibleCreateBetweenConstraintWithDifferentTypes()
        {
            Assert.Throws<ArgumentException>(() => new BetweenConstraint("Age", 12, DateTime.UtcNow));
        }

        [Fact]
        public void ShouldNotBePossibleCreateBetweenConstraintWithNullPropertyName()
        {
            Assert.Throws<ArgumentNullException>(() => new BetweenConstraint(null, DateTime.MinValue, DateTime.UtcNow));
        }

        [Fact]
        public void ShouldNotBePossibleCreateBetweenConstraintWithNullLowerBound()
        {
            Assert.Throws<ArgumentNullException>(() => new BetweenConstraint("Age", null, DateTime.UtcNow));
        }

        [Fact]
        public void ShouldNotBePossibleCreateBetweenConstraintWithNullUpperBound()
        {
            Assert.Throws<ArgumentNullException>(() => new BetweenConstraint("Age", DateTime.MinValue, null));
        }
    }
}
