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
    public class FixedOrderFixture
    {
        [Theory]
        [InlineData(1, Breakpoint.None, "order-1")]
        [InlineData(1, Breakpoint.Small, "order-sm-1")]
        public void BuildCssClassSucceeds(uint order, Breakpoint breakpoint, string expectedCssClass)
        {
            new FixedOrder(order).BuildCssClass(breakpoint).Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("auto")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public void CastStringFailed(string value)
        {
            Action action = () => { _ = (FixedOrder) value; };
            action.Should().ThrowExactly<InvalidCastException>();
        }

        [Fact]
        public void CastStringSucceeds()
        {
            ((FixedOrder) "1").Order.Should().Be(1);
        }

        [Fact]
        public void CastUintSucceeds()
        {
            ((FixedOrder) 1).Order.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public void InstantiationFailed(uint order)
        {
            Action action = () => new FixedOrder(order);
            action.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be("order");
        }

        [Fact]
        public void InstantiationSucceeds()
        {
            new FixedOrder(1).Order.Should().Be(1);
        }
    }
}
