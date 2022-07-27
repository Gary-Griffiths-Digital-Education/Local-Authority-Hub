using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralService_Taxonomy : BaseEntity<string>
{
    private OpenReferralService_Taxonomy() { }
    public OpenReferralService_Taxonomy(string id, string? linkId, OpenReferralTaxonomy? taxonomy)
    {
        Id = id;
        LinkId = linkId;
        Taxonomy = taxonomy;
    }
    public string? LinkId { get; init; }
    public OpenReferralTaxonomy? Taxonomy { get; init; }
}
