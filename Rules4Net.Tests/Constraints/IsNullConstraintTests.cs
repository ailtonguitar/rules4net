using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class IsNullConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithIsNullConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new IsNullConstraint("Name"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new
            {
                Name = (string)null
            });

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldBePossibleEvaluateRuleWithIsNullConstraintWithNotPresentProperty()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new IsNullConstraint("Name"));

            this.AddRule(rule);

            var rules = this.Engine.Evaluate(new { });

            Assert.Equal(1, rules.Count());
        }

    }
}
