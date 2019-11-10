using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF.Core
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
            try
            {
                return await GetSet().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
    }
}
