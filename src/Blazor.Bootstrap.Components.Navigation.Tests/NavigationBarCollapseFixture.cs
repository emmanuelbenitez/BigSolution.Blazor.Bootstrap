#region Copyright & License

// Copyright © 2020 - 2023 Emmanuel Benitez
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

public class NavigationBarCollapseFixture
{
    [Theory]
    [InlineData(true, "collapse navbar-collapse show")]
    [InlineData(false, "collapse navbar-collapse hide")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
    public void CssClassWellFormattedForExpanded(bool expanded, string expected)
    {
        new NavigationBarCollapse {
                Expanded = expanded,
                ShowClass = "show",
                HideClass = "hide"
            }
            .CssClasses.Should().Be(expected);
    }
}
