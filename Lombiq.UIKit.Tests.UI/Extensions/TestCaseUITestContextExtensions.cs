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
        context.TestGroupCount();
        await context.TestAccordionAsync();
        await context.TestDropdownButtonAsync();
    }

    public static void TestGroupCount(this UITestContext context)
    {
        // Groups are correct
        string[] correctGroupNames =
        {
            "Textbox:",
            "Checkbox:",
            "Custom classes:",
            "Hint positioning:",
            "Bootstrap dropdown:",
            "Bootstrap controls:",
        };

        var groupNames = context.GetAll(By.CssSelector("showcaseContainer__item h1"));

        groupNames.ShouldBeSameAs(correctGroupNames);
    }

    public static async Task TestAccordionAsync(this UITestContext context)
    {
        var accordionFirst = context.Get(By.Id("collapse-first"));

        await accordionFirst.ClickReliablyAsync(context);

        accordionFirst.HasClass("show");

        var closedIcons = context.GetAll(By.CssSelector(".bootstrapAccordionSample .card-header-icon"));
        var openIcons = context.GetAll(By.CssSelector(".bootstrapAccordionSample .card-header-icon .hide"));

        for (var i = 0; i < closedIcons.Count; i++)
        {
            if (i == 0)
            {
                closedIcons[i].Displayed.ShouldBeFalse();
                openIcons[i].Displayed.ShouldBeTrue();
            }
            else
            {
                closedIcons[i].Displayed.ShouldBeTrue();
                openIcons[i].Displayed.ShouldBeFalse();
            }
        }
    }

    public static async Task TestDropdownButtonAsync(this UITestContext context)
    {
        await context.ClickReliablyOnAsync(By.CssSelector("#buttonContainerId2 button"));
        context.Get(By.CssSelector("#buttonContainerId2 > div")).Displayed.ShouldBeTrue();
    }
}
