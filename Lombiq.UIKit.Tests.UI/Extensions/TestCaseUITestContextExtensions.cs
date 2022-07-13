using Atata;
using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using OpenQA.Selenium;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Tests.UI.Extensions;

public static class TestCaseUITestContextExtensions
{
    public static async Task TestUIKitShowcaseBehaviorAsync(this UITestContext context)
    {
        await context.TestGroupCountAsync();
        await context.TestGroupCountAsync();
    }

    public static async Task TestGroupCountAsync(this UITestContext context)
    {
        throw new NotImplementedException();
    }
}
