using LAHub.Domain.Entities;


namespace LAHub.Domain.DbEntities;

public sealed class CategoryDto : Category
{
    public CategoryDto() : base(String.Empty, null) { }
}
