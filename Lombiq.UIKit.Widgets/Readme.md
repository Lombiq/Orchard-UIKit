# Lombiq UI Kit Widgets for Orchard Core

[![Lombiq.UIKit Widgets NuGet](https://img.shields.io/nuget/v/Lombiq.UIKit?label=Lombiq.UIKit.Widgets)](https://www.nuget.org/packages/Lombiq.UIKit.Widgets/) [![Lombiq.UIKit.Tests.UI NuGet](https://img.shields.io/nuget/v/Lombiq.UIKit.Tests.UI?label=Lombiq.UIKit.Widgets.Tests.UI)](https://www.nuget.org/packages/Lombiq.UIKit.widgets.Tests.UI/)

## About

This module contains widgets that are based on the reusable shapes from [Lombiq UI Kit](../Lombiq.UIKit).

Available widgets:

- Carousel Widget

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

Add this project to your solution. Then go to Admin panel and enable `Lombiq.UIKit.Widgets` by going to `Configuration` -> `Features`.

Once it's enabled you can use all widgets from this module just like any other widget.

### Carousel Widget

Based on UI Kit's [SlickCarousel](../Lombiq.UIKit/Views/SlickCarousel.cshtml) shape, this widget allows you to easily create carousels from the admin panel. The widget doesn't have any styles (except the default Slick style) and you can make ones that fit your site needs without any overhead.

To configure the global settings (for all carousels widgets) go to `Content`->`ContentDefinition`->`ContentTypes`. Find `CarouselWidget` content type and click on `Edit` button. There, under parts, edit `CarouselWidget` and on that page you can set [Slick slider options](https://kenwheeler.github.io/slick/#settings) using JSON.

To quickly see the carousel widget in action, go to `Configuration`->`Recipes` and find `Lombiq UI Kit widgets - Sample Content - Carousel Widget` recipe. This recipe will add a new page called `Carousel Widget Example` which will contain the carousel widget.

Please note that, like mentioned above, the carousel widget doesn't have any styles so you might need to make some CSS adjustments (depending on the theme).

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
