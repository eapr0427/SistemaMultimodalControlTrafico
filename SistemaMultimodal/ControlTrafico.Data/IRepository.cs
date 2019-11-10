using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data
{
    public interface IRepository<TEntity, in TEntityId> : IDisposable where TEntity : Entity<TEntityId>
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
