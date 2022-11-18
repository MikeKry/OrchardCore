using GraphQL.Types;
using OrchardCore.Test.GQLPart.Models;

namespace OrchardCore.Test.GQLPart.GraphQL
{
    public class DrilldownPartObjectType : ObjectGraphType<DrilldownPart>
    {
        public DrilldownPartObjectType()
        {
            Name = nameof(DrilldownPart);

            // Map the fields you want to expose
            Field(x => x.YearContentId, nullable: true);
            Field(x => x.MakeContentId, nullable: true);
            Field(x => x.ModelContentId, nullable: true);
            Field(x => x.SeriesContentId, nullable: true);
            Field(x => x.StyleContentId, nullable: true);
        }
    }
}
