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
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap;

/// <summary>
/// A component that renders an anchor tag based on a Bootstrap button, automatically toggling its 'active' class based on whether its 'href' matches the current URI.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Components.Routing.NavLink"/>
public class ButtonNavLink : BootstrapNavLink, IButton
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
}
