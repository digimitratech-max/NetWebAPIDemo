using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.DbContext;
using System.Collections.Generic;

namespace StudentRegistration.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SchoolDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public T GetById(object id) => _dbSet.Find(id);

        public async Task<T> GetByIdAsync(object id)
            => await _dbSet.FindAsync(id);

        public IEnumerable<T> GetList(Func<T, bool> predicate)
            => _dbSet.Where(predicate);

        public async Task<IEnumerable<T>> GetListAsync(Func<T, bool> predicate)
            => await Task.FromResult(_dbSet.Where(predicate));

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
