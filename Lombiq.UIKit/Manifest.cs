using OrchardCore.Modules.Manifest;
using static Lombiq.UIKit.FeatureIds;

[assembly: Module(
    Name = "Lombiq UI Kit",
    Author = "Lombiq Technologies",
    Version = "0.0.1",
    Description = "Module for reusable shapes containing text editors, dropdown editors, and potentially more complex editors.",
    Website = "https://github.com/Lombiq/Orchard-UIKit"
)]

[assembly: Feature(
    Id = Base,
    Name = "Lombiq UI Kit",
    Category = "Development",
    Description = "Module for reusable shapes containing text editors, dropdown editors, and potentially more complex editors."
)]

[assembly: Feature(
    Id = Showcase,
    Name = "Lombiq UI Kit - Showcase page",
    Category = "Development",
    Description = "You can reach the showcase page under /UIKitShowcase",
    Dependencies = ["Lombiq.UIKit"]
)]
