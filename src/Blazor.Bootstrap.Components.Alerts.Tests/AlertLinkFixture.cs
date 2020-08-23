using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BigSolution.Bootstrap.Components.Alerts
{
    public class AlertLinkFixture : TestContext
    {
        [Fact]
        public void CssClassWellFormatted()
        {
            Services.AddSingleton<NavigationManager>(new MockNavigationManager("http://localhost/"));
            var renderedComponent = RenderComponent<AlertLink>();
            renderedComponent.Find("a").ClassName.Should().Contain("alert-link", Exactly.Once());
        }
    }
}
