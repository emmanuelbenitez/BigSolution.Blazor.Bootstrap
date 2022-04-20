#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class GridRowFixture
{
    [Theory]
    [InlineData(null, "row")]
    [InlineData(0U, "row")]
    [InlineData(1U, "row row-cols-1")]
    [InlineData(6U, "row row-cols-6")]
    [InlineData(7U, "row")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
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
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
    public void CssClassWellFormattedForExtraLargeColumns(uint? value, string expectedCssClass)
    {
        _row.ExtraLargeColumns = value;
        _row.CssClasses.Should().Be(expectedCssClass);
    }

    [Theory]
    [InlineData(false, "row")]
    [InlineData(true, "row no-gutters")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
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
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
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
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
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
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Test purpose")]
    public void CssClassWellFormattedForSmallColumns(uint? value, string expectedCssClass)
    {
        _row.SmallColumns = value;
        _row.CssClasses.Should().Be(expectedCssClass);
    }

    private readonly GridRow _row = new();
}