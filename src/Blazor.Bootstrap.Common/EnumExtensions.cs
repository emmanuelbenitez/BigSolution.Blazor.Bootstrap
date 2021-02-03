#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
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

namespace BigSolution.Bootstrap
{
    public static class EnumExtensions
    {
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

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static bool IsFlag<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            return typeof(TEnum).GetCustomAttribute<FlagsAttribute>() != null;
        }

        public static bool IsSingleValue<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            Requires.Argument(value, nameof(value))
                .IsFlag()
                .Check();

            return Enum.GetValues(typeof(TEnum)).OfType<TEnum>().Any(v => Equals(v, value));
        }
    }
}
