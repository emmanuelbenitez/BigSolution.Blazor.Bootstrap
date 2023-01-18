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

using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using FluentAssertions;
using Moq;
using Xunit;

namespace BigSolution.Bootstrap;

public class CssBuilderExtensionsFixture
{
	[Fact]
	public void AddButtonClassesSucceeds()
	{
		var mockButton = new Mock<IButton>();
		new CssBuilder().AddButtonClasses(mockButton.Object).Build().Should().Be("btn");
	}

	[Theory]
	[InlineData(ButtonSize.None, "btn")]
	[InlineData(ButtonSize.Large, "btn btn-lg")]
	public void AddButtonClassesSucceedsForButtonSize(ButtonSize buttonSize, string expectedCssClass)
	{
		var mockButton = new Mock<IButton>();
		mockButton.SetupGet(button => button.Size)
			.Returns(buttonSize);

		new CssBuilder().AddButtonClasses(mockButton.Object).Build().Should().Be(expectedCssClass);
	}

	[Theory]
	[InlineData(true, Color.None, "btn")]
	[InlineData(true, Color.Info, "btn btn-outline-info")]
	[InlineData(false, Color.Info, "btn btn-info")]
	public void AddButtonClassesSucceedsForOutline(bool hasOutline, Color color, string expectedCssClass)
	{
		var mockButton = new Mock<IButton>();
		mockButton.SetupGet(button => button.Color)
			.Returns(color);
		mockButton.SetupGet(button => button.HasOutline)
			.Returns(hasOutline);

		new CssBuilder().AddButtonClasses(mockButton.Object).Build().Should().Be(expectedCssClass);
	}

	[Theory]
	[InlineData(ButtonSize.None, "")]
	[InlineData(ButtonSize.Small, "btn-sm")]
	[InlineData(ButtonSize.Large, "btn-lg")]
	public void AddButtonSizeSucceeds(ButtonSize buttonSize, string expected)
	{
		new CssBuilder().AddButtonSize(() => buttonSize).Build().Should().Be(expected);
	}
}
