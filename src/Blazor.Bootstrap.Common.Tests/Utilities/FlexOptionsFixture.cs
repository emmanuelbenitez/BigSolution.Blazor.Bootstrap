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

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Utilities
{
    public class FlexOptionsFixture
    {
        [Theory]
        [MemberData(nameof(ValidFlexOptions))]
        public void BuildCssClassesSucceeds(FlexOptions flexOptions, Breakpoint breakpoint, string[] expected)
        {
            flexOptions.BuildCssClasses(breakpoint).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CastFlexContentAlignmentSucceeds()
        {
            ((FlexOptions) FlexContentAlignment.Center).ContentAlignment.Should().Be(FlexContentAlignment.Center);
        }

        [Fact]
        public void CastFlexDirectionSucceeds()
        {
            var flexDirection = new FlexDirection();
            ((FlexOptions) flexDirection).Direction.Should().Be(flexDirection);
        }

        [Fact]
        public void CastFlexOrientationSucceeds()
        {
            ((FlexOptions) FlexOrientation.Vertical).Direction.Orientation.Should().Be(FlexOrientation.Vertical);
        }

        [Fact]
        public void CastFlexWrapSucceeds()
        {
            var flexWrap = new FlexWrap();
            ((FlexOptions) flexWrap).Wrap.Should().Be(flexWrap);
        }

        [Fact]
        public void CastJustifyContentSucceeds()
        {
            ((FlexOptions) FlexJustifyContent.Center).JustifyContent.Should().Be(FlexJustifyContent.Center);
        }

        public static IEnumerable<object[]> ValidFlexOptions
        {
            get
            {
                yield return new object[] { new FlexOptions(), Breakpoint.None, new string[0] };
                yield return new object[] { new FlexOptions { Direction = FlexOrientation.Horizontal }, Breakpoint.None, new[] { "flex-row" } };
                yield return new object[] { new FlexOptions { JustifyContent = FlexJustifyContent.Center }, Breakpoint.None, new[] { "justify-content-center" } };
                yield return new object[] { new FlexOptions { ItemsAlignment = FlexAlignment.Center }, Breakpoint.None, new[] { "align-items-center" } };
                yield return new object[] { new FlexOptions { Wrap = true }, Breakpoint.None, new[] { "flex-wrap" } };
                yield return new object[] { new FlexOptions { ContentAlignment = FlexContentAlignment.Center }, Breakpoint.None, new[] { "align-content-center" } };
            }
        }
    }
}
