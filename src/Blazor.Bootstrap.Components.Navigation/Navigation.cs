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

using System.Collections.Generic;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap
{
    public class Navigation : BootstrapComponentBase
    {
        #region Base Class Member Overrides

        protected override string DefaultTagName => HtmlTagNames.UL;

        protected override IEnumerable<string> SupportedTagNames => new[] { HtmlTagNames.UL };

        #endregion

        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass(MainClass)
            .AddClass($"{CSS_CLASS_PREFIX}-{Style.GetCssClassPart()}", () => Style != NavigationStyle.None)
            .AddClass(NavigationBarScrollingContainer.DefaultCssClass, () => IsInNavigationBar && SupportScrolling);

        protected override bool IsFlex => true;

        #endregion

        [CascadingParameter]
        public NavigationBar NavigationBar { get; set; }

        [Parameter]
        public NavigationStyle Style { get; set; }

        [Parameter]
        public bool SupportScrolling { get; set; }

        private bool IsInNavigationBar => NavigationBar != null;

        private string MainClass => new CssClassBuilder(string.Empty)
            .Append(NavigationBar.CSS_CLASS_PREFIX, () => IsInNavigationBar)
            .Append(CSS_CLASS_PREFIX)
            .Build();

        public const string CSS_CLASS_PREFIX = "nav";
    }
}
