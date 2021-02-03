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
using System.Diagnostics.CodeAnalysis;

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class BackgroundColor
    {
        #region Operators

        public static bool operator ==(BackgroundColor value, Color valueToCompare)
        {
            return value?.Color == valueToCompare;
        }

        public static implicit operator BackgroundColor(Color color)
        {
            return ToBackgroundColor(color);
        }

        public static bool operator !=(BackgroundColor value, Color valueToCompare)
        {
            return value?.Color != valueToCompare;
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

        #region Base Class Member Overrides

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is BackgroundColor other && Equals(other);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            return HashCode.Combine((int) Color, IsGradient);
        }

        #endregion

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

        private bool Equals(BackgroundColor other)
        {
            return Color == other.Color && IsGradient == other.IsGradient;
        }

        private const string CSS_CLASS_PREFIX = "bg";
    }
}
