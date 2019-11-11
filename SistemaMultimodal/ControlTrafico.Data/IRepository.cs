using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data
{
    public interface IRepository<TEntity, in TEntityId> : IDisposable where TEntity : Entity<TEntityId>
    {
        void Add(TEntity item);
        Task AddAsync(TEntity item);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
