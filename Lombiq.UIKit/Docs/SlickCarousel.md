# Slick Carousel

The [`SlickCarousel`](../Views/SlickCarousel.cshtml) shape creates a responsive sliding container using the [Slick](https://kenwheeler.github.io/slick/) JavaScript library.

## Usage

You can display this shape in Razor or Liquid with Orchard Core's shape tag helper. It has the following properties

- **Shapes**: A collection of objects that implement `IShape`. These are each rendered inside a `<div class="slickCarousel__item">` element and considered an individual slide.
- **AdditionalClasses**: A `string` which is added to the `class` attribute of the carousel's wrapper element (`.slickCarousel`).
- **MergeSettings**: A `string` containing a JSON object. It can be used to override the [`settings` object](https://kenwheeler.github.io/slick/#settings) pass to Slick during creation.
