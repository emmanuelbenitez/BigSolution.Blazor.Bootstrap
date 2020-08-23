using System;
using System.Collections.Generic;
using System.Reflection;
using BigSolution.Bootstrap.Utilities;
using FluentAssertions;
using Xunit;

namespace BigSolution.Bootstrap
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
    public class BootstrapComponentBaseFixture
    {
        [Theory]
        [InlineData(Color.Active, "bg-active")]
        [InlineData(Color.None, "")]
        [InlineData(Color.Muted, "")]
        public void CssClassWellFormattedForBackgroundColor(Color color, string expectedCssClass)
        {
            _component.BackgroundColor = color;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Fact]
        public void CssClassWellFormattedForBorder()
        {
            _component.Border = Sides.All;
            _component.CssClasses.Should().Be("border");
        }

        [Fact]
        public void CssClassWellFormattedForClearFix()
        {
            _component.ClearFix = true;
            _component.CssClasses.Should().Be("clearfix");
        }

        [Fact]
        public void CssClassWellFormattedForDisplay()
        {
            _component.Display = DisplayType.Block;
            _component.CssClasses.Should().Be("d-block");
        }

        [Fact]
        public void CssClassWellFormattedForDisplayPrint()
        {
            _component.PrintDisplay = DisplayType.Block;
            _component.CssClasses.Should().Be("d-print-block");
        }

        [Fact]
        public void CssClassWellFormattedForExtraLargeDisplay()
        {
            _component.ExtraLargeDisplay = DisplayType.Block;
            _component.CssClasses.Should().Be("d-xl-block");
        }

        [Fact]
        public void CssClassWellFormattedForExtraLargeFlexSelfAlignment()
        {
            _component.ExtraLargeFlexSelfAlignment = FlexAlignment.Center;
            _component.CssClasses.Should().Be("align-self-xl-center");
        }

        [Theory]
        [InlineData(FloatPosition.None, "float-xl-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForExtraLargeFloatPosition(FloatPosition? position, string expectedCssClass)
        {
            _component.ExtraLargeFloatPosition = position;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [MemberData(nameof(ValidFlexOptions))]
        public void CssClassWellFormattedForFlexOptions(Action<BootstrapComponentBase> componentConfigurator, PropertyInfo property, string expected)
        {
            componentConfigurator?.Invoke(_component);
            property.SetValue(_component, (FlexOptions) FlexOrientation.Horizontal);
            _component.CssClasses.Should().Be(expected);
        }

        [Fact]
        public void CssClassWellFormattedForFlexSelfAlignment()
        {
            _component.FlexSelfAlignment = FlexAlignment.Center;
            _component.CssClasses.Should().Be("align-self-center");
        }

        [Theory]
        [InlineData(FloatPosition.None, "float-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForFloatPosition(FloatPosition? position, string expectedCssClass)
        {
            _component.FloatPosition = position;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(true, "text-hide")]
        [InlineData(false, "")]
        public void CssClassWellFormattedForHideText(bool hideText, string expectedCssClass)
        {
            _component.HideText = hideText;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Fact]
        public void CssClassWellFormattedForLargeDisplay()
        {
            _component.LargeDisplay = DisplayType.Block;
            _component.CssClasses.Should().Be("d-lg-block");
        }

        [Fact]
        public void CssClassWellFormattedForLargeFlexSelfAlignment()
        {
            _component.LargeFlexSelfAlignment = FlexAlignment.Center;
            _component.CssClasses.Should().Be("align-self-lg-center");
        }

        [Theory]
        [InlineData(FloatPosition.None, "float-lg-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForLargeFloatPosition(FloatPosition? position, string expectedCssClass)
        {
            _component.LargeFloatPosition = position;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Fact]
        public void CssClassWellFormattedForMediumDisplay()
        {
            _component.MediumDisplay = DisplayType.Block;
            _component.CssClasses.Should().Be("d-md-block");
        }

        [Fact]
        public void CssClassWellFormattedForMediumFlexSelfAlignment()
        {
            _component.MediumFlexSelfAlignment = FlexAlignment.Center;
            _component.CssClasses.Should().Be("align-self-md-center");
        }

        [Theory]
        [InlineData(FloatPosition.None, "float-md-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForMediumFloatPosition(FloatPosition? position, string expectedCssClass)
        {
            _component.MediumFloatPosition = position;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [MemberData(nameof(ValidOrders))]
        public void CssClassWellFormattedForOrder(Order order, PropertyInfo property, string expected)
        {
            property.SetValue(_component, order);
            _component.CssClasses.Should().Be(expected);
        }

        [Theory]
        [InlineData(Overflow.Auto, "overflow-auto")]
        [InlineData(Overflow.None, "")]
        public void CssClassWellFormattedForOverflow(Overflow overflow, string expectedCssClass)
        {
            _component.Overflow = overflow;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [MemberData(nameof(ValidScreenReaderOptions))]
        public void CssClassWellFormattedForScreenReaderOptions(ScreenReaderOptions options, string expected)
        {
            _component.ScreenReaderOptions = options;
            _component.CssClasses.Should().Be(expected);
        }

        [Theory]
        [InlineData(Shadow.Regular, "shadow")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForShadow(Shadow? shadow, string expectedCssClass)
        {
            _component.Shadow = shadow;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Fact]
        public void CssClassWellFormattedForSmallDisplay()
        {
            _component.SmallDisplay = DisplayType.Block;
            _component.CssClasses.Should().Be("d-sm-block");
        }

        [Fact]
        public void CssClassWellFormattedForSmallFlexSelfAlignment()
        {
            _component.SmallFlexSelfAlignment = FlexAlignment.Center;
            _component.CssClasses.Should().Be("align-self-sm-center");
        }

        [Theory]
        [InlineData(FloatPosition.None, "float-sm-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForSmallFloatPosition(FloatPosition? position, string expectedCssClass)
        {
            _component.SmallFloatPosition = position;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(Color.Active, "text-active")]
        [InlineData(Color.None, "")]
        public void CssClassWellFormattedForTextColor(Color color, string expectedCssClass)
        {
            _component.TextColor = color;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        [Theory]
        [InlineData(UserSelection.None, "user-select-none")]
        [InlineData(null, "")]
        public void CssClassWellFormattedForUserSelection(UserSelection? userSelection, string expectedCssClass)
        {
            _component.UserSelection = userSelection;
            _component.CssClasses.Should().Be(expectedCssClass);
        }

        public static IEnumerable<object[]> ValidScreenReaderOptions
        {
            get
            {
                yield return new object[] { null, "" };
                yield return new object[] { ScreenReaderOptions.Only, "sr-only" };
            }
        }

        public static IEnumerable<object[]> ValidFlexOptions
        {
            get
            {
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.FlexOptions)),
                    "d-flex flex-row"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Table),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.FlexOptions)),
                    "d-table"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.PrintDisplay = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.FlexOptions)),
                    "flex-row d-print-flex"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.PrintDisplay = DisplayType.Table),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.FlexOptions)),
                    "d-print-table"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.SmallFlexOptions)),
                    "d-flex flex-sm-row"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.MediumFlexOptions)),
                    "d-flex flex-md-row"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.LargeFlexOptions)),
                    "d-flex flex-lg-row"
                };
                yield return new object[] {
                    new Action<BootstrapComponentBase>(component => component.Display = DisplayType.Flex),
                    typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.ExtraLargeFlexOptions)),
                    "d-flex flex-xl-row"
                };
            }
        }

        public static IEnumerable<object[]> ValidOrders
        {
            get
            {
                yield return new object[] { (Order)1U, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.Order)), "order-1" };
                yield return new object[] { null, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.Order)), string.Empty };
                yield return new object[] { (Order)1U, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.SmallOrder)), "order-sm-1" };
                yield return new object[] { (Order)1U, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.MediumOrder)), "order-md-1" };
                yield return new object[] { (Order)1U, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.LargeOrder)), "order-lg-1" };
                yield return new object[] { (Order)1U, typeof(BootstrapComponentBase).GetProperty(nameof(BootstrapComponentBase.ExtraLargeOrder)), "order-xl-1" };
            }
        }

        private readonly FakeBootstrapComponent _component = new FakeBootstrapComponent();

        private class FakeBootstrapComponent : BootstrapComponentBase { }
    }
}
