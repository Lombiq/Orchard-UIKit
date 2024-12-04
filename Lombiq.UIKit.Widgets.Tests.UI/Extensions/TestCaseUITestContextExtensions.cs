using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Widgets.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    public static async Task TestUIKitShowcaseBehaviorAsync(this UITestContext context)
    {
        context.TestSlickCarousel();
    }

    public static void TestSlickCarousel(this UITestContext context) =>
        context.GetAll(By.ClassName("slick-active")).Count.ShouldBe(4);
}
