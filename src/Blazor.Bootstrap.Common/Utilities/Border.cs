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
using BlazorComponentUtilities;

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class Border
    {
        #region Operators

        public static implicit operator Border(Sides sides)
        {
            return ToBorder(sides);
        }

        public static implicit operator Border(Color color)
        {
            return ToBorder(color);
        }

        #endregion

        private static IEnumerable<string> BuildSideCssClasses(Sides sides, string suffix = null)
        {
            if (sides == Sides.All)
            {
                yield return new CssClassBuilder(CSS_CLASS_PREFIX)
                    .Append(suffix, () => !string.IsNullOrWhiteSpace(suffix))
                    .Build();
            }
            else
            {
                foreach (var side in sides.ExtractSides())
                {
                    yield return new CssClassBuilder(CSS_CLASS_PREFIX)
                        .Append(() => side.GetCssClassPart())
                        .Append(suffix)
                        .Build();
                }
            }
        }

        private static bool IsValidCssClass(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        private static Border ToBorder(Sides sides)
        {
            return new Border { AdditiveSides = sides };
        }

        private static Border ToBorder(Color color)
        {
            return new Border { AdditiveSides = Sides.All, Color = color };
        }

        public Sides AdditiveSides { get; set; }

        public Color Color { get; set; }

        public Sides SubtractiveSides { get; set; }

        public IEnumerable<string> BuildCssClasses()
        {
            return CssBuilder.Empty()
                .AddClasses(BuildSideCssClasses(AdditiveSides), IsValidCssClass)
                .AddClasses(BuildSideCssClasses(SubtractiveSides, "0"), IsValidCssClass)
                .AddColor(CSS_CLASS_PREFIX, () => Color, () => Color != Color.Muted && Color != Color.None)
                .Build()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private const string CSS_CLASS_PREFIX = "border";
    }
}
