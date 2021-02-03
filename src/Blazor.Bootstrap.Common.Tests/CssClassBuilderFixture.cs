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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap
{
    public class CssClassBuilderFixture
    {
        [Fact]
        public void AppendFails()
        {
            Action action = () => new CssClassBuilder("a").Append((Func<string>) null, null);
            action.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("valueGetter");
        }

        [Theory]
        [MemberData(nameof(GetValidBuilder))]
        public void BuildSucceeds(CssClassBuilder builder, string expected)
        {
            builder.Build().Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("prefix")]
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public void InstanceCreated(string prefix)
        {
            new CssClassBuilder(prefix);
        }

        public static IEnumerable<object[]> GetValidBuilder()
        {
            yield return new object[] { new CssClassBuilder("a").Append(string.Empty), "a" };
            yield return new object[] { new CssClassBuilder("a").Append((string) null), "a" };
            yield return new object[] { new CssClassBuilder("a").Append(" "), "a" };
            yield return new object[] { new CssClassBuilder("a").Append("test"), "a-test" };
            yield return new object[] { new CssClassBuilder("a").Append("test", false), "a" };
            yield return new object[] { new CssClassBuilder("a").Append("test", () => false), "a" };
            yield return new object[] { new CssClassBuilder("a").Append("test", () => true), "a-test" };
        }
    }
}
