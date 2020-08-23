﻿#region Copyright & License

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

namespace BigSolution.Bootstrap.Layout
{
    public class GridColumnFixture
    {
        [Fact]
        public void ColumnWidthInitialized()
        {
            var gridColumn = new GridColumn {
                Width = "auto",
                ExtraLargeWidth = "",
                LargeWidth = new GridColumnFixedWidth(6),
                MediumWidth = 3,
                SmallWidth = 12
            };
            gridColumn.CssClasses.Should().Contain("col-auto")
                .And.Contain("col-md-3")
                .And.Contain("col-lg-6")
                .And.Contain("col-xl");
        }
    }
}