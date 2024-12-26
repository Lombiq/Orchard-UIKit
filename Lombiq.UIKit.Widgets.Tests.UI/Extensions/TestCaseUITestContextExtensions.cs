using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Widgets.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    private const string CarouselWidgetPartSettingsUrl = "/ContentTypes/CarouselWidget/ContentParts/CarouselWidgetPart/Edit";
    private const string CarouselWidgetExamplePageUrl = "/carousel-widget-example";

    public static async Task TestCarouselWidgetBehaviorAsync(this UITestContext context)
    {
        await context.GoToRelativeUrlAsync(CarouselWidgetExamplePageUrl);
        context.TestCarouselWidgetContainerExistence();
        context.TestSlickCarouselExistence();
        context.TestCorrectNumberOfItemsIsDisplayed();
    }

    public static async Task TestCarouselWidgetOptionsAsync(this UITestContext context)
    {
        int slidesToShow = 3;
        bool showDots = false;

        await context.SignInDirectlyAndGoToAdminRelativeUrlAsync(CarouselWidgetPartSettingsUrl);
        context.WaitForPageLoad();
        var options = JsonSerializer.Serialize(new { slidesToShow, dots = showDots });
        context.ExecuteScript($"codeMirrorJsonEditor.setValue('{options}')");
        await context.ClickReliablyOnSubmitAsync();
        await context.GoToRelativeUrlAsync(CarouselWidgetExamplePageUrl);
        context.TestCorrectNumberOfItemsIsDisplayed(slidesToShow);
        context.TestCarouselWidgetDotsVisibility(showDots);
    }

    public static void TestCorrectNumberOfItemsIsDisplayed(this UITestContext context, int numberOfItems = 1) =>
        context.GetAll(By.ClassName("slick-active")).Count.ShouldBe(numberOfItems);

    public static void TestSlickCarouselExistence(this UITestContext context) =>
        context.Exists(By.ClassName("slickCarousel__carousel"));

    public static void TestCarouselWidgetContainerExistence(this UITestContext context) =>
        context.Exists(By.ClassName("carouselWidget"));

    public static void TestCarouselWidgetDotsVisibility(this UITestContext context, bool showDots)
    {
        var by = By.CssSelector("ul.slick-dots");
        if (showDots)
            context.Exists(by);
        else
            context.GetAll(by).Count.ShouldBe(0);
    }
}
