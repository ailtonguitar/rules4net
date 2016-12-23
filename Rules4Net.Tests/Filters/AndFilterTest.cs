using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Data.Filters;
using System.Collections.Generic;
using Xunit;

namespace Rules4Net.Tests.Filters {
    public class AndFilterTest {
        [Fact]
        public void ShouldBeAConstraint() {
            AndFilter sut = new AndFilter();
            Assert.IsAssignableFrom<IConstraint>(sut);
        }


        [Fact]
        public void ShouldBeComposableWithOthersFilters() {
            var aTrueFilter = new FakeTrueFilter();
            var sut = new AndFilter(new Filter[] { new AndFilter(new Filter[] { aTrueFilter }), new FakeTrueFilter() });
            Assert.True(sut.Evaluate(null));
            Assert.True(aTrueFilter.Called);
        }

    } //class

    public class FakeTrueFilter : Filter {
        public bool Called { get; set; } = false;
        public override bool Evaluate(IDictionary<string, object> data) {
            Called = true;
            return true;
        }
    }

    public class FakeFalseFilter : Filter {
        public bool Called { get; set; } = false;
        public override bool Evaluate(IDictionary<string, object> data) {
            Called = true;
            return false;
        }
    }
}
