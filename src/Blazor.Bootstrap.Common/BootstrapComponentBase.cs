#region Copyright & License

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

using System.Collections.Generic;
using System.Linq;
using BigSolution.Blazor;
using BigSolution.Bootstrap.Utilities;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace BigSolution.Bootstrap
{
    public abstract class BootstrapComponentBase : DynamicElement
    {
        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder
        {
            get
            {
                var cssBuilder = base.CssBuilder;

                foreach (var floatPosition in _floatPositionDictionary.Where(pair => pair.Value != null))
                {
                    cssBuilder.AddClass(() => floatPosition.Value.GetValueOrDefault().ToCssClass(floatPosition.Key), true);
                }

                foreach (var display in _displayDictionary.Where(pair => pair.Value != null))
                {
                    cssBuilder.AddClass(display.Value?.ToCssClass(display.Key));
                }

                foreach (var selfAlignment in _flexSelfAlignmentDictionary.Where(pair => pair.Value != FlexAlignment.None))
                {
                    cssBuilder.AddClass(selfAlignment.Value.ToCssClass(FlexAlignmentScope.Self, selfAlignment.Key));
                }

                foreach (var order in _orderDictionary.Where(pair => pair.Value != null))
                {
                    cssBuilder.AddClass(order.Value.BuildCssClass(order.Key));
                }

                cssBuilder = _marginDictionary
                    .Where(pair => pair.Value != null)
                    .Aggregate(
                        cssBuilder,
                        (current, margin) => current.AddClasses(margin.Value.BuildCssClasses(margin.Key)));

                if (IsFlex)
                {
                    cssBuilder = _flexOptionsDictionary
                        .Where(pair => pair.Value != null)
                        .Aggregate(
                            cssBuilder,
                            (current, flexDirection) => current.AddClasses(flexDirection.Value.BuildCssClasses(flexDirection.Key)));
                }

                return cssBuilder
                    .AddClass(() => TextAlign.ToCssClass(), () => TextAlign != TextAlign.None)
                    .AddClass(() => BackgroundColor.BuildCssClass(), () => BackgroundColor?.HasValidColor ?? false)
                    .AddClass(() => new CssClassBuilder(Constants.TEXT_PREFIX_CLASS).Append(TextColor.GetCssClassPart()).Build(), () => TextColor != Color.None)
                    .AddClasses(Border?.BuildCssClasses())
                    .AddClass(() => PrintDisplay?.ToPrintCssClass(), () => PrintDisplay != null)
                    .AddClass(() => "clearfix", ClearFix)
                    .AddClass(() => "text-hide", () => HideText)
                    .AddClass(() => UserSelection.ToCssClass(), () => UserSelection != null)
                    .AddClass(() => Overflow.ToCssClass(), () => Overflow != Overflow.None)
                    .AddClass(() => Shadow.ToCssClass(), () => Shadow != null)
                    .AddClasses(ScreenReaderOptions?.BuildCssClasses());
            }
        }

        #endregion

        [Parameter]
        public BackgroundColor BackgroundColor { get; set; }

        [Parameter]
        public Border Border { get; set; }

        [Parameter]
        public bool ClearFix { get; set; }

        [Parameter]
        public DisplayType? Display
        {
            get => _displayDictionary[Breakpoint.None];
            set => _displayDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public DisplayType? ExtraLargeDisplay
        {
            get => _displayDictionary[Breakpoint.ExtraLarge];
            set => _displayDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public FlexOptions ExtraLargeFlexOptions
        {
            get => _flexOptionsDictionary[Breakpoint.ExtraLarge];
            set => _flexOptionsDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public FlexAlignment ExtraLargeFlexSelfAlignment
        {
            get => _flexSelfAlignmentDictionary[Breakpoint.ExtraLarge];
            set => _flexSelfAlignmentDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public FloatPosition? ExtraLargeFloatPosition
        {
            get => _floatPositionDictionary[Breakpoint.ExtraLarge];
            set => _floatPositionDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public Margin ExtraLargeMargin
        {
            get => _marginDictionary[Breakpoint.ExtraLarge];
            set => _marginDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public Order ExtraLargeOrder
        {
            get => _orderDictionary[Breakpoint.ExtraLarge];
            set => _orderDictionary[Breakpoint.ExtraLarge] = value;
        }

        [Parameter]
        public FlexOptions FlexOptions
        {
            get => _flexOptionsDictionary[Breakpoint.None];
            set => _flexOptionsDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public FlexAlignment FlexSelfAlignment
        {
            get => _flexSelfAlignmentDictionary[Breakpoint.None];
            set => _flexSelfAlignmentDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public FloatPosition? FloatPosition
        {
            get => _floatPositionDictionary[Breakpoint.None];
            set => _floatPositionDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public bool HideText { get; set; }

        [Parameter]
        public DisplayType? LargeDisplay
        {
            get => _displayDictionary[Breakpoint.Large];
            set => _displayDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public FlexOptions LargeFlexOptions
        {
            get => _flexOptionsDictionary[Breakpoint.Large];
            set => _flexOptionsDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public FlexAlignment LargeFlexSelfAlignment
        {
            get => _flexSelfAlignmentDictionary[Breakpoint.Large];
            set => _flexSelfAlignmentDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public FloatPosition? LargeFloatPosition
        {
            get => _floatPositionDictionary[Breakpoint.Large];
            set => _floatPositionDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public Margin LargeMargin
        {
            get => _marginDictionary[Breakpoint.Large];
            set => _marginDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public Order LargeOrder
        {
            get => _orderDictionary[Breakpoint.Large];
            set => _orderDictionary[Breakpoint.Large] = value;
        }

        [Parameter]
        public Margin Margin
        {
            get => _marginDictionary[Breakpoint.None];
            set => _marginDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public DisplayType? MediumDisplay
        {
            get => _displayDictionary[Breakpoint.Medium];
            set => _displayDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public FlexOptions MediumFlexOptions
        {
            get => _flexOptionsDictionary[Breakpoint.Medium];
            set => _flexOptionsDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public FlexAlignment MediumFlexSelfAlignment
        {
            get => _flexSelfAlignmentDictionary[Breakpoint.Medium];
            set => _flexSelfAlignmentDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public FloatPosition? MediumFloatPosition
        {
            get => _floatPositionDictionary[Breakpoint.Medium];
            set => _floatPositionDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public Margin MediumMargin
        {
            get => _marginDictionary[Breakpoint.Medium];
            set => _marginDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public Order MediumOrder
        {
            get => _orderDictionary[Breakpoint.Medium];
            set => _orderDictionary[Breakpoint.Medium] = value;
        }

        [Parameter]
        public Order Order
        {
            get => _orderDictionary[Breakpoint.None];
            set => _orderDictionary[Breakpoint.None] = value;
        }

        [Parameter]
        public Overflow Overflow { get; set; }

        [Parameter]
        public DisplayType? PrintDisplay { get; set; }

        [Parameter]
        public ScreenReaderOptions ScreenReaderOptions { get; set; }

        [Parameter]
        public Shadow? Shadow { get; set; }

        [Parameter]
        public DisplayType? SmallDisplay
        {
            get => _displayDictionary[Breakpoint.Small];
            set => _displayDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public FlexOptions SmallFlexOptions
        {
            get => _flexOptionsDictionary[Breakpoint.Small];
            set => _flexOptionsDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public FlexAlignment SmallFlexSelfAlignment
        {
            get => _flexSelfAlignmentDictionary[Breakpoint.Small];
            set => _flexSelfAlignmentDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public FloatPosition? SmallFloatPosition
        {
            get => _floatPositionDictionary[Breakpoint.Small];
            set => _floatPositionDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public Margin SmallMargin
        {
            get => _marginDictionary[Breakpoint.Small];
            set => _marginDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public Order SmallOrder
        {
            get => _orderDictionary[Breakpoint.Small];
            set => _orderDictionary[Breakpoint.Small] = value;
        }

        [Parameter]
        public TextAlign TextAlign { get; set; }

        [Parameter]
        public Color TextColor { get; set; }

        [Parameter]
        public UserSelection? UserSelection { get; set; }

        protected virtual bool IsFlex => PrintDisplay.IsFlex() || _displayDictionary.Values.Any(display => display.IsFlex());

        private readonly Dictionary<Breakpoint, DisplayType?> _displayDictionary = new Dictionary<Breakpoint, DisplayType?> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null },
        };

        private readonly Dictionary<Breakpoint, FlexOptions> _flexOptionsDictionary = new Dictionary<Breakpoint, FlexOptions> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null },
        };

        private readonly Dictionary<Breakpoint, FlexAlignment> _flexSelfAlignmentDictionary = new Dictionary<Breakpoint, FlexAlignment> {
            { Breakpoint.None, default },
            { Breakpoint.Small, default },
            { Breakpoint.Medium, default },
            { Breakpoint.Large, default },
            { Breakpoint.ExtraLarge, default },
        };

        private readonly Dictionary<Breakpoint, FloatPosition?> _floatPositionDictionary = new Dictionary<Breakpoint, FloatPosition?> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null }
        };

        private readonly Dictionary<Breakpoint, Margin> _marginDictionary = new Dictionary<Breakpoint, Margin> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null },
        };

        private readonly Dictionary<Breakpoint, Order> _orderDictionary = new Dictionary<Breakpoint, Order> {
            { Breakpoint.None, null },
            { Breakpoint.Small, null },
            { Breakpoint.Medium, null },
            { Breakpoint.Large, null },
            { Breakpoint.ExtraLarge, null },
        };
    }
}
