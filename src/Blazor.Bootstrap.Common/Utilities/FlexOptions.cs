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
    public sealed class FlexOptions
    {
        #region Operators

        public static implicit operator FlexOptions(FlexDirection direction)
        {
            return ToFlexOptions(direction);
        }

        public static implicit operator FlexOptions(FlexOrientation orientation)
        {
            return ToFlexOptions(orientation);
        }

        public static implicit operator FlexOptions(FlexJustifyContent justifyContent)
        {
            return ToFlexOptions(justifyContent);
        }

        public static implicit operator FlexOptions(FlexWrap wrap)
        {
            return ToFlexOptions(wrap);
        }

        public static implicit operator FlexOptions(FlexContentAlignment contentAlignment)
        {
            return ToFlexOptions(contentAlignment);
        }

        #endregion

        private static FlexOptions ToFlexOptions(FlexDirection direction)
        {
            return new FlexOptions { Direction = direction };
        }

        private static FlexOptions ToFlexOptions(FlexOrientation orientation)
        {
            return (FlexDirection) orientation;
        }

        private static FlexOptions ToFlexOptions(FlexJustifyContent justifyContent)
        {
            return new FlexOptions { JustifyContent = justifyContent };
        }

        private static FlexOptions ToFlexOptions(FlexWrap wrap)
        {
            return new FlexOptions { Wrap = wrap };
        }

        private static FlexOptions ToFlexOptions(FlexContentAlignment contentAlignment)
        {
            return new FlexOptions { ContentAlignment = contentAlignment };
        }

        public FlexContentAlignment ContentAlignment { get; set; }

        public FlexDirection Direction { get; set; }

        public FlexAlignment ItemsAlignment { get; set; }

        public FlexJustifyContent JustifyContent { get; set; }

        public FlexWrap Wrap { get; set; }

        public IEnumerable<string> BuildCssClasses(Breakpoint breakpoint)
        {
            if (Direction != null) yield return Direction.BuildCssClass(breakpoint);
            if (JustifyContent != FlexJustifyContent.None) yield return JustifyContent.ToCssClass(breakpoint);
            if (ItemsAlignment != FlexAlignment.None) yield return ItemsAlignment.ToCssClass(FlexAlignmentScope.Items, breakpoint);
            if (Wrap != null) yield return Wrap.BuildCssClass(breakpoint);
            if (ContentAlignment != FlexContentAlignment.None) yield return ContentAlignment.ToCssClass(breakpoint);
        }
    }
}
