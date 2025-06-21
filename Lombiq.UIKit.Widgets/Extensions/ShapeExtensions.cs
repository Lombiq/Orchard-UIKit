using OrchardCore.DisplayManagement.Shapes;
using OrchardCore.Flows.Models;
using OrchardCore.Flows.ViewModels;

namespace OrchardCore.DisplayManagement;

public static class ShapeExtensions
{
    /// <summary>
    /// Returns the <see cref="IShape"/> objects in <see cref="IShape.Items"/>, keyed by <see
    /// cref="ShapeMetadata.Differentiator"/>.
    /// </summary>
    public static IDictionary<string, IShape> GetChildrenByDifferentiator(this IShape content) =>
        content
            .Items
            .CastWhere<IShape>()
            .ToDictionary(shape => shape.Metadata.Differentiator);

    /// <summary>
    /// Gets the <see cref="BagPartViewModel"/> from the <see cref="BagPart"/> child shape of the <paramref
    /// name="content"/>.
    /// </summary>
    public static BagPartViewModel? GetBagPartViewModel(this IShape content) =>
        content.GetChildrenByDifferentiator().GetMaybe(nameof(BagPart)) as BagPartViewModel;
}
