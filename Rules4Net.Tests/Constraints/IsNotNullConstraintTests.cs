using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class IsNotNullConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithIsNotNullConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new IsNotNullConstraint("Name"));

            this.AddRule(rule);


            var rules = this.Engine.Evaluate(new
            {
                Name = "John Doe"
            });

            Assert.Equal(1, rules.Count());
        }
    }
}
