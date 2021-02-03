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
    public static class ShadowExtensions
    {
        [NotNull]
        public static string ToCssClass(this Shadow? value)
        {
            return value == null
                ? string.Empty
                : new CssClassBuilder("shadow")
                    .Append(() => value.GetValueOrDefault().GetCssClassPart(), () => value != Shadow.None)
                    .Build();
        }
    }
}
