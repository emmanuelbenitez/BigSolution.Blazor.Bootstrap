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

namespace BigSolution.Bootstrap;

/// <summary>
/// Defines the common parameters of a Bootstrap button.
/// </summary>
public interface IButton
{
	/// <summary>
	/// The <see cref="Utilities.Color"/> of button.
	/// </summary>
	public Color Color { get; }

	/// <summary>
	/// If <see langword="true" />, indicates that the button is not active. So, the user cannot not click on it.
	/// </summary>
	public bool Disabled { get; }

	/// <summary>
	/// If <see langword="true" />, indicates that the button has only colored outline. The color is defined by <see cref="Color"/>.
	/// </summary>
	public bool HasOutline { get; }

	/// <summary>
	/// Defines the size of the button.
	/// </summary>
	public ButtonSize Size { get; }

	/// <summary>
	/// Gets the <c>HTML</c> tag name which is used for rendering for <c>HTML</c> element.
	/// </summary>
	public string TagName { get; }
}