using OrchardCore.Modules.Manifest;
using static Lombiq.UIKit.FeatureIds;

[assembly: Module(
    Name = "Lombiq UiKit",
    Author = "Lombiq Technologies",
    Version = "1.0",
    Description = "Module for reusable shapes containing text editors, dropdown editors, and potentially more complex editors."
)]

[assembly: Feature(
    Id = ShowCase,
    Name = "Lombiq UiKit - Showcase page",
    Category = "Development",
    Description = "You can reach the showcase page at /UIKitShowCase"
)]
