using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Layout
{
    public class GridColumnWidthFixture
    {
        [Fact]
        public void CastUintSucceeds()
        {
            ((GridColumnWidth) 6).Should().BeOfType<GridColumnFixedWidth>().Subject.Width.Should().Be(6);
        }

        [Theory]
        [MemberData(nameof(GetValidString))]
        public void CastStringSucceeds(string value, Type expectedType)
        {
            ((GridColumnWidth) value).Should().NotBeNull().And.BeOfType(expectedType);
        }

        public static IEnumerable<object[]> GetValidString()
        {
            yield return new object[] { "", typeof(GridColumnDefaultWidth) };
            yield return new object[] { null, typeof(GridColumnDefaultWidth) };
            yield return new object[] { "auto", typeof(GridColumnAutoWidth) };
            yield return new object[] { "AUTO", typeof(GridColumnAutoWidth) };
            yield return new object[] { "6", typeof(GridColumnFixedWidth) };
        }
    }
}
