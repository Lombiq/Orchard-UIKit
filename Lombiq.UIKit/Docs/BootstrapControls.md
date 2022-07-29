# Bootstrap Controls

This document describes some more complex controls from Bootstrap available as reusable shapes.

## BootstrapAccordion

Displays an [accordion](https://getbootstrap.com/docs/5.0/components/accordion/) using shapes passed to its `Children` property as content. Other properties are optional.

```html
<shape type="BootstrapAccordion" 
       prop-AdditionalClasses="string" 
       prop-Children="IEnumerable<BootstrapAccordionItem>"></shape>
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
