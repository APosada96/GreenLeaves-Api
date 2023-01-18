using GreenLeaves.Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Infrastructure.GenericRepository
{
    public class GenericUnitOfWork: IGenericUnitOfWork
    {
        protected DbContext Context { get; }

        public GenericUnitOfWork(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await Context.SaveChangesAsync(cancellationToken);
    }
}
