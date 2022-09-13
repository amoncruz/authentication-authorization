namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> List();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
