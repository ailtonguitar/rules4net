using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Listeners
{
    public class ExpressionListenerTests : TestBase
    {
        [Fact]
        public void ShouldBePossibleEvaluateRuleAndFireExpressionListener()
        {
            var rule = new Rule();
            rule.Name = "fake.rule";

            rule.AddListener<IDictionary<string, object>>((o) =>
            {
                o["Email"] = "fake@fake.com";
            });

            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            this.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            this.Engine.EvaluateAndFire(data);

            Assert.Equal("fake@fake.com", data["Email"]);
        }
    }
}
