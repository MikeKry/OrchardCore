using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Test.GQLPart.Models;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Mvc.ModelBinding;
using YesSql;

namespace OrchardCore.Test.GQLPart.Drivers
{
    public class DrilldownPartDisplayDriver : ContentPartDisplayDriver<DrilldownPart>
    {

        private readonly ISession _session;
        private readonly IStringLocalizer S;

        public DrilldownPartDisplayDriver(
            ISession session,
            IStringLocalizer<DrilldownPartDisplayDriver> localizer
        )
        {
            _session = session;
            S = localizer;
        }

        public override IDisplayResult Edit(DrilldownPart aliasPart, BuildPartEditorContext context)
        {
            return Initialize<DrilldownPart>(GetEditorShapeType(context), m => BuildViewModel(m, aliasPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(DrilldownPart model, IUpdateModel updater, UpdatePartEditorContext context)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.ModelContentId, t => t.MakeContentId, t => t.YearContentId, t => t.StyleContentId, t => t.SeriesContentId);


            return Edit(model, context);
        }

        private void BuildViewModel(DrilldownPart model, DrilldownPart part)
        {
            model.ModelContentId = part.ModelContentId;
            model.MakeContentId = part.MakeContentId;
            model.ContentItem = part.ContentItem;
            model.YearContentId = part.YearContentId;
            model.SeriesContentId = part.SeriesContentId;
            model.StyleContentId = part.StyleContentId;

        }

    }
}
