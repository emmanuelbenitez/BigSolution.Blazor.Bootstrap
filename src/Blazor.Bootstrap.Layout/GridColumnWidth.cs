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
using JetBrains.Annotations;

namespace BigSolution.Bootstrap
{
    public abstract class GridColumnWidth
    {
        #region Operators

        public static implicit operator GridColumnWidth(string value)
        {
            return ToGridColumnWidth(value);
        }

        public static implicit operator GridColumnWidth(uint value)
        {
            return ToGridColumnWidth(value);
        }

        #endregion

        private static GridColumnWidth ToGridColumnWidth(string value)
        {
            if (GridColumnDefaultWidth.CanConvert(value)) return (GridColumnDefaultWidth) value;
            if (GridColumnAutoWidth.CanConvert(value)) return (GridColumnAutoWidth) value;
            if (GridColumnFixedWidth.CanConvert(value)) return (GridColumnFixedWidth) value;

            throw new InvalidCastException(
                $"The string can be only cast to {nameof(GridColumnWidth)} when value equals to '{GridColumnAutoWidth.CSS_CLASS_SUFFIX}' or null or empty or is a number (value={value})");
        }

        private static GridColumnWidth ToGridColumnWidth(uint value)
        {
            return GridColumnFixedWidth.ToGridColumnFixedWidth(value);
        }

        public string BuildCssClass(Breakpoint breakpoint)
        {
            var builder = new CssClassBuilder("col")
                .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None);
            ConfigureCssClassBuilder(builder);
            return builder.Build();
        }

        protected virtual void ConfigureCssClassBuilder([NotNull] CssClassBuilder builder) { }
    }
}
