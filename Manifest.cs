using OrchardCore.Modules.Manifest;
using static Lombiq.UIKit.FeatureIds;

[assembly: Module(
    Name = "Lombiq UI Kit",
    Author = "Lombiq Technologies",
    Version = "2.1.1-alpha.osoe-84.0",
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
    Description = "You can reach the showcase page under /UIKitShowcase"
)]
