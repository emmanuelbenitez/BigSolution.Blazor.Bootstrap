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

namespace BigSolution.Bootstrap.Utilities
{
    public abstract class MarginSide
    {
        #region Operators

        public static implicit operator MarginSide(int value)
        {
            return ToMarginSide(value);
        }

        public static implicit operator MarginSide(string value)
        {
            return ToMarginSide(value);
        }

        #endregion

        private static string GetCssClassPrefix(Sides side)
        {
            return $"{Margin.CSS_CLASS_PREFIX}{side.GetCssClassPart(true, nameof(Margin))}";
        }

        private static MarginSide ToMarginSide(string value)
        {
            if (FixedMarginSide.CanConvert(value)) return (FixedMarginSide) value;
            if (AutoMarginSide.CanConvert(value)) return (AutoMarginSide) value;

            throw new InvalidCastException(
                $"The string can be only cast to {nameof(MarginSide)} when value equals to 'auto' or is a number (value={value})");
        }

        private static MarginSide ToMarginSide(int value)
        {
            return (FixedMarginSide) value;
        }

        public Sides Sides { get; set; }

        public IEnumerable<string> BuildCssClasses(Breakpoint breakpoint)
        {
            if (Sides == Sides.None) yield break;

            foreach (var side in GetSides())
            {
                var builder = new CssClassBuilder(GetCssClassPrefix(side))
                    .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None)
                    .Append(GenerateSize);

                yield return builder.Build();
            }
        }

        protected abstract string GenerateSize();

        private IEnumerable<Sides> GetSides()
        {
            return Sides.IsSingleValue() ? new[] { Sides } : Sides.ExtractSides();
        }
    }
}
