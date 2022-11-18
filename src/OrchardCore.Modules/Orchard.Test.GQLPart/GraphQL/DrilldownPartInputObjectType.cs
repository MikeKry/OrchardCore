using GraphQL.Types;
using Microsoft.Extensions.Localization;
using OrchardCore.Test.GQLPart.Models;
using OrchardCore.Apis.GraphQL.Queries;

namespace OrchardCore.Test.GQLPart.GraphQL
{
    public class DrilldownPartInputObjectType : WhereInputObjectGraphType<DrilldownPart>
    {
        public DrilldownPartInputObjectType(IStringLocalizer<DrilldownPartInputObjectType> S)
        {
            Name = $"DrilldownPartInput";

            AddScalarFilterFields<StringGraphType>(nameof(DrilldownPart.YearContentId), S["the year ID"]);
            AddScalarFilterFields<StringGraphType>(nameof(DrilldownPart.MakeContentId), S["the make ID"]);
            AddScalarFilterFields<StringGraphType>(nameof(DrilldownPart.ModelContentId), S["the model ID"]);
            AddScalarFilterFields<StringGraphType>(nameof(DrilldownPart.SeriesContentId), S["the series ID"]);
            AddScalarFilterFields<StringGraphType>(nameof(DrilldownPart.StyleContentId), S["the style ID"]);
        }
    }
}
