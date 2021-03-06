﻿using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{
    public class GreaterOrEqualConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithGreaterOrEqualConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new GreaterOrEqualConstraint("Age", 18));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Age = 19
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldBeReturnedTrueWhenEvaluateGreaterOrEqualConstraintAndValueIsEqualsToConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 18 });
            var constraint = new GreaterOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterOrEqualConstraintAndValueIsLessThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Age = 17 });
            var constraint = new GreaterOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterOrEqualConstraintAndPropertyNotExists()
        {
            var data = ObjectHelper.ToDictionary(new { });
            var constraint = new GreaterOrEqualConstraint("Age", 18);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }

        [Fact]
        public void ShouldBeReturnedTrueWhenEvaluateGreaterOrEqualConstraintAndValueIsADate()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(1) });
            var constraint = new GreaterOrEqualConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeReturnedFalseWhenEvaluateGreaterOrEqualConstraintAndValueIsADateLessThanConstraint()
        {
            var data = ObjectHelper.ToDictionary(new { Deadline = DateTime.Today.AddDays(-1) });
            var constraint = new GreaterOrEqualConstraint("Deadline", DateTime.Today);
            var result = constraint.Evaluate(data);
            Assert.False(result);
        }
    }
}
