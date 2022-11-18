using OrchardCore.Test.GQLPart.Indexes;
using OrchardCore.Test.GQLPart.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace OrchardCore.Test.GQLPart
{
    public class Migrations : DataMigration
    {
        private IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(DrilldownPart), builder => builder
                .Attachable()
                .WithDescription("test."));

            SchemaBuilder.CreateMapIndexTable<DrilldownPartIndex>(table => table
                .Column<string>(nameof(DrilldownPart.MakeContentId))
                .Column<string>(nameof(DrilldownPart.ModelContentId))
                .Column<string>(nameof(DrilldownPart.YearContentId))
                .Column<string>(nameof(DrilldownPart.StyleContentId))
                .Column<string>(nameof(DrilldownPart.SeriesContentId))
                .Column<string>("ContentItemId", c => c.WithLength(26))
                .Column<bool>("Latest", c => c.WithDefault(false))
                .Column<bool>("Published", c => c.WithDefault(true))
            );

            SchemaBuilder.AlterIndexTable<DrilldownPartIndex>(table => table
                .CreateIndex("IDX_DrilldownPartIndex_DocumentId",
                    "DocumentId",
                    nameof(DrilldownPart.MakeContentId),
                    nameof(DrilldownPart.ModelContentId),
                    nameof(DrilldownPart.YearContentId),
                    nameof(DrilldownPart.StyleContentId),
                    nameof(DrilldownPart.SeriesContentId),
                    "ContentItemId",
                    "Published",
                    "Latest")
            );

            return 1;
        }
    }
}
