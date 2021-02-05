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

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Utilities
{
    public class FixedPaddingSideFixture
    {
        [Theory]
        [MemberData(nameof(ValidFixedPaddings))]
        public void BuildCssClassesSucceeds(uint value, Sides sides, Breakpoint breakpoint, string[] expectedCssClasses)
        {
            new FixedPaddingSide(value) { ImpactedSides = sides }.BuildCssClasses(breakpoint).Should().BeEquivalentTo(expectedCssClasses);
        }

        public static IEnumerable<object[]> ValidFixedPaddings
        {
            get
            {
                yield return new object[] { 0, Sides.LeftAndRight, Breakpoint.None, new[] { "px-0" } };
                yield return new object[] { 2, Sides.Left, Breakpoint.Small, new[] { "pl-sm-2" } };
            }
        }
    }
}
