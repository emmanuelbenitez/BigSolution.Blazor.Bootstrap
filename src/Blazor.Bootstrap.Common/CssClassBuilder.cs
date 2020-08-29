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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BigSolution.Bootstrap
{
    public sealed class CssClassBuilder
    {
        #region Nested Type: CssClassPart

        private class CssClassPart
        {
            public CssClassPart(Func<string> valueGetter, Func<bool> conditionGetter)
            {
                ValueGetter = valueGetter;
                ConditionGetter = conditionGetter;
            }

            public Func<bool> ConditionGetter { get; }

            public Func<string> ValueGetter { get; }
        }

        #endregion

        public CssClassBuilder(string prefix)
        {
            _prefix = prefix;
            Append(() => _prefix);
        }

        public CssClassBuilder Append(string value, bool condition = true)
        {
            return Append(() => value, () => condition);
        }

        public CssClassBuilder Append(string value, Func<bool> conditionGetter)
        {
            return Append(() => value, conditionGetter);
        }

        public CssClassBuilder Append(Func<string> valueGetter, bool condition = true)
        {
            return Append(valueGetter, () => condition);
        }

        public CssClassBuilder Append(Func<string> valueGetter, Func<bool> conditionGetter)
        {
            Requires.Argument(valueGetter, nameof(valueGetter))
                .IsNotNull()
                .Check();
            Requires.Argument(conditionGetter, nameof(conditionGetter))
                .IsNotNull()
                .Check();
            _parts.Add(new CssClassPart(valueGetter, conditionGetter));
            return this;
        }

        public string Build()
        {
            return string.Join(
                SEPARATOR,
                _parts
                    .Where(part => part.ConditionGetter())
                    .Select(part => part.ValueGetter())
                    .Where(value => !string.IsNullOrWhiteSpace(value)));
        }

        private const string SEPARATOR = "-";

        private readonly List<CssClassPart> _parts = new List<CssClassPart>();

        [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
        private readonly string _prefix;
    }
}
