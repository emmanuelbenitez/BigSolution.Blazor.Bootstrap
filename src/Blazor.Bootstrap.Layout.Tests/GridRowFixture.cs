using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Layout
{
    public class GridRowFixture
    {
        [Theory]
        [InlineData(null, "row")]
        [InlineData(0U, "row")]
        [InlineData(1U, "row row-cols-1")]
        [InlineData(6U, "row row-cols-6")]
        [InlineData(7U, "row")]
        public void CssClassWellFormattedForColumns(uint? value, string expectedCssClass)
        {
            _row.Columns = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(null, "row")]
        [InlineData(0U, "row")]
        [InlineData(1U, "row row-cols-xl-1")]
        [InlineData(6U, "row row-cols-xl-6")]
        [InlineData(7U, "row")]
        public void CssClassWellFormattedForExtraLargeColumns(uint? value, string expectedCssClass)
        {
            _row.ExtraLargeColumns = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(false, "row")]
        [InlineData(true, "row no-gutters")]
        public void CssClassWellFormattedForHasNoGutters(bool value, string expectedCssClass)
        {
            _row.HasNoGutters = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(null, "row")]
        [InlineData(0U, "row")]
        [InlineData(1U, "row row-cols-lg-1")]
        [InlineData(6U, "row row-cols-lg-6")]
        [InlineData(7U, "row")]
        public void CssClassWellFormattedForLargeColumns(uint? value, string expectedCssClass)
        {
            _row.LargeColumns = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(null, "row")]
        [InlineData(0U, "row")]
        [InlineData(1U, "row row-cols-md-1")]
        [InlineData(6U, "row row-cols-md-6")]
        [InlineData(7U, "row")]
        public void CssClassWellFormattedForMediumColumns(uint? value, string expectedCssClass)
        {
            _row.MediumColumns = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(null, "row")]
        [InlineData(0U, "row")]
        [InlineData(1U, "row row-cols-sm-1")]
        [InlineData(6U, "row row-cols-sm-6")]
        [InlineData(7U, "row")]
        public void CssClassWellFormattedForSmallColumns(uint? value, string expectedCssClass)
        {
            _row.SmallColumns = value;
            _row.CssClasses.Should().Be(expectedCssClass);
        }

        private readonly GridRow _row = new GridRow();
    }
}
