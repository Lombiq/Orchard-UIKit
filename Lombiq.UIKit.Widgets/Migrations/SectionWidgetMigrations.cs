using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Models;
using Lombiq.UIKit.Widgets.Constants;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using OrchardCore.Media.Settings;
using OrchardCore.Taxonomies.Settings;

namespace Lombiq.UIKit.Widgets.Migrations;

public class SectionWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public SectionWidgetMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(SectionWidget), builder => builder
            .Stereotype(CommonStereotypes.Widget)
            .WithPart<HtmlTitlePart>()
            .WithPart<SectionWidget>()
            .WithPart<FlowPart>());

        await _contentDefinitionManager.AlterPartDefinitionAsync<SectionWidget>(builder => builder
            .WithField(part => part.Images, part => part.WithSettings(new MediaFieldSettings
            {
                Multiple = true,
                AllowAnchors = true,
            }))
            .WithField(part => part.Classes, part => part
                .WithSettings(new TaxonomyFieldSettings
                {
                    Hint = "Additional HTML classes applied to the section, for styling.",
                    LeavesOnly = true,
                    Open = true,
                    TaxonomyContentItemId = ContentItemIds.SectionClassesTaxonomy,
                })
                .WithEditor(ContentFieldEditorEnums.TaxonomyFieldEditors.Tags))
            .WithField(part => part.ImagePositionName, builder => builder
                .WithDisplayName("Image Position")
                .WithEnumEditor<SectionWidget.SectionImagePosition>())
        );

        return 1;
    }
}
