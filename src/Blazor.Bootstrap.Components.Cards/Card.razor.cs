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

using BigSolution.Bootstrap.Utilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap
{
    public partial class Card
    {
        #region Base Class Member Overrides

        protected override bool IsFlex => true;

        #endregion

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public string BodyClasses { get; set; }

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public string FooterClasses { get; set; }

        [Parameter]
        public bool HasOutline { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public string HeaderClasses { get; set; }
    }
}
