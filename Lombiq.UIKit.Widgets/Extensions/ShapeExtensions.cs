using OrchardCore.DisplayManagement.Shapes;

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
}
