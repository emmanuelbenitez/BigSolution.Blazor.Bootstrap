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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace BigSolution.Bootstrap
{
	/// <summary>
	/// Provides extensions of <seealso cref="Enum"/>.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Gets the CSS class part associated to a <see cref="Enum"/> value.
		/// </summary>
		/// <remarks>The <see cref="CssClassPartAttribute"/> attribute is used. WHen the enumeration can be used in the generation of multiple CSS class, the <paramref name="scope"/> parameter should be used.</remarks>
		/// <param name="value">The enumeration value.</param>
		/// <param name="isSingleValue">Indicates if the value </param>
		/// <param name="scope">Define the scope of CSS class.</param>
		/// <typeparam name="TEnum">Type of enumeration.</typeparam>
		/// <returns>
		/// Returns the value of CSS class part when the <see cref="CssClassPartAttribute"/> attribute is defined on <paramref name="value"/>; otherwise, <see cref="string.Empty"/>.
		/// </returns>
		/// <seealso cref="CssClassPartAttribute"/>.
		public static string GetCssClassPart<TEnum>(this TEnum value, bool isSingleValue = false, string scope = null)
			where TEnum : Enum
		{
			var type = typeof(TEnum);

			if (value.IsFlag() && !isSingleValue)
			{
				return string.Join(
					" ",
					value.GetFlags()
						.Select(flag => type.GetField(flag.ToString()).GetCssClassPartAttribute(scope)?.Value ?? string.Empty)
						.Where(s => !string.IsNullOrEmpty(s)));
			}

			return type.GetField(value.ToString()).GetCssClassPartAttribute(scope)?.Value ?? string.Empty;
		}

		private static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum value)
			where TEnum : Enum
		{
			return Enum.GetValues(value.GetType()).Cast<Enum>().Where(f => f != null && value.HasFlag(f)).Cast<TEnum>();
		}

		[SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = "Enum extension.")]
		private static bool IsFlag<TEnum>(this TEnum value)
			where TEnum : Enum
		{
			return typeof(TEnum).GetCustomAttribute<FlagsAttribute>() != null;
		}

		/// <summary>
		/// Determines if <paramref name="value"/> represents one or more enumeration values.
		/// </summary>
		/// <remarks><typeparamref name="TEnum"/> must be a flag. So, the enum must have the <see cref="FlagsAttribute"/> attribute.</remarks>
		/// <param name="value">The value is inspected.</param>
		/// <typeparam name="TEnum">The type of enumeration.</typeparam>
		/// <returns>
		/// <c>true</c> if <paramref name="value"/> represents more than one enumeration value of 
		/// </returns>
		/// <seealso cref="FlagsAttribute"/>
		public static bool IsSingleValue<TEnum>(this TEnum value)
			where TEnum : Enum
		{
			Requires.Argument(value, nameof(value))
				.IsFlag()
				.Check();

			return Enum.GetValues(typeof(TEnum)).OfType<TEnum>().Any(v => Equals(v, value));
		}

		/// <summary>
		/// Gets the HTML attribute value associated to a <see cref="Enum"/> value for a specific HTML attribute name.
		/// </summary>
		/// <param name="value">The inspected enumeration value.</param>
		/// <param name="attributeName">The HTML attribute name.</param>
		/// <typeparam name="TEnum">The type of enumeration.</typeparam>
		/// <returns>
		/// Returns <see cref="string.Empty"/> when the attribute is set on the enumeration value; otherwise, the associated value of HTML attribute.
		/// </returns>
		public static string GetHtmlAttributeValue<TEnum>(this TEnum value, string attributeName) where TEnum : Enum
		{
			return typeof(TEnum).GetField(value.ToString()).GetHtmlAttributeValueAttribute(attributeName)?.Value ?? string.Empty;
		}
	}
}
