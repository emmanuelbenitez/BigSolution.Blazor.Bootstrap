#region Copyright & License

// Copyright © 2020 - 2020 Emmanuel Benitez
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
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Utilities
{
    public class AbsoluteOrderFixture
    {
        [Theory]
        [InlineData(OrderPosition.First, Breakpoint.None, "order-first")]
        [InlineData(OrderPosition.Last, Breakpoint.None, "order-last")]
        [InlineData(OrderPosition.Last, Breakpoint.Small, "order-sm-last")]
        public void BuildCssClassSucceeds(OrderPosition position, Breakpoint breakpoint, string expectedCssClass)
        {
            new AbsoluteOrder(position).BuildCssClass(breakpoint).Should().Be(expectedCssClass);
        }

        [Fact]
        public void CastOrderPositionSucceeds()
        {
            ((AbsoluteOrder) OrderPosition.Last).Position.Should().Be(OrderPosition.Last);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("auto")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public void CastStringFailed(string value)
        {
            Action action = () => { _ = (AbsoluteOrder) value; };
            action.Should().ThrowExactly<InvalidCastException>();
        }

        [Theory]
        [InlineData("first", OrderPosition.First)]
        [InlineData("last", OrderPosition.Last)]
        [InlineData("FIRST", OrderPosition.First)]
        [InlineData("LAST", OrderPosition.Last)]
        public void CastStringSucceeds(string value, OrderPosition expectedPosition)
        {
            ((AbsoluteOrder) value).Position.Should().Be(expectedPosition);
        }
    }
}
