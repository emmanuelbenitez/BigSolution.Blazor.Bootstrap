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
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap.Utilities
{
    public class BackgroundColorFixture
    {
        [Theory]
        [InlineData(Color.Muted)]
        [InlineData(Color.None)]
        public void BuildCssClassFailed(Color color)
        {
            Action action = () => new BackgroundColor { Color = color }.BuildCssClass();
            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Theory]
        [InlineData(Color.Active, true, "bg-gradient-active")]
        [InlineData(Color.Active, false, "bg-active")]
        public void BuildCssClassSucceeds(Color color, bool isGradient, string expectedCssClass)
        {
            new BackgroundColor { Color = color, IsGradient = isGradient }.BuildCssClass().Should().Be(expectedCssClass);
        }
    }
}
