using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Lombiq.UIKit.Models;

public sealed class HtmlTitlePart : ContentPart
{
    public HtmlField Title { get; set; } = new();

    public string GetPlainText() => HtmlHelper.ConvertToPlainText(Title.Html);
}
