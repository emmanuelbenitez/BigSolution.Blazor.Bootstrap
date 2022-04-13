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

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap
{
    public class SideExtensionsFixture
    {
        [Theory]
        [MemberData(nameof(SideExtractions))]
        public void ExtractSides(Sides sides, Sides[] extractedSides)
        {
            sides.ExtractSides().Should().BeEquivalentTo(extractedSides);
        }

        public static IEnumerable<object[]> SideExtractions
        {
            get
            {
                yield return new object[] { Sides.Left, new[] { Sides.Left } };
                yield return new object[] { Sides.Right, new[] { Sides.Right } };
                yield return new object[] { Sides.Top, new[] { Sides.Top } };
                yield return new object[] { Sides.Bottom, new[] { Sides.Bottom } };
                yield return new object[] { Sides.All, new[] { Sides.Left, Sides.Bottom, Sides.Top, Sides.Right } };
                yield return new object[] { Sides.TopAndBottom, new[] { Sides.Bottom, Sides.Top } };
                yield return new object[] { Sides.LeftAndRight, new[] { Sides.Left, Sides.Right } };
                yield return new object[] { Sides.None, Array.Empty<Sides>() };
            }
        }
    }
}
