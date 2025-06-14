using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace Lombiq.UIKit.Widgets.Models;

public class ImageLinkWidget : ContentPart
{
    public MediaField Images { get; set; } = new();

    /// <summary>
    /// Correlates the data from the different collections in this object into a single enumerable.
    /// </summary>
    public IEnumerable<(string Path, string Text, string? Link)> GetItemData()
    {
        if (Images.Paths is not { Length: > 0 } paths) return [];

        var length = paths.Length;
        var mediaTexts = (Images.MediaTexts ?? []).TakeExactly(length);
        var links = new string?[length];

        for (var i = 0; i < length; i++)
        {
            var text = mediaTexts[i]?.Trim();

            if (text == "-")
            {
                text = string.Empty;
                links[i] = "-";
            }

            if (string.IsNullOrEmpty(text))
            {
                mediaTexts[i] = paths[i]
                    .Split('/')[^1]
                    .Split('?')[0];
            }
            else if (text.Partition("|") is ({ } left, not null, { } right))
            {
                mediaTexts[i] = left.TrimEnd();
                links[i] = right.TrimStart();
            }
            else
            {
                mediaTexts[i] = text;
            }
        }

        return paths.Zip(mediaTexts, links);
    }
}
