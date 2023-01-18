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
using JetBrains.Annotations;

namespace BigSolution.Bootstrap;

/// <summary>
/// Associates the enumeration value to a value of a HTML attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public sealed class HtmlAttributeValueAttribute : Attribute
{
	/// <summary>
	/// Initializes a new instance of the <see cref="HtmlAttributeValueAttribute" /> class.
	/// </summary>
	/// <param name="attributeName">The name of the associated HTML attribute.</param>
	/// <param name="value">The associated value for the HTML attribute.</param>
	public HtmlAttributeValueAttribute([NotNull]string attributeName, string value)
	{
		Requires.Argument(attributeName, nameof(attributeName))
			.IsNotNullOrWhiteSpace()
			.Check();

		AttributeName = attributeName;
		Value = value;
	}

	/// <summary>
	/// The name of the HTML attribute.
	/// </summary>
	public string AttributeName { get; }

	/// <summary>
	/// The value of the HTML attribute.
	/// </summary>
	public string Value { get; }
}
