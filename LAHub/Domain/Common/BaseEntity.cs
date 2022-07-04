namespace LAHub.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; } = DateTime.MinValue;

    public string CreatedBy { get; set; } = String.Empty;

    public DateTime LastModified { get; set; } = DateTime.MinValue;

    public string LastModifiedBy { get; set; } = String.Empty;
}
