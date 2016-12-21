using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Tests.TestObjects.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rules4Net.Tests.Constraints {
    public class EqualsConstraintTests : TestBase {
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

        [Fact]
        public void ShouldEvaluateBoolValue() {
            var fakeData = new Dictionary<string, object>() { { "myProperty", true  } };
            var sut = new EqualsConstraint("myProperty", true);
            
            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluatePrimitiveInteger() {            
            var fakeData = new Dictionary<string, object>() { { "myProperty", 18 } };
            var sut = new EqualsConstraint("myProperty", 18);
            
            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluateDecimalValue() {
            var fakeData = new Dictionary<string, object>() { { "myProperty", -18.4m } };
            var sut = new EqualsConstraint("myProperty", -18.4m);

            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluatePrimitiveDate() {
            var fakeData = new Dictionary<string, object>() { { "myProperty", new DateTime(2016, 12, 21) } };
            var sut = new EqualsConstraint("myProperty", new DateTime(2016, 12, 21));

            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluatePrimitiveChar() {
            var fakeData = new Dictionary<string, object>() { { "myProperty", 'C' } };
            var sut = new EqualsConstraint("myProperty", 'C');

            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluatePrimitiveString() {
            var fakeData = new Dictionary<string, object>() { { "myProperty", "John Doe" } };
            var sut = new EqualsConstraint("myProperty", "John Doe");

            var result = sut.Evaluate(fakeData);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluateByValueComplexTypeWithEqualsOverrided() {            
            var fakeData = new Dictionary<string, object>() { { "myProperty", new Money(12.3m, Currency.DOLAR) } };

            var sut = new EqualsConstraint("myProperty", new Money(12.3m, Currency.REAL));
            Assert.False(sut.Evaluate(fakeData));

            sut = new EqualsConstraint("myProperty", new Money(12.3m, Currency.DOLAR));
            Assert.True(sut.Evaluate(fakeData));
        }

        [Fact]
        public void ShouldEvaluateByReferenceComplexTypeWithoutEqualsOverrided() {
            var aComplexTypeWithNoEquals = new DummyClass(21);
            var fakeData = new Dictionary<string, object>() { { "myProperty", aComplexTypeWithNoEquals } };

            var sut = new EqualsConstraint("myProperty", new DummyClass(21));            
            Assert.False(sut.Evaluate(fakeData));

            sut = new EqualsConstraint("myProperty", aComplexTypeWithNoEquals);
            Assert.True(sut.Evaluate(fakeData));
        }
    } //class

    public class DummyClass {
        public int Value { get; set; }
        public DummyClass(int value) {
            this.Value = value;
        }
    }
}
