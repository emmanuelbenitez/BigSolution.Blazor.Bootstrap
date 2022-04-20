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

namespace BigSolution.Bootstrap.Utilities;

public class OrderFixture
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("test")]
    [SuppressMessage("ReSharper", "RedundantCast")]
    public void CastStringFailed(string value)
    {
        Action action = () => { _ = (Order) value; };
        action.Should().ThrowExactly<InvalidCastException>();
    }

    [Theory]
    [InlineData("first", "order-first")]
    [InlineData("1", "order-1")]
    public void CastToStringSucceeds(string value, string expectedCssClass)
    {
        ((Order) value).BuildCssClass(Breakpoint.None).Should().Be(expectedCssClass);
    }

    [Fact]
    public void CastUintSucceeds()
    {
        ((Order) 1).Should().BeOfType<FixedOrder>().Which.Order.Should().Be(1);
    }
}