using MANAM.GlobalHealthCare.Common.Models;
using System.Linq.Expressions;

namespace MANAM.GlobalHealthCare.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? offset = null, int? limit = null);

        Task<T?> GetByIdAsync(object id);

        void Add(T obj);

        void Update(T obj);

        void Delete(object id);

        Task<PagedResult<TResult>> GetPagedAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
    }
}
