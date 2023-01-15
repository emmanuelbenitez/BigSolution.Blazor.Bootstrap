#region Copyright & License

// Copyright © 2020 - 2023 Emmanuel Benitez
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

using Bunit;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class NavigationBarTogglerFixture
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void ToggleSucceeds(bool expanded)
    {
        using var context = new TestContext();
        var navigationBar = new NavigationBar();
        var navigationBarCollapse = new NavigationBarCollapse { Expanded = expanded };
        navigationBar.SetCollapse(navigationBarCollapse);
        var renderedComponent = context.RenderComponent<NavigationBarToggler>(builder => builder.AddCascadingValue(navigationBar).Add(toggler => toggler.Expanded, expanded));
        var buttonElement = renderedComponent.Find("button");

        buttonElement.Click();

        renderedComponent.Instance.Expanded.Should().NotBe(expanded);
        navigationBarCollapse.Expanded.Should().NotBe(expanded);
    }
}
