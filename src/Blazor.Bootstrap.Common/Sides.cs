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
using BigSolution.Bootstrap.Utilities;

namespace BigSolution.Bootstrap
{
    [Flags]
    public enum Sides
    {
        None = 0,

        [CssClassPart("top")]
        [CssClassPart("t", Scope = nameof(Margin))]
        Top = 1,

        [CssClassPart("right")]
        [CssClassPart("r", Scope = nameof(Margin))]
        Right = 2,

        [CssClassPart("bottom")]
        [CssClassPart("b", Scope = nameof(Margin))]
        Bottom = 4,

        [CssClassPart("left")]
        [CssClassPart("l", Scope = nameof(Margin))]
        Left = 8,

        [CssClassPart("x", Scope = nameof(Margin))]
        LeftAndRight = 10,

        [CssClassPart("y", Scope = nameof(Margin))]
        TopAndBottom = 5,

        All = 15
    }
}
