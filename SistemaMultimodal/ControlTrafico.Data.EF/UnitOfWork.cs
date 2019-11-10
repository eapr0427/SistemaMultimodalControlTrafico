using ControlTrafico.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF
{
    public interface IEfUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
    public class UnitOfWork : DbContext, IEfUnitOfWork
    {
        public DbSet<Flujo> Flujos { get; set; }

        public void CommitChanges()
        {
            SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                 .ToList()
                 .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
