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
using BigSolution.Bootstrap.Utilities;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BigSolution.Bootstrap
{
    public class BadgeLinkFixture : TestContext
    {
        [Theory]
        [MemberData(nameof(CssClassData))]
        public void CssClassWellFormatted(Color color, BadgeType badgeType, string expectedCssClass)
        {
            Services.AddSingleton<NavigationManager>(new MockNavigationManager("http://localhost/"));
            var component = RenderComponent<BadgeLink>(
                ComponentParameter.CreateParameter(nameof(BadgeLink.Color), color),
                ComponentParameter.CreateParameter(nameof(BadgeLink.Type), badgeType));
            component.Find("a").ClassName.Should().Be(expectedCssClass);
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
