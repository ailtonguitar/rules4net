using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Strategies
{
    public class RuleEvaluationStrategiesTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleWithCustomStrategy()
        {
            var rule = new Rule();
            rule.Name = "fake.rule";

            rule.AddAndFilter().Add(new EqualsConstraint("Name", "John Doe"));

            this.AddRule(rule);

            var data = new
            {
                Name = "John Doe"
            };

            Assert.NotEmpty(this.Engine.Evaluate(data));

            var customEngine = new RuleEngine(this.Pool, new EmptyRuleStrategy());
            Assert.Empty(customEngine.Evaluate(data));
        }
    }

    public class EmptyRuleStrategy : IRuleEvaluationStrategy
    {
        public IEnumerable<IRule> Evaluate(IEnumerable<IRule> rules, IDictionary<string, object> data)
        {
            return Enumerable.Empty<IRule>();
        }
    }
}
