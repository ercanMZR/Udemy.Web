using System.Linq.Expressions;

namespace Udemy.Web.Models.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SoftDelete(T entity);

        IQueryable<T> WhereAsync(Expression<Func<T, bool>> predicate);//predicate ile filtreleme yapabilmek için kullanıldı.

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
