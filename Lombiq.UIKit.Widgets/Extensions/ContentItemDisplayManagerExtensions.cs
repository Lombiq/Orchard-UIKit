using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using OrchardCore.DisplayManagement;
using OrchardCore.Flows.ViewModels;

namespace OrchardCore.ContentManagement.Display;

public static class ContentItemDisplayManagerExtensions
{
    /// <summary>
    /// Render each <see cref="ContentItem"/> in a <paramref name="bagViewModel"/> into <see cref="IShape"/> using the
    /// information in the view-model.
    /// </summary>
    public static Task<IList<IShape>> DisplayBagPartContentItemsAsync(
        this IContentItemDisplayManager manager,
        BagPartViewModel? bagViewModel) =>
        manager.DisplayBagPartContentItemsAsync(bagViewModel, itemDisplayType: string.Empty);

    /// <inheritdoc cref="DisplayBagPartContentItemsAsync(IContentItemDisplayManager, BagPartViewModel)"/>
    /// <param name="itemDisplayType">
    /// The display type used to render the individual content items in the bag. If not specified, the configuration in
    /// the part settings is used instead.
    /// </param>
    public static async Task<IList<IShape>> DisplayBagPartContentItemsAsync(
        this IContentItemDisplayManager manager,
        BagPartViewModel? bagViewModel,
        string itemDisplayType)
    {
        if (bagViewModel == null) return [];

        var items = bagViewModel.BagPart?.ContentItems ?? [];
        var results = new List<IShape>(capacity: items.Count);
        var context = bagViewModel.BuildPartDisplayContext;

        var displayType = itemDisplayType.OrIfEmpty(
            bagViewModel.Settings.DisplayType?.Trim(),
            CommonContentDisplayTypes.Summary);

        foreach (var item in items)
        {
            var shape = await manager.BuildDisplayAsync(item, context.Updater, displayType, context.GroupId);
            results.Add(shape);
        }

        return results;
    }
}
