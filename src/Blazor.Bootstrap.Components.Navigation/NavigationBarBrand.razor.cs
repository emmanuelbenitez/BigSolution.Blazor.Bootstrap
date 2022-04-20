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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BlazorComponentUtilities;
using JetBrains.Annotations;

namespace BigSolution.Bootstrap;

[UsedImplicitly]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class NavigationBarBrand
{
    #region Base Class Member Overrides

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass(CssClass);

    #endregion

    private IReadOnlyDictionary<string, object> Attributes
    {
        get
        {
            var attributes = AdditionalAttributes?.ToDictionary(attribute => attribute.Key, attribute => attribute.Value)
                ?? new Dictionary<string, object>();
            if (attributes.ContainsKey(HtmlAttributeNames.CLASS))
            {
                attributes[HtmlAttributeNames.CLASS] = string.Join(" ", attributes[HtmlAttributeNames.CLASS], CssClasses);
            }
            else
            {
                attributes.Add(HtmlAttributeNames.CLASS, CssClasses);
            }
            return attributes;
        }
    }

    private const string CSS_CLASS_SUFFIX = "brand";

    public static readonly string CssClass = new CssClassBuilder(NavigationBar.CSS_CLASS_PREFIX).Append(CSS_CLASS_SUFFIX).Build();
}
