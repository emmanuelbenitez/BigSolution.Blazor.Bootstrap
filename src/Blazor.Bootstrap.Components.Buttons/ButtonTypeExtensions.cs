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

namespace BigSolution.Bootstrap;

/// <summary>
/// Provides extensions of <see cref="ButtonType"/>.
/// </summary>
public static class ButtonTypeExtensions
{
	/// <summary>
	/// Gets the value of the attribute <c>type</c> of the HTML element <c>button</c> or <c>input</c>.
	/// </summary>
	/// <param name="value">The inspected value.</param>
	/// <returns>Returns the value or <see cref="string.Empty"/>.</returns>
	public static string GetHtmlButtonType(this ButtonType value)
	{
		return value.GetHtmlAttributeValue(HtmlAttributeNames.TYPE);
	}
}
