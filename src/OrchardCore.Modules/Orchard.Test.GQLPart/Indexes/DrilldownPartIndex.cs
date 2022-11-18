using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Test.GQLPart.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data;
using YesSql.Indexes;

namespace OrchardCore.Test.GQLPart.Indexes
{
    public class DrilldownPartIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public string YearContentId { get; set; }
        public string MakeContentId { get; set; }
        public string ModelContentId { get; set; }
        public string SeriesContentId { get; set; }
        public string StyleContentId { get; set; }
        public bool Latest { get; set; }
        public bool Published { get; set; }
    }

    public class DrilldownPartIndexProvider : IndexProvider<ContentItem>
    {
        public DrilldownPartIndexProvider()
        {
        }

        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<DrilldownPartIndex>()
               .Map(contentItem =>
               {
                    // Remove index records of soft deleted items.
                   if (!contentItem.Published && !contentItem.Latest)
                   {
                       return null;
                   }

                   var part = contentItem.As<DrilldownPart>();
                   if (part == null || String.IsNullOrEmpty(part.MakeContentId))
                   {
                       return null;
                   }

                   return new DrilldownPartIndex
                   {
                       MakeContentId = part.MakeContentId,
                       ModelContentId = part.ModelContentId,
                       SeriesContentId = part.SeriesContentId,
                       StyleContentId = part.StyleContentId,
                       YearContentId = part.YearContentId,
                       ContentItemId = contentItem.ContentItemId,
                       Latest = contentItem.Latest,
                       Published = contentItem.Published
                   };
               });
        }
    }
}
