#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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
            var border = (Border)Color.Active;
            border.AdditiveSides.Should().Be(Sides.All);
            border.SubtractiveSides.Should().Be(Sides.None);
            border.Color.Should().Be(Color.Active);
        }

        [Fact]
        public void CastSideSucceeds()
        {
            var border = (Border)Sides.Top;
            border.AdditiveSides.Should().Be(Sides.Top);
            border.SubtractiveSides.Should().Be(Sides.None);
            border.Color.Should().Be(Color.None);
        }

        [Fact]
        public void CustomizeCssClassBuilder()
        {
            var customBorder = new CustomBorder();
            customBorder.BuildCssClasses().Should().BeEquivalentTo("border-test");
        }

        public static IEnumerable<object[]> AdditiveSides
        {
            get
            {
                yield return new object[] { Sides.End, new[] { "border-end" } };
                yield return new object[] { Sides.Start, new[] { "border-start" } };
                yield return new object[] { Sides.Top, new[] { "border-top" } };
                yield return new object[] { Sides.Bottom, new[] { "border-bottom" } };
                yield return new object[] { Sides.Bottom | Sides.Start, new[] { "border-bottom", "border-start" } };
                yield return new object[] { Sides.Bottom | Sides.Top | Sides.End | Sides.Start, new[] { "border" } };
                yield return new object[] { Sides.None, Array.Empty<string>() };
            }
        }

        public static IEnumerable<object[]> SubtractiveSides
        {
            get
            {
                yield return new object[] { Sides.End, new[] { "border-end-0" } };
                yield return new object[] { Sides.Start, new[] { "border-start-0" } };
                yield return new object[] { Sides.Top, new[] { "border-top-0" } };
                yield return new object[] { Sides.Bottom, new[] { "border-bottom-0" } };
                yield return new object[] { Sides.Bottom | Sides.Start, new[] { "border-bottom-0", "border-start-0" } };
                yield return new object[] { Sides.Bottom | Sides.Top | Sides.End | Sides.Start, new[] { "border-0" } };
                yield return new object[] { Sides.None, Array.Empty<string>() };
            }
        }

        public static IEnumerable<object[]> BorderColors
        {
            get
            {
                yield return new object[] { Color.Active, new[] { "border-active" } };
                yield return new object[] { Color.Muted, Array.Empty<string>() };
                yield return new object[] { Color.None, Array.Empty<string>() };
            }
        }

        private class CustomBorder : Border
        {
            #region Base Class Member Overrides

            protected override IEnumerable<string> BuildCustomClasses()
            {
                yield return $"{CSS_CLASS_PREFIX}-test";
            }

            #endregion
        }
    }
}
