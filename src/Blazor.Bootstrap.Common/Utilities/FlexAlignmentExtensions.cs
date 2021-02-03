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

using JetBrains.Annotations;

namespace BigSolution.Bootstrap.Utilities
{
    public static class FlexAlignmentExtensions
    {
        [NotNull]
        public static string ToCssClass(this FlexAlignment alignment, FlexAlignmentScope scope, Breakpoint breakpoint)
        {
            return alignment == FlexAlignment.None
                ? string.Empty
                : new CssClassBuilder("align")
                    .Append(() => scope.GetCssClassPart())
                    .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None)
                    .Append(() => alignment.GetCssClassPart())
                    .Build();
        }
    }
}
