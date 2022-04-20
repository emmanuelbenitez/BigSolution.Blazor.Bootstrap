#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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

public class NavigationBarFixture
{
    [Theory]
    [InlineData(null, "navbar")]
    [InlineData(Breakpoint.None, "navbar navbar-expand")]
    [InlineData(Breakpoint.Large, "navbar navbar-expand-lg")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
    public void CssClassWellFormattedForExpendBreakpoint(Breakpoint? breakpoint, string expected)
    {
        new NavigationBar { ExpandBreakpoint = breakpoint }
            .CssClasses.Should().Be(expected);
    }

    [Theory]
    [InlineData(NavigationBarColor.None, "navbar")]
    [InlineData(NavigationBarColor.Dark, "navbar navbar-dark")]
    [InlineData(NavigationBarColor.Light, "navbar navbar-light")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
    public void CssClassWellFormattedForNavigationBarColor(NavigationBarColor color, string expected)
    {
        new NavigationBar { Color = color }
            .CssClasses.Should().Be(expected);
    }
}
