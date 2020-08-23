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

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class ScreenReaderOptions
    {
        public bool IsFocusable { get; set; }

        public bool IsOnlyVisible { get; set; }

        public IEnumerable<string> BuildCssClasses()
        {
            if (!IsOnlyVisible) yield break;

            yield return CSS_CLASS_PREFIX;
            if (IsFocusable) yield return new CssClassBuilder(CSS_CLASS_PREFIX).Append("focusable").Build();
        }

        private const string CSS_CLASS_PREFIX = "sr-only";

        public static readonly ScreenReaderOptions Only = new ScreenReaderOptions { IsOnlyVisible = true };

        public static readonly ScreenReaderOptions OnlyFocusable = new ScreenReaderOptions { IsOnlyVisible = true, IsFocusable = true };
    }
}
