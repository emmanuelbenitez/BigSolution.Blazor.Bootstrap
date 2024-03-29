﻿#region Copyright & License

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
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

namespace BigSolution.Bootstrap;

/// <summary>
/// A component that renders an Bootstrap anchor tag , automatically toggling its 'active'
/// class based on whether its 'href' matches the current URI.
/// </summary>
public abstract class BootstrapNavLink : BootstrapComponentBase
{
	#region Base Class Member Overrides

	/// <inheritdoc />
	protected sealed override void BuildRenderTree(RenderTreeBuilder builder)
	{
		Requires.Argument(builder, nameof(builder))
			.IsNotNull()
			.Check();

		var sequenceGenerator = new SequenceGenerator();
		builder.OpenComponent<NavLink>(sequenceGenerator.GetNextValue());
		{
			if (!string.IsNullOrWhiteSpace(ActiveClass)) builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(NavLink.ActiveClass), ActiveClass);
			builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(NavLink.Match), Match);
			builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(NavLink.AdditionalAttributes), CalculateAdditionalAttributes());
			builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(NavLink.ChildContent), ChildContent);
		}
		builder.CloseComponent();
	}

	#endregion

	#region Base Class Member Overrides

	/// <inheritdoc />
	protected override IEnumerable<string> SupportedTagNames => new[] { HtmlTagNames.A };

	#endregion

	/// <inheritdoc cref="NavLink.ActiveClass"/>
	[Parameter]
	public string ActiveClass { get; set; }

	/// <inheritdoc cref="NavLink.Match"/>
	[Parameter]
	public NavLinkMatch Match { get; set; }

	private IReadOnlyDictionary<string, object> CalculateAdditionalAttributes()
	{
		var additionalAttributes = new Dictionary<string, object>(AdditionalAttributes ?? Enumerable.Empty<KeyValuePair<string, object>>());

		if (!additionalAttributes.ContainsKey(HtmlAttributeNames.CLASS)) additionalAttributes.Add(HtmlAttributeNames.CLASS, string.Empty);
		additionalAttributes[HtmlAttributeNames.CLASS] = CssBuilder
			.AddClass(
				additionalAttributes[HtmlAttributeNames.CLASS] as string,
				!string.IsNullOrWhiteSpace(additionalAttributes[HtmlAttributeNames.CLASS] as string))
			.Build();

		return new ReadOnlyDictionary<string, object>(additionalAttributes);
	}
}
