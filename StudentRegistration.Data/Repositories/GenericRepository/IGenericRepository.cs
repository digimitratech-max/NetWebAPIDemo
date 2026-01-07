namespace StudentRegistration.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T GetById(object id);
        Task<T> GetByIdAsync(object id);

        IEnumerable<T> GetList(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetListAsync(Func<T, bool> predicate);

        T Create(T entity);
        Task<T> CreateAsync(T entity);

        T Update(T entity);
        Task<T> UpdateAsync(T entity);

        void Delete(object id);
        Task DeleteAsync(object id);
    }
}
