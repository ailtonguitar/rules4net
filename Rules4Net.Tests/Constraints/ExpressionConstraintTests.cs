using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class ExpressionConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithExpressionConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();

            filter.Add(new ExpressionConstraint("Name", (o) => {
                return o.ToString().Length > 5;
            }));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Jane Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(1, rules.Count());

            data["Name"] = "Jane";
            
            rules = this.Engine.Evaluate(data);
            Assert.Equal(0, rules.Count());
        }
    }
}
