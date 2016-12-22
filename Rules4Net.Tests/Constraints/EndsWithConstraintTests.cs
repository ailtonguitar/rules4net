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
    public class EndssWithConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithEndssWithConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EndsWithConstraint("Name", "Doe"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "John Doe"
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithEndsWithConstraintAndOtherEndSubstring()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EndsWithConstraint("Name", "John"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = "Penelope"
            });

            Assert.Equal(0, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithEndsWithConstraintAndNullValue()
        {
            var constraint = new EndsWithConstraint("Name", "John");
            var result = constraint.Evaluate(ObjectHelper.ToDictionary(new
            {
                Name = (string)null
            }));

            Assert.False(result);
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithEndsWithConstraintAndMissingProperty()
        {
            var constraint = new EndsWithConstraint("Name", "John");
            var result = constraint.Evaluate(ObjectHelper.ToDictionary(new { }));

            Assert.False(result);
        }
    }
}
