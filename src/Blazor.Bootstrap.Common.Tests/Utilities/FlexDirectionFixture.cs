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

namespace BigSolution.Bootstrap.Utilities
{
    public class FlexDirectionFixture
    {
        [Theory]
        [InlineData(FlexOrientation.Horizontal, false, Breakpoint.None, "flex-row")]
        [InlineData(FlexOrientation.Horizontal, true, Breakpoint.None, "flex-row-reverse")]
        [InlineData(FlexOrientation.Vertical, false, Breakpoint.None, "flex-column")]
        [InlineData(FlexOrientation.Vertical, true, Breakpoint.None, "flex-column-reverse")]
        [InlineData(FlexOrientation.Vertical, false, Breakpoint.Small, "flex-sm-column")]
        public void BuildCssClassSucceeds(FlexOrientation orientation, bool reversed, Breakpoint breakpoint, string expected)
        {
            new FlexDirection { Orientation = orientation, Reversed = reversed }.BuildCssClass(breakpoint).Should().Be(expected);
        }

        [Fact]
        public void CastFlexOrientationSucceeds()
        {
            var flexDirection = (FlexDirection) FlexOrientation.Vertical;
            flexDirection.Orientation.Should().Be(FlexOrientation.Vertical);
            flexDirection.Reversed.Should().BeFalse();
        }
    }
}
