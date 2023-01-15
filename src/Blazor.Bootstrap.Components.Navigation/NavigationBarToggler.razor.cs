#region Copyright & License

// Copyright © 2020 - 2023 Emmanuel Benitez
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

using BlazorComponentUtilities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BigSolution.Bootstrap;

[UsedImplicitly]
public partial class NavigationBarToggler
{
    [Parameter]
    public bool Expanded { get; set; }

    [CascadingParameter]
    public NavigationBar NavigationBar { get; set; }

    [Parameter]
    public string Target { get; set; }

    private void Toggle(MouseEventArgs arg)
    {
        Expanded = !Expanded;
        if (Expanded) NavigationBar?.Expand();
        else NavigationBar?.Collapse();
    }

    public static readonly string CssClass = new CssClassBuilder(NavigationBar.CSS_CLASS_PREFIX).Append("toggler").Build();

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass(CssClass);
}
