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

using BlazorComponentUtilities;

namespace BigSolution.Bootstrap;

/// <summary>
/// Represents a Bootstrap button group.
/// </summary>
/// <seealso href="https://getbootstrap.com/docs/5.2/components/button-group/"> Bootstrap button group - documentation</seealso>
public class ButtonGroup : BootstrapComponentBase
{
	#region Base Class Member Overrides

	/// <inheritdoc />
	protected override CssBuilder CssBuilder => base.CssBuilder
		.AddClass(_defaultCssClass);

	#endregion

	private const string CSS_CLASS_SUFFIX = "group";

	private static readonly string _defaultCssClass = new CssClassBuilder(Button.DEFAULT_CSS_CLASS).Append(CSS_CLASS_SUFFIX).Build();
}
