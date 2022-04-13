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
    public class FixedMarginSideFixture
    {
        [Theory]
        [MemberData(nameof(ValidFixedMargins))]
        public void BuildCssClassesSucceeds(int value, Sides sides, Breakpoint breakpoint, string[] expectedCssClasses)
        {
            new FixedMarginSide(value) { ImpactedSides = sides }.BuildCssClasses(breakpoint).Should().BeEquivalentTo(expectedCssClasses);
        }

        public static IEnumerable<object[]> ValidFixedMargins
        {
            get
            {
                yield return new object[] { 0, Sides.StartAndEnd, Breakpoint.None, new[] { "mx-0" } };
                yield return new object[] { -1, Sides.End, Breakpoint.None, new[] { "me-n1" } };
                yield return new object[] { 0, Sides.Start, Breakpoint.Small, new[] { "ms-sm-0" } };
            }
        }
    }
}
