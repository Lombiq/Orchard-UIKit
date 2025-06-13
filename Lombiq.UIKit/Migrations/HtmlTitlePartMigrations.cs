using Lombiq.UIKit.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Migrations;

public class HtmlTitlePartMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public HtmlTitlePartMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync<HtmlTitlePart>(builder => builder
            .WithField(part => part.Title)
            .Configure(part => part
                .Attachable()
                .WithDisplayName("HTML Title")
                .WithDescription("Provides a title for your content item which can contain HTML."))
        );

        return 1;
    }
}
