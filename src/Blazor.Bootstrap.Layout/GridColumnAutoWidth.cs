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

namespace BigSolution.Bootstrap;

public sealed class GridColumnAutoWidth : GridColumnWidth
{
    #region Operators

    public static implicit operator GridColumnAutoWidth(string value)
    {
        return ToGridColumnAutoWidth(value);
    }

    #endregion

    public static bool CanConvert(string value)
    {
        return string.Equals(CSS_CLASS_SUFFIX, value, StringComparison.InvariantCultureIgnoreCase);
    }

    private static GridColumnAutoWidth ToGridColumnAutoWidth(string value)
    {
        if (!CanConvert(value))
        {
            throw new InvalidCastException(
                $"The string can be only cast to {nameof(GridColumnAutoWidth)} when value equals to '{CSS_CLASS_SUFFIX}' (value={value})");
        }

        return Instance;
    }

    #region Base Class Member Overrides

    protected override void ConfigureCssClassBuilder(CssClassBuilder builder)
    {
        builder.Append(CSS_CLASS_SUFFIX);
    }

    #endregion

    internal const string CSS_CLASS_SUFFIX = "auto";

    public static readonly GridColumnAutoWidth Instance = new();
}