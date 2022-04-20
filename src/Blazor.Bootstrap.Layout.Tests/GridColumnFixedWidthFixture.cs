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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class GridColumnFixedWidthFixture
{
    [Theory]
    [MemberData(nameof(GetSize))]
    public void BuildCssClassSucceeds(Breakpoint breakpoint, string expected)
    {
        var gridColumnFixedWidth = new GridColumnFixedWidth(6);
        gridColumnFixedWidth.Width.Should().Be(6);
        gridColumnFixedWidth.BuildCssClass(breakpoint).Should().Be(expected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("auto")]
    [InlineData("test")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public void CastStringFailed(string value)
    {
        Action action = () => {
            GridColumnFixedWidth gridColumnFixedWidth = value;
        };
        action.Should().ThrowExactly<InvalidCastException>();
    }

    [Fact]
    public void CastStringSucceeds()
    {
        GridColumnFixedWidth gridColumnFixedWidth = "6";
        gridColumnFixedWidth.Width.Should().Be(6);
    }

    [Fact]
    [SuppressMessage("ReSharper", "RedundantCast")]
    public void CastUintFailed()
    {
        Action action = () => { _ = (GridColumnFixedWidth) 0; };
        action.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be("width");
    }

    [Fact]
    public void CastUintSucceeds()
    {
        GridColumnFixedWidth gridColumnFixedWidth = 1;
        gridColumnFixedWidth.Width.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    public void InstantiationFailed(uint width)
    {
        Action action = () => new GridColumnFixedWidth(width);
        action.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be("width");
    }

    public static IEnumerable<object[]> GetSize()
    {
        return Enum.GetValues(typeof(Breakpoint))
            .Cast<Breakpoint>()
            .Select(size => new object[] { size, size != Breakpoint.None ? $"col-{size.GetCssClassPart()}-6" : "col-6" });
    }
}