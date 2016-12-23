using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rules4Net.Tests.Filters {
    public class OrFilterTest {
        [Fact]
        public void ShouldBeAConstraint() {
            var sut = new OrFilter(new Rule());
            Assert.IsAssignableFrom<IConstraint>(sut);
        }
        
        [Fact]
        public void ShouldBeComposableWithOthersFilters() {
            var aFalseFilter = new FakeFalseFilter();
            var sut = new OrFilter(new Filter[] { new OrFilter(new Filter[] { aFalseFilter }), new FakeTrueFilter() });
            Assert.True(sut.Evaluate(null));
            Assert.True(aFalseFilter.Called);
        }
    }    
}
