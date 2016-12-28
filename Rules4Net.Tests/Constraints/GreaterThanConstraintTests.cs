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
    public class GreaterThanConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithGreaterThanConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new GreaterThanConstraint("Age", 18));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Age = 19
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterThanConstraintAndValueIsEqualsToConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 18 });
            var constraint = new GreaterThanConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterThanConstraintAndValueHasAnotherType()
        {
            var data = ObjectHelper.ToDictionary(new { Age = "Older" });
            var constraint = new GreaterThanConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterThanConstraintAndValueIsLessThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 17 });
            var constraint = new GreaterThanConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterThanConstraintAndPropertyNotExists()
        {
            var data = ObjectHelper.ToDictionary(new { });
            var constraint = new GreaterThanConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedTrueWhenEvaluateGreaterThanConstraintAndValueIsADate()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(1) });
            var constraint = new GreaterThanConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterThanConstraintAndValueIsADateLessThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(-1) });
            var constraint = new GreaterThanConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }
    }
}
