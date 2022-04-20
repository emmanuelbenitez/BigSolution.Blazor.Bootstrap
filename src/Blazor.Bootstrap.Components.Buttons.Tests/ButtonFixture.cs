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
using System.Diagnostics.CodeAnalysis;
using Bunit;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class ButtonFixture : TestContext
{
    [Theory]
    [InlineData(ButtonType.None, "button")]
    [InlineData(ButtonType.Submit, "submit")]
    [InlineData(ButtonType.Reset, "reset")]
    public void ButtonTypeInitialized(ButtonType buttonType, string expectedType)
    {
        var component = RenderComponent<Button>(ComponentParameter.CreateParameter(nameof(Button.Type), buttonType));
        component.Find("button").Attributes[HtmlAttributeNames.TYPE]!.Value.Should().Be(expectedType);
    }

    [Theory]
    [InlineData("div")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
    public void TagNameInitializationFailed(string tagName)
    {
        Action action = () => new Button { TagName = tagName };
        action.Should().ThrowExactly<ArgumentOutOfRangeException>().Which.ActualValue.Should().Be(tagName);
    }

    [Theory]
    [InlineData("input")]
    [InlineData("a")]
    [InlineData("button")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "Testing purpose")]
    public void TagNameInitializationSucceeds(string tagName)
    {
        Action action = () => new Button { TagName = tagName };
        action.Should().NotThrow();
    }
}
