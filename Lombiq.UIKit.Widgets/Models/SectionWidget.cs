using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;
using OrchardCore.Taxonomies.Fields;
using System.Text.Json.Serialization;

namespace Lombiq.UIKit.Widgets.Models;

public class SectionWidget : ContentPart
{
    public MediaField Images { get; set; } = new();
    public TaxonomyField Classes { get; set; } = new();

    [JsonInclude]
    internal TextField ImagePositionName { get; set; } = new();

    [JsonIgnore]
    public SectionImagePosition ImagePosition
    {
        get => ImagePositionName.ParseEnum<SectionImagePosition>();
        set => ImagePositionName.Text = value.ToString();
    }

    public enum SectionImagePosition
    {
        Above,
        Behind,
    }
}
