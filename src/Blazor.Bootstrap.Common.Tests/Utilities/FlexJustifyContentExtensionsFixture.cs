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

public class FlexJustifyContentExtensionsFixture
{
    [Theory]
    [InlineData(FlexJustifyContent.Center, Breakpoint.Small, "justify-content-sm-center")]
    [InlineData(FlexJustifyContent.Center, Breakpoint.None, "justify-content-center")]
    [InlineData(FlexJustifyContent.Around, Breakpoint.None, "justify-content-around")]
    [InlineData(FlexJustifyContent.Between, Breakpoint.None, "justify-content-between")]
    [InlineData(FlexJustifyContent.End, Breakpoint.None, "justify-content-end")]
    [InlineData(FlexJustifyContent.None, Breakpoint.None, "")]
    public void ToCssClassSucceeds(FlexJustifyContent justifyContent, Breakpoint breakpoint, string expected)
    {
        justifyContent.ToCssClass(breakpoint).Should().Be(expected);
    }
}