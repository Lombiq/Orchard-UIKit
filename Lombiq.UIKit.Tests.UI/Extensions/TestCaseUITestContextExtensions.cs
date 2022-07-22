using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    public static async Task TestUIKitShowcaseBehaviorAsync(this UITestContext context)
    {
        await context.SignInDirectlyAndGoToRelativeUrlAsync("UIKitShowcase");
        await context.TestAccordionAsync();
        await context.TestDropdownButtonAsync();
    }

    public static async Task TestAccordionAsync(this UITestContext context)
    {
        await context.ClickReliablyOnAsync(By.Id("heading-first"));

        var accordionFirst = context.Get(By.Id("collapse-first"));
        accordionFirst.HasClass("show").ShouldBeTrue();

        var openIcons = context.GetAll(By.CssSelector(".bootstrapAccordionSample .card-header-icon.hide"));
        openIcons.Count.ShouldBe(1);
    }

    public static async Task TestDropdownButtonAsync(this UITestContext context)
    {
        await context.ClickReliablyOnAsync(By.CssSelector("#buttonContainerId2 button"));
        context.Get(By.CssSelector("#buttonContainerId2 > div")).Displayed.ShouldBeTrue();
    }
}
