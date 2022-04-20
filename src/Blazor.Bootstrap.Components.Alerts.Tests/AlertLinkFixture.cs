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

using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BigSolution.Bootstrap;

public class AlertLinkFixture : TestContext
{
    [Fact]
    public void CssClassWellFormatted()
    {
        Services.AddSingleton<NavigationManager>(new MockNavigationManager("http://localhost/"));
        var renderedComponent = RenderComponent<AlertLink>();
        renderedComponent.Find("a").ClassName.Should().Contain("alert-link", Exactly.Once());
    }
}