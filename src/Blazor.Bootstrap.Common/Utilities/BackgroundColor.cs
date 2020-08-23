﻿#region Copyright & License

// Copyright © 2020 - 2020 Emmanuel Benitez
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

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class BackgroundColor
    {
        #region Operators

        public static implicit operator BackgroundColor(Color color)
        {
            return ToBackgroundColor(color);
        }

        #endregion

        private static bool IsValidColor(Color color)
        {
            return color != Color.Muted && color != Color.None;
        }

        private static BackgroundColor ToBackgroundColor(Color color)
        {
            return new BackgroundColor { Color = color };
        }

        public Color Color { get; set; }

        public bool HasValidColor => IsValidColor(Color);

        public bool IsGradient { get; set; }

        public string BuildCssClass()
        {
            Ensures.IsValid(IsValidColor(Color), "The color is supported.");

            return new CssClassBuilder(CSS_CLASS_PREFIX)
                .Append("gradient", () => IsGradient)
                .Append(() => Color.GetCssClassPart(), () => Color != Color.None && Color != Color.Muted)
                .Build();
        }

        private const string CSS_CLASS_PREFIX = "bg";
    }
}