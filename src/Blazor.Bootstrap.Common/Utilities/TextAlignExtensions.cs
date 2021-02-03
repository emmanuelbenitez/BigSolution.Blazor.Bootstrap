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
    public static class TextAlignExtensions
    {
        public static string ToCssClass(this TextAlign value)
        {
            return value == TextAlign.None
                ? string.Empty
                : new CssClassBuilder(CSS_CLASS_PREFIX)
                    .Append(() => value.GetCssClassPart(), () => value != TextAlign.None)
                    .Build();
        }

        private const string CSS_CLASS_PREFIX = "text";
    }
}
