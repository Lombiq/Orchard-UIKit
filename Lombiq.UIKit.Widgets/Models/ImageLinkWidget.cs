using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Lombiq.UIKit.Widgets.Models;

public class ImageLinkWidget : ContentPart
{
    public MediaField Images { get; set; } = new();
    public TextField Links { get; set; } = new();

    /// <summary>
    /// Correlates the data from the different collections in this object into a single enumerable.
    /// </summary>
    public IEnumerable<(string Path, string Text, string? Link, int Index)> GetItemData()
    {
        var paths = Images.Paths ?? [];
        var mediaTexts = Images.MediaTexts ?? [];
        var links = JsonHelpers.TryParse(Links.Text, out var linksJson) && linksJson is JsonArray linksJsonArray
            ? linksJsonArray.Select(item => item?.GetValueKind() == JsonValueKind.String ? item.GetValue<string>() : null)
            : [];

        return paths
            .Zip(mediaTexts.TakeExactly(paths.Length), links.TakeExactly(paths.Length))
            .Select((zip, index) => (Path: zip.First, Text: zip.Second, Link: zip.Third, Index: index));
    }
}
