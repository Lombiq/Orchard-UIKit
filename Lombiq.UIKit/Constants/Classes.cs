namespace Lombiq.UIKit.Constants;

public static class Classes
{
    // General classes.
    public const string UiKitEditorBlockName = "uiKitEditor";
    public const string UiKitEditorRequiredAsteriskClass = "requiredAsterisk";
    public const string UiKitEditorHintClass = "hint";

    // Dropdown classes.
    public const string DropdownBlockName = "dropdownEditor";
    public const string DropdownInputClass = DropdownBlockName + InputElement;
    public const string DropdownButtonClass = DropdownBlockName + ButtonElement;
    public const string DropdownButtonContainerClass = DropdownBlockName + ButtonContainerElement;
    public const string DropdownItemContainerClass = DropdownBlockName + ItemContainerElement;
    public const string DropdownItemClass = DropdownBlockName + ItemElement;
    public const string DropdownItemParentClass = DropdownBlockName + ItemElement + "Parent";

    // Textbox classes.
    public const string TextboxBlockName = "textboxEditor";
    public const string TextboxInputClass = TextboxBlockName + InputElement;
    public const string TextboxPlaceholderClass = TextboxBlockName + PlaceHolderElement;
    public const string TextboxIconContainerClass = TextboxBlockName + IconContainerElement;
    public const string TextboxIconClass = TextboxBlockName + IconElement;

    // Checkbox classes.
    public const string CheckboxBlockName = "checkboxEditor";
    public const string CheckboxInputClass = CheckboxBlockName + InputElement;

    // Elements.
    private const string InputElement = "__input";
    private const string PlaceHolderElement = "__placeholder";
    private const string ButtonElement = "__button";
    private const string ButtonContainerElement = "__buttonContainer";
    private const string ItemContainerElement = "__itemContainer";
    private const string ItemElement = "__item";
    private const string IconContainerElement = "__iconContainer";
    private const string IconElement = "__icon";
}
