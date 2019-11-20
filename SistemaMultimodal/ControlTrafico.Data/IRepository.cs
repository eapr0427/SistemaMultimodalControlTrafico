using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data
{
    public interface IRepository<TEntity, in TEntityId> : IDisposable where TEntity : Entity<TEntityId>
    {
        void Add(TEntity item);
        Task AddAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity t, object key);
        TEntity Get(TEntityId id);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
