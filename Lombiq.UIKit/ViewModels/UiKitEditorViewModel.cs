using Lombiq.UIKit.Extensions;
using Lombiq.UIKit.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Lombiq.UIKit.Constants.Classes;

namespace Lombiq.UIKit.ViewModels;

public class UiKitEditorViewModel : ShapeViewModel
{
    public EditorTypes Type { get; set; }
    public string BlockId { get; set; }
    public string BlockClassName { get; set; }
    public string ButtonContainerId { get; set; }
    public string ButtonId { get; set; }
    public bool Disabled { get; set; }
    public string DropdownContainerId { get; set; }
    public ModelExpression For { get; set; }
    public bool HideSelectedFromDropdownList { get; set; }
    public LocalizedHtmlString Hint { get; set; }
    public HintPosition HintPosition { get; set; }
    public string IconClasses { get; set; }
    public string InputClasses { get; set; }
    public LocalizedHtmlString Label { get; set; }
    public LabelPosition LabelPosition { get; set; }
    public string LabelClasses { get; set; }
    public int? MaxLength { get; set; }
    public LocalizedHtmlString Placeholder { get; set; }
    public ViewContext ViewContext { get; set; }

    [SuppressMessage(
        "Usage",
        "CA2227:Collection properties should be read only",
        Justification = "Shape properties should not be read-only.")]
    public IList<DropdownItem> DropdownData { get; set; }

    public UiKitEditorViewModel() => Metadata.Type = "EditorDropdown";

    public bool IsRequired() => For.Metadata.RequiredAttributeExists();

    public bool IsLabelEmpty() => LabelPosition == LabelPosition.None || string.IsNullOrWhiteSpace(Label?.Value);

    public TagBuilder GenerateLabel(IHtmlGenerator htmlGenerator, params string[] additionalClasses)
    {
        if (IsLabelEmpty()) return null;

        var labelClasses = new List<string> { LabelClasses };
        labelClasses.AddRange(additionalClasses);
        if (Type == EditorTypes.Checkbox) labelClasses.Add("form-check-label");

        var label = htmlGenerator.GenerateLabel(
            ViewContext,
            For.ModelExplorer,
            For.Name,
            string.Empty, // This parameter expects unencoded text, but we want to pass HTML.
            new Dictionary<string, object>().WithClasses(labelClasses));

        label.InnerHtml.AppendHtml(Label.Html());

        if (IsRequired())
        {
            label.InnerHtml.AppendHtml($" <span class=\"{UiKitEditorRequiredAsteriskClass}\">*</span>");
        }

        return label;
    }

    public TagBuilder GenerateInput(IHtmlGenerator htmlGenerator, params string[] additionalClasses) =>
        GenerateInput(htmlGenerator, additionalAttributes: null, additionalClasses);

    public TagBuilder GenerateInput(
        IHtmlGenerator htmlGenerator,
        IDictionary<string, object> additionalAttributes,
        params string[] additionalClasses)
    {
        var inputAttributes = new Dictionary<string, object>();

        if (IsRequired() &&
            (additionalAttributes == null || !additionalAttributes.TryGetValue("type", out var type) || type.ToString() != "hidden"))
        {
            inputAttributes["required"] = string.Empty;
        }

        if (Disabled) inputAttributes["disabled"] = string.Empty;
        if (MaxLength is { } maxLength) inputAttributes["maxlength"] = maxLength;

        if (!string.IsNullOrEmpty(Placeholder?.Value))
        {
            inputAttributes["placeholder"] = Placeholder.Value;
        }

        if (additionalAttributes != null)
        {
            foreach (var (key, value) in additionalAttributes)
            {
                inputAttributes[key] = value;
            }
        }

        var bootstrapClass = Type == EditorTypes.Checkbox ? "form-check-input" : "form-control";
        var inputClasses = new[] { InputClasses, bootstrapClass }.Concat(additionalClasses);

        var tagBuilder = Type == EditorTypes.Checkbox
            ? htmlGenerator.GenerateCheckBox(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                (bool?)For.Model,
                inputAttributes.WithClasses(inputClasses))
            : htmlGenerator.GenerateTextBox(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                For.Model,
                string.Empty,
                inputAttributes.WithClasses(inputClasses));

        if (Type == EditorTypes.Number)
        {
            tagBuilder.Attributes["type"] = "number";
        }

        return tagBuilder;
    }

    public TagBuilder GenerateHintBefore() => GenerateHint(HintPosition.BeforeInput);
    public TagBuilder GenerateHintAfter() => GenerateHint(HintPosition.AfterInput);

    public TagBuilder GenerateHint(HintPosition expectedHintPosition)
    {
        if (HintPosition != expectedHintPosition) return null;

        var hintHtml = Hint?.Html();
        if (string.IsNullOrWhiteSpace(hintHtml)) return null;

        var hint = new TagBuilder("div");
        hint.Attributes["class"] = $"{UiKitEditorHintClass}";
        hint.InnerHtml.AppendHtml(hintHtml);

        return hint;
    }

    public string GetBlockIdWithFallback(string id = null, string blockName = null)
    {
        blockName ??= Type switch
        {
            EditorTypes.Textbox => TextboxBlockName,
            EditorTypes.Checkbox => CheckboxBlockName,
            EditorTypes.Dropdown => DropdownBlockName,
            EditorTypes.Number => "numberEditor",
            _ => throw new ArgumentOutOfRangeException($"Unknown editor type \"{Type}\"."),
        };

        return WithUniqueFallback(BlockId, blockName);
    }

    /// <summary>
    /// Returns the provided <paramref name="id"/> if it's not <see langword="null"/> or whitespace. Otherwise, returns
    /// the <paramref name="blockName"/> suffixed with a random unique string.
    /// </summary>
    public static string WithUniqueFallback(string id, string blockName) =>
        string.IsNullOrWhiteSpace(id)
            ? $"{blockName}_{Guid.NewGuid():N}"
            : id;
}
