using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Lombiq.UIKit.Widgets.Migrations;

public abstract class WidgetMigrationBase<TPart> : DataMigration
    where TPart : ContentPart
{
    protected readonly IContentDefinitionManager _contentDefinitionManager;

    protected WidgetMigrationBase(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    protected virtual Task<int> AdditionalCreateAsync() => Task.FromResult(1);

    protected abstract void DefinePart(ContentPartDefinitionBuilder<TPart> builder);

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync(typeof(TPart).Name, builder => builder
            .Stereotype(CommonStereotypes.Widget)
            .WithPart<TPart>());

        await _contentDefinitionManager.AlterPartDefinitionAsync<TPart>(DefinePart);

        return await AdditionalCreateAsync();
    }
}
