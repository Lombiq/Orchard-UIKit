using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.HelpfulLibraries.OrchardCore.Fields;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Lombiq.UIKit.Widgets.Migrations;

public class ButtonWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public ButtonWidgetMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(ButtonWidget), builder => builder
            .Stereotype(CommonStereotypes.Widget)
            .WithPart(nameof(ButtonWidget)));

        await _contentDefinitionManager.AlterPartDefinitionAsync<ButtonWidget>(builder => builder
            .WithField(part => part.Link, DefinitionHelper.ConfigureRequired<LinkField>)
            .WithField(part => part.TypeName, builder => builder
                .WithDisplayName("Type")
                .WithEnumEditor<ButtonWidget.ButtonType>())
            .WithField(part => part.SizeName, builder => builder
                .WithDisplayName("Size")
                .WithEnumEditor<ButtonWidget.ButtonSize>())
            .WithField(part => part.Outlined)
            .WithField(part => part.Disabled)
        );

        return 1;
    }
}
