using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF
{
    public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        private readonly IEfUnitOfWork _unitOfWork;

        public Repository(IEfUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetSet().ToListAsync();
        }

        private DbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
    }
}
