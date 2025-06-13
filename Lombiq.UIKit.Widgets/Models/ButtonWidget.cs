using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Lombiq.UIKit.Widgets.Models;

public class ButtonWidget : ContentPart
{
    public LinkField Link { get; set; } = new();

    [JsonInclude]
    internal TextField TypeName { get; set; } = new();

    [JsonInclude]
    internal TextField SizeName { get; set; } = new();

    public BooleanField Outlined { get; set; } = new();
    public BooleanField Disabled { get; set; } = new();

    [JsonIgnore]
    public ButtonType Type
    {
        get => TypeName.ParseEnum<ButtonType>();
        set => TypeName.Text = value.ToString();
    }

    [JsonIgnore]
    public ButtonSize Size
    {
        get => SizeName.ParseEnum<ButtonSize>();
        set => SizeName.Text = value.ToString();
    }

    public enum ButtonType
    {
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark,
        Link,
    }

    public enum ButtonSize
    {
        Small = -1,
        Medium = 0,
        Large = 1,
    }

    [SuppressMessage(
        "Globalization",
        "CA1308:Normalize strings to uppercase",
        Justification = "The HTML class names are expected to be lower case.")]
    public string GetClasses()
    {
        var classes = new[]
        {
            "btn",
            string.Join(
                '-',
                new[]
                {
                    "btn",
                    Outlined.Value ? "outline" : null,
                    Type.ToString().ToLowerInvariant(),
                }.WhereNot(string.IsNullOrEmpty)),
            Size switch
            {
                ButtonSize.Small => "btn-sm",
                ButtonSize.Medium => null,
                ButtonSize.Large => "btn-lg",
                _ => throw new ArgumentOutOfRangeException($"Unknown {nameof(ButtonSize)} value \"{Size}\"."),
            },
            Disabled.Value ? "disabled" : null,
        };

        return string.Join(' ', classes.WhereNot(string.IsNullOrEmpty));
    }
}
