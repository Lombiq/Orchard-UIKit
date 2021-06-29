namespace Lombiq.UIKit.Constants
{
    public static class Classes
    {
        // Dropdown classes.
        public const string DropdownBlockName = "dropdownEditor";
        public const string DropdownInputClass = DropdownBlockName + InputElement;
        public const string DropdownInputRequiredClass = DropdownInputClass + RequiredModifier;
        public const string DropdownLabelClass = DropdownBlockName + LabelElement;
        public const string DropdownLabelRequiredClass = DropdownLabelClass + RequiredModifier;
        public const string DropdownButtonClass = DropdownBlockName + ButtonElement;
        public const string DropdownButtonContainerClass = DropdownBlockName + ButtonContainerElement;
        public const string DropdownItemContainerClass = DropdownBlockName + ItemContainerElement;
        public const string DropdownItemClass = DropdownBlockName + ItemElement;

        // Textbox classes.
        public const string TextboxBlockName = "textboxEditor";
        public const string TextboxInputClass = TextboxBlockName + InputElement;
        public const string TextboxInputRequiredClass = TextboxInputClass + RequiredModifier;
        public const string TextboxInputBorderLabelClass = TextboxInputClass + BorderLabelInputModifier;
        public const string TextboxLabelClass = TextboxBlockName + LabelElement;
        public const string TextboxLabelRequiredClass = TextboxLabelClass + RequiredModifier;
        public const string TextboxLabelDisabledClass = TextboxLabelClass + DisabledModifier;
        public const string TextboxLabelPositionTopClass = TextboxLabelClass + BorderPositionTopModifier;
        public const string TextboxLabelPositionNoneClass = TextboxLabelClass + BorderPositionNoneModifier;
        public const string TextboxLabelPositionBorderClass = TextboxLabelClass + BorderPositionBorderModifier;
        public const string TextboxPlaceholderClass = TextboxBlockName + PlaceHolderElement;
        public const string TextboxPlaceholderLabelClass = TextboxBlockName + PlaceHolderLabelElement;
        public const string TextboxAsteriskClass = TextboxBlockName + AsteriskElement;
        public const string TextboxIconContainerClass = TextboxBlockName + IconContainerElement;
        public const string TextboxIconClass = TextboxBlockName + IconElement;
        public const string TextboxHintClass = TextboxBlockName + HintElement;

        // Checkbox classes.
        public const string CheckboxBlockName = "checkboxEditor";
        public const string CheckboxLabelClass = CheckboxBlockName + LabelElement;
        public const string CheckboxLabelRequiredClass = CheckboxLabelClass + RequiredModifier;
        public const string CheckboxInputClass = CheckboxBlockName + InputElement;
        public const string CheckboxInputRequiredClass = CheckboxInputClass + RequiredModifier;
        public const string CheckboxAsteriskClass = CheckboxBlockName + AsteriskElement;

        // Elements.
        public const string InputElement = "__input";
        public const string LabelElement = "__label";
        public const string HintElement = "__hint";
        public const string PlaceHolderElement = "__placeholder";
        public const string PlaceHolderLabelElement = "__placeholderLabel";
        public const string ButtonElement = "__button";
        public const string AsteriskElement = "__asterisk";
        public const string ButtonContainerElement = "__buttonContainer";
        public const string ItemContainerElement = "__itemContainer";
        public const string ItemElement = "__item";
        public const string IconContainerElement = "__iconContainer";
        public const string IconElement = "__icon";

        // Modifiers.
        public const string LabelPositionModifierLeft = "_left";
        public const string LabelPositionModifierRight = "_right";
        public const string BorderLabelInputModifier = "_borderLabel";
        public const string IconLeftModifier = "_iconOnLeft";

        public const string BorderPositionBorderModifier = "_border";
        public const string BorderPositionTopModifier = "_top";
        public const string BorderPositionNoneModifier = "_none";

        public const string RequiredModifier = "_required";
        public const string DisabledModifier = "_disabled";
    }
}
