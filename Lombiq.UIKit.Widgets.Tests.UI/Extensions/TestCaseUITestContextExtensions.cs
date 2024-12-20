using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Widgets.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    public static async Task TestUIKitWidgetsBehaviorAsync(this UITestContext context)
    {
        context.TestCarouselWidgetExistence();
        context.TestCorrectNumberOfItemsIsDisplayed();
    }

    public static void TestCorrectNumberOfItemsIsDisplayed(this UITestContext context) =>
        context.GetAll(By.ClassName("slick-active")).Count.ShouldBe(1);
    public static void TestCarouselWidgetExistence(this UITestContext context) =>
        context.Exists(By.ClassName("slickCarousel__carousel"));
}
