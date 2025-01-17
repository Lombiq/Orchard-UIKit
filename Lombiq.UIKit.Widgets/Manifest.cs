using Lombiq.UIKit;
using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Lombiq UI Kit Widgets",
    Author = "Lombiq Technologies",
    Version = "0.0.1",
    Description = "Module for reusable widgets based on Lombiq UI Kit.",
    Website = "https://github.com/Lombiq/Orchard-UIKit",
    Category = "Development",
    Dependencies = [
        FeatureIds.Base,
        "Lombiq.HelpfulExtensions.ContentTypes",
        "OrchardCore.ContentFields",
        "OrchardCore.Media"
        ]
)]
