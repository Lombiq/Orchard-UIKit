using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.Flows.Models;

namespace Lombiq.UIKit.Widgets.Migrations;

public class AddMetadataWidgetMigrations : WidgetMigrationBase<AddMetadataWidget>
{
    public AddMetadataWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
        : base(contentDefinitionManager)
    { }

    protected override void DefinePart(ContentPartDefinitionBuilder<AddMetadataWidget> builder) => builder
        .WithField(part => part.Alternate)
        .WithField(part => part.Classes, field => field.WithEditor(ContentFieldEditorEnums.TextFieldEditors.TextArea))
        .WithField(part => part.DisplayType, field => field.WithSettings(new TextFieldSettings
        {
            DefaultValue = CommonContentDisplayTypes.Detail,
        }))
        .WithField(part => part.Wrapper);

    protected async override Task<int> AdditionalCreateAsync()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(AddMetadataWidget), builder => builder
            .WithPart<BagPart>(part => part.WithSettings(new BagPartSettings
            {
                ContainedStereotypes = [CommonStereotypes.Widget],
            })));

        return 1;
    }
}
