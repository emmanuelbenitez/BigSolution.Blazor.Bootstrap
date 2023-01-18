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
/// Defines the supported type of a HTML button.
/// </summary>
/// <see href="https://www.w3schools.com/tags/att_button_type.asp">W3Schools - HTML button type attribute.</see>
public enum ButtonType
{
	/// <summary>
	/// The button is a clickable button.
	/// </summary>
	[HtmlAttributeValue(HtmlAttributeNames.TYPE, "button")]
	None,

	/// <summary>
	/// The button is a submit button (submits form-data).
	/// </summary>
	[HtmlAttributeValue(HtmlAttributeNames.TYPE, "reset")]
	Reset,

	/// <summary>
	/// The button is a reset button (resets the form-data to its initial values).
	/// </summary>
	[HtmlAttributeValue(HtmlAttributeNames.TYPE, "submit")]
	Submit
}