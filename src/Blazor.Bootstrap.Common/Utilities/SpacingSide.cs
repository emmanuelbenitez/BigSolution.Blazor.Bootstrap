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

namespace BigSolution.Bootstrap.Utilities
{
    public abstract class SpacingSide
    {
        public Sides ImpactedSides { get; set; }

        protected abstract string CssClassPrefix { get; }

        public IEnumerable<string> BuildCssClasses(Breakpoint breakpoint)
        {
            if (ImpactedSides == Sides.None) yield break;

            foreach (var side in GetSides())
            {
                var builder = new CssClassBuilder(GetCssClassPrefix(side))
                    .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None)
                    .Append(GetCssClassSuffix);

                yield return builder.Build();
            }
        }

        private string GetCssClassPrefix(Sides side)
        {
            return $"{CssClassPrefix}{side.GetCssClassPart(true, nameof(SpacingSide))}";
        }

        protected abstract string GetCssClassSuffix();

        private IEnumerable<Sides> GetSides()
        {
            return ImpactedSides.IsSingleValue() ? new[] { ImpactedSides } : ImpactedSides.ExtractSides();
        }
    }
}
