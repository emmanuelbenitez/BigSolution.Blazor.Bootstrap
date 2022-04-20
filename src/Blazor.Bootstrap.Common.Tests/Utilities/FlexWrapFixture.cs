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

using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Utilities;

public class FlexWrapFixture
{
    [Theory]
    [InlineData(true, true, Breakpoint.None, "flex-wrap-reverse")]
    [InlineData(false, true, Breakpoint.None, "flex-nowrap")]
    [InlineData(false, false, Breakpoint.None, "flex-nowrap")]
    [InlineData(true, false, Breakpoint.None, "flex-wrap")]
    [InlineData(true, false, Breakpoint.Small, "flex-sm-wrap")]
    public void BuildCssClassSucceeds(bool wrap, bool reversed, Breakpoint breakpoint, string expected)
    {
        new FlexWrap { Wrap = wrap, Reversed = reversed }.BuildCssClass(breakpoint).Should().Be(expected);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CastBooleanSucceeds(bool value)
    {
        var flexWrap = (FlexWrap) value;
        flexWrap.Wrap.Should().Be(value);
        flexWrap.Reversed.Should().BeFalse();
    }
}