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
using System.Linq;
using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;

namespace BigSolution.Bootstrap
{
	public static class CssBuilderExtensions
	{
		public static CssBuilder AddClasses(this CssBuilder builder, IEnumerable<string> values, Func<string, bool> condition = null)
		{
			foreach (var value in values ?? Enumerable.Empty<string>())
			{
				builder.AddClass(value, condition?.Invoke(value) ?? true);
			}

			return builder;
		}

		public static CssBuilder AddColor(this CssBuilder builder, string prefix, Color color)
		{
			return builder.AddColor(new CssClassBuilder(prefix), () => color);
		}

		public static CssBuilder AddColor(this CssBuilder builder, CssClassBuilder classBuilder, Color color)
		{
			return builder.AddColor(classBuilder, () => color);
		}

		public static CssBuilder AddColor(this CssBuilder builder, string prefix, Func<Color> colorGetter, Func<bool> condition = null)
		{
			return builder.AddColor(new CssClassBuilder(prefix), colorGetter, condition);
		}

		public static CssBuilder AddColor(this CssBuilder builder, CssClassBuilder classBuilder, Func<Color> colorGetter, Func<bool> condition = null)
		{
			return builder.AddEnumValue(classBuilder, colorGetter, condition ?? (() => colorGetter() != Color.None));
		}

		public static CssBuilder AddEnumValue<TEnum>(this CssBuilder builder, string prefix, Func<TEnum> valueGetter, Func<bool> condition)
			where TEnum : Enum
		{
			Requires.Argument(prefix, nameof(prefix))
				.IsNotNullOrWhiteSpace()
				.Check();

			var isSame = Equals(builder, builder.AddEnumValue(new CssClassBuilder(prefix), valueGetter, condition));
			return builder.AddEnumValue(new CssClassBuilder(prefix), valueGetter, condition);
		}

		public static CssBuilder AddEnumValue<TEnum>(this CssBuilder builder, CssClassBuilder classBuilder, Func<TEnum> valueGetter, Func<bool> condition)
			where TEnum : Enum
		{
			Requires.Argument(builder, nameof(builder))
				.IsNotNull()
				.Check();
			Requires.Argument(classBuilder, nameof(classBuilder))
				.IsNotNull()
				.Check();
			Requires.Argument(valueGetter, nameof(valueGetter))
				.IsNotNull()
				.Check();

			return builder.AddClass(() => classBuilder.Append(() => valueGetter().GetCssClassPart()).Build(), condition);
		}
	}
}
