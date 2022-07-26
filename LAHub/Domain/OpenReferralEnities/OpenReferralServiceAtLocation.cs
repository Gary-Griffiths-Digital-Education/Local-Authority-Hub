using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAHub.Domain.OpenReferralEnities;

public class OpenReferralServiceAtLocation
{
    private OpenReferralServiceAtLocation() { }
    public OpenReferralServiceAtLocation(string id //, OpenReferralLocation location
        , ICollection<Holiday_Schedule>? holidayScheduleCollection, ICollection<Regular_Schedule>? regular_schedule
        )
    {
        Id = id;
        //Location = location;
        HolidayScheduleCollection = holidayScheduleCollection;
        Regular_schedule = regular_schedule;
    }

    public string Id { get; init; } = default!;
    //public OpenReferralLocation Location { get; init; } = default!;
    public virtual ICollection<Holiday_Schedule>? HolidayScheduleCollection { get; init; }
    public virtual ICollection<Regular_Schedule>? Regular_schedule { get; init; }
}
