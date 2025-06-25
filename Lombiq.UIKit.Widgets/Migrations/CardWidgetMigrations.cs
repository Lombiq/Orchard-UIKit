using Lombiq.UIKit.Models;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Flows.Models;
using OrchardCore.Media.Settings;

namespace Lombiq.UIKit.Widgets.Migrations;

public class CardWidgetMigrations : WidgetMigrationBase<CardWidget>
{
    public CardWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
        : base(contentDefinitionManager)
    {
    }

    protected override void DefinePart(ContentPartDefinitionBuilder<CardWidget> builder) => builder
        .WithField(part => part.Image, field => field.WithSettings(new MediaFieldSettings { Multiple = false }))
        .WithField(part => part.ImageBottom, field => field
            .WithDisplayName("Is the image at the bottom?")
            .WithSettings(new BooleanFieldSettings
            {
                Hint = "Check if the cap image should be at the bottom instead of the top.",
            }));

    protected async override Task<int> AdditionalCreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(FlowPart), part => part.Reusable());

        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(CardWidget), builder => builder
            .WithPart<HtmlTitlePart>()
            .WithPart<FlowPart>("Header")
            .WithPart<FlowPart>("Content")
            .WithPart<FlowPart>("Footer")
        );

        return 1;
    }
}
