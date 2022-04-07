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
using System.Linq;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap
{
    public class GridColumn : BootstrapComponentBase
    {
        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder
        {
            get
            {
                var cssBuilder = base.CssBuilder;

                foreach (var (breakpoint, gridColumnWidth) in _widthDictionary.Where(pair => pair.Value != null))
                {
                    cssBuilder.AddClass(gridColumnWidth.BuildCssClass(breakpoint));
                }

                return cssBuilder
                    .AddClass("col", () => !HasWidth);
            }
        }

        #endregion

        [Parameter]
        public GridColumnWidth ExtraLargeWidth
        {
            get => _widthDictionary[Breakpoint.ExtraLarge];
            set => _widthDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public GridColumnWidth LargeWidth
        {
            get => _widthDictionary[Breakpoint.Large];
            set => _widthDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public GridColumnWidth MediumWidth
        {
            get => _widthDictionary[Breakpoint.Medium];
            set => _widthDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public GridColumnWidth SmallWidth
        {
            get => _widthDictionary[Breakpoint.Small];
            set => _widthDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public GridColumnWidth Width
        {
            get => _widthDictionary[Breakpoint.None];
            set => _widthDictionary[Breakpoint.None] = value;
        }

        private bool HasWidth => _widthDictionary.Values.Any(value => value != null);

        private readonly Dictionary<Breakpoint, GridColumnWidth> _widthDictionary = new() {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.ExtraLarge, null },
            { Breakpoint.Large, null },
            { Breakpoint.Medium, null }
        };
    }
}
