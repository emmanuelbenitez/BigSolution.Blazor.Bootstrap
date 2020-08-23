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

using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Bunit;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Components.Alerts
{
    public class AlertFixture : TestContext
    {
        [Fact]
        public void HeadingBuilt()
        {
            var renderedComponent = RenderComponent<Alert>(ComponentParameterFactory.RenderFragment(nameof(Alert.Heading), "heading-content"));

            var divisionElement = renderedComponent.Find("div");
            divisionElement.ClassName.Should().Be("alert");
            var headerElement = divisionElement.FindChild<IHtmlHeadingElement>();
            headerElement.LocalName.Should().Be("h1");
            headerElement.ClassName.Should().Be("alert-heading");
            headerElement.GetInnerText().Should().Be("heading-content");
        }

        [Fact]
        public void HeadingDoesNotBuild()
        {
            var renderedComponent = RenderComponent<Alert>();
           
            var divisionElement = renderedComponent.Find("div");
            divisionElement.ClassName.Should().Be("alert");
            divisionElement.FindChild<IHtmlHeadingElement>().Should().BeNull();
        }
    }
}
