using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.HelpfulLibraries.OrchardCore.Fields;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Lombiq.UIKit.Widgets.Migrations;

public class ButtonWidgetMigrations : WidgetMigrationBase<ButtonWidget>
{
    public ButtonWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
        : base(contentDefinitionManager)
    { }

    protected override void DefinePart(ContentPartDefinitionBuilder<ButtonWidget> builder) => builder
        .WithField(part => part.Link, DefinitionHelper.ConfigureRequired<LinkField>)
        .WithField(part => part.TypeName, part => part
            .WithDisplayName("Type")
            .WithEnumEditor<ButtonWidget.ButtonType>())
        .WithField(part => part.SizeName, part => part
            .WithDisplayName("Size")
            .WithEnumEditor<ButtonWidget.ButtonSize>())
        .WithField(part => part.Outlined)
        .WithField(part => part.Disabled);
}
