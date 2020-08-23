using System.Diagnostics.CodeAnalysis;
using BigSolution.Bootstrap.Utilities;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Components.Alerts
{
    public class AlertWrapperFixture
    {
        [Theory]
        [InlineData(Color.None, "alert")]
        [InlineData(Color.Active, "alert alert-active")]
        [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
        public void CssClassWellFormattedForColor(Color color, string expectedCssClass)
        {
            _ = new AlertWrapper { Color = color }.CssClasses.Should().Be(expectedCssClass);
        }
    }
}
