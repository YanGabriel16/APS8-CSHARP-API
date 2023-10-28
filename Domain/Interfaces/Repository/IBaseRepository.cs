namespace APS8_CSHARP_API.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
    }
}