using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System;

namespace Lombiq.UIKit.Widgets.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    public static void TestUIKitWidgetsBehavior(this UITestContext context)
    {
        context.TestCarouselWidgetContainerExistence();
        context.TestSlickCarouselExistence();
        context.TestCorrectNumberOfItemsIsDisplayed();
    }

    public static void TestCorrectNumberOfItemsIsDisplayed(this UITestContext context, int numberOfItems = 1) =>
        context.GetAll(By.ClassName("slick-active")).Count.ShouldBe(numberOfItems);

    public static void TestSlickCarouselExistence(this UITestContext context) =>
        context.Exists(By.ClassName("slickCarousel__carousel"));

    public static void TestCarouselWidgetContainerExistence(this UITestContext context) =>
      context.Exists(By.ClassName("carouselWidget"));
}
