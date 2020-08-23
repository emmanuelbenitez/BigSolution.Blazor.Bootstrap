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

namespace BigSolution.Bootstrap.Utilities
{
    public class FlexAlignmentExtensionsFixture
    {
        [Theory]
        [InlineData(FlexAlignment.Center, FlexAlignmentScope.Items, Breakpoint.Small, "align-items-sm-center")]
        [InlineData(FlexAlignment.Center, FlexAlignmentScope.Items, Breakpoint.None, "align-items-center")]
        [InlineData(FlexAlignment.End, FlexAlignmentScope.Items, Breakpoint.None, "align-items-end")]
        [InlineData(FlexAlignment.Baseline, FlexAlignmentScope.Items, Breakpoint.None, "align-items-baseline")]
        [InlineData(FlexAlignment.Start, FlexAlignmentScope.Items, Breakpoint.None, "align-items-start")]
        [InlineData(FlexAlignment.Stretch, FlexAlignmentScope.Items, Breakpoint.None, "align-items-stretch")]
        [InlineData(FlexAlignment.None, FlexAlignmentScope.Items, Breakpoint.None, "")]
        public void ToCssClassSucceeds(FlexAlignment alignment, FlexAlignmentScope scope, Breakpoint breakpoint, string expected)
        {
            alignment.ToCssClass(scope, breakpoint).Should().Be(expected);
        }
    }
}
