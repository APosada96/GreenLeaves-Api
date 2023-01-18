using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Services.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        Task<List<TEntity>> ListAsync();
        Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
