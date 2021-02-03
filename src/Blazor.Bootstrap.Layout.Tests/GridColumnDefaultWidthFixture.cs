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

namespace BigSolution.Bootstrap
{
    public class GridColumnDefaultWidthFixture
    {
        [Theory]
        [MemberData(nameof(GetSize))]
        public void BuildCssClassSucceeds(Breakpoint breakpoint, string expected)
        {
            GridColumnDefaultWidth.Instance.BuildCssClass(breakpoint).Should().Be(expected);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("auto")]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void CastStringFailed(string value)
        {
            Action action = () => {
                GridColumnDefaultWidth gridColumnAutoWidth = value;
            };
            action.Should().ThrowExactly<InvalidCastException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CastStringSucceeds(string value)
        {
            ((GridColumnDefaultWidth) value).Should().Be(GridColumnDefaultWidth.Instance);
        }

        public static IEnumerable<object[]> GetSize()
        {
            return Enum.GetValues(typeof(Breakpoint))
                .Cast<Breakpoint>()
                .Select(size => new object[] { size, size != Breakpoint.None ? $"col-{size.GetCssClassPart()}" : "col" });
        }
    }
}
