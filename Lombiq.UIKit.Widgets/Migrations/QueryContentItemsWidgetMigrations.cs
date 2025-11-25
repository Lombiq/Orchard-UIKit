using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Lombiq.UIKit.Widgets.Migrations;

public class QueryContentItemsWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public QueryContentItemsWidgetMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(QueryContentItemsWidget), builder => builder
            .Stereotype(CommonStereotypes.Widget)
            .WithPart<QueryContentItemsWidget>());

        await _contentDefinitionManager.AlterPartDefinitionAsync<QueryContentItemsWidget>(builder => builder
            .WithField(part => part.QueryName, part => part
                .WithDisplayName("Query Name")
                .WithEditor("ContentItemQueryNamesDropdown")
                .WithSettings(new TextFieldSettings
                {
                    Hint = "The technical name of the query from Admin > Search > All queries.",
                    Required = true,
                }))
            .WithField(part => part.SortColumn, part => part
                .WithDisplayName("Sort Column")
                .WithSettings(new TextFieldSettings
                {
                    Hint = "The technical name of the database column used in the query's ORDER BY statement.",
                }))
            .WithField(part => part.Order, part => part
                .WithEnumEditor(ContentFieldEditorEnums.TextFieldEditors.PredefinedList)
                .WithSettings(new TextFieldSettings
                {
                    Hint = "The sorting direction of the query results, when sorted by the \"Sort Column\".",
                })
                .WithSettings(new TextFieldPredefinedListEditorSettings
                {
                    DefaultValue = "DESC",
                    Editor = EditorOption.Dropdown,
                    Options = [new("Ascending", "ASC"), new("Descending", "DESC")],
                }))
            .WithField(part => part.Limit, part => part
                .WithSettings(new NumericFieldSettings
                {
                    Hint = "The maximum number of results.",
                    Minimum = 1,
                    DefaultValue = 10.ToTechnicalString(),
                }))
            .WithField(part => part.DisplayType, part => part
                .WithDisplayName("Display Type")
                .WithSettings(new TextFieldSettings
                {
                    Hint = "The shape display type (such as \"Summary\", \"Detail\", etc) used when displaying the " +
                           "content items returned by the query.",
                    Required = true,
                    DefaultValue = CommonContentDisplayTypes.Summary,
                }))
            .WithField(part => part.ShuffleResults, part => part
                .WithDisplayName("Shuffle Results")
                .WithEditor("Switch")
                .WithSettings(new BooleanFieldSettings
                {
                    Hint = "When enabled, the results are displayed in a random order.",
                    DefaultValue = false,
                }))
        );

        return 1;
    }
}
