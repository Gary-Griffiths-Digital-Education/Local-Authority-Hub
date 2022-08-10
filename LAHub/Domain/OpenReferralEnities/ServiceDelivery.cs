using System.ComponentModel;

namespace LAHub.Domain.OpenReferralEnities;

public enum ServiceDelivery : byte
{
    [Description("Not Entered")]
    NotEntered = 0,
    [Description("In Person")]
    InPerson = 1,
    [Description("Online")]
    Online = 2,
    [Description("Telephone")]
    Telephone = 3
}

