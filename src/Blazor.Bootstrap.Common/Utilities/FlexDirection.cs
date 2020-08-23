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

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class FlexDirection
    {
        #region Operators

        public static implicit operator FlexDirection(FlexOrientation orientation)
        {
            return ToFlexDirection(orientation);
        }

        #endregion

        private static FlexDirection ToFlexDirection(FlexOrientation orientation)
        {
            return new FlexDirection { Orientation = orientation };
        }

        public FlexOrientation Orientation { get; set; }

        public bool Reversed { get; set; }

        public string BuildCssClass(Breakpoint breakpoint)
        {
            return new CssClassBuilder(CSS_CLASS_PREFIX)
                .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None)
                .Append(() => Orientation.GetCssClassPart())
                .Append("reverse", () => Reversed)
                .Build();
        }

        private const string CSS_CLASS_PREFIX = "flex";
    }
}
