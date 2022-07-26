using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAHub.Domain.OpenReferralEnities;

public class Service_Taxonomy
{
    private Service_Taxonomy() { }
    public Service_Taxonomy(string id, string? linkId) //, Taxonomy? taxonomy)
    {
        Id = id;
        LinkId = linkId;
        //Taxonomy = taxonomy;
    }

    public string Id { get; init; } = default!;
    public string? LinkId { get; init; }
    //public Taxonomy? Taxonomy { get; init; }
}
