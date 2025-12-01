using MANAM.GlobalHealthCare.Common.Db;
using MANAM.GlobalHealthCare.Common.Models;
using MANAM.GlobalHealthCare.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MANAM.GlobalHealthCare.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? offset = null, int? limit = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (offset != null && limit != null)
            {
                query = query.Skip(offset.Value).Take(limit.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            var entry = _dbSet.Entry(obj);

            if (entry.State == EntityState.Detached)
            {
                try
                {
                    _dbSet.Attach(obj);
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                }
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T? existing = _dbSet.Find(id);
            if (existing != null)
            {
                _dbSet.Remove(existing);
            }
        }

        public async Task<PagedResult<TResult>> GetPagedAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            IQueryable<T> query = _dbSet.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageSize > 0)
            {
                query = query.Skip(pageIndex * pageSize).Take(pageSize);
            }

            var projected = query.Select(selector);

            var items = await projected.ToListAsync(cancellationToken);

            return new PagedResult<TResult>
            {
                Items = items,
                TotalCount = totalCount,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
    }
}
