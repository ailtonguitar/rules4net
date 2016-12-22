using Rules4Net.Data.Constraints;
using Rules4Net.Tests.TestObjects.Financial;
using System.Collections.Generic;
using Xunit;

namespace Rules4Net.Tests.Constraints {
    public class ContainsConstraintTests : TestBase {
        #region With String
        [Fact]
        public void ShouldEvaluateStringValue() {
            var data = new Dictionary<string, object>() { { "myProperty", "Joao Paulo Lindgren" } };
            var sut = new ContainsConstraint("myProperty", "Lindgr");

            var result = sut.Evaluate(data);
            Assert.True(result);
        }

        [Fact]
        public void ShouldEvaluateAsFalseIfDataNotContainsValue() {
            var data = new Dictionary<string, object>() { { "myProperty", "Joao Paulo Lindgren" } };
            var sut = new ContainsConstraint("myProperty", "John");

            Assert.False(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsFalseAndNullValueData() {
            var data = new Dictionary<string, object>() { { "myProperty", null } };
            var sut = new ContainsConstraint("myProperty", "John");
            Assert.False(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsFalseWhenEmptyValueData() {
            var data = new Dictionary<string, object>() { { "myProperty", string.Empty } };
            var sut = new ContainsConstraint("myProperty", "John");
            Assert.False(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsFalseAndNullValueInTheConstraint() {
            var data = new Dictionary<string, object>() { { "myProperty", "Complete Phrase" } };
            var sut = new ContainsConstraint("myProperty", null);
            Assert.False(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsTrueWithGermanCulture() {
            var data = new Dictionary<string, object>() { { "myProperty", "Straße" } };
            using (InCulture("de-DE")) {
                var sut = new ContainsConstraint("myProperty", "Straß");
                Assert.True(sut.Evaluate(data));
            }
        }

        [Fact]
        public void ShouldEvaluateAsTrueWithTurkeyCulture() {
            var data = new Dictionary<string, object>() { { "myProperty", "DocumentInfo".ToLower() } };

            using (InCulture("tr-TR")) {
                var sut = new ContainsConstraint("myProperty", "Info");
                Assert.True(sut.Evaluate(data));
            }
        }

        #endregion

        #region With IEnumerable
        [Fact]
        public void ShouldEvaluateAgainstDictionaryValue() {
            var data = new Dictionary<string, object>() {
                                                { "myProperty", new Dictionary<string, string> {
                                                        { "hello", "world" },
                                                        { "hi", "there" }
                                                    }
                                                }
                                            };
            var sut = new ContainsConstraint("myProperty", new KeyValuePair<string, string>("hello", "world"));
            Assert.True(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAsFalseWhenNullAgainstListValue() {
            var data = new Dictionary<string, object>() { { "myProperty", new string[] { "hello", "world" } } };
            var sut = new ContainsConstraint("myProperty", null);
            Assert.False(sut.Evaluate(data));
        }


        [Fact]
        public void ShouldEvaluateAsFalseWhenNotFindAgainstListValue() {
            var data = new Dictionary<string, object>() { { "myProperty", new string[] { "hello", "world" } } };
            var sut = new ContainsConstraint("myProperty", "I'm");
            Assert.False(sut.Evaluate(data));
        }

        [Fact]
        public void ShouldEvaluateAgainstObjectListValue() {
            var data = new Dictionary<string, object>() { { "myProperty", new Money[] { new Money(12.3m, Currency.REAL), new Money(10.0m, Currency.REAL) } } };
            var sut = new ContainsConstraint("myProperty", new Money(10.0m, Currency.REAL));
            Assert.True(sut.Evaluate(data));
        }
        #endregion
    } //class
}
