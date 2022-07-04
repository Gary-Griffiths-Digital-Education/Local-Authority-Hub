using Ardalis.Specification;

namespace LAHub.Domain.Interfaces
{


    // from Ardalis.Specification
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}