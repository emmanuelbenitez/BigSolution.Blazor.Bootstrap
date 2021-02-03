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

using BlazorComponentUtilities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;

namespace BigSolution.Bootstrap
{
    public class NavigationBar : BootstrapComponentBase
    {
        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder
        {
            get
            {
                return new CssBuilder(CSS_CLASS_PREFIX)
                    .AddClass($"{CSS_CLASS_PREFIX}-{Color.GetCssClassPart()}", () => Color != NavigationBarColor.None)
                    .AddClass(GetExpandCssClass(), () => ExpandBreakpoint.HasValue);
            }
        }

        #endregion

        #region Base Class Member Overrides

        protected override string DefaultTagName => HtmlTagNames.NAV;

        #endregion

        #region Base Class Member Overrides

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sequenceGenerator = new SequenceGenerator();
            builder.OpenComponent<CascadingValue<NavigationBar>>(sequenceGenerator.GetNextValue());
            builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(CascadingValue<NavigationBar>.Value), RuntimeHelpers.TypeCheck(this));
            builder.AddAttribute(sequenceGenerator.GetNextValue(), nameof(CascadingValue<NavigationBar>.ChildContent), (RenderFragment) (b => base.BuildRenderTree(b)));
            builder.CloseComponent();
        }

        #endregion

        [Parameter]
        public NavigationBarColor Color { get; set; }

        [Parameter]
        public Breakpoint? ExpandBreakpoint { get; [UsedImplicitly] set; }

        private string GetExpandCssClass()
        {
            return ExpandBreakpoint.HasValue
                ? new CssClassBuilder(CSS_CLASS_PREFIX)
                    .Append("expand")
                    .Append(() => ExpandBreakpoint.Value.GetCssClassPart(), ExpandBreakpoint.Value != Breakpoint.None)
                    .Build()
                : string.Empty;
        }

        public const string CSS_CLASS_PREFIX = "navbar";
    }
}
