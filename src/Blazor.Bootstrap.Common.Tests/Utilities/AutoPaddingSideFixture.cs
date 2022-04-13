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
    public class AutoPaddingSideFixture
    {
        [Theory]
        [MemberData(nameof(ValidAutoPaddings))]
        public void BuildCssClassesSucceeds(Sides sides, Breakpoint breakpoint, string[] expectedCssClasses)
        {
            new AutoPaddingSide { ImpactedSides = sides }.BuildCssClasses(breakpoint).Should().BeEquivalentTo(expectedCssClasses);
        }

        public static IEnumerable<object[]> ValidAutoPaddings
        {
            get
            {
                yield return new object[] { Sides.StartAndEnd, Breakpoint.None, new[] { "px-auto" } };
                yield return new object[] { Sides.End, Breakpoint.None, new[] { "pe-auto" } };
                yield return new object[] { Sides.Start, Breakpoint.Small, new[] { "ps-sm-auto" } };
            }
        }
    }
}
