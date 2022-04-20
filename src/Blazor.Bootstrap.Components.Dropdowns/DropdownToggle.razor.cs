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

using System.Collections.Generic;
using System.Linq;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap;

public partial class DropdownToggle
{
    #region Base Class Member Overrides

    protected override CssBuilder CssBuilder => new("dropdown-toggle");

    protected override string DefaultTagName => IsLink ? "a" : "button";

    #endregion

    [Parameter]
    public bool IsLink { get; set; }

    private IReadOnlyDictionary<string, object> Attributes
    {
        get
        {
            var attributes = AdditionalAttributes?.ToDictionary(attribute => attribute.Key, attribute => attribute.Value)
                ?? new Dictionary<string, object>();
            attributes.Add("data-toggle", "dropdown");
            return attributes;
        }
    }
}
