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
    public abstract class Order
    {
        #region Operators

        public static implicit operator Order(uint value)
        {
            return ToOrder(value);
        }

        public static implicit operator Order(string value)
        {
            return ToOrder(value);
        }

        #endregion

        private static Order ToOrder(string value)
        {
            if (FixedOrder.CanConvert(value)) return (FixedOrder) value;
            if (AbsoluteOrder.CanConvert(value)) return (AbsoluteOrder) value;

            throw new InvalidCastException(
                $"The string can be only cast to {nameof(Order)} when value equals to '{OrderPosition.First.GetCssClassPart()}' or '{OrderPosition.Last.GetCssClassPart()}' or is a number (value={value})");
        }

        private static Order ToOrder(uint value)
        {
            return (FixedOrder) value;
        }

        public string BuildCssClass(Breakpoint breakpoint)
        {
            var builder = new CssClassBuilder("order")
                .Append(() => breakpoint.GetCssClassPart(), () => breakpoint != Breakpoint.None);
            ConfigureCssClassBuilder(builder);
            return builder.Build();
        }

        protected abstract void ConfigureCssClassBuilder(CssClassBuilder builder);
    }
}
