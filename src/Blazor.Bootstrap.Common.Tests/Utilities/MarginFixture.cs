#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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

namespace BigSolution.Bootstrap.Utilities;

public class MarginFixture
{
    [Fact]
    public void IsAutoSucceeds()
    {
        var margin = Margin.IsAuto().OnStart().Build();
        margin.Should().NotBeNull();
        margin.Sides.Should().BeEquivalentTo(new[] { new AutoMarginSide() { ImpactedSides = Sides.Start } });
    }

    [Fact]
    public void IsFixedSucceeds()
    {
        var margin = Margin.IsFixedAt(0).OnStart().Build();
        margin.Should().NotBeNull();
        margin.Sides.Should().BeEquivalentTo(new[] { new FixedMarginSide(0) { ImpactedSides = Sides.Start } });
    }
}
