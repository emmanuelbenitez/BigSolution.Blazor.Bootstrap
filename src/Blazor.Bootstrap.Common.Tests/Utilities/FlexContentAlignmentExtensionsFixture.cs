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

public class FlexContentAlignmentExtensionsFixture
{
    [Theory]
    [InlineData(FlexContentAlignment.Center, Breakpoint.None, "align-content-center")]
    [InlineData(FlexContentAlignment.Stretch, Breakpoint.None, "align-content-stretch")]
    [InlineData(FlexContentAlignment.Around, Breakpoint.None, "align-content-around")]
    [InlineData(FlexContentAlignment.Between, Breakpoint.None, "align-content-between")]
    [InlineData(FlexContentAlignment.Start, Breakpoint.None, "align-content-start")]
    [InlineData(FlexContentAlignment.End, Breakpoint.None, "align-content-end")]
    [InlineData(FlexContentAlignment.None, Breakpoint.None, "")]
    [InlineData(FlexContentAlignment.Center, Breakpoint.Small, "align-content-sm-center")]
    public void ToCssClass(FlexContentAlignment contentAlignment, Breakpoint breakpoint, string expected)
    {
        contentAlignment.ToCssClass(breakpoint).Should().Be(expected);
    }
}