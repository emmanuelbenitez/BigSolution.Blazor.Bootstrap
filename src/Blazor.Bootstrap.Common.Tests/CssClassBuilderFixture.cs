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
        public void AppendFailed()
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
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public void CreationFailed(string prefix)
        {
            Action action = () => new CssClassBuilder(prefix);
            action.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be("prefix");
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
