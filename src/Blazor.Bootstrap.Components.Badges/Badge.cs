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

using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap
{
    public class Badge : BootstrapComponentBase
    {
        #region Base Class Member Overrides

        protected override string DefaultTagName => "span";

        #endregion

        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass(DEFAULT_CSS_CLASS)
            .AddBadgeType(() => Type)
            .AddColor(DEFAULT_CSS_CLASS, Color);

        #endregion

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public BadgeType Type { get; set; }

        internal const string DEFAULT_CSS_CLASS = "badge";
    }
}
