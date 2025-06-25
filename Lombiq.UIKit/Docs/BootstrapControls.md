# Bootstrap Controls

This document describes some more complex controls from Bootstrap available as reusable shapes.

## BootstrapAccordion

Displays an [accordion](https://getbootstrap.com/docs/5.0/components/accordion/) using shapes passed to its `Children` property as content. Other properties are optional.

```html
<shape type="BootstrapAccordion" 
       prop-AdditionalClasses="string" 
       prop-Children="IEnumerable<BootstrapAccordionItem>"></shape>
```

## BootstrapCard

Displays a [card](https://getbootstrap.com/docs/5.3/components/card/). All properties are optional.

- Image cap properties: Cards can include "image caps", images at the top or bottom of a card.
  - `Image`: Either an absolute URL, or a relative content URL pointing to the image.
  - `Alt`: The text to be used for the `alt` attribute of the image. Can be `LocalizedHtmlString` as well. If empty or not provided, the file name is extracted from the `Image` property.
  - `ImageBottom`: If its value is `true` or `"true"`, the image will be a bottom cap instead of the default top cap.
- Body properties: The `BootstrapCard` shape always contains a `<div class="card-body">` element. These properties define elements inside it, displayed in this specific order.
  - `Title`: Displays this value inside an H5 element with the `card-title` class.
  - `Subtitle`: Displays this value inside an H6 element with the `card-subtitle` class.
  - `Text`: Displays a line of text inside a `<p class="card-text">` element.
  - `Content`: Displays arbitrary content. The value property must implement the `IHtmlContent`. You can use Orchard Core's [`<add-property>` tag helper](https://docs.orchardcore.net/en/main/reference/modules/DisplayManagement/#adding-properties-with-additional-tag-helpers) to pass HTML.
  - `Links`: Displays links that can contain absolute URLs or relative content URLs. The value property must implement `IEnumerable` where each item must implement `ITuple` with 2 items, for example `IEnumerable<(string, LocalizedHtmlString)>`.
- Others:
  - `Header`: A header is a separate bordered area that can appear above the body, but below the top image cap.
  - `Footer`: A footer is a separate bordered area that can appear below the body and the list, but above the bottom image cap.
  - `List`: A list of bordered items displayed below the body, but above the footer and the bottom image cap. The value property must implement `IEnumerable`.

> [!TIP]
> You can use the `<add-class name="@className" />` tag helper to insert additional HTML classes into the shape's outer element. For example, you can add `text-center` to change the alignment without further CSS styling.

```cshtml
<shape type="BootstrapCard"
       Image="~/Lombiq.UIKit/lombiq-logo-small.svg"
       prop-Alt="@T["My Top Image"]"
       prop-Title="@T["Hello World!"]"
       prop-Subtitle="@T["Do you like this card?"]"
       prop-Text="@T["An example line of text"]"
       prop-Links="@links"
       prop-List="@list">
<metadata>
    <add-property name="Content">
        <h6>@T["Some complicated HTML"]</h6>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit...
        </p>
    </add-property>
    <add-property name="Footer">
        <h6>@T["Excerpt from the English OC Documentation."]</h6>
        <blockquote>
            Properties can be passed to a shape by adding attributes...
        </blockquote>
    </add-property>
    <add-class name="text-center"/>
</metadata>
</shape>
```

## BootstrapSplitButton

Displays a [split button](https://getbootstrap.com/docs/5.0/components/dropdowns/#split-button) with multiple name-URL pairs as optional links in a dropdown and the first one as button action. It has a tag helper with one required attribute (`options`) and many optional ones.

```html
<bootstrap-split-button options="IEnumerable<(string Url, string Text)>"
                        type="string : btn-type suffix like primary (default), secondary, danger, etc"
                        text="string : main button text, if null or empty the first option text is used"
                        class="string : HTML class attribute for the wrapper element"
                        button-classes="string : HTML class attribute for the main button"
                        toggle-classes="string : HTML class attribute for the [▾] button"
                        dropdown-classes="string : HTML class attribute for the dropdown menu list" />
```
