using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _unitOfWork?.Dispose();
        }

        public void Add(TEntity item)
        {
            GetSet().Add(item);
            _unitOfWork.CommitChanges();
        }

        public async Task AddAsync(TEntity item)
        {
            try
            {
                await GetSet().AddAsync(item);
                _unitOfWork.CommitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<TEntity> UpdateAsync(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = await GetSet().FindAsync(key);
            if (exist != null)
            {
                GetSet().Attach(exist).CurrentValues.SetValues(t);
                _unitOfWork.CommitChanges();
            }
            return exist;
        }
        public TEntity Get(TEntityId id)
        {
            return !id.Equals(default(TEntityId)) ? GetSet().Find(id) : null;
        }
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await GetSet().Where(match).ToListAsync();
        }
    }
}
