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
using System.Linq;

namespace BigSolution.Bootstrap.Utilities
{
    public sealed class AbsoluteOrder : Order
    {
        #region Operators

        public static implicit operator AbsoluteOrder(OrderPosition position)
        {
            return ToAbsoluteOrder(position);
        }

        public static implicit operator AbsoluteOrder(string value)
        {
            return ToAbsoluteOrder(value);
        }

        #endregion

        internal static bool CanConvert(string value)
        {
            return ParseOrderPosition(value) != null;
        }

        private static OrderPosition? ParseOrderPosition(string value)
        {
            return Enum.GetValues(typeof(OrderPosition))
                .Cast<OrderPosition?>()
                .SingleOrDefault(position => string.Equals(position.GetValueOrDefault().GetCssClassPart(), value, StringComparison.InvariantCultureIgnoreCase));
        }

        private static AbsoluteOrder ToAbsoluteOrder(string value)
        {
            var orderPosition = ParseOrderPosition(value);
            return orderPosition.HasValue ? new AbsoluteOrder(orderPosition.Value) : throw new InvalidCastException();
        }

        private static AbsoluteOrder ToAbsoluteOrder(OrderPosition position)
        {
            return new AbsoluteOrder(position);
        }

        public AbsoluteOrder(OrderPosition position)
        {
            Position = position;
        }

        #region Base Class Member Overrides

        protected override void ConfigureCssClassBuilder(CssClassBuilder builder)
        {
            builder.Append(Position.GetCssClassPart());
        }

        #endregion

        public OrderPosition Position { get; }
    }
}
