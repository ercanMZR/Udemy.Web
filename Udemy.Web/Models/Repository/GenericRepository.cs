using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void SoftDelete(T entity)//açıklayıcı olması için IAuditSoftDelete interface'ini implemente eden entity'ler için kullanıldı.
        {
            var entitySoftDelete = entity as IAuditSoftDelete;//entity'nin IAuditSoftDelete interface'ini implemente eden bir entity olup olmadığını kontrol ediyoruz.
            entitySoftDelete.IsDeleted = true;//entity'nin IsDeleted property'sini true yapıyoruz.
            _dbSet.Update(entity);

        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


    }
}
