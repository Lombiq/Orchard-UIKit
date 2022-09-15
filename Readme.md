# Lombiq UI Kit for Orchard Core

[![Lombiq.UIKit NuGet](https://img.shields.io/nuget/v/Lombiq.UIKit?label=Lombiq.UIKit)](https://www.nuget.org/packages/Lombiq.UIKit/)

## About

This module contains reusable shapes like text editors, custom-style checkboxes, dropdown editors, and in the future potentially more complex editors. [Here](https://www.youtube.com/watch?v=PONfn2K8AHg) you can also see a demo of it.

Do you want to quickly try out this project and see it in action? Check it out in our [Open-Source Orchard Core Extensions](https://github.com/Lombiq/Open-Source-Orchard-Core-Extensions) full Orchard Core solution and also see our other useful Orchard Core-related open-source projects!

## Documentation

Add the module to your solution and enable the `Lombiq UI Kit - Showcase page` feature if you want to check out the currently available shapes. Be sure that the dependencies can be found in the directory specified in the [Project file](Lombiq.UIKit/Lombiq.UIKit.csproj), or modify them where they are located in your solution. You can see them under `~/UIKitShowcase` after the feature is enabled. The example code for using these shapes can be seen in _[Views/Showcase/Showcase.cshtml](Lombiq.UIKit/Views/Showcase/Showcase.cshtml)_. This module contains only those stylings which are needed for these shapes to work.

To see documentation on the Bootstrap controls, see [Docs/BootstrapControls.md](Lombiq.UIKit/Docs/BootstrapControls.md).

### Custom class and id

For your own styling you can override the default class stylings, or you can create a new class and add it to the shape block via the `BlockClassName` parameter.

If it is needed to add an Id for the container block, then you can do that with the `BlockId` parameter.

## Dependencies

- [Lombiq NPM MSBuild Targets](https://github.com/Lombiq/NPM-Targets)
- [Lombiq Gulp Extensions](https://github.com/Lombiq/Gulp-Extensions)

## Contributing and support

Bug reports, feature requests, comments, questions, code contributions and love letters are warmly welcome. You can send them to us via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.
