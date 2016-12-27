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
    public class IsTodayConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithIsTodayConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new IsTodayConstraint("Birthday"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Birthday = DateTime.Now
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithIsTodayConstraintWhenDateIsNotToday()
        {
            var data = new { Birthday = DateTime.Now.AddDays(-10) };
            var constraint = new IsTodayConstraint("Birthday");
            var result = constraint.Evaluate(ObjectHelper.ToDictionary(data));
            Assert.False(result);
        }
    }
}
