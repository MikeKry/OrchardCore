using OrchardCore.ContentManagement;

namespace OrchardCore.Test.GQLPart.Models
{
    public class DrilldownPart : ContentPart
    {
        public string YearContentId { get; set; }
        public string MakeContentId { get; set; }
        public string ModelContentId { get; set; }
        public string SeriesContentId { get; set; }
        public string StyleContentId { get; set; }
    }
}
