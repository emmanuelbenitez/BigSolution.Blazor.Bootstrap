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
        [CssClassPart("t", Scope = nameof(SpacingSide))]
        Top = 1,

        [CssClassPart("start")]
        [CssClassPart("s", Scope = nameof(SpacingSide))]
        Start = 2,

        [CssClassPart("bottom")]
        [CssClassPart("b", Scope = nameof(SpacingSide))]
        Bottom = 4,

        [CssClassPart("end")]
        [CssClassPart("e", Scope = nameof(SpacingSide))]
        End = 8,

        [CssClassPart("x", Scope = nameof(SpacingSide))]
        StartAndEnd = 10,

        [CssClassPart("y", Scope = nameof(SpacingSide))]
        TopAndBottom = 5,

        All = 15
    }
}
