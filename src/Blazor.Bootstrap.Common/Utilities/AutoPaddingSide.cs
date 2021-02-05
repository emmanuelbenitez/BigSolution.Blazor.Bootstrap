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

using System;

namespace BigSolution.Bootstrap.Utilities
{
    public class AutoPaddingSide : PaddingSide
    {
        #region Operators

        public static implicit operator AutoPaddingSide(string value)
        {
            return ToAutoPaddingSide(value);
        }

        #endregion

        private static bool CanConvert(string value)
        {
            return string.Equals(CSS_CLASS_SUFFIX, value, StringComparison.InvariantCultureIgnoreCase);
        }

        private static AutoPaddingSide ToAutoPaddingSide(string value)
        {
            if (!CanConvert(value))
            {
                throw new InvalidCastException(
                    $"The string can be only cast to {nameof(AutoPaddingSide)} when value equals to '{CSS_CLASS_SUFFIX}' (value={value})");
            }

            return new AutoPaddingSide { ImpactedSides = Sides.All };
        }

        #region Base Class Member Overrides

        protected override string GetCssClassSuffix()
        {
            return CSS_CLASS_SUFFIX;
        }

        #endregion

        private const string CSS_CLASS_SUFFIX = "auto";
    }
}
