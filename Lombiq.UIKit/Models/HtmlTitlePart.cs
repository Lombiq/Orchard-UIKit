using AngleSharp;
using AngleSharp.Dom;
using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Models;

public sealed class HtmlTitlePart : ContentPart
{
    public HtmlField Title { get; set; } = new();

    public static async Task<string> CleanUpHtmlAsync(string html)
    {
        var node = HtmlHelper.ParseHtmlFragment(html);
        var elements = node
            .Descendants<IElement>()
            .Where(element =>
                element.ParentElement != null &&
                element.TagName.ToUpperInvariant() is "DIV" or "P")
            .ToList();

        foreach (var element in elements)
        {
            var parent = element.ParentElement!;

            foreach (var child in element.ChildNodes.ToList())
            {
                parent.InsertBefore(child, element);
            }

            parent.RemoveChild(element);
        }

        var builder = new StringBuilder();
        await using (var writer = new StringWriter(builder)) { await node.ToHtmlAsync(writer); }

        return builder.ToString();
    }
}
