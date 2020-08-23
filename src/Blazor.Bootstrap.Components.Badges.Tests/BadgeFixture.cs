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
using System.Diagnostics.CodeAnalysis;
using BigSolution.Bootstrap.Utilities;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Components.Badges
{
    public class BadgeFixture
    {
        [Theory]
        [MemberData(nameof(CssClassData))]
        [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
        public void CssClassInitialized(Color color, BadgeType badgeType, string expectedCssClass)
        {
            _ = new Badge {
                Color = color,
                Type = badgeType
            }.CssClasses.Should().Be(expectedCssClass);
        }

        public static IEnumerable<object[]> CssClassData
        {
            get
            {
                yield return new object[] { Color.None, BadgeType.None, "badge" };
                yield return new object[] { Color.Active, BadgeType.Pill, "badge badge-pill badge-active" };
            }
        }
    }
}
