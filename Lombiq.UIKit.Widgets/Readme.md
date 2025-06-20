# Lombiq UI Kit - Widgets for Orchard Core

[![Lombiq.UIKit Widgets NuGet](https://img.shields.io/nuget/v/Lombiq.UIKit?label=Lombiq.UIKit.Widgets)](https://www.nuget.org/packages/Lombiq.UIKit.Widgets/) [![Lombiq.UIKit.Tests.UI NuGet](https://img.shields.io/nuget/v/Lombiq.UIKit.Tests.UI?label=Lombiq.UIKit.Widgets.Tests.UI)](https://www.nuget.org/packages/Lombiq.UIKit.widgets.Tests.UI/)

## About

This module contains widgets that are based on the reusable shapes from [Lombiq UI Kit](../Lombiq.UIKit).

Available widgets:

- [Button Widget](#button-widget)
- [Card Widget](#card-widget)
- [Carousel Widget](#carousel-widget)
- [Carousel Bag Widget](#carousel-bag-widget)
- [Image Link Widget](#image-link-widget)
- [Random Widget](#random-widget)
- [Section Widget](#section-widget)

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

Add this project to your solution. Then go to Admin panel and enable `Lombiq.UIKit.Widgets` by going to `Configuration` -> `Features`.

Once it's enabled you can use all widgets from this module just like any other widget.

### Carousel Widget

Based on UI Kit's [SlickCarousel](../Lombiq.UIKit/Views/SlickCarousel.cshtml) shape, this widget allows you to easily create carousels from the admin panel. The widget doesn't have any styles (except the default Slick style) but you can make ones that fit your site' needs without any overhead. [Here](https://www.youtube.com/watch?v=1CzUnzMMr-w) you can also see a demo of it.

#### Configuration

To configure the global settings (for all carousels widgets) go to `Content`->`ContentDefinition`->`ContentTypes`. Find `CarouselWidget` content type and click on `Edit` button. There, under parts, edit `CarouselWidget` and on that page you can set [Slick slider options](https://kenwheeler.github.io/slick/#settings) using JSON.

#### Samples

To quickly see the carousel widget in action, go to `Configuration`->`Recipes` and find `Lombiq UI Kit - Widgets - Sample Content - Carousel Widget` recipe. This recipe will add a new page called `Carousel Widget Example` which will contain the carousel widget.

Please note that, like mentioned above, the carousel widget doesn't have any styles so you might need to make some CSS adjustments (depending on the theme).

### Carousel Bag Widget

Similar to the above _Carousel Widget_, but it has a Bag Part that can contain any widget type instead of the specific Slide content type. Use this, if you want a carousel that contains complex HTML.

Besides the Bag Part, it has two additional text fields to configure the individual widget:

- **Slide Element Selector**: Specify a CSS selector that's used to find the individual slides in the carousel. The default value will turn each widget inside the Bag Part. You can customize it if you use another widget to fetch or generate the content. For example, using the _Random Widget_ you can set this value to `.randomWidgetItem` - a class that's automatically added to any item returned by the Random Widget.
- **Additional Settings JSON**: This JSON object is merged into the Slick settings object before the carousel is created. You can learn more about configuring Slick [here](https://kenwheeler.github.io/slick/#settings).

### Button Widget

This widget displays a link as a Bootstrap [button](https://getbootstrap.com/docs/5.3/components/buttons/). You can select the button type, size, if it's full or empty (outlined), or if it's disabled. This is especially useful in Flow parts.

You can also use the `ButtonWidget` shape which can be directly configured, for example in Liquid:

```liquid
{% shape "ButtonWidget", Text: 'Contact Us', Url: '~/contact-us', TypeName: 'Secondary', SizeName: 'Small' %}
```

### Card Widget

Displays a Bootstrap [card](https://getbootstrap.com/docs/5.3/components/card/) with a media field for the cap image and several flow parts for the header, body and footer areas.

> [!NOTE]  
> You can also use this card in other templates, with the related [`BootstrapCard` shape](../Lombiq.UIKit/Docs/BootstrapControls.md#bootstrapcard) in _Lombiq,UIKit_. It has even more customization options too.

### Image Link Widget

This widget simply contains a media field, but on display each image is also a link. By default, clicking on the image just opens it, which can be used as a gallery element. But if you customize the item's media text, you can use the `{actual media text}|{absolute or relative URL}` format. For example, use the media text `Site Logo|~/` to create an image link that sends you to the home page.

### Section Widget

A self-contained, illustrated section for your page. Best used inside a Flow part. Can contain a title, images, Markdown body and an inner Flow part.

The images can be placed in all directions of the content, or the first image can be used as a background. The latter is good for "hero" sections. Note that if the Image Position is set to "Behind", any images besides the first are ignored.

The classes taxonomy can be used to add further styling instructions to the section from the admin UI. It uses the "tags" editor, so you can define additional classes on the fly. To use this, you have to create a Taxonomy content item and assign it to the Classes field. If you create the taxonomy from recipe, you can set its `ContentItemId` to `"sectionstylestaxonomy00000"`, or you can assign it in the Content Type Definitions admin UI as you would with any Taxonomy field.

### Random Widget

Lets you select one or more content types, then it will pick a random published content item from those types to display. You can specify the count to show several consecutive items from a random starting point, or even to retrieve all content items and then shuffle them into a random order.

You can also specify the display type and group ID, for additional customization.

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
