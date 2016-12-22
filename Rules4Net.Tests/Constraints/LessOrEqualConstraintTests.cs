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
    public class LessOrEqualConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithLessOrEqualConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new LessOrEqualConstraint("Age", 18));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Age = 17
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldBeReturnedTrueWhenEvaluateLessOrEqualConstraintAndValueIsEqualsToConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 18 });
            var constraint = new LessOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateLessOrEqualConstraintAndValueIsGreaterThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 20 });
            var constraint = new LessOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateLessOrEqualConstraintAndPropertyNotExists()
        {
            var data = ObjectHelper.ToDictionary(new { });
            var constraint = new LessOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedTrueWhenEvaluateLessOrEqualConstraintAndValueIsADate()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(-1) });
            var constraint = new LessOrEqualConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateLessOrEqualConstraintAndValueIsADateGreaterThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(1) });
            var constraint = new LessOrEqualConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }
    }
}
