using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Test.GQLPart.Indexes;
using OrchardCore.Test.GQLPart.Models;
using OrchardCore.Apis;
using OrchardCore.ContentManagement.GraphQL;
using OrchardCore.ContentManagement.GraphQL.Queries;
using OrchardCore.Modules;
using OrchardCore.ContentManagement;
using Orchard.Test.GQLPart.GraphQL;

namespace OrchardCore.Test.GQLPart.GraphQL
{
    [RequireFeatures("OrchardCore.Apis.GraphQL")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddObjectGraphType<DrilldownPart, DrilldownPartObjectType>();
            services.AddTransient<IIndexAliasProvider, DrilldownPartIndexAliasProvider>();
            services.AddWhereInputIndexPropertyProvider<DrilldownPartIndex>();

            // whereinput
            //services.AddInputObjectGraphType<DrilldownPart, DrilldownPartInputObjectType>();

            // prequery
            services.AddInputObjectGraphType<DrilldownPart, DrilldownPartPrequeryInputObjectType>();
            services.AddGraphQLFilterType<ContentItem, DrilldownPartGraphQLFilter>();
        }
    }
}
