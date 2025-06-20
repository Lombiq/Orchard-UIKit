using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using OrchardCore.DisplayManagement;
using OrchardCore.Flows.ViewModels;

namespace OrchardCore.ContentManagement.Display;

public static class ContentItemDisplayManagerExtensions
{
    public static async Task<IList<IShape>> DisplayBagPartContentItemsAsync(
        this IContentItemDisplayManager manager,
        BagPartViewModel? bagViewModel)
    {
        if (bagViewModel == null) return [];

        var items = bagViewModel.BagPart?.ContentItems ?? [];
        var results = new List<IShape>(capacity: items.Count);

        foreach (var item in items)
        {
            var shape = await manager.BuildDisplayAsync(
                item,
                bagViewModel.BuildPartDisplayContext.Updater,
                string.IsNullOrWhiteSpace(bagViewModel.Settings.DisplayType)
                    ? CommonContentDisplayTypes.Summary
                    : bagViewModel.Settings.DisplayType,
                bagViewModel.BuildPartDisplayContext.GroupId);

            results.Add(shape);
        }

        return results;
    }
}
