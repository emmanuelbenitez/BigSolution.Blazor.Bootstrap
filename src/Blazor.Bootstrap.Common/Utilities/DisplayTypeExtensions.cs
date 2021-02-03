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

namespace BigSolution.Bootstrap.Utilities
{
    public static class DisplayTypeExtensions
    {
        public static bool IsFlex(this DisplayType? display)
        {
            return display == DisplayType.Flex || display == DisplayType.InlineFlex;
        }

        public static string ToCssClass(this DisplayType display, Breakpoint breakpoint)
        {
            return display.ToCssClass(breakpoint.GetCssClassPart());
        }

        private static string ToCssClass(this DisplayType display, string scope)
        {
            return new CssClassBuilder("d")
                .Append(() => scope, () => !string.IsNullOrWhiteSpace(scope))
                .Append(() => display.GetCssClassPart())
                .Build();
        }

        public static string ToPrintCssClass(this DisplayType display)
        {
            return display.ToCssClass("print");
        }
    }
}
