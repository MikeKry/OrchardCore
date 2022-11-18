using System.Collections.Generic;
using OrchardCore.Test.GQLPart.Indexes;
using OrchardCore.ContentManagement.GraphQL.Queries;

namespace OrchardCore.Test.GQLPart.GraphQL
{
    public class DrilldownPartIndexAliasProvider : IIndexAliasProvider
    {
        private static readonly IndexAlias[] _aliases = new[]
        {
            new IndexAlias
            {
                Alias = "drilldownPart",
                Index = "DrilldownPartIndex",
                IndexType = typeof(DrilldownPartIndex)
            }
        };

        public IEnumerable<IndexAlias> GetAliases()
        {
            return _aliases;
        }
    }
}
