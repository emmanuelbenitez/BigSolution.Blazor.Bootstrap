#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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

using BigSolution.Bootstrap.Utilities.Fluent;

namespace BigSolution.Bootstrap.Utilities;

public class Margin : Spacing<MarginSide>
{
    #region Operators

    public static implicit operator Margin(MarginSide marginSide)
    {
        return ToMargin(marginSide);
    }

    public static implicit operator Margin(int value)
    {
        return ToMargin(value);
    }

    public static implicit operator Margin(string value)
    {
        return ToMargin(value);
    }

    #endregion

    public static IFixedMarginBuilder IsFixedAt(int value)
    {
        return new FixedMarginBuilder(new Margin(), value);
    }

    public static IAutoMarginBuilder IsAuto()
    {
        return new AutoMarginBuilder(new Margin());
    }

    private static Margin ToMargin(string value)
    {
        return (MarginSide)value;
    }

    private static Margin ToMargin(int value)
    {
        return (FixedMarginSide)value;
    }

    private static Margin ToMargin(MarginSide marginSide)
    {
        return new Margin { Sides = new[] { marginSide } };
    }
}
