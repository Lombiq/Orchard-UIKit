using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    /// <summary>
    /// Executes the UI test instructions for testing the UI Kit module.
    /// </summary>
    /// <param name="context">The UI Test context.</param>
    /// <param name="goToUrl">
    /// If set to <see langword="true"/>, it will navigate to <c>~/UIKitShowcase</c> directly, otherwise use the main
    /// menu from Lombiq Helpful Extensions.
    /// </param>
    /// <param name="validateScreenshot">
    /// If set to <see langword="true"/>, it will create a screenshot of the whole showcase page, which is used for
    /// visual verification.
    /// </param>
    public static async Task TestUIKitShowcaseBehaviorAsync(
        this UITestContext context,
        bool goToUrl = false,
        bool validateScreenshot = true)
    {
        if (goToUrl)
        {
            await context.SignInDirectlyAndGoToRelativeUrlAsync("UIKitShowcase");
        }
        else
        {
            await context.SignInDirectlyAndGoToHomepageAsync();
            await context.ClickReliablyOnAsync(By.XPath("//a[contains(@class, 'menuWidget__dropdown') and contains(., 'UI Kit')]"));
            await context.ClickReliablyOnAsync(By.CssSelector(".menuWidget__dropdownItem[href*='/UIKitShowcase']"));
            context.SwitchToLastWindow(); // Necessary because it opens in a new tab.
        }

        if (validateScreenshot)
        {
            // Clean up page and ensure daylight mode for more reliable screenshotting.
            await context.SelectFromBootstrapDropdownReliablyAsync(
                context.Get(By.Id("bd-theme")),
                By.CssSelector("[data-bs-theme-value='light']"));
            context.ExecuteScript(
                "document.querySelectorAll('.ta-navbar-top, #ta-left-sidebar').forEach((element) => element.remove());" +
                "document.querySelector('.ta-content').style.margin = '0';" +
                "document.body.style.width = '1500px';" +
                "document.body.style.minHeight = '2800px';" +
                "document.body.style.overflow = 'hidden';");

            // Add some delay to ensure that any admin theme animations have finished.
            await Task.Delay(TimeSpan.FromSeconds(2), CancellationToken.None);

            context.AssertVisualVerificationApproved(
                pixelErrorPercentageThreshold: 5,
                configurator: configuration => configuration
                    .WithUsePlatformAsSuffix()
                    .WithUseBrowserNameAsSuffix());
            await context.RefreshAsync();
        }

        await context.TestAccordionAsync();
        await context.TestDropdownButtonAsync();
        context.TestSlickCarousel();
    }

    public static async Task TestAccordionAsync(this UITestContext context)
    {
        await context.ClickReliablyOnAsync(By.Id("heading-first"));

        var accordionFirst = context.Get(By.Id("collapse-first"));
        context.WaitElementToNotChange(By.Id("collapse-first"));
        accordionFirst.HasClass("show").ShouldBeTrue();

        var openIcons = context.GetAll(By.CssSelector(".bootstrapAccordionSample .card-header-icon.hide"));
        openIcons.Count.ShouldBe(1);
    }

    public static async Task TestDropdownButtonAsync(this UITestContext context)
    {
        await context.ClickReliablyOnAsync(By.CssSelector("#buttonContainerId2 button"));
        context.Get(By.CssSelector("#buttonContainerId2 > ul")).Displayed.ShouldBeTrue();
    }

    public static void TestSlickCarousel(this UITestContext context) =>
        context.GetAll(By.ClassName("slick-active")).Count.ShouldBe(4);
}
