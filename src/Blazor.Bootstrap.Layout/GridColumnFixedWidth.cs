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
using System.Globalization;

namespace BigSolution.Bootstrap;

public class GridColumnFixedWidth : GridColumnWidth
{
    #region Operators

    public static implicit operator GridColumnFixedWidth(uint value)
    {
        return ToGridColumnFixedWidth(value);
    }

    public static implicit operator GridColumnFixedWidth(string value)
    {
        return ToGridColumnFixedWidth(value);
    }

    #endregion

    public static bool CanConvert(string value)
    {
        return uint.TryParse(value, out _);
    }

    private static GridColumnFixedWidth ToGridColumnFixedWidth(string value)
    {
        if (!CanConvert(value))
        {
            throw new InvalidCastException(
                $"The string can be only cast to {nameof(GridColumnFixedWidth)} when value can converted to uint (value={value})");
        }

        return new GridColumnFixedWidth(Convert.ToUInt32(value, NumberFormatInfo.CurrentInfo));
    }

    public static GridColumnFixedWidth ToGridColumnFixedWidth(uint value)
    {
        return new GridColumnFixedWidth(value);
    }

    public GridColumnFixedWidth(uint width)
    {
        Requires.Argument(width, nameof(width))
            .IsGreaterOrEqualThan(MIN_WIDTH)
            .IsLessOrEqualThan(MAX_WIDTH)
            .Check();

        Width = width;
    }

    #region Base Class Member Overrides

    protected override void ConfigureCssClassBuilder(CssClassBuilder builder)
    {
        Requires.Argument(builder, nameof(builder))
            .IsNotNull()
            .Check();

        builder.Append(() => $"{Width}");
    }

    #endregion

    public uint Width { get; }

    // ReSharper disable once MemberCanBePrivate.Global
    public const uint MAX_WIDTH = 12U;

    // ReSharper disable once MemberCanBePrivate.Global
    public const uint MIN_WIDTH = 1U;
}