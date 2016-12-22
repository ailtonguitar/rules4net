using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Tests.TestObjects.Financial;
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
        public void ShouldEvaluateWithUntypedExpression() {
            var data = new Dictionary<string, object> { { "Name", "Jane Doe" } };            

            var sut = new ExpressionConstraint("Name", (o) => {
                return o.ToString().Length > 5;
            });

            Assert.True(sut.Evaluate(data));            

            data["Name"] = "Jane";
            Assert.False(sut.Evaluate(data));
        }        

        [Fact]
        public void ShouldEvaluateWithTypedExpression() {
            var data = new Dictionary<string, object>() { { "Debt", new Money(10.0m, Currency.REAL) } };            

            var sut = new ExpressionConstraint<Money>("Debt", (o) => {
                return o.Amount > 12.3m;
            });

            Assert.False(sut.Evaluate(data));
            
            sut = new ExpressionConstraint<Money>("Debt", (o) => {
                return o.Amount > 9.3m;
            });
            Assert.True(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsFalseIfExpressionIsNull() {
            var data = new Dictionary<string, object>() { { "Name", "Jhon Doe" } };
            var sut = new ExpressionConstraint<Money>("Debt", null);
            Assert.False(sut.Evaluate(data));
        }
    } //class
}
