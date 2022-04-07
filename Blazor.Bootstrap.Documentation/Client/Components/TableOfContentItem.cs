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

using System.Diagnostics.CodeAnalysis;
using BigSolution.Bootstrap;
using BlazorComponentUtilities;

namespace Blazor.Bootstrap.Documentation.Client.Components
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class TableOfContentItem : ActivatableDynamicElement
    {
        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder => base.CssBuilder.AddClass("bd-toc-item");

        #endregion
    }
}
