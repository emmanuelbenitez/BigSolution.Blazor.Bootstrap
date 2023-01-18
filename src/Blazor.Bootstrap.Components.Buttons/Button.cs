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

using System.Collections.Generic;
using System.Linq;
using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BigSolution.Bootstrap;

/// <summary>
/// Represents a Bootstrap button.
/// </summary>
/// <seealso href="https://getbootstrap.com/docs/5.2/components/buttons/">Bootstrap button documentation</seealso>
public class Button : BootstrapComponentBase, IButton
{
	#region IButton Members

	/// <inheritdoc cref="IButton.Color"/>
	[Parameter]
	public Color Color { get; set; }

	/// <inheritdoc cref="IButton.Disabled"/>
	[Parameter]
	public bool Disabled { get; set; }

	/// <inheritdoc cref="IButton.HasOutline"/>
	[Parameter]
	public bool HasOutline { get; set; }

	/// <inheritdoc cref="IButton.Size"/>
	[Parameter]
	public ButtonSize Size { get; set; }

	#endregion

	#region Base Class Member Overrides

	/// <inheritdoc />
	protected override CssBuilder CssBuilder => base.CssBuilder.AddButtonClasses(this);

	#endregion

	#region Base Class Member Overrides

	/// <summary>
	/// Returns <see cref="HtmlTagNames.BUTTON"/>.
	/// </summary>
	protected override string DefaultTagName => HtmlTagNames.BUTTON;

	/// <inheritdoc />
	protected override IEnumerable<string> SupportedTagNames => new[] { HtmlTagNames.A, HtmlTagNames.BUTTON, HtmlTagNames.INPUT };

	#endregion

	#region Base Class Member Overrides

	/// <inheritdoc />
	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		var sequenceGenerator = new SequenceGenerator();

		builder.OpenElement(sequenceGenerator.GetNextValue(), TagName);
		builder.AddAttribute(sequenceGenerator.GetNextValue(), "class", CssClasses);
		if (TagName is HtmlTagNames.BUTTON or HtmlTagNames.INPUT) builder.AddAttribute(sequenceGenerator.GetNextValue(), "type", Type.GetHtmlButtonType());
		else builder.AddAttribute(sequenceGenerator.GetNextValue(), "role", "button");
		builder.AddMultipleAttributes(sequenceGenerator.GetNextValue(), AdditionalAttributes?.Where(pair => pair.Key != "class"));
		builder.AddContent(sequenceGenerator.GetNextValue(), ChildContent);
		builder.CloseElement();
	}

	#endregion

	/// <summary>
	/// The button type.
	/// </summary>
	[Parameter]
	public ButtonType Type { get; set; }

	/// <summary>
	/// The default CSS class for a Bootstrap button.
	/// </summary>
	public const string DEFAULT_CSS_CLASS = "btn";
}
