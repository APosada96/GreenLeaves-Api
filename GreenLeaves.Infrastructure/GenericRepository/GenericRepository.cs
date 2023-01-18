using GreenLeaves.Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Infrastructure.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Set { get; set; }
        protected DbContext Context { get; set; }

        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();

        }

        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default(CancellationToken))
             => await Set.FindAsync(keyValues, cancellationToken);

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
           => await Set.FirstOrDefaultAsync(predicate, cancellationToken);

        public virtual async Task<List<TEntity>> ListAsync()
           => await Set.ToListAsync();

        public virtual async Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
           => await Set.Where(predicate).ToListAsync<TEntity>();

        public virtual void Insert(TEntity item)
            => Context.Entry(item).State = EntityState.Added;

        public virtual void Update(TEntity item)
            => Context.Entry(item).State = EntityState.Modified;

        public virtual void Delete(TEntity item)
            => Context.Entry(item).State = EntityState.Deleted;

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default(CancellationToken))
        {
            var item = await FindAsync(keyValues, cancellationToken);
            if (item == null) return false;
            Context.Entry(item).State = EntityState.Deleted;
            return true;
        }
    }
}
