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
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap;

public class NavigationBarCollapse : BootstrapComponentBase
{
    #region Base Class Member Overrides

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass(CSS_CLASS)
        .AddClass(CssClass)
        .AddClass(() => Expanded ? ShowClass : HideClass, true);

    #endregion

    #region Base Class Member Overrides

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _initialized = true;
    }

    protected override void OnParametersSet()
    {
        NavigationBar.SetCollapse(this);
    }

    #endregion

    public bool Expanded
    {
        get => _expanded;
        set
        {
            _expanded = value;
            if (_initialized) StateHasChanged();
        }
    }

    [Parameter]
    public string HideClass { get; set; }

    [CascadingParameter]
    public NavigationBar NavigationBar { get; set; }

    [Parameter]
    public string ShowClass { get; set; }

    private const string CSS_CLASS = "collapse";

    public static readonly string CssClass = new CssClassBuilder(NavigationBar.CSS_CLASS_PREFIX).Append(CSS_CLASS).Build();
    private bool _expanded;

    private bool _initialized;
}
