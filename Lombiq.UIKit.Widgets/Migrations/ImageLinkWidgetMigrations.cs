using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.Media.Settings;

namespace Lombiq.UIKit.Widgets.Migrations;

public class ImageLinkWidgetMigrations : WidgetMigrationBase<ImageLinkWidget>
{
    public ImageLinkWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
        : base(contentDefinitionManager)
    { }

    protected override void DefinePart(ContentPartDefinitionBuilder<ImageLinkWidget> builder) => builder
        .WithField(part => part.Images, field => field.WithSettings(new MediaFieldSettings { Multiple = true }));
}
