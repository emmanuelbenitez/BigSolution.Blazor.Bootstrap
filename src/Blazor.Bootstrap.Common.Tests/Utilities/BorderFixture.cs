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
    public class BorderFixture
    {
        [Theory]
        [MemberData(nameof(AdditiveSides))]
        public void BuildCssClassesSucceedsForAdditiveSides(Sides sides, string[] expectedCssClasses)
        {
            new Border { AdditiveSides = sides }.BuildCssClasses().Should().BeEquivalentTo(expectedCssClasses);
        }

        [Theory]
        [MemberData(nameof(BorderColors))]
        public void BuildCssClassesSucceedsForColor(Color color, string[] expectedCssClasses)
        {
            new Border { Color = color }.BuildCssClasses().Should().BeEquivalentTo(expectedCssClasses);
        }

        [Theory]
        [MemberData(nameof(SubtractiveSides))]
        public void BuildCssClassesSucceedsForSubtractiveSides(Sides sides, string[] expectedCssClasses)
        {
            new Border { SubtractiveSides = sides }.BuildCssClasses().Should().BeEquivalentTo(expectedCssClasses);
        }

        [Fact]
        public void CastColorSucceeds()
        {
            var border = (Border) Color.Active;
            border.AdditiveSides.Should().Be(Sides.All);
            border.SubtractiveSides.Should().Be(Sides.None);
            border.Color.Should().Be(Color.Active);
        }

        [Fact]
        public void CastSideSucceeds()
        {
            var border = (Border) Sides.Top;
            border.AdditiveSides.Should().Be(Sides.Top);
            border.SubtractiveSides.Should().Be(Sides.None);
            border.Color.Should().Be(Color.None);
        }

        public static IEnumerable<object[]> AdditiveSides
        {
            get
            {
                yield return new object[] { Sides.Left, new[] { "border-left" } };
                yield return new object[] { Sides.Right, new[] { "border-right" } };
                yield return new object[] { Sides.Top, new[] { "border-top" } };
                yield return new object[] { Sides.Bottom, new[] { "border-bottom" } };
                yield return new object[] { Sides.Bottom | Sides.Top, new[] { "border-bottom", "border-top" } };
                yield return new object[] { Sides.Bottom | Sides.Top | Sides.Left | Sides.Right, new[] { "border" } };
                yield return new object[] { Sides.None, new string[0] };
            }
        }

        public static IEnumerable<object[]> SubtractiveSides
        {
            get
            {
                yield return new object[] { Sides.Left, new[] { "border-left-0" } };
                yield return new object[] { Sides.Right, new[] { "border-right-0" } };
                yield return new object[] { Sides.Top, new[] { "border-top-0" } };
                yield return new object[] { Sides.Bottom, new[] { "border-bottom-0" } };
                yield return new object[] { Sides.Bottom | Sides.Top, new[] { "border-bottom-0", "border-top-0" } };
                yield return new object[] { Sides.Bottom | Sides.Top | Sides.Left | Sides.Right, new[] { "border-0" } };
                yield return new object[] { Sides.None, new string[0] };
            }
        }

        public static IEnumerable<object[]> BorderColors
        {
            get
            {
                yield return new object[] { Color.Active, new[] { "border-active" } };
                yield return new object[] { Color.Muted, new string[0] };
                yield return new object[] { Color.None, new string[0] };
            }
        }
    }
}
