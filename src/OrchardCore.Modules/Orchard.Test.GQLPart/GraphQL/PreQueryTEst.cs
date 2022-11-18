using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json.Linq;
using OrchardCore.Apis.GraphQL;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.GraphQL.Queries;
using OrchardCore.Test.GQLPart.Indexes;
using OrchardCore.Test.GQLPart.Models;
using YesSql;

namespace Orchard.Test.GQLPart.GraphQL;
public class DrilldownPartPrequeryInputObjectType : InputObjectGraphType<DrilldownPart>
{
    public DrilldownPartPrequeryInputObjectType()
    {
        Name = $"{nameof(DrilldownPart)}Input";

        Field(x => x.YearContentId, nullable: true).Description("The Id of the Year this vehicle belongs to.");
        Field(x => x.MakeContentId, nullable: true).Description("The Id of the Make this vehicle belongs to.");
        Field(x => x.ModelContentId, nullable: true).Description("The Id of the Model this vehicle belongs to.");
        Field(x => x.SeriesContentId, nullable: true).Description("The Id of the Series this vehicle belongs to.");
        Field(x => x.StyleContentId, nullable: true).Description("The Id of the Style this vehicle belongs to.");
    }
}
public class DrilldownPartGraphQLFilter : GraphQLFilter<ContentItem>
{
    public override async Task<IQuery<ContentItem>> PreQueryAsync(IQuery<ContentItem> query, IResolveFieldContext context)
    {
        if (!context.HasPopulatedArgument("where"))
        {
            return query;
        }

        var whereArguments = JObject.FromObject(context.Arguments["where"].Value);

        if (whereArguments == null)
        {
            return query;
        }

        var drilldown = JObject.FromObject(whereArguments.Property("drilldown").Value);

        if (drilldown != null)
        {
            var drilldownQuery = query.With<DrilldownPartIndex>();

            if (drilldown.TryGetValue(nameof(DrilldownPart.YearContentId), out var yearContentId) && !String.IsNullOrWhiteSpace(yearContentId?.ToString()))
            {
                drilldownQuery.Where(x => x.YearContentId == yearContentId.ToString().Trim());
            }

            if (drilldown.TryGetValue(nameof(DrilldownPart.MakeContentId), out var makeContentId) && !String.IsNullOrWhiteSpace(makeContentId?.ToString()))
            {
                drilldownQuery.Where(x => x.MakeContentId == makeContentId.ToString().Trim());
            }

            if (drilldown.TryGetValue(nameof(DrilldownPart.ModelContentId), out var modelContentId) && !String.IsNullOrWhiteSpace(modelContentId?.ToString()))
            {
                drilldownQuery.Where(x => x.ModelContentId == modelContentId.ToString().Trim());
            }

            if (drilldown.TryGetValue(nameof(DrilldownPart.SeriesContentId), out var seriesContentId) && !String.IsNullOrWhiteSpace(seriesContentId?.ToString()))
            {
                drilldownQuery.Where(x => x.SeriesContentId == seriesContentId.ToString().Trim());
            }

            if (drilldown.TryGetValue(nameof(DrilldownPart.StyleContentId), out var styleContentId) && !String.IsNullOrWhiteSpace(styleContentId?.ToString()))
            {
                drilldownQuery.Where(x => x.StyleContentId == styleContentId.ToString().Trim());
            }

            return drilldownQuery;
        }

        return query;
    }
}
