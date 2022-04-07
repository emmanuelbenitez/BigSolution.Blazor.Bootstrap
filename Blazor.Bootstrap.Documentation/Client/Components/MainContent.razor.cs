﻿#region Copyright & License

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

using BigSolution.Bootstrap;
using BigSolution.Bootstrap.Utilities;
using Microsoft.AspNetCore.Components;

namespace Blazor.Bootstrap.Documentation.Client.Components
{
    public partial class MainContent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        private static readonly Padding _mediumPadding = new() {
            Sides = new PaddingSide[] {
                new FixedPaddingSide(3) { ImpactedSides = Sides.TopAndBottom },
                new FixedPaddingSide(5) { ImpactedSides = Sides.Left }
            }
        };
    }
}
