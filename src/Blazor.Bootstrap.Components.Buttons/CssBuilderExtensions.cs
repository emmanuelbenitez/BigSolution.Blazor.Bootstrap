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

using System;
using BlazorComponentUtilities;

namespace BigSolution.Bootstrap;

/// <summary>
/// Provides extensions of <see cref="CssBuilder"/> for handling the CSS class related to a Bootstrap button.
/// </summary>
public static class CssBuilderExtensions
{
	/// <summary>
	/// Add the specific CSS classes for a Bootstrap button.
	/// </summary>
	/// <param name="builder">The builder where the CSS classes will be added.</param>
	/// <param name="button">The button instance for determining which CSS classes has to be added.</param>
	/// <returns>
	/// Returns the <see cref="CssBuilder"/> instance containing the added CSS classes.
	/// </returns>
	public static CssBuilder AddButtonClasses(this CssBuilder builder, IButton button)
	{
		Requires.Argument(button, nameof(button))
			.IsNotNull()
			.Check();

		return builder.AddClass(Button.DEFAULT_CSS_CLASS)
			.AddClass("disabled", () => button.TagName == HtmlTagNames.A && button.Disabled)
			.AddColor(new CssClassBuilder(Button.DEFAULT_CSS_CLASS).Append("outline", () => button.HasOutline), () => button.Color)
			.AddButtonSize(() => button.Size);
	}

	/// <summary>
	/// Add the CSS class for the size of a Bootstrap button.
	/// </summary>
	/// <param name="builder">The builder where the CSS classes will be added.</param>
	/// <param name="valueGetter">The lambda function for getting the <see cref="ButtonSize"/> value.</param>
	/// <returns>
	/// Returns the <see cref="CssBuilder"/> instance containing the added CSS classes.
	/// </returns>
	public static CssBuilder AddButtonSize(this CssBuilder builder, Func<ButtonSize> valueGetter)
	{
		return builder.AddEnumValue(Button.DEFAULT_CSS_CLASS, valueGetter, () => valueGetter() != ButtonSize.None);
	}
}
