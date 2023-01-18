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

using System.Linq;
using System.Reflection;

namespace BigSolution.Bootstrap
{
	/// <summary>
	/// Provides extensions of <see cref="MemberInfo"/>.
	/// </summary>
	public static class MemberInfoExtensions
	{
		/// <summary>
		/// Gets the <see cref="CssClassPartAttribute"/> attribute of a <paramref name="member"/> for an optional <paramref name="scope"/>.
		/// </summary>
		/// <param name="member">The inspected member.</param>
		/// <param name="scope">The scope of CSS class part.</param>
		/// <returns>Returns the found <see cref="CssClassPartAttribute"/>.</returns>
		public static CssClassPartAttribute GetCssClassPartAttribute(this MemberInfo member, string scope = null)
		{
			return member?.GetCustomAttributes<CssClassPartAttribute>().SingleOrDefault(attribute => attribute.Scope == scope);
		}

		/// <summary>
		/// Gets the <see cref="HtmlAttributeValueAttribute"/> attribute of a <paramref name="member"/> for an <paramref name="attributeName"/>.
		/// </summary>
		/// <param name="member">The inspected member.</param>
		/// <param name="attributeName">The HTML attribute name.</param>
		/// <returns>Returns the found <see cref="HtmlAttributeValueAttribute"/>.</returns>
		public static HtmlAttributeValueAttribute GetHtmlAttributeValueAttribute(this MemberInfo member, string attributeName)
		{
			Requires.Argument(attributeName, nameof(attributeName))
				.IsNotNullOrWhiteSpace()
				.Check();

			return member?.GetCustomAttributes<HtmlAttributeValueAttribute>().SingleOrDefault(attribute => attribute.AttributeName == attributeName);
		}
	}
}
