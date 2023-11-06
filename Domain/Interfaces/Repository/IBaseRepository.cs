namespace APS8_CSHARP_API.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
    }
}