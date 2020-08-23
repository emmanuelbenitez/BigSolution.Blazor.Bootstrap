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

using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap
{
    public class HeadingFixture
    {
        [Theory]
        [InlineData(HeadingSize.One, "h1")]
        [InlineData(HeadingSize.Two, "h2")]
        [InlineData(HeadingSize.Three, "h3")]
        [InlineData(HeadingSize.Four, "h4")]
        [InlineData(HeadingSize.Five, "h5")]
        [InlineData(HeadingSize.Six, "h6")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
        public void SizeInitializationFailed(HeadingSize size, string expectedTagName)
        {
            _ = new Heading { Size = size }.TagName.Should().Be(expectedTagName);
        }
    }
}
