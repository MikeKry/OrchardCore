using System;
using Fluid;
using Fluid.Values;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.Indexing;
using OrchardCore.Liquid;
using OrchardCore.Modules;
using OrchardCore.Test.GQLPart;
using OrchardCore.Test.GQLPart.Drivers;
using OrchardCore.Test.GQLPart.Indexes;
using OrchardCore.Test.GQLPart.Models;
using YesSql;
using YesSql.Indexes;

namespace Orchard.Test.GQLPart
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IIndexProvider, DrilldownPartIndexProvider>();
            //services.AddScoped<IScopedIndexProvider>(sp => sp.GetRequiredService<DrilldownPartIndexProvider>());
            //services.AddScoped<IContentHandler>(sp => sp.GetRequiredService<DrilldownPartIndexProvider>());

            services.AddDataMigration<Migrations>();
            ////services.AddScoped<IContentHandleProvider, AliasPartContentHandleProvider>();

            services.AddContentPart<DrilldownPart>().UseDisplayDriver<DrilldownPartDisplayDriver>();

            ////services.AddScoped<IContentPartIndexHandler, DrilldownPartIndexHandler>();
            ////services.AddScoped<IContentTypePartDefinitionDisplayDriver, AliasPartSettingsDisplayDriver>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}
