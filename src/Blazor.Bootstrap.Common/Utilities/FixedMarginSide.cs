﻿#region Copyright & License

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
    public sealed class FixedMarginSide : MarginSide
    {
        #region Operators

        public static implicit operator FixedMarginSide(int value)
        {
            return ToFixedMarginSide(value);
        }

        public static implicit operator FixedMarginSide(string value)
        {
            return ToFixedMarginSide(value);
        }

        #endregion

        internal static bool CanConvert(string value)
        {
            return uint.TryParse(value, out _);
        }

        private static FixedMarginSide ToFixedMarginSide(string value)
        {
            if (!CanConvert(value))
            {
                throw new InvalidCastException(
                    $"The string can be only cast to {nameof(FixedMarginSide)} when value can converted to int (value={value})");
            }

            return new FixedMarginSide(Convert.ToInt32(value, NumberFormatInfo.CurrentInfo)) { ImpactedSides = Sides.All };
        }

        private static FixedMarginSide ToFixedMarginSide(int value)
        {
            return new FixedMarginSide(value) { ImpactedSides = Sides.All };
        }

        public FixedMarginSide(int size)
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
            return Size < 0 ? $"n{Math.Abs(Size)}" : $"{Size}";
        }

        #endregion

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public int Size { get; }

        // ReSharper disable once MemberCanBePrivate.Global
        public const int MAX_VALUE = 5;

        // ReSharper disable once MemberCanBePrivate.Global
        public const int MIN_VALUE = -5;
    }
}
