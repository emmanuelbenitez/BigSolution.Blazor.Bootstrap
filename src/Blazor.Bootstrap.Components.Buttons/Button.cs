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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BigSolution.Bootstrap;

public class Button : BootstrapComponentBase
{
    #region Base Class Member Overrides

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass(DEFAULT_CSS_CLASS)
        .AddColor(HasOutline ? $"{DEFAULT_CSS_CLASS}-outline" : DEFAULT_CSS_CLASS, () => Color)
        .AddButtonSize(() => Size)
        .AddClass("disabled", () => TagName == HtmlTagNames.A && Disabled);

    #endregion

    #region Base Class Member Overrides

    protected override string DefaultTagName => HtmlTagNames.BUTTON;

    protected override IEnumerable<string> SupportedTagNames => new[] { HtmlTagNames.A, HtmlTagNames.BUTTON, HtmlTagNames.INPUT };

    #endregion

    #region Base Class Member Overrides

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var sequenceGenerator = new SequenceGenerator();

        builder.OpenElement(sequenceGenerator.GetNextValue(), TagName);
        builder.AddAttribute(sequenceGenerator.GetNextValue(), "class", CssClasses);
        if (TagName == HtmlTagNames.BUTTON || TagName == HtmlTagNames.INPUT) builder.AddAttribute(sequenceGenerator.GetNextValue(), "type", Type.GetCssClassPart());
        else builder.AddAttribute(sequenceGenerator.GetNextValue(), "role", "button");
        builder.AddMultipleAttributes(sequenceGenerator.GetNextValue(), AdditionalAttributes?.Where(pair => pair.Key != "class"));
        builder.AddContent(sequenceGenerator.GetNextValue(), ChildContent);
        builder.CloseElement();
    }

    #endregion

    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool HasOutline { get; set; }

    [Parameter]
    public ButtonSize Size { get; set; }

    [Parameter]
    public ButtonType Type { get; set; }

    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Constant")]
    public const string DEFAULT_CSS_CLASS = "btn";
}