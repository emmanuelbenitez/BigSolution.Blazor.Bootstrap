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
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap;

public class GridColumnWidthFixture
{
    [Theory]
    [MemberData(nameof(GetValidString))]
    public void CastStringSucceeds(string value, Type expectedType)
    {
        ((GridColumnWidth) value).Should().NotBeNull().And.BeOfType(expectedType);
    }

    [Fact]
    public void CastUintSucceeds()
    {
        ((GridColumnWidth) 6).Should().BeOfType<GridColumnFixedWidth>().Subject.Width.Should().Be(6);
    }

    public static IEnumerable<object[]> GetValidString()
    {
        yield return new object[] { "", typeof(GridColumnDefaultWidth) };
        yield return new object[] { null, typeof(GridColumnDefaultWidth) };
        yield return new object[] { "auto", typeof(GridColumnAutoWidth) };
        yield return new object[] { "AUTO", typeof(GridColumnAutoWidth) };
        yield return new object[] { "6", typeof(GridColumnFixedWidth) };
    }
}