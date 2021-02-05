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
using System.Globalization;

namespace BigSolution.Bootstrap.Utilities
{
    public class FixedPaddingSide : PaddingSide
    {
        #region Operators

        public static implicit operator FixedPaddingSide(uint value)
        {
            return ToFixedPaddingSide(value);
        }

        public static implicit operator FixedPaddingSide(string value)
        {
            return ToFixedPaddingSide(value);
        }

        #endregion

        private static bool CanConvert(string value)
        {
            return uint.TryParse(value, out _);
        }

        private static FixedPaddingSide ToFixedPaddingSide(string value)
        {
            if (!CanConvert(value))
            {
                throw new InvalidCastException(
                    $"The string can be only cast to {nameof(FixedMarginSide)} when value can converted to int (value={value})");
            }

            return new FixedPaddingSide(Convert.ToUInt32(value, NumberFormatInfo.CurrentInfo)) { ImpactedSides = Sides.All };
        }

        private static FixedPaddingSide ToFixedPaddingSide(uint value)
        {
            return new FixedPaddingSide(value) { ImpactedSides = Sides.All };
        }

        public FixedPaddingSide(uint size)
        {
            Requires.Argument(size, nameof(size))
                .IsGreaterOrEqualThan(MIN_VALUE)
                .IsLessOrEqualThan(MAX_VALUE)
                .Check();

            Size = size;
        }

        #region Base Class Member Overrides

        protected override string GetCssClassSuffix()
        {
            return Size.ToString();
        }

        #endregion

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public uint Size { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public const uint MAX_VALUE = 5;

        // ReSharper disable once MemberCanBePrivate.Global
        public const uint MIN_VALUE = 0;
    }
}
