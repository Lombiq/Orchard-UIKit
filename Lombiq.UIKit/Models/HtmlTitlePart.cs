using AngleSharp;
using AngleSharp.Dom;
using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Models;

public sealed class HtmlTitlePart : ContentPart
{
    private static readonly string[] _blockElements = ["DIV", "P"];
    private static readonly string[] _headerElements = ["H1", "H2", "H3", "H4", "H5", "H6"];

    public HtmlField Title { get; set; } = new();

    /// <summary>
    /// Verifies and if necessary, sanitizes the provided <paramref name="html"/>.
    /// </summary>
    /// <returns>
    /// If it contains a heading element (e.g. <c>&lt;h1&gt;</c> or <c>&lt;h2&gt;</c>) then <paramref name="html"/> is
    /// returned as-is. Otherwise, the content is wrapped with a heading element of the provided <paramref
    /// name="headingLevel"/> with an optional <c>class=""</c> attribute containing <paramref name="classes"/>. In this
    /// case block elements like <c>&lt;div&gt;</c> and <c>&lt;p&gt;</c> are also stripped out.
    /// </returns>
    public static Task<string> GetHtmlAsync(string html, int headingLevel = 1, string classes = null)
    {
        var node = HtmlHelper.ParseHtmlFragment(html);
        var containsHeaderElement = node
            .Descendants<IElement>()
            .Any(element => _headerElements.Contains(element.TagName.ToUpperInvariant()));

        return containsHeaderElement ? Task.FromResult(html) : GetHtmlInnerAsync(node, headingLevel);
    }

    private static async Task<string> GetHtmlInnerAsync(INode node, int headingLevel)
    {
        var elements = node
            .Descendants<IElement>()
            .Where(element =>
                element.ParentElement != null &&
                _blockElements.Contains(element.TagName.ToUpperInvariant()))
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

        var level = int.Clamp(headingLevel, 1, 6).ToTechnicalString();
        return $"<h{level}>{builder}</h{level}>";
    }
}
