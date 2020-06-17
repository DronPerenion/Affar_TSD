using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default);
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity> InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity Remove<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity GetById<TEntity>(Guid id) where TEntity : class;
        Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class;
    }
}