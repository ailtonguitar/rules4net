using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Constraints
{    
    public class EqualsConstraintTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithEqualsConstraint()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(1, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNotEqualValue()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Fake User";

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(0, rules.Count());
        }

        [Fact]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNullValue()
        {
            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));
            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = null;

            var rules = this.Engine.Evaluate(data);

            Assert.Equal(0, rules.Count());
        }
    }
}
