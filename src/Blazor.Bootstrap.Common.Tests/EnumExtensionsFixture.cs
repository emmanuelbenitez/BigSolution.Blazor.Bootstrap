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
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class EnumExtensionsFixture
{
    [Fact]
    public void IsFlagSucceedsForEnum()
    {
        Enum.None.IsFlag().Should().BeFalse();
    }

    [Fact]
    public void IsFlagSucceedsForFlagEnum()
    {
        Flag.Value1.IsFlag().Should().BeTrue();
    }

    [Fact]
    public void IsSingleValueFailed()
    {
        Action action = () => { Enum.None.IsSingleValue(); };
        action.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be("value");
    }

    [Theory]
    [InlineData(Flag.Value1, true)]
    [InlineData(Flag.Value1 | Flag.Value2, false)]
    public void IsSingleValueSucceeds(Flag value, bool expected)
    {
        value.IsSingleValue().Should().Be(expected);
    }

    [Fact]
    public void ToValueStringSucceedsForFlag()
    {
        (Flag.Value1 | Flag.Value2).GetCssClassPart().Should().Be("1 2");
    }

    [Fact]
    public void ToValueStringSucceedsForNotFlag()
    {
        Enum.Public.GetCssClassPart().Should().Be("public");
    }

    [Fact]
    public void ToValueStringSucceedsForValueWithoutDescriptionAttribute()
    {
        Enum.None.GetCssClassPart().Should().BeEmpty();
    }

    private enum Enum
    {
        None,

        [CssClassPart("public")]
        Public
    }

    [Flags]
    public enum Flag
    {
        [CssClassPart("1")]
        Value1 = 1,

        [CssClassPart("2")]
        Value2 = 2
    }
}