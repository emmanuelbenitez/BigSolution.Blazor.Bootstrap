#region Copyright & License

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

using System.Collections.Generic;
using System.Linq;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap.Layout
{
    public class GridRow : BootstrapComponentBase
    {
        private static string BuildColumnsCssClass(Breakpoint breakpoint, uint columns)
        {
            return new CssClassBuilder(CSS_CLASS_PREFIX)
                .Append("cols")
                .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None)
                .Append(() => $"{columns}")
                .Build();
        }

        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder
        {
            get
            {
                var cssBuilder = base.CssBuilder
                    .AddClass(CSS_CLASS_PREFIX)
                    .AddClass("no-gutters", () => HasNoGutters);

                foreach (var columns in _columnsDictionary.Where(pair => pair.Value >= 1 && pair.Value <= 6))
                {
                    cssBuilder.AddClass(() => BuildColumnsCssClass(columns.Key, columns.Value.GetValueOrDefault()), true);
                }

                return cssBuilder;
            }
        }

        protected override bool IsFlex => true;

        #endregion

        [Parameter]
        public uint? Columns
        {
            get => _columnsDictionary[Breakpoint.None];
            set => _columnsDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public uint? ExtraLargeColumns
        {
            get => _columnsDictionary[Breakpoint.ExtraLarge];
            set => _columnsDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public bool HasNoGutters { get; set; }

        [Parameter]
        public uint? LargeColumns
        {
            get => _columnsDictionary[Breakpoint.Large];
            set => _columnsDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public uint? MediumColumns
        {
            get => _columnsDictionary[Breakpoint.Medium];
            set => _columnsDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public uint? SmallColumns
        {
            get => _columnsDictionary[Breakpoint.Small];
            set => _columnsDictionary[Breakpoint.Small] = value;
        }

        private const string CSS_CLASS_PREFIX = "row";

        private readonly Dictionary<Breakpoint, uint?> _columnsDictionary = new Dictionary<Breakpoint, uint?> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null }
        };
    }
}
