﻿#region Copyright & License

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

using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap;

public class CardWrapper : BootstrapComponentBase
{
    #region Base Class Member Overrides

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass(CSS_CLASS_PREFIX)
        .AddColor(CSS_CLASS_PREFIX, () => Color, () => Color != Color.None)
        .AddClass(_outlineCssClass, () => HasOutline);

    protected override bool IsFlex => true;

    #endregion

    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public bool HasOutline { get; set; }

    public const string CSS_CLASS_PREFIX = "card";

    private static readonly string _outlineCssClass = new CssClassBuilder(CSS_CLASS_PREFIX).Append("outline").Build();
}
